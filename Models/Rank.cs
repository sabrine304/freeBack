using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Models
{
    public class Rank
    {
        [Key]
        public int Id { get; set; }
        public string RankName { get; set; }

    }
}
