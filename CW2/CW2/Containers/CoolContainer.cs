using CW2.Exceptions;

namespace CW2;

public class CoolContainer : Container
{
    public string productType { get;}
    public double containerTemp { get;}
    public CoolContainer(double continerHeight, double containerWeight, double containerDepth, int maxCapacity, string productType, double containerTemp) : base(continerHeight, containerWeight, containerDepth, maxCapacity)
    {
        this.containerTemp = containerTemp;
        this.containerType = "C";
        this.serialNumber = generateSerialNumber();
        this.productType = productType;
        this.containerTemp = containerTemp;
    }
    
    public void loadContainer(CoolProduct product)
    {
        if (this.isOnShip)
        {
            throw new OverfillException(serialNumber + ": cannot load container because it is on ship");
        }
        if (product.productName.ToUpper() != productType.ToUpper())
        {
            throw new OverfillException(serialNumber + ": cannot load " + product.productName + ", this container only takes " + productType);
        }
        if (product.mass + contentWeight > maxCapacity)
        {
            double exceededCapacity =product.mass + contentWeight - maxCapacity;
            throw new OverfillException(serialNumber + ": cannot load " + product.mass + " kg, max mass is exceeded by " + exceededCapacity + " kg");
        }

        if (containerTemp > product.temperature)
        {
            throw new OverfillException(serialNumber + ": cannot load " + product.productName + " max temperature is exceeded ");
        }
        contentWeight += product.mass ;
        Logger.Log("You have successfully loaded " + product.productName + " to container " + serialNumber);
        
    }
}