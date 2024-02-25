using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverBasedOnEvent;
public class Customer
{
    public event EventHandler<BoughtProductEvent> BuyingProduct;  
    public void BuyProduct(string product)
    {
        BuyingProduct?.Invoke(this, new BoughtProductEvent { Name = product });
    }
}
