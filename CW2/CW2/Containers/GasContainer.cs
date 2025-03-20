using System.Runtime.CompilerServices;

namespace CW2;

public class GasContainer : Container
{
    public GasContainer(double continerHeight, double containerWeight, double containerDepth,
        int maxCapacity) : base( continerHeight, containerWeight, containerDepth, maxCapacity)
    {
        this.containerType = "G";
        this.serialNumber = generateSerialNumber();
    }

    override
        public void unLoadContainer()
    {
        this.contentWeight *= 0.05;
        Console.WriteLine("You have successfully unloaded container: " + serialNumber);
    }
    
}