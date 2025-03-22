using CW2;
using CW2.Exceptions;
///Tests specified in the PDF
//Stworzenie kontenera danego typu
Logger.Log();
Logger.Log("Creating containers");

LiquidContainer firstLiquid = new LiquidContainer(10,  20,2,20);
GasContainer firstGas = new GasContainer(10,  20,2,14);
CoolContainer firstCool = new CoolContainer(10,  20,2,20, "bananas", 12);


//Załadowanie ładunku do danego kontenera
Logger.Log();
Logger.Log("Loading containers: ");
try
{
    firstLiquid.loadContainer(8, true);
    firstGas.loadContainer(3);
    firstCool.loadContainer(new CoolProduct("bananas", 20, 20));
}
catch (OverfillException e)
{
    Logger.Log(e.Message);
}

//Załadowanie kontenera na statek
Logger.Log();
Logger.Log("Loading container on freight : ");
Freight firstFreight = new Freight(15, 100, 50);

firstFreight.loadSingleContainerOnFreight(firstLiquid);

//Załadowanie listy kontenerów na statek
Logger.Log();
Logger.Log("Loading container list on freight : ");

List<Container> containersToLoad = new List<Container>();

containersToLoad.Add(firstCool);
containersToLoad.Add(firstGas);
containersToLoad.Add(firstLiquid); //this container is already loadaded, added it to show how program handles duplicates

firstFreight.loadContainersOnFreight(containersToLoad);

//Usunięcie kontenera ze statku
Logger.Log();
Logger.Log("Removing container from freight: ");
firstFreight.unloadContainerFromFreight(firstLiquid);
//Rozładowanie kontenera
Logger.Log();
Logger.Log("Unloading container: ");
bool test = firstLiquid.isOnShip;
firstLiquid.unLoadContainer();


//Zastąpienie kontenera na statku o danym numerze innym kontenerem
Logger.Log();
Logger.Log("Replacing container: ");
Logger.Log();
Logger.Log("Before replacing containers on freight: ");
firstFreight.showFreight();

firstFreight.replaceContaier(firstCool.serialNumber, firstLiquid);

Logger.Log();
Logger.Log("After replacing containers on freight:");
firstFreight.showFreight();

Freight secondFreight = new Freight(15, 100, 50);


//Możliwość przeniesienie kontenera między dwoma statkami
Logger.Log();
Logger.Log("Moving containers between freights: ");
Freight.moveToFreight(firstFreight, secondFreight, firstGas);

secondFreight.showFreight();

Logger.Log();

firstFreight.showFreight();
