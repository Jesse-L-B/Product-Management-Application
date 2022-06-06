using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        
        [Display(Name = "Product Id")]
        [Required(ErrorMessage = "Please fill in Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please fill in a product name")]
        [MaxLength(75)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage ="Please enter a price!")]
        public decimal Price { get; set; }
        public string ImageName { get; set; }

    }
}
