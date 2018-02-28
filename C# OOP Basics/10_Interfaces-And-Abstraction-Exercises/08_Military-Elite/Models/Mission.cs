public class Mission : IMission
{
    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        State = state;
    }

    public string CodeName { get; }

    public string State { get; set; }

    public void CompleteMission()
    {
        this.State = "Finished";
    }

    public override string ToString()
    {
        return $"  Code Name: {CodeName} State: {State}";
    }
}
