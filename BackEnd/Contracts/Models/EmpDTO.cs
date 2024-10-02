using Microsoft.EntityFrameworkCore;

namespace Contracts.Models
{
    public class EmpDTO
    {

        public string? EmpNodeText { get; set; } //=>EmpDTO

        public short? EmpLevel { get; set; } //=>EmpDTO

        public string? ManagerNodeText { get; set; } //=>EmpDTO

        public string? ManagerNodeName { get; set; } //for swagger

        public string? EmpFunctionNodeText { get; set; } //=>EmpDTO

        public string? EmpFunctionNodeName { get; set; } //for swagger

        public string Name { get; set; } = null!;//=>EmpDTO

        public string? Surname { get; set; } //=>EmpDTO

        public string? Location { get; set; } //=>EmpDTO

      


    }
}
