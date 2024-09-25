namespace Contracts.Models
{
    public class EmpDTO
    {
        public string? EmpNodeText { get; set; } = null!; //hierarchyId as string as is

        public string? ManagerNodeText { get; set; } = null!; //ManagerNode hierarchyId as string

        public string? ManagerNodeName { get; set; } //for user easy swagger

        public string? FunctionNodeText { get; set; } = null!; //FunctionNode hierarchyId as string

        public string? FunctionNodeName { get; set; } //for user easy swagger

        public string Name { get; set; } = null!;

        public short EmpLevel { get; set; }

        public string? EmpFunctionText { get; set; } = null!;

        public string? Surname { get; set; }

        public string? Location { get; set; }

    }
}
