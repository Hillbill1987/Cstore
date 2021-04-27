using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.Database.Entites
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }
        public bool Threefortwo { get; set; }

        public bool Bogof { get; set; }
        public bool FreeDelivery { get; set; }
    }
}
