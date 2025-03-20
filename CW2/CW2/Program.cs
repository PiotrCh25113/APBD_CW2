// See https://aka.ms/new-console-template for more information

using CW2;
using CW2.Exceptions;

Console.WriteLine("Hello, World!");

GasContainer test = new GasContainer(10,  21,2,14);
test.printContainer();
Console.WriteLine(test.contentWeight);
try
{
    test.loadContainer(10);
}
catch (OverfillException ex)
{
    Console.WriteLine(ex);
}

test.unLoadContainer();
test.unLoadContainer();
Console.WriteLine(test.contentWeight);
