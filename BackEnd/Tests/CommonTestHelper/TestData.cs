using Contracts.Models;

namespace CommonTestHelper
{
    public static class TestData
    {
        public static OrgDTO GetOrgDTO(int level, string? parent = null)
        {
            OrgDTO org = new OrgDTO();
            switch (level)
            {
                case 0:
                    org.Name = "Company";
                    break;
                case 1:
                    org.Name = "Department";
                    break;
                case 2:
                    org.Name = "Activity";
                    break;
                case 3:
                    org.Name = "Function";
                    break;
            }
            org.ParentNodeText = parent;
            org.Location = "Location";
            return org;
        }

        public static EmpDTO GetEmpDTO(int level, string? parent = null)
        {
            EmpDTO emp = new EmpDTO();
            switch (level)
            {
                case 0:
                    emp.Name = "Eu";
                    break;
                case 1:
                    emp.Name = "mama";
                    break;
                case 2:
                    emp.Name = "Vili";
                    break;

            }
            emp.ManagerNodeText = parent;
            emp.Location = "Location";
            return emp;
        }
    }
}
