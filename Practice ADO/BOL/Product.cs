using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;  //namespace
namespace BOL
{
    //metdata
    //.net we use special attribute
    //annotations are associated with b. objects
    //data level constraints
    //Rules
    //Policies



    //POCO object

    public class Product
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
