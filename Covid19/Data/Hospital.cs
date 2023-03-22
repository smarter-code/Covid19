using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Data
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Max beds capacity is required")]
        public int MaxBedsCount { get; set; }

        [Required(ErrorMessage = "Available beds capacity is required")]
        public int AvailableBedsCount { get; set; }

        [Required(ErrorMessage = "Max ventilator capacity is required")]
        public int MaxVentilatorCount { get; set; }

        [Required(ErrorMessage = "Available ventilator capacity is required")]
        public int AvailableVentilatorCount { get; set; }

        [Required(ErrorMessage = "Max ICU beds capacity is required")]
        public int MaxICUBedsCount { get; set; }

        [Required(ErrorMessage = "Available ICU beds capacity is required")]
        public int AvailableICUBedsCount { get; set; }

        [Required(ErrorMessage = "Please indicate if the ER is active")]
        public bool IsERActive { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int? StateId { get; set; }
        public virtual State State { get; set; }


    }
}
