using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace NetSevenCommerece.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order should be between 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
