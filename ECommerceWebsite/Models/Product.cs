using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebsite.Models
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Prodid { get; set; }
        [Required]
        public string? Prodname { get; set;}
        [Required]
        public decimal Price { get; set;}

        [Display(Name = "Product Image")]
        public string? ImageUrl { get; set; }
        [Required]
        public string? Company  { get; set;}
        [ForeignKey("CatId")]
        [Display(Name = "Catagery Name")]
        public int Catid { get; set;}
        [ScaffoldColumn(false)]
        [NotMapped]
        public string? Catname { get; set; }
        public int Discount { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Description { get; set; }

        public int Stock { get; set; }

    }
}