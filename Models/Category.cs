using System.ComponentModel.DataAnnotations;

namespace FinalProjectRyan.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a Category Name.")]
        public string CategoryName { get; set; } = string.Empty;

    }
}
