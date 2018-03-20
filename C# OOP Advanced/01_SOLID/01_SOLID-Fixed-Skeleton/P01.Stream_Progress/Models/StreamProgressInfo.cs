public class StreamProgressInfo
{
    private IStream iStream;

    public StreamProgressInfo(IStream stream)
    {
        this.iStream = stream;
    }

    public int CalculateCurrentPercent()
    {
        return this.iStream.BytesSent * 100 / this.iStream.Length;
    }
}
