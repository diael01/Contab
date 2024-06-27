namespace Contracts.Models
{
    public class OrgDTO
    {
        public string OrgNodeText { get; set; } = null!; //hierarchyId as string as is

        public string ParentNodeText { get; set; } = null!; //ParentNode hierarchyId as string

        public string Name { get; set; } = null!;

        public int Type { get; set; }

        public string? LongName { get; set; }

        public string? Location { get; set; }

    }
}
