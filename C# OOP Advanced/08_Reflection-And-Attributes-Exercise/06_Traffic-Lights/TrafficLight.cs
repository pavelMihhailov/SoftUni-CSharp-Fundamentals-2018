public class TrafficLight
{
    public TrafficLight(Light lightState)
    {
        LightState = lightState;
    }

    public Light LightState { get; set; }

    public void SwitchState()
    {
        LightState = (Light)((int)++LightState % 3);
    }

    public override string ToString()
    {
        return LightState.ToString();
    }
}
