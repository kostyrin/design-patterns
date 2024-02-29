using System.Reactive.Linq;
using ObserverViaSpecialEvent;

public class Demo : IObserver<Event>
{
    public Demo()
    {
        var customer = new Customer();
        var subscription = customer.Subscribe(this);
        customer.OfType<BoughtProductEvent>().Subscribe(args => Console.WriteLine($"Subscribe " + args.ProductName));
    }

    static void Main(string[] args)
    {
        var demo = new Demo();
        


        //Console.ReadLine();
    }

    public void OnCompleted()
    {
        
    }

    public void OnError(Exception error)
    {
        
    }

    public void OnNext(Event value)
    {
        if (value is BoughtProductEvent boughtProductEvent)
        {
            Console.WriteLine($"{nameof(OnNext)}:{boughtProductEvent.ProductName}");
        }
    }
}




