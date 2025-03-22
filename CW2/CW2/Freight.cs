namespace CW2;

public class Freight
{
    public List<Container> containersOnFreight = new List<Container>();
    public double maxSpeed { get; set; }
    public int maxContainersCount { get; }
    public double maxContainersWeight { get; }
    private int currentContainersCount = 0;
    private double currentContainersWeight = 0;
    public Freight(double maxSpeed, int maxContainersCount, double maxContainersWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainersCount = maxContainersCount;
        this.maxContainersWeight = maxContainersWeight * 1000;
    }
    
    public bool loadSingleContainerOnFreight(Container container)
    {
        if (checkIfCanBeLoaded(container))
        {
            container.isOnShip = true;
            currentContainersCount++;
            currentContainersWeight += container.containerWeight + container.contentWeight;
            containersOnFreight.Add(container);
            Logger.Log("Loaded container on the freight: " + container.serialNumber);
            return true;
        }
        return false;
    }

    public void loadContainersOnFreight(List<Container> containers)
    {
        foreach (Container container in containers)
        {
            loadSingleContainerOnFreight(container);
        }
    }

    public bool unloadContainerFromFreight(Container container)
    {
        if (containersOnFreight.Contains(container))
        {   
            container.isOnShip = false;
            containersOnFreight.Remove(container);
            currentContainersCount--;
            currentContainersWeight -= container.containerWeight + container.contentWeight;
            Logger.Log("Unloaded container from freight: " + container.serialNumber);
            return true;
        }
        Logger.Log("Cannot unload container because it's not present on this freight: " + container.serialNumber);
        return false;
    }

    public void replaceContaier(String containerToReplaceId, Container container)
    {
        bool isOnThisFreight = false;
        Container containerToReplace = null;
        foreach (Container containerOnFreight in containersOnFreight)
        {
            if (containerToReplaceId == containerOnFreight.serialNumber)
            {   
                containerToReplace = containerOnFreight;
                isOnThisFreight = true;
                break;
            }
        }

        if (isOnThisFreight)
        {
            Logger.Log("Replacing containers!");
            unloadContainerFromFreight(containerToReplace);
            loadSingleContainerOnFreight(container);
        }
    }

    public static void moveToFreight(Freight originFreight, Freight destinationFreight, Container containerToMove)
    {
        if (originFreight.unloadContainerFromFreight(containerToMove))
        {
            if (destinationFreight.loadSingleContainerOnFreight(containerToMove))
            {
                Logger.Log("Succesfully moved container: " + containerToMove.serialNumber);
            }
            else
            {
                Logger.Log("Cannot load container to new ship: " + containerToMove.serialNumber);
            }
        }
        else
        {
            Logger.Log("Cannot load container to new ship: " + containerToMove.serialNumber);
        }
    }

    public void showFreight()
    {
        Console.WriteLine("Current Freight has: " + currentContainersCount + "/" + maxContainersCount + " containers.");
        Console.WriteLine("Current Freight weight: " + currentContainersWeight/1000 + "/" + maxContainersWeight/1000 + " tons.");
        Console.WriteLine("Current Freight payload:");
        foreach (Container container in containersOnFreight)
        {
            container.printContainer();
        }
    }

    public bool checkIfCanBeLoaded(Container container)
    {
        if (
            currentContainersCount + 1 <= this.maxContainersCount
            && currentContainersWeight + container.containerWeight + container.contentWeight <= this.maxContainersWeight
            && !container.isOnShip)
        {
            return true;
        }
        Logger.Log("Cannot load container: " + container.serialNumber);
        return false;
    }
}