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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FormationController : ControllerBase
    {
        public readonly DbContextApplication _context;

        public FormationController(DbContextApplication context)
        {
            _context = context;
        }

        [HttpGet("/GetAllFormation")]
        public async Task<ActionResult<IEnumerable<Formation>>> GetFormation()
        {
            return await _context.Formations.ToListAsync();

        }

        //Get : api/RegisterDetail/5
        [HttpGet("/GetAllFormationByID/{id}")]
        public async Task<ActionResult<Formation>> GetFormationDetail(int id)
        {
            var formationDetail = await _context.Formations.FindAsync(id);
            if (formationDetail == null)
            {
                return NotFound();

            }
            return formationDetail;
        }

        [HttpPost]
        public async Task<IActionResult> PostFormation([FromBody] Formation formation)
        {
            try
            {
                _context.Formations.Add(formation);
                await _context.SaveChangesAsync();
                var result = CreatedAtAction("PostFormation", new { id = formation.Id }, formation);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //PUT: apiFormationDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormation(int id, [FromBody] Formation formation)
        {


            if (id != formation.Id)
            {
                return BadRequest();
            }
            _context.Entry(formation).State = EntityState.Modified;
            //_context.Entry(register.userRefId).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormationDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFormation(int id)
        {
            var formation = await _context.Formations.FindAsync(id);
            if (formation == null)
            {
                return NotFound();
            }
            _context.Formations.Remove(formation);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool FormationDetailExists(int id)
        {
            return _context.Formations.Any(e => e.Id == id);
        }
    }

    
}
