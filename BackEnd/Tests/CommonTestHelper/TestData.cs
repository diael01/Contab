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

        public static EmpDTO GetEmpDTO(int level, string? manager = null, string func = null)
        {
            EmpDTO emp = new EmpDTO();
            switch (level)
            {
                case 0:
                    emp.Name = "Eu";
                    //emp.ManagerNodeText = "Eu";
                    //emp.FunctionNodeName = "CEO";
                    break;
                case 1:
                    emp.Name = "mama";
                    //emp.ManagerNodeName = "Eu";
                    //emp.FunctionNodeName = "CTO";
                    break;
                case 2:
                    emp.Name = "Vili";
                    //emp.ManagerNodeName = "mama";
                    //emp.FunctionNodeName = "Sr. Dev";
                    break;

            }
            emp.FunctionNodeName = func;
            emp.ManagerNodeName = manager;
            emp.Location = "Location";
            return emp;
        }
    }
}
