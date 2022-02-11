
using webjob6;
    
    //await Task.Delay(30000);
    //var currentDateTime = DateTime.Now;
    //Console.WriteLine($"{Environment.NewLine}Hello from WebJob on {currentDateTime:d} at {currentDateTime:t}!");

    await Utils<Product>.AddMessage(new Product());