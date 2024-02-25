using ObserverBasedOnEvent;

var customer = new Customer();

customer.BuyingProduct += Subscribe;

customer.BuyProduct("product1");

customer.BuyingProduct -= Subscribe;

Console.WriteLine("done.");
Console.ReadLine();

static void Subscribe(object? sender, BoughtProductEvent @event)
{
    Console.WriteLine($"bought {@event.Name}");
}