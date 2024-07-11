using Contracts.Models;
using Contracts.Models.Enums;

namespace CommonTestHelper
{
    public static class TestData
    {
        public static OrgDTO GetOrgDTO()
        {
            OrgDTO org = new OrgDTO();

            org.Type = (int)NodeType.Company;
            org.Name = "Construct";
            org.Location = "Location";

            return org;
        }
    }
}
