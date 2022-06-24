using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using crudProjectWebApi.Models;
using Education.Models;

namespace crudProjectWebApi.Controllers
{
    [Route("api/demo")]
    public class DemoController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private IHttpContextAccessor httpContextAccessor;
        private readonly DbContextApplication _context;


        public DemoController(DbContextApplication context,
                                IWebHostEnvironment _webHostEnvironment , IHttpContextAccessor _httpContextAccessor)
        {
            webHostEnvironment = _webHostEnvironment;
            httpContextAccessor = _httpContextAccessor;
            _context = context;


        }

        [Produces("application/json")]
        [HttpPost("upload")]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            try
            {
                var path = Path.Combine(webHostEnvironment.WebRootPath,"uploads",
                    file.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))

                {
                    var document = new Document
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        FileSize = file.Length
                    };

                    file.CopyTo(fileStream);
                    var resut = _context.Documents.Add(document);
                    await _context.SaveChangesAsync();
                }
                var baseURL =   httpContextAccessor.HttpContext.Request.Scheme + "://" +
                                httpContextAccessor.HttpContext.Request.Host +
                                httpContextAccessor.HttpContext.Request.PathBase;

                return Ok(new
                {
                    fileName = baseURL+ "/uploads/"+ file.FileName,
                    fileSize = file.Length                }) ;
            } 
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{FileName}")]
        public async Task<ActionResult<Document>> GetFileByName(int FileName)
        {
            var fileDetail = await _context.Documents.FindAsync(FileName);
            if(fileDetail == null)
            {
                return NotFound();
            }
            return fileDetail;
        }


    }
}
