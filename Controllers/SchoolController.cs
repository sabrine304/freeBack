using crudProjectWebApi.Models;
using Education.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {

        readonly DbContextApplication _context;

        public SchoolController(DbContextApplication context)
        {
            _context = context;
        }

        [HttpGet("/GetSchoolList")]
        public async Task<ActionResult<IEnumerable<School>>> GetAllSchool()
        {
            return await _context.School.ToListAsync();

        }

        [HttpGet("/GetSchoolById/{id}")]
        public async Task<ActionResult<School>> GetSchoolByDetail(int id)
        {
            var schoolDetail = await _context.School.FindAsync(id);
            if (schoolDetail == null)
            {
                return NotFound();

            }
            return schoolDetail;
        }

     
    }

}