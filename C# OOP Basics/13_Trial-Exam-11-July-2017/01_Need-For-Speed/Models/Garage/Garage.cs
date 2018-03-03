using System.Collections.Generic;

public class Garage
{
    public Garage()
    {
        ParkedCars = new List<int>();
    }

    public List<int> ParkedCars { get; set; }

    public void Modify()
    {

    }

    public void AddCar(int id)
    {
        ParkedCars.Add(id);
    }

    public void RemoveCar(int id)
    {
        ParkedCars.Remove(id);
    }
}
