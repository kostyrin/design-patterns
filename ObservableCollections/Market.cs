using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollections;
public class Market
{
    public Market()
    {
        
    }

    public BindingList<decimal> Prices = new BindingList<decimal>();

    public void AddPrice(decimal price)
    {
        Prices.Add(price); 
    }
}
