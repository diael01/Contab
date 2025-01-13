namespace Contracts.Models
{
    public class EmpDTO
    {
        public int Id { get; set; }

        public string? EmpNodeAsText { get; set; }

        public int EmpRecordChangeDay { get; set; }

        public string? EmpNodeAsName { get; set; }

        public short? EmpLevel { get; set; }

        public string Name { get; set; } = null!;

        public string IdCardSerieNo { get; set; } = null!;

        public string IdCardCnp { get; set; } = null!;

        public DateTime LastIdCardCreationDate { get; set; }

        public decimal MainSalary { get; set; }

        public DateTime HiringDate { get; set; }

        public string EmpShift { get; set; } = null!;

        public string CountyCode { get; set; } = null!;

        public int WorkGroup { get; set; }

        public int HoursToWork { get; set; }

        public int TypeWorkContract { get; set; }

        public string Email { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateTime Birthday { get; set; }

        public string? Surname { get; set; }

        public string? Location { get; set; }


        //Send to UI the HierarchyId As name for dispaying the Hierarchycal tree

        public string? ManagerNodeName { get; set; }

        public string? EmpDeptNodeName { get; set; } = null!;

        public string? EmpActivityNodeName { get; set; } = null!;

        public string? EmpWorkTypeNodeName { get; set; } = null!;

        public string? EmpFunctionNodeName { get; set; } = null!;


        //Also retrieve HierarchyId as text just in case we need to send them back for a search

        public string? ManagerNodeText { get; set; }

        public string? EmpDeptNodeText { get; set; } = null!;

        public string? EmpActivityNodeText { get; set; } = null!;

        public string? EmpWorkTypeNodeText { get; set; } = null!;

        public string? EmpFunctionNodeText { get; set; } = null!;

        public short? ExceptedRetributionDays { get; set; }

        public decimal? MoneyAdvance { get; set; }

    }
}
