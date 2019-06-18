using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class Order
    {
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Range(10, 25)]
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
