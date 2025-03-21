// See https://aka.ms/new-console-template for more information

using CW2;
using CW2.Exceptions;

Console.WriteLine("Hello, World!");

GasContainer testGas = new GasContainer(10,  21,2,14);
testGas.printContainer();
Console.WriteLine(testGas.contentWeight);
try
{
    testGas.loadContainer(10);
}
catch (OverfillException ex)
{
    Console.WriteLine(ex);
}

testGas.unLoadContainer();
testGas.unLoadContainer();
Console.WriteLine(testGas.contentWeight);
testGas.sendWarning();

LiquidContainer testLiquid = new LiquidContainer(10,  21,2,100);


try
{
    testLiquid.loadContainer(46, false);
    testLiquid.loadContainer(3, true);
    testLiquid.loadContainer(3);

}
catch (OverfillException ex)
{
    Console.WriteLine(ex);
}
Console.WriteLine(testLiquid.hasDangerous);
CoolProduct bananas = new CoolProduct("bananas", 10, 12.9);
CoolProduct chocolate = new CoolProduct("chocolate", 3, -2.9);

CoolContainer testCool = new CoolContainer(10,  21,2,20, "bananas", 11);
try
{
    testCool.loadContainer(bananas);
    testCool.loadContainer(bananas);
    testCool.loadContainer(chocolate);
    
}
catch (OverfillException e)
{
    Console.WriteLine(e);
}

testCool.printContainer();




