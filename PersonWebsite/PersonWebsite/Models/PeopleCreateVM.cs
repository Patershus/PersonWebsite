using PersonWebsite.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebsite.Models
{
    public class PeopleCreateVM
    {
        [Required(ErrorMessage = "A Person needs a name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email input")]
        [EmailString(ErrorMessage = "Email needs to end with .se or .com")]
        [Display(Name="E-Mail")]
        public string Email { get; set; }

        [Range(4,4, ErrorMessage ="Wrong Input! Are you a bot?")]
        [Display(Name="What is 2+2?")]
        public int BotCheck { get; set; }
    }
}
