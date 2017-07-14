using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebsite.Models
{
    public class Person
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="A Person needs a name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid email input")]
        public string Email { get; set; }

    }
}
