namespace Task1;

public class ContainerShip
{
    public List<Container> Containers { get; set; }
    public float MaxShipSpeedInKnots { get; set; }
    public int MaxContainersCount{ get; set; }
    public float MaxContainerCapacity { get; set; }

    public ContainerShip(float maxShipSpeedInKnots, int maxContainersCount, float maxContainerCapacity)
    {
        MaxShipSpeedInKnots = maxShipSpeedInKnots;
        MaxContainersCount = maxContainersCount;
        MaxContainerCapacity = maxContainerCapacity;
        Containers = new List<Container>();
    }

    public void LoadContainerOnShip(Container container)
    {
        Containers = Containers.Append(container).ToList();
    }
    public void LoadContainerOnShip(List<Container> container)
    {
        Containers = Containers.Concat(container).ToList();
    }

    public void UnloadContainerFromShip(Container container)
    {
        Containers.Remove(container);
    }

    public void SwapContainers(string serialNumber, Container container)
    {
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].SerialNumber == serialNumber)
            {
                Containers.Insert(i, container);
                return;
            }
        }
    }

    public void MoveContainerToOtherShip(Container container, ContainerShip containerShip)
    {
        Containers.Remove(container);
        containerShip.LoadContainerOnShip(container);
    }

    public override string ToString()
    {
        return @$"Container ship has {Containers.Count} containers on board
has maximum speed on {MaxShipSpeedInKnots} knots
max container count of {MaxContainersCount}
and maximum loading capacity of {MaxContainerCapacity} tons";
        
    }
}