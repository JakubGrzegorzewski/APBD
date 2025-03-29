namespace Task1;

public class CoolingContainer : Container
{
    public float CurrentTemperature { get; set; }
    private EProductType[] ProductsInContainer { get; set; }

    private static Dictionary<EProductType, float> _requiredTemperature = new Dictionary<EProductType, float>()
    {
        { EProductType.Banana, 13.3f },
        { EProductType.Chocolate, 18f },
        { EProductType.Fish, 2.0f },
        { EProductType.Meat, -15.0f },
        { EProductType.IceCream, -18.0f },
        { EProductType.FrozenPizza, 30.0f },
        { EProductType.Cheese, 7.2f },
        { EProductType.Sausages, 5f },
        { EProductType.Butter, 20.5f },
        { EProductType.Eggs, 19.0f },
    };

    private static Dictionary<EProductType, ECoolingType> _productType = new Dictionary<EProductType, ECoolingType>()
    {
        { EProductType.Banana, ECoolingType.RoomTemperatureProducts },
        { EProductType.Chocolate, ECoolingType.RoomTemperatureProducts },
        { EProductType.Butter, ECoolingType.RoomTemperatureProducts },
        { EProductType.Eggs, ECoolingType.RoomTemperatureProducts },

        { EProductType.Fish, ECoolingType.RefrigeratedProducts },
        { EProductType.Cheese, ECoolingType.RefrigeratedProducts },
        { EProductType.Sausages, ECoolingType.RefrigeratedProducts },

        { EProductType.Meat, ECoolingType.FrozenProducts },
        { EProductType.IceCream, ECoolingType.FrozenProducts },
        { EProductType.FrozenPizza, ECoolingType.FrozenProducts },
    };

    public CoolingContainer(
        float cargoMassInKg,
        float containerMassInKg,
        float maxLoadCapacityInKg,
        float heightInCm,
        float depthInCm,
        string serialNumber,
        float currentTemperature,
        EProductType[] productsInContainer
    ) : base(
        cargoMassInKg,
        containerMassInKg,
        maxLoadCapacityInKg,
        heightInCm,
        depthInCm,
        serialNumber
    )
    {
        CurrentTemperature = currentTemperature;
        ProductsInContainer = productsInContainer;
    }


    public void LoadContainer(float cargoAmount, EProductType productType) {
        if (CanProductBeTransported(productType))
            throw new Exception("This product is not compatible with current cargo");
        if (CurrentTemperature < _requiredTemperature[productType])
            throw new Exception("Container doesn't have the right temperature");

        base.LoadCargo(cargoAmount);
    }

    private bool CanProductBeTransported(EProductType currentProduct) {
        foreach (var product in ProductsInContainer)
            if (_productType[product] != _productType[currentProduct])
                return false;
        return true;
    }

    public override string GetContainerType() {
        return "C";
    }
}