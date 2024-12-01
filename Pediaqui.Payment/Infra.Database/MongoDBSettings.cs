namespace Infra.Database;

public record MongoDBSettings
{
    public string URI { get; set; }
    public string DatabaseName { get; set; }
}
