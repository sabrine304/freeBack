using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InspectorId { get; set; }
    }
}
