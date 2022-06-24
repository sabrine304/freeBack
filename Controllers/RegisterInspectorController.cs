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
    public class RegisterInspectorController : ControllerBase
    {
        public readonly DbContextApplication _context;

        public RegisterInspectorController(DbContextApplication context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterInspector>>> GetList()
        {
            return await _context.RegisterInspectors.ToListAsync();
        }

        //Get : api/RegisterDetail/5
        [HttpGet]
        public async Task<ActionResult<RegisterInspector>> GetRegisterDetail(int id)
        {
            var registerDetail = await _context.RegisterInspectors.FindAsync(id);
            if (registerDetail == null)
            {
                return NotFound();

            }
            return registerDetail;
        }
        [HttpPost]
        public async Task<IActionResult> PostRegister(RegisterInspector register)
        {
            try
            {

                //save data into userModel
                var user = new User();
                user.FirstName = register.FullName;
                user.UserName = register.FullName;
                user.LastName = register.FullName;
                user.Password = register.Password;
                user.RoleCode = register.RoleCode;
                user.Email = register.Email;

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                var userId = user.Id;

                //get idUser
                register.UserId = userId;
                // save data into registerTeacherModel
                register.Password = BCrypt.Net.BCrypt.HashPassword(register.Password);
                _context.RegisterInspectors.Add(register);
                await _context.SaveChangesAsync();
                return CreatedAtAction("PostRegister", new { id = register.Id }, register);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut]
        public async Task<IActionResult> PutRegister(int id, RegisterInspector register)
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
            var register = await _context.RegisterInspectors.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            _context.RegisterInspectors.Remove(register);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool RegisterDetailExists(int id)
        {
            return _context.RegisterInspectors.Any(e => e.Id == id);
        }

    }
}
