using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public string FileName{ get; set; }
        public string ContentType { get; set; }
        public long? FileSize { get; set; }
    }
}
