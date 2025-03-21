namespace CW2;

public class CoolProduct
{
    public String productName { get; set; }
    public double mass { get; set; }
    public double temperature { get; set; }

    public CoolProduct(string productName, double mass, double temperature)
    {
        this.productName = productName;
        this.mass = mass;
        this.temperature = temperature;
    }
}