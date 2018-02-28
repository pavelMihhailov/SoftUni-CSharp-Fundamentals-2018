public class Robot : IId
{
    public string Id { get; set; }

    public string Model { get; set; }

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }
}