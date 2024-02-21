using Library.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Entities
{
    [Table(nameof(Human))]
    public class Human:BaseEntity
    {
        public string Name { get; set; }    
        public int Age { get; set; }
    }
}
