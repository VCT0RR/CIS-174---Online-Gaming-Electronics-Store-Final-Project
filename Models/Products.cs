using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectRyan.Models
{
    public class Products
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please select a Category.")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a Product Brand.")]
        public string ProductBrand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Product Model.")]
        public string ProductModel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Product Price.")]
        public double ProductPrice { get; set; }

        public string Slug => ProductModel.Replace(' ', '-');

        [ValidateNever]
        public Category Category { get; set; } = null!;
    }
}
