public abstract class Worker
{
    private string id;
    private int workingHours;

    protected Worker(string id)
    {
        this.id = id;
    }

    public void Work(int hours)
    {
        this.workingHours += hours;
    }
}