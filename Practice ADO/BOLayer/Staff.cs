using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOLayer
{
    public class Staff
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(18, 56)]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}
