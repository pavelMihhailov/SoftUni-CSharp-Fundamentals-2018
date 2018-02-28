public interface ICar
{
    string DriverName { get; }

    string Model { get; }

    string Brakes();

    string GasPedal();
}
