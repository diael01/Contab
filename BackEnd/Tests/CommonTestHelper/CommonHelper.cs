
using Contracts.Interfaces;
using Contracts.Models;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Repository.Models;
using System.Net;

namespace CommonTestHelper
{
    public static class CommonHelper
    {
        static public IOrgService orgService;
        static public IEmpService empService;
        static public ContabContext DBContext;
        public class EmpData
        {
            public string orgId, deptId, actId, funcId1, funcId2, funcId3, empId, empId1, empId2;
            public EmpDTO dto, dto1, dto2;
        }

        public static async Task DeleteEmployee(HttpClient httpClient, Dictionary<string, string> query)
        {
            var uri = QueryHelpers.AddQueryString("/api/v1/Emp/DeleteEmployee", query!);
            var remove = await httpClient.DeleteAsync(uri);
            remove.Should().NotBeNull();
            remove.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static async Task<EmpData> Setup(IOrgService org,
                                                  IEmpService emp,
                                                  ContabContext con,
                                                  bool addEmp = true)
        {
            orgService = org;
            empService = emp;
            DBContext = con;
            EmpData d = new EmpData();
            d.orgId = await CommonHelper.AddEntityNode("Con");

            d.deptId = await CommonHelper.AddEntityNode("Business", d.orgId, "Con");
            d.actId = await CommonHelper.AddEntityNode("Mgmt", d.deptId, "Business");
            d.funcId1 = await CommonHelper.AddEntityNode("CEO", d.actId, "Mgmt");
            d.funcId2 = await CommonHelper.AddEntityNode("CTO", d.actId, "Mgmt");
            d.funcId3 = await CommonHelper.AddEntityNode("Manager", d.actId, "Mgmt");

            if (addEmp)
            {
                d.dto = TestData.GetEmpDTO(0, "Eu", null, "CEO", d.funcId1);
                d.empId = await empService.AddEmployee(d.dto);
                //var empNode = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 0).FirstOrDefaultAsync();
            }
            //d.dto = TestData.GetEmpDTO(0, "Eu", null, "CEO", d.funcId1);
            //d.empId = await empService.AddEmployee(d.dto);
            //var empNode = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 0).FirstOrDefaultAsync();

            ////Arrange add employee level 1
            //d.dto1 = TestData.GetEmpDTO(1, "Vili", "Eu", "CTO", d.funcId2);
            //d.dto1.ManagerNodeText = empNode.EmpNode.ToString();
            //d.empId1 = await empService.AddEmployee(d.dto1);

            ////Arrange add employee level 2
            //d.dto2 = TestData.GetEmpDTO(2, "mama", "Eu", "Manager", d.funcId3);
            //d.dto2.ManagerNodeText = empNode.EmpNode.ToString();
            //d.empId2 = await empService.AddEmployee(d.dto2);
            return d;
        }

        public static async Task TearDown(EmpData d, bool empAdded = true)
        {

            //await empService.DeleteEmployee(d.empId2);
            //await empService.DeleteEmployee(d.empId1);
            if (empAdded)
                await empService.DeleteEmployee(d.empId);

            await orgService.DeleteNode(d.funcId3);
            await orgService.DeleteNode(d.funcId1);
            await orgService.DeleteNode(d.funcId2);

            await orgService.DeleteNode(d.actId);
            await orgService.DeleteNode(d.deptId);
            await orgService.DeleteNode(d.orgId);
        }

        public static async Task CheckResponse(HttpResponseMessage response)
        {
            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            using (HttpContent content = response.Content)
            {
                string contentString = await content.ReadAsStringAsync();
                var cli = JsonConvert.DeserializeObject<EmpDTO[]>(contentString);
                cli.Should().NotBeNull();
            }
        }


        public static async Task<string> AddEntityNode(string name, string nodeId = null,
                                                        string parentName = null)
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

        public static async Task DeleteNode(HttpClient httpClient, Dictionary<string, string> query)
        {
            var uri = QueryHelpers.AddQueryString("/api/v1/Org/DeleteNode", query!);
            var remove = await httpClient.DeleteAsync(uri);
            remove.Should().NotBeNull();
            remove.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
