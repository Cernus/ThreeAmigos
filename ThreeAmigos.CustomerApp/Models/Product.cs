namespace ThreeAmigos.CustomerApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        // TODO: Format so price leads with a "£"
        public double? Price { get; set; }
        public int? StockLevel { get; set; }
    }
}