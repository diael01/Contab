namespace Contracts.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Secret { get; set; }

    public string? Name { get; set; }

    public int? ApplicationType { get; set; }

    public bool? Active { get; set; }

    public int? RefreshTokenLifetime { get; set; }

    public string? AllowedOrigin { get; set; }
}
