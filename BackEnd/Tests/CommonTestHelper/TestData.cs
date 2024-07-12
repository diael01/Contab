using Contracts.Models;
using Contracts.Models.Enums;

namespace CommonTestHelper
{
    public static class TestData
    {
        public static OrgDTO GetOrgDTO(int level)
        {
            OrgDTO org = new OrgDTO();
            switch (level)
            {
                case 0:
                    org.Type = (int)NodeType.Company;
                    break;
                case 1:
                    org.Type = (int)NodeType.Department;
                    break;
                case 2:
                    org.Type = (int)NodeType.Activity;
                    break;
                case 3:
                    org.Type = (int)NodeType.Function;
                    break;
            }

            org.Name = "Construct";
            org.Location = "Location";

            return org;
        }
    }
}
