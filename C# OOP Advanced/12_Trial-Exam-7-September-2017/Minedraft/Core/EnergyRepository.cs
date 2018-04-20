public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public bool TakeEnergy(double energyNeeded)
    {
        if (EnergyStored < energyNeeded) return false;

        EnergyStored -= energyNeeded;
        return true;
    }

    public void StoreEnergy(double energy)
    {
        EnergyStored += energy;
    }
}