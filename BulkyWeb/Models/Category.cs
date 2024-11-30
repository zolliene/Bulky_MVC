using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required] // cannot be null
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="The number must be beetween 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
