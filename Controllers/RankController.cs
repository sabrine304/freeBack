using crudProjectWebApi.Models;
using Education.Models;
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
    public class RankController : ControllerBase
    {

        readonly DbContextApplication _context;

        public RankController(DbContextApplication context)
        {
            _context = context;
        }

        [HttpGet("/GetRankList")]
        public async Task<ActionResult<IEnumerable<Rank>>> GetAllSchool()
        {
            return await _context.Rank.ToListAsync();

        }

        [HttpGet("/GetRankById/{id}")]
        public async Task<ActionResult<Rank>> GetRankDetail(int id)
        {
            var rankDetail = await _context.Rank.FindAsync(id);
            if (rankDetail == null)
            {
                return NotFound();

            }
            return rankDetail;
        }
    }
}
