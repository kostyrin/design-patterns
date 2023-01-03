using Command;

var ba = new BankAccount();
var commands = new List<BankAccountCommand>();
commands.Add(new BankAccountCommand(ba, Command.Action.Deposit, 100));
commands.Add(new BankAccountCommand(ba, Command.Action.Withdraw, 50));
Console.WriteLine(ba);
foreach (var command in commands)
    command.Call();
Console.WriteLine(ba);

// See https://aka.ms/new-console-template for more information
Console.ReadLine();
