using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffService.Database.Entites
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        [Required(ErrorMessage ="Must enter a first name")]
        [StringLength(10,MinimumLength =3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Must enter a surname")]
        [StringLength(15,MinimumLength =3)]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Must enter a role")]
        public string Role { get; set; }

        public int overtime { get; set; }
    }
}
