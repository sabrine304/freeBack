using crudProjectWebApi.Models;
using Education.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DbContextApplication _context;
        private readonly IWebHostEnvironment _enviroment;

        public DocumentController(DbContextApplication context, IWebHostEnvironment environment)
        {
            _context = context;
            _enviroment = environment;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult>Upload (List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var rootPath = Path.Combine(_enviroment.ContentRootPath, "Resources", "Documents");

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);
            foreach(var file in files)
            {
                var filePath = Path.Combine(rootPath, file.FileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    var document = new Document
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        FileSize = file.Length
                    };
                    await file.CopyToAsync(stream);

                   var resut= _context.Documents.Add(document);
                    await _context.SaveChangesAsync();
                }
            }

            return Ok(new { count = files.Count, size });
                 
        }

        [HttpPost]
        [Route("download/{id}")]
        public async Task<ActionResult> Download(int id)
        {
            var provider = new FileExtensionContentTypeProvider();
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
                return NotFound();

            var file = Path.Combine(_enviroment.ContentRootPath, "Resources", "Documents", document.FileName);


            string contentType;
            if(!provider.TryGetContentType(file, out contentType))
            {
                contentType = "application/octet-stream";
            }
            byte[] fileBytes;
            if(System.IO.File.Exists(file))
            {
                fileBytes = System.IO.File.ReadAllBytes(file);
            }
            else
            {
                return NotFound();
            }
            return File(fileBytes, contentType, document.FileName);

                }



    }
}
