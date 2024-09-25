using Contracts.Interfaces;
using Contracts.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestHelper
{
    public static class CommonHelper
    {
        public static IOrgService orgService;

        public static async Task<string> AddDept(string orgId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.ParentNodeText = orgId;

            //Act add company
            return (await orgService.AddNode(dto)).ToString();
        }

        public static async Task<string> AddOrg()
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = "Construct";

            //Act add company
            return (await orgService.AddNode(dto)).ToString();
        }

        public static async Task<string> AddActivity(string deptId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.ParentNodeText = deptId;

            //Act add activity
            return (await orgService.AddNode(dto)).ToString();
        }

        public static async Task<string> AddFunction(string actId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.ParentNodeText = actId;

            //Act add function
            return (await orgService.AddNode(dto)).ToString();
        }
    }
}
