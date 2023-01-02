using BrokerChain;
using static BrokerChain.CarModifier;

var maintenance = new Maintenance();

var honda = new Car(maintenance, "Honda", 100);
Console.WriteLine(honda);
using var doubleSpeed = new DoubleModifier(maintenance, honda);
Console.WriteLine(doubleSpeed);
using var decreaseSpeed = new DecreaseModifier(maintenance, honda);
Console.WriteLine(honda);

Console.ReadLine();

