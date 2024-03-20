namespace AppRazorPage.Models.Product
{
    public class AddProductCommand
    {
        public string Title { get; set; }
        public string Price { get; set; }
    }
    public class EditProductCommand
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
    }
}
