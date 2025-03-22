using CW2.Exceptions;

namespace CW2;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool hasDangerous = false;
    public LiquidContainer(double continerHeight, double containerWeight, double containerDepth,
        int maxCapacity) : base(continerHeight, containerWeight, containerDepth, maxCapacity)
    {
        this.containerType = "L";
        this.serialNumber = generateSerialNumber();
    }
    
    public void sendWarning()
    {
        Console.WriteLine("Warning, dangerous operation in: " + serialNumber);
    }
    
    public void loadContainer(double mass, bool isDangerous)
    {
        if (this.isOnShip)
        {
            throw new OverfillException(serialNumber + ": cannot load container because it is on ship");
        }
        double capacity = maxCapacity * (isDangerous || hasDangerous ? 0.5 : 0.9);
        double exceededCapacity = (mass + contentWeight) - capacity;
        
        if (exceededCapacity > 0)
        {
            Console.WriteLine("Warning, dangerous operation in: " + serialNumber);
            throw new OverfillException(serialNumber + ": cannot load " + mass + " kg, max mass is exceeded by " + exceededCapacity + " kg");
        }

        hasDangerous |= isDangerous;
        
        contentWeight += mass;
        Console.WriteLine("You have successfully loaded " + mass + " kg to container " + serialNumber);
        
    }

}
