using Education.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        public readonly DbContextApplication _context;

        public LoginController(DbContextApplication context)
        {
            _context = context;
        }

        //[HttpGet]
         
    }
}
