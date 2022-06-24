using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace crudProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Manager")] //you can use this methode only with login
        public IEnumerable<string> Get()
            => new string[] { "John Doe", "Jane Doe" };


    }
}
