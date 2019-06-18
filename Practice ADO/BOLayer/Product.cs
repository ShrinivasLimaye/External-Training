using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOLayer
{
    public class Product
    {
        [Required]
        //public int ProductId { get; set; }
        public string Title { get; set; }
        //public string Discription { get; set; }
        //[Range(10, 25)]
       // public double unitPrise { get; set; }
        public int ID { get; set; }

        public string Description { get; set; }

        public int UnitPrice { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }

        public int Likes { get; set; }
        public int Total { get; set; }

    }
}
