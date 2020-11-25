using System;
using System.Net.Sockets;

namespace Prototype
{
    [Serializable]
    public class Person
    {
        public string[] Names { get; set; }

        public Address Address { get; set; }

    }

    [Serializable]
    public class Address
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}
