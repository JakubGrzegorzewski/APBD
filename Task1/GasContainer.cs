namespace Task1;

public class GasContainer : Container, IHazardNotifier
{
    private float PressureInAtm { get; set; }

    public GasContainer(
            float cargoMassInKg,
            float containerMassInKg,
            float maxLoadCapacityInKg,
            float heightInCm,
            float depthInCm,
            string serialNumber,
            float pressureInAtm
        ) : base(
                cargoMassInKg, 
                containerMassInKg, 
                maxLoadCapacityInKg, 
                heightInCm, 
                depthInCm, 
                serialNumber
        )
    {
        PressureInAtm = pressureInAtm;
    }

    public override void UnloadCargo() {
        CargoMassInKG *= 0.05;
    }

    public override void LoadCargo(float cargoAmount = 0) {
        if (CargoMassInKG + cargoAmount > MaxLoadCapacityInKG) {
            IHazardNotifier.SendDangerNotification(this, "Cargo is being overfilled");
            throw new Exception("OverfillException");
        }
        CargoMassInKG += cargoAmount;    
    }
    
    public override string GetContainerType() {
        return "G";
    }

    public override string ToString()
    {
        return $@"{base.ToString()}
has a pressure of {PressureInAtm} atm,";
    }
}