namespace Contracts.Models
{
    public class OrgDTO
    {
        public string? NodeText { get; set; } = null!; //hierarchyId as string as is

        public string? NodeName { get; set; } //for user easy swagger

        public string? ParentNodeText { get; set; } = null!; //ParentNode hierarchyId as string

        public string Name { get; set; } = null!;

        public short NodeLevel { get; set; }

        public string? Location { get; set; }

    }
}
