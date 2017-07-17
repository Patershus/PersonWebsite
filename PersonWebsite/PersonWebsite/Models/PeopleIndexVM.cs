using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebsite.Models
{
    public class PeopleIndexVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool ShowAsHighlighted { get; set; }
        public int Id { get; set; }
    }
}
