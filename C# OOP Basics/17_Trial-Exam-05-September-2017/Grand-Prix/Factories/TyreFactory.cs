using System.Collections.Generic;

public class TyreFactory
{
    public static Tyre CreateTyre(List<string> tyreArgs)
    {
        string type = tyreArgs[0];
        double hardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        if (type.Equals("Ultrasoft"))
        {
            double grip = double.Parse(tyreArgs[2]);
            tyre = new UltrasoftTyre(hardness, grip);
        }
        else if (type.Equals("Hard")) tyre = new HardTyre(hardness);

        return tyre;
    }
}
