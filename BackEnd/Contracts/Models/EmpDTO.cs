namespace Contracts.Models
{
    public class EmpDTO
    {

        public string? EmpNodeAsText { get; set; } 

        public short? EmpLevel { get; set; } 

        public string? ManagerNodeAsText { get; set; } 

        public string? ManagerNodeAsName { get; set; } //for swagger

        public string? EmpFunctionNodeAsText { get; set; } 

        public string? EmpFunctionNodeAsName { get; set; } //for swagger

        public string Name { get; set; } = null!;

        public string? Surname { get; set; } 

        public string? Location { get; set; } 




    }
}
