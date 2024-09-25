namespace Contracts.Models
{
    public class OrgDTO
    {
        public string? OrgNodeText { get; set; } = null!; //hierarchyId as string as is

        public string? ParentNodeText { get; set; } = null!; //ParentNode hierarchyId as string

        public string? ParentNodeName { get; set; } //for user easy swagger

        public string Name { get; set; } = null!;

        public short OrgLevel { get; set; }

        public string? Surname { get; set; }

        public string? Location { get; set; }

    }
}
