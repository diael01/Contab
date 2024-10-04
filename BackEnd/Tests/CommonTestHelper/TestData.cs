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

        public static EmpDTO GetEmpDTO(short? level = null, string name = null, string manager = null,
                                                     string func = null,
                                                     string funcText = null)
        {
            EmpDTO emp = new EmpDTO();
            emp.Name = name == null ? "Eu" : name;
            emp.EmpLevel = level == null ? 0 : level;
            emp.EmpFunctionNodeName = func == null ? "CEO" : func;
            emp.EmpFunctionNodeText = funcText;
            emp.ManagerNodeName = manager;
            emp.Location = "Location_" + name;
            return emp;
        }
    }
}
