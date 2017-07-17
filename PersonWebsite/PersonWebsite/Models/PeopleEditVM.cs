using PersonWebsite.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebsite.Models
{
    public class PeopleEditVM
    {
        [Required(ErrorMessage = "A Person needs a name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email input")]
        [EmailString(ErrorMessage = "Email needs to end with .se or .com")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        //public int Id { get; set; }

    }
}
