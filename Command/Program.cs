using Command;

var from = new BankAccount();
from.Deposit(100);
var to = new BankAccount();
var mtc = new MoneyTransferCommand(from, to, 1000);
mtc.Call();
Console.WriteLine(from);
Console.WriteLine(to);

mtc.Undo();

//var ba = new BankAccount();
//var commands = new List<BankAccountCommand>();
//commands.Add(new BankAccountCommand(ba, Command.Action.Deposit, 100));
//commands.Add(new BankAccountCommand(ba, Command.Action.Withdraw, 50));
//Console.WriteLine(ba);
//foreach (var command in commands)
//    command.Call();
//Console.WriteLine(ba);
//foreach (var command in Enumerable.Reverse(commands))
//    command.Undo();
//Console.WriteLine(ba);
// See https://aka.ms/new-console-template for more information
Console.ReadLine();
