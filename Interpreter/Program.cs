using Interpreter;

string input = "(13+4)-(12+1)";
var tokens = Token.Lex(input);

var result = BinaryOperation.Parse(tokens);

Console.WriteLine(string.Join("\t", tokens));