using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
    }
}
