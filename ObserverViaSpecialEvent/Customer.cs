using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverViaSpecialEvent;
public class Customer: IObservable<Event>
{
    private readonly HashSet<Subscription> _subscriptions = new HashSet<Subscription>();
    public IDisposable Subscribe(IObserver<Event> observer)
    {
        var subscription = new Subscription(this, observer);
        _subscriptions.Add(subscription);
        return subscription;
    }

    public void Catch()
    {
        foreach (var subscription in _subscriptions)
        {
            subscription.Observer.OnNext(new BoughtProductEvent { ProductName = "product" });
        } 
    }

    private class Subscription : IDisposable
    {
        private Customer _customer;
        public IObserver<Event> Observer;

        public Subscription(Customer customer, IObserver<Event> observer)
        {
            _customer = customer;
            Observer = observer;
        }

        public void Dispose()
        {
            _customer._subscriptions.Remove(this);
        }
    }
}
