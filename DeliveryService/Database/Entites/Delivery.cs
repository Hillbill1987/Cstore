using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Database.Entites
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        [Required(ErrorMessage = "Must enter a delivery cost in")]
        [DataType(DataType.Currency)]
        public decimal DeliveryCost { get; set; }
        [Required(ErrorMessage = "A delivery method must be entered")]
        public string DeliveryMethod { get; set; }
        [Required(ErrorMessage = "Must enter a date for delivery")]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }
    }
}
