using System.Collections;

namespace Task1;

public class Container
{
    public double CargoMassInKG { get; set; }
    public float ContainerMassInKG { get; set; }
    public float MaxLoadCapacityInKG { get; set; }
    public float HeightInCM { get; set; }
    public float DepthInCM { get; set; }
    public String SerialNumber { get; set; }
    private static int[] _declaredNumbers = [];

    public Container(
        float cargoMassInKg,
        float containerMassInKg,
        float maxLoadCapacityInKg,
        float heightInCm,
        float depthInCm,
        string serialNumber
        ) 
    {
        CargoMassInKG = cargoMassInKg;
        ContainerMassInKG = containerMassInKg;
        MaxLoadCapacityInKG = maxLoadCapacityInKg;
        HeightInCM = heightInCm;
        DepthInCM = depthInCm;
        SetSerialNumber(serialNumber);
    }

    private void SetSerialNumber(String serialNumber) {
        String[] serialSplit = serialNumber.Split("-");
        if (serialSplit.Length != 3)
            throw new FormatException("Serial numbers need to follow pattern of 'KON-X-Y', where X is the type of container, and Y is random unique number.");
        if (serialSplit[0]!="KON")
            throw new FormatException("Serial numbers always start with 'KON'");
        if (_declaredNumbers.Contains(int.Parse(serialSplit[2])))
            throw new FormatException("Container number already exists");
        SerialNumber = serialNumber;
        _declaredNumbers.Append(int.Parse(serialSplit[2]));
    }

    public static int GenerateUniqueContainerNumber() {
        int randomInt = new Random().Next();
        return _declaredNumbers.Contains(randomInt) ? randomInt : GenerateUniqueContainerNumber();
    }

    public virtual void UnloadCargo() {
        CargoMassInKG = 0;
    }

    public virtual void LoadCargo(float cargoAmount = 0) {
        if (CargoMassInKG + cargoAmount > MaxLoadCapacityInKG)
            throw new Exception("OverfillException");
        CargoMassInKG += cargoAmount;
    }

    public virtual string GetContainerType() {
        return null;
    }

    public string GenerateSerialNumber() {
        return "KON-" + GetContainerType() + "-" + GenerateUniqueContainerNumber();
    }

    public override string ToString()
    {
        return $@"Container with serial {SerialNumber}, 
has max load capacity of {MaxLoadCapacityInKG} kg,
nett weight of {CargoMassInKG} kg,
current load weight of {CargoMassInKG} kg,
dimensions of {HeightInCM} cm in height and {DepthInCM} cm in depth.";
    }
}