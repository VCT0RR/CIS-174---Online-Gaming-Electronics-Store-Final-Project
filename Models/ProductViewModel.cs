namespace FinalProjectRyan.Models
{
    public class ProductViewModel
    {
        public List<Category> Categories { get; set; } = null!;
        public List<Products> Products { get; set; } = null!;
        public string SelectedCategory { get; set; } = string.Empty;
        public string CheckActiveCategory(string category) =>
            category == SelectedCategory ? "active" : "";
    }
}
