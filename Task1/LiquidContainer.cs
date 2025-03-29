namespace Task1;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool HazardousMaterial { get; set; }

    public LiquidContainer(
            float cargoMassInKg,
            float containerMassInKg,
            float maxLoadCapacityInKg,
            float heightInCm,
            float depthInCm,
            string serialNumber,
            bool hazardousMaterial
        ) : base(
                cargoMassInKg,
                containerMassInKg,
                maxLoadCapacityInKg,
                heightInCm,
                depthInCm,
                serialNumber
            )
    {
        HazardousMaterial = hazardousMaterial;
    }

    public override void LoadCargo(float cargoAmount) {
        if (HazardousMaterial) {
            if (CargoMassInKG + cargoAmount > MaxLoadCapacityInKG + .5)
                IHazardNotifier.SendDangerNotification(this, "Amount exceeds max load.");
        }else {
            if (CargoMassInKG + cargoAmount > MaxLoadCapacityInKG * .9)
                IHazardNotifier.SendDangerNotification(this, "Amount exceeds max load.");
        }
        CargoMassInKG += cargoAmount;
    }

    public override string GetContainerType() {
        return "L";
    }
}