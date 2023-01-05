using Interpreter;

string input = "(13+4)-(12+1)";
var tokens = Token.Lex(input);
Console.WriteLine(string.Join("\t", tokens));