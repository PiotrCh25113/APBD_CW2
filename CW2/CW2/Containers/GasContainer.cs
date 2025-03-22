using System.Runtime.CompilerServices;

namespace CW2;

public class GasContainer : Container, IHazardNotifier
{
    public double pressure { get; set; }
    public GasContainer(double continerHeight, double containerWeight, double containerDepth,
        int maxCapacity) : base( continerHeight, containerWeight, containerDepth, maxCapacity)
    {
        this.containerType = "G";
        this.serialNumber = generateSerialNumber();
    }
    
        public void unLoadContainer()
    {
        if (!this.isOnShip)
        {
            this.contentWeight *= 0.05;
            Logger.Log("You have successfully unloaded container: " + serialNumber);
        }
        else
        {
            Logger.Log("Cannot unload container because it's on the freight: " + serialNumber);
        }
    }
    
    public void sendWarning()
    {
        Logger.Log("Warning, dangerous operation in: " + serialNumber);
    }
    
}