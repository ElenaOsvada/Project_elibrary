namespace Project_elibrary.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierAdress { get; set; }
        public ICollection<Product>? Products { get; set; }//navigation property
    }
}
