
using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repository.Models;
using System.Net;

namespace CommonTestHelper
{
    public static class CommonHelper
    {
        public static class TestParams
        {
            public static IOrgService org;
            public static IEmpService emp;
            public static ContabContext DBContext;
            public static IMapper mapper;
        }

        public class EmpData
        {
            public string orgId, deptId, actId, workTypeId,
                          funcId1, funcId2, funcId3, empId, empId1, empId2;
            public EmpDTO dto, dto1, dto2;
        }

        public static async Task DeleteEmployee(HttpClient httpClient, Dictionary<string, string> query)
        {
            var uri = QueryHelpers.AddQueryString("/api/v1/Emp/DeleteEmployee", query!);
            var remove = await httpClient.DeleteAsync(uri);
            remove.Should().NotBeNull();
            remove.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static async Task<EmpData> SetupOrg()
        {
            EmpData d = new EmpData();
            d.orgId = await AddEntityNode("Con");

            d.deptId = await AddEntityNode("Business", d.orgId, "Con");
            d.actId = await AddEntityNode("Mgmt", d.deptId, "Business");
            d.workTypeId = await AddEntityNode("Paza", d.actId, "Mgmt");
            d.funcId1 = await AddEntityNode("CEO", d.workTypeId, "Paza");
            d.funcId2 = await AddEntityNode("CTO", d.workTypeId, "Paza");
            d.funcId3 = await AddEntityNode("Manager", d.workTypeId, "Paza");

            return d;
        }

        public static async Task TearDownOrg(EmpData d)
        {

            await TestParams.org.DeleteNode(d.funcId3);
            await TestParams.org.DeleteNode(d.funcId2);
            await TestParams.org.DeleteNode(d.funcId1);
            await TestParams.org.DeleteNode(d.workTypeId);
            await TestParams.org.DeleteNode(d.actId);
            await TestParams.org.DeleteNode(d.deptId);
            await TestParams.org.DeleteNode(d.orgId);
        }

        public static async Task<EmpData> SetupEmp()
        {
            EmpData d = await SetupOrg();
            d.dto = TestData.GetEmpDTO(d, 0, "Eu");
            d.empId = await TestParams.emp.AddEmployee(d.dto);
            var empNode = await TestParams.DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 0).FirstOrDefaultAsync();
            var empNodeAsText = empNode.EmpNode.ToString();

            //Arrange add employee level 1
            d.dto1 = TestData.GetEmpDTO(d, 1, "Vili", empNodeAsText);
            d.empId1 = await TestParams.emp.AddEmployee(d.dto1);

            //Arrange add employee level 2
            d.dto2 = TestData.GetEmpDTO(d, 2, "mama", empNodeAsText);
            d.empId2 = await TestParams.emp.AddEmployee(d.dto2);

            return d;
        }

        public static async Task TearDownEmp(EmpData d)
        {

            if (d.empId2 != null)
                await TestParams.emp.DeleteEmployee(d.empId2);
            if (d.empId1 != null)
                await TestParams.emp.DeleteEmployee(d.empId1);
            if (d.empId != null)
                await TestParams.emp.DeleteEmployee(d.empId);

            await TearDownOrg(d);
        }

        //public static async Task<EmpData> Setup(bool addEmp = true)
        //{

        //    EmpData d = new EmpData();
        //    d.orgId = await AddEntityNode("Con", null, null);

        //    d.deptId = await AddEntityNode("Business", d.orgId, "Con");
        //    d.actId = await AddEntityNode("Mgmt", d.deptId, "Business");
        //    d.funcId1 = await AddEntityNode("CEO", d.actId, "Mgmt");
        //    d.funcId2 = await AddEntityNode("CTO", d.actId, "Mgmt");
        //    d.funcId3 = await AddEntityNode("Manager", d.actId, "Mgmt");

        //    if (addEmp)
        //    {
        //        d.dto = TestData.GetEmpDTO(d, 0, "Eu", "Eu");
        //        d.empId = await TestParams.emp.AddEmployee(d.dto);
        //        //var empNode = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 0).FirstOrDefaultAsync();
        //    }
        //    //d.dto = TestData.GetEmpDTO(0, "Eu", null, "CEO", d.funcId1);
        //    //d.empId = await empService.AddEmployee(d.dto);
        //    //var empNode = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 0).FirstOrDefaultAsync();

        //    ////Arrange add employee level 1
        //    //d.dto1 = TestData.GetEmpDTO(1, "Vili", "Eu", "CTO", d.funcId2);
        //    //d.dto1.ManagerNodeAsText = empNode.EmpNode.ToString();
        //    //d.empId1 = await empService.AddEmployee(d.dto1);

        //    ////Arrange add employee level 2
        //    //d.dto2 = TestData.GetEmpDTO(2, "mama", "Eu", "Manager", d.funcId3);
        //    //d.dto2.ManagerNodeAsText = empNode.EmpNode.ToString();
        //    //d.empId2 = await empService.AddEmployee(d.dto2);
        //    return d;
        //}

        //public static async Task TearDown(
        //                                                EmpData d,
        //                                                bool empAdded = true
        //                                               )
        //{

        //    //await empService.DeleteEmployee(d.empId2);
        //    //await empService.DeleteEmployee(d.empId1);
        //    if (empAdded)
        //        await TestParams.emp.DeleteEmployee(d.empId);

        //    await TestParams.org.DeleteNode(d.funcId3);
        //    await TestParams.org.DeleteNode(d.funcId1);
        //    await TestParams.org.DeleteNode(d.funcId2);

        //    await TestParams.org.DeleteNode(d.actId);
        //    await TestParams.org.DeleteNode(d.deptId);
        //    await TestParams.org.DeleteNode(d.orgId);
        //}

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
                                                        string parentName = null
                                                       )
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.ParentNodeAsText = nodeId;

            //Act add company
            return (await TestParams.org.AddNode(dto)).ToString();
        }

        public static async Task DeleteNode(HttpClient httpClient, Dictionary<string, string> query)
        {
            var uri = QueryHelpers.AddQueryString("/api/v1/Org/DeleteNode", query!);
            var remove = await httpClient.DeleteAsync(uri);
            remove.Should().NotBeNull();
            remove.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static void SetTestParams(ContabContext ctx, IOrgService org,
                                    IEmpService emp, IMapper map)
        {
            TestParams.DBContext = ctx;
            TestParams.org = org;
            TestParams.emp = emp;
            TestParams.mapper = map;
        }
    }
}
