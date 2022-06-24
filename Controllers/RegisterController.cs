using crudProjectWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Education.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace crudProjectWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public readonly DbContextApplication _context;

        public RegisterController(DbContextApplication context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetList()
        {
            return await _context.Register.ToListAsync();
        }

        //Get : api/RegisterDetail/5
        [HttpGet]
        public async Task<ActionResult<Register>> GetRegisterDetail(int id)
        {
            var registerDetail = await _context.Register.FindAsync(id);
            if (registerDetail == null)
            {
                return NotFound();

            }
            return registerDetail;
        }
        [HttpPost]
        public async Task<IActionResult> PostRegister(Register register)
        {
            try
            {
                register.Password = BCrypt.Net.BCrypt.HashPassword(register.Password);
                _context.Register.Add(register);
                await _context.SaveChangesAsync();
                var result = CreatedAtAction("PostRegister", new { id = register.Id }, register);
                return result;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutRegister(int id, Register register)
        {
            if (id != register.Id)
            {
                return BadRequest();
            }
            _context.Entry(register).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterDetailExists(id))
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
        public async Task<IActionResult> DeleteRegister(int id)
        {
            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            _context.Register.Remove(register);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool RegisterDetailExists(int id)
        {
            return _context.Register.Any(e => e.Id == id);
        }
    }
}
