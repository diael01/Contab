namespace Contracts.Models
{
    public class OrgDTO
    {
        public string? NodeAsText { get; set; } = null!; //hierarchyId as string as is

        public string? ParentNodeAsText { get; set; } = null!; //ParentNode hierarchyId as string

        public string? ParentNodeAsName { get; set; } //for user easy swagger

        public string Name { get; set; } = null!;

        public short NodeLevel { get; set; }

        public string? Surname { get; set; }

        public string? Location { get; set; }

    }
}
