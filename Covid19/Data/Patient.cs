using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Data
{
    public class Patient
    {


        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Patient name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        public bool? isSuspeciousData { get; set; }

    }
}
