using Contracts.Models;
using Contracts.Models.Enums;

namespace CommonTestHelper
{
    public static class TestData
    {
        public static OrgDTO GetOrgDTO(int level, string? parent=null)
        {
            OrgDTO org = new OrgDTO();
            switch (level)
            {
                case 0:
                    org.Type = (int)NodeType.Company;
                    org.Name = "Company";
                    break;
                case 1:
                    org.Type = (int)NodeType.Department;
                    org.Name = "Department";
                    break;
                case 2:
                    org.Type = (int)NodeType.Activity;
                    org.Name = "Activity";
                    break;
                case 3:
                    org.Type = (int)NodeType.Function;
                    org.Name = "Function";
                    break;
            }
            org.ParentNodeText = parent;
            org.Location = "Location";

            return org;
        }
    }
}
