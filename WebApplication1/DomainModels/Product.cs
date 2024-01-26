using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DomainModels
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        public string productName { get; set; }

        public int productPrice { get; set; }
    }
}
