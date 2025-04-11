// See https://aka.ms/new-console-template for more information

using Task1;

Container container =  new Container(
    5,
    10f,
    10f,
    10f,
    10f,
    "KON-C-111");
LiquidContainer liquidContainer =  new LiquidContainer(
    5,
    10f,
    10f,
    10f,
    10f,
    "KON-C-112",
    false);

GasContainer gasContainer = new GasContainer(
    5,
    10f,
    10f,
    10f,
    10f,
    "KON-C-113",
    10.0f);
CoolingContainer coolingContainer = new CoolingContainer(
    5,
    10f,
    10f,
    10f,
    10f,
    "KON-C-114",
    10.0f,
    [EProductType.Banana]);
container.LoadCargo(1);
ContainerShip containerShip = new ContainerShip(10.0f,10,10.0f);
containerShip.LoadContainerOnShip(container);
containerShip.LoadContainerOnShip([coolingContainer, liquidContainer]);
containerShip.UnloadContainerFromShip(container);
containerShip.SwapContainers("KON-C-114", gasContainer);

ContainerShip ship = new ContainerShip(10.0f,10,10.0f);
containerShip.MoveContainerToOtherShip(coolingContainer, ship);

Console.WriteLine(coolingContainer.ToString());
Console.WriteLine(ship.ToString());