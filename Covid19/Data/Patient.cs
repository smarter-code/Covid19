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
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
        public bool? isSuspeciousData { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int? StateId { get; set; }
        public virtual State State { get; set; }

        [Required(ErrorMessage = "Municipality is required")]
        public int? MunicipalityId { get; set; }
        public virtual Municipality Municipality { get; set; }


    }
}
