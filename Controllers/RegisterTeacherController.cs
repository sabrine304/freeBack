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
    public class RegisterTeacherController : ControllerBase
    {
        public readonly DbContextApplication _context;

        public RegisterTeacherController(DbContextApplication context)
        {
            _context = context;
        }

         [HttpGet("/GetAllRegisterTeacher")]
        public async Task<ActionResult<IEnumerable<RegisterTeacher>>> GetList()
        {
            return await _context.RegisterTeachers.Include(c=>c.userRefId).ToListAsync();

        }

        //Get : api/RegisterDetail/5
        [HttpGet("/GetAllRegisterTeacherByID/{id}")]
        public async Task<ActionResult<RegisterTeacher>> GetRegisterTeacherDetail(int id)
        {
            var registerDetail = await _context.RegisterTeachers.FindAsync(id);
            if (registerDetail == null)
            {
                return NotFound();

            }
            return registerDetail;
        }

        [HttpPost]
        public async Task<IActionResult> PostRegister([FromBody] RegisterTeacher register)
        {
            try
            {

                //save data into userModel
                var user = new User();
                user.FirstName = register.FullName;
                user.LastName = register.FullName;
                user.UserName = register.FullName;
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
                _context.RegisterTeachers.Add(register);
                await _context.SaveChangesAsync();
                return CreatedAtAction("PostRegister", new { id = register.Id }, register);


            } catch (Exception ex)
            {
                throw ex;
            }
         
        }

        //PUT: apiRegisterDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister(int id, [FromBody] RegisterTeacher register)
        {
          

            if (id != register.Id)
            {
                return BadRequest();
            }
            _context.Entry(register).State = EntityState.Modified;
            //_context.Entry(register.userRefId).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            var register = await _context.RegisterTeachers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            _context.RegisterTeachers.Remove(register);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool RegisterDetailExists(int id)
        {
            return _context.RegisterTeachers.Any(e => e.Id == id);
        }
    }
}
