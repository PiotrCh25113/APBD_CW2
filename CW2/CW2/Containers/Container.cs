﻿using CW2.Exceptions;

namespace CW2;

public abstract class Container
{
    public double contentWeight { get; set; }
    public double continerHeight { get; set; }
    public double containerWeight { get; set; }
    public double containerDepth { get; set; }
    //fields to build serial number
    public const string preffix = "KON"; //autogenertaed
    public string containerType { get; set; } //autogenerated
    public int containerId { get; } //autogenertaed
    public static List<int> containerIdList = new(); //autogenertaed, list of ids to ensure uniqe values
    public string serialNumber { get; set; } //autogenertaed
    public int maxCapacity { get; set; }

    protected Container(double continerHeight, double containerWeight, double containerDepth, int maxCapacity)
    {
        this.contentWeight = 0;
        this.continerHeight = continerHeight;
        this.containerWeight = containerWeight;
        this.containerDepth = containerDepth;
        this.containerId = generateId();
        this.maxCapacity = maxCapacity;
    }

    //Creates new id and makes sure that this id doesn't exist
    private int generateId()
    {
        Random random = new Random();
        int newId;

        do
        {
            newId = random.Next(100000, 999999); // Generates a 6-digit number
        } while (containerIdList.Contains(newId)); // Ensure uniqueness

        containerIdList.Add(newId); // Add the new unique ID to the list
        return newId;
    }

    protected string generateSerialNumber()
    {
        return preffix + "-" + containerType + "-" + containerId;
    }

    public void printContainer()
    {
        Console.WriteLine("Container: " + containerType);
        Console.WriteLine("serial number: " + serialNumber);
    }

    public virtual void  unLoadContainer()
    {
        this.contentWeight = 0;
        Console.WriteLine("You have successfully unloaded container: " + serialNumber);
    }

    public void loadContainer(int mass)
    {
        if (mass + contentWeight > maxCapacity)
        {
            double exceededCapacity =mass + contentWeight - maxCapacity;
            throw new OverfillException(serialNumber + ": cannot load " + mass + " kg, max mass is exceeded by " + exceededCapacity + " kg");
        }
        contentWeight += mass ;
        Console.WriteLine("You have successfully loaded " + mass + " kg to container " + serialNumber);
        
    }
    
    
}