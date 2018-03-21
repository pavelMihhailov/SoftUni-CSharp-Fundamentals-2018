using System;

public class LayoutFactory
{
    public ILayout CreateLayout(string layoutType)
    {
        ILayout layout = null;

        switch (layoutType)
        {
            case "SimpleLayout":
                layout = new SimpleLayout();
                break;
            default:
                throw new ArgumentException("Invalid Layout Type!");
        }
        return layout;
    }
}
