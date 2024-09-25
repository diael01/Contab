using Contracts.Interfaces;
using Contracts.Models;

namespace CommonTestHelper
{
    public static class CommonHelper
    {
        public static IOrgService orgService;


        public static async Task<string> AddEntityNode(string name, string nodeId=null, string parentName = null)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            if (!string.IsNullOrEmpty(nodeId))
                dto.ParentNodeText = nodeId;
            dto.ParentNodeName = parentName;

            //Act add company
            return (await orgService.AddNode(dto)).ToString();
        }


    }
}
