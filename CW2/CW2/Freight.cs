namespace CW2;

public class Freight
{
    public List<Container> containersOnFreight = new List<Container>();
    public double maxSpeed { get; set; }
    public int maxContainerCount { get; }
    public double maxContainerWeight { get; }
    private int currentContainersCount = 0;
    private int currentContainersWeight = 0;
    public Freight(double maxSpeed, int maxContainerCount, double maxContainerWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainerCount = maxContainerCount;
        this.maxContainerWeight = maxContainerWeight;
    }
    
    public void loadSingleContainerOnFreight(Container container)
    {
        if (
            currentContainersCount + 1 <= this.maxContainerCount 
            && currentContainersWeight + container.containerWeight + container.contentWeight <= this.maxContainerWeight)
        {
            
        }
    }

    public void loadContainersOnFreight(List<Container> containers)
    {
        
    }
}