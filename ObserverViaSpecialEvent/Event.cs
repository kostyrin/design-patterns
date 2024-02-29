using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverViaSpecialEvent;
public class Event
{
}

public class BoughtProductEvent : Event
{
    public string ProductName;
}


