
using webjob6;

//await Task.Delay(30000);
//var currentDateTime = DateTime.Now;
//Console.WriteLine($"{Environment.NewLine}Hello from WebJob on {currentDateTime:d} at {currentDateTime:t}!");

List<Product> products = new List<Product>();
const int count = 8000;
for (int i = 0; i < count; i++)
{
    products.Add(new Product(i));
}
await Utils<List<Product>>.AddMessage(products);
