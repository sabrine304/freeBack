using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Models
{
    public class Role
    {
        [Key]
        public string Code { get; set; }
        public string Designation { get; set; }
    }
}
