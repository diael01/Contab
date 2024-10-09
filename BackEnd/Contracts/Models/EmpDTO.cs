namespace Contracts.Models
{
    public class EmpDTO
    {

        public string? EmpNodeAsText { get; set; }

        public string? EmpNodeAsName { get; set; }

        public short? EmpLevel { get; set; }

        public string? ManagerNodeAsText { get; set; }

        public string Name { get; set; } = null!;

        public string? Surname { get; set; }

        public string? Location { get; set; }

    }
}
