using Microsoft.VisualStudio.Debugger.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_elibrary.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int? SupplierID { get; set; }
        public Supplier?Supplier { get; set; }//navigation property
    }
}

