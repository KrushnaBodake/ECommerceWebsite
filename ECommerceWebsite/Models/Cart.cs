using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebsite.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Cartid { get; set; }
        [ForeignKey("Id")]
        
        public int Id { get; set; }
        [ForeignKey("Prodid")]
        
        public int Prodid { get; set; }
    }
}
