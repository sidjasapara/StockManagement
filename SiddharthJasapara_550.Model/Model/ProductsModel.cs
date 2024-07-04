using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiddharthJasapara_550.Model.Model
{
    public class ProductsModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string type { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float price { get; set; }
    }
}
