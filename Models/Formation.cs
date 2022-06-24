using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Models
{
    public class Formation
    {
       public int Id { get; set; }
       public string DateFormation { get; set; }
       public string Topic { get; set; }
       public string ConcernedPeople { get; set; }
       public int SchoolId { get; set; }
       //public School SchoolRefId { get; set; }


    }
}
