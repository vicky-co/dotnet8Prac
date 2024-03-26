using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [StringLength(50 ,ErrorMessage ="String length should be between 1 to 50")]
        public string Name { get; set; }
        [Range(0, 150, ErrorMessage ="Order should be between the range 1 to 150")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
