using System.ComponentModel;

namespace ObservableCollections;

internal class Program
{
    static void Main(string[] args)
    {
        var market = new Market();
        market.Prices.ListChanged += (sender, eventArgs) =>
        {
            if (eventArgs.ListChangedType == ListChangedType.ItemAdded)
            {
                Console.WriteLine($"price has been added {((BindingList<decimal>)sender)[eventArgs.NewIndex]}");
            }
            
        };

        market.AddPrice(100);
        Console.ReadLine();
    }
}
