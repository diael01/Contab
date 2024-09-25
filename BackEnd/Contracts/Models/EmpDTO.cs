namespace Contracts.Models
{
    public class EmpDTO
    {
        public string? EmpNodeText { get; set; } = null!; //hierarchyId as string as is

        public string? ManagerNodeText { get; set; } = null!; //ParentNode hierarchyId as string

        public string Name { get; set; } = null!;

        public short EmpLevel { get; set; }

        public string? EmpFunctionText { get; set; } = null!;

        public string? Surname { get; set; }

        public string? Location { get; set; }

    }
}
