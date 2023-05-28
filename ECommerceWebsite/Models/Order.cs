using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebsite.Models
{
    [Table("tblOrder")]
    public class Order
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Oid{ get; set; }
        [Required]
        [ForeignKey("ProdId")]
        public int ProdId{ get; set; }
        [Required]
        [ForeignKey("Id")]
        public int Id { get; set; }
        [Required]
        public int Qty { get; set; }

        [ScaffoldColumn(false)]
        [NotMapped]
        public string? ProdName { get; set; }
    }
}
