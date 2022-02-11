public class Product
{
    public string Company { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public Product(int modelNumber = 0)
    {
        Company = "Lotus, Inc";
        Name = $"ATS 909-{modelNumber}l (White)";
        Price = (decimal) (599.99 + 10*modelNumber);
    }
}