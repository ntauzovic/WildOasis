namespace WildOasis.Infrastructure.Configuration;

public class PostgresDbConfiguration
{
    public string? DbHost { get; set; }
    public string? DbPort { get; set; }
    public string? DbName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public string ConnectionString => $"Host={DbHost}; Database={DbName}; Username={Username}; Password={Password};";

}