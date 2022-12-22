// See https://aka.ms/new-console-template for more information

using Stack;

Console.WriteLine(ETA.CarFleet(10, new [] { 8,3,7,4,6,5 }, new [] { 4,4,4,4,4,4 }));
foreach (var s in Parantheses.Generate(3))
{
    Console.WriteLine(s);
}
Console.WriteLine(RPN.EvalRPN(new [] { "10","6","9","3","+","-11","*","/","*","17","+","5","+" }));
Console.WriteLine(13/5);
Console.WriteLine(ValidParentheses.IsValid("()[]{}"));