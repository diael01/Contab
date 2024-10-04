using CommonTestHelper;
using Contracts.Models;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests
{
    [TestClass]
    public class EmpIntegrationTests : BaseIntegrationTest
    {
        //[TestMethod]
        //public async Task GetNodes_Integration_Should_Return_OK()
        //{
        //    // Arrange - in base test
        //    var data = await CommonHelper.Setup(orgService, empService, DBContext);
        //    var content = JsonContent.Create(TestData.GetEmpDTO(0));
        //    var comp = await httpClient.PostAsync("/api/v1/Emp/AddEmployee", content);
        //    comp.Should().NotBeNull();
        //    comp.StatusCode.Should().Be(HttpStatusCode.OK);
        //    content = JsonContent.Create(TestData.GetEmpDTO(1, await comp.Content.ReadAsStringAsync()));
        //    var dept = await httpClient.PostAsync("/api/v1/Emp/AddEmployee", content);
        //    dept.Should().NotBeNull();
        //    dept.StatusCode.Should().Be(HttpStatusCode.OK);
        //    content = JsonContent.Create(TestData.GetEmpDTO(2, await dept.Content.ReadAsStringAsync()));
        //    var act = await httpClient.PostAsync("/api/v1/Emp/AddEmployee", content);
        //    act.Should().NotBeNull();
        //    act.StatusCode.Should().Be(HttpStatusCode.OK);

        //    // Act      
        //    using (HttpResponseMessage response = await httpClient.GetAsync("/api/v1/Emp/GetEmployees"))
        //    {
        //        await CheckResponse(response);
        //    }

        //    //cleanup
        //    await CommonHelper.DeleteEmployee(httpClient, new Dictionary<string, string>
        //    {
        //        ["id"] = await act.Content.ReadAsStringAsync()
        //    });
        //    await CommonHelper.DeleteEmployee(httpClient, new Dictionary<string, string>
        //    {
        //        ["id"] = await dept.Content.ReadAsStringAsync()
        //    });
        //    await CommonHelper.DeleteEmployee(httpClient, new Dictionary<string, string>
        //    {
        //        ["id"] = await comp.Content.ReadAsStringAsync()
        //    });

        //    await CommonHelper.TearDown(data);
        //}




        [TestMethod]
        public async Task AddEmp_Integration_Should_Return_OK()
        {
            var dt = await CommonHelper.Setup(orgService, empService, DBContext);

            // Arrange
            var empdt = TestData.GetEmpDTO(0, "Eu", null, "CEO");
            var content = JsonContent.Create(empdt);

            // Act          
            var add = await httpClient.PostAsync("/api/v1/Emp/AddEmployee", content);

            //Assert
            add.Should().NotBeNull();
            add.StatusCode.Should().Be(HttpStatusCode.OK);

            // Remove the object to leave the DB in the same state  
            await CommonHelper.DeleteEmployee(httpClient, new Dictionary<string, string>
            {
                ["id"] = await add.Content.ReadAsStringAsync()
            });

            await CommonHelper.TearDown(dt);
        }


        [TestMethod]
        public async Task UpdateEmp_Integration_Should_Return_OK()
        {
            // Arrange
            var dt = await CommonHelper.Setup(orgService, empService, DBContext);

            var org = TestData.GetEmpDTO(0, "Eu", null, "CEO");
            var content = JsonContent.Create(org);
            var add = await httpClient.PostAsync("/api/v1/Emp/AddEmployee", content);
            add.Should().NotBeNull();
            add.StatusCode.Should().Be(HttpStatusCode.OK);
            org.Name = "TestDataNameUpdate";
            org.EmpNodeText = await add.Content.ReadAsStringAsync();
            content = JsonContent.Create(org);

            // Act
            var update = await httpClient.PutAsync("/api/v1/Emp/UpdateEmployee", content);
            //Assert
            update.Should().NotBeNull();
            update.StatusCode.Should().Be(HttpStatusCode.OK);

            //get again the Emp from DB
            var query = new Dictionary<string, string>
            {
                ["id"] = await update.Content.ReadAsStringAsync()
            };

            // Act
            var node = await httpClient.GetAsync(QueryHelpers.AddQueryString("/api/v1/Emp/GetEmployeeById", query!));
            string contentString = await node.Content.ReadAsStringAsync();
            var orgres = JsonConvert.DeserializeObject<EmpDTO>(contentString);
            orgres.Should().NotBeNull();
            orgres!.Name.Should().Be(org.Name);

            // Remove the object to leave the DB in the same state  
            query = new Dictionary<string, string> { ["id"] = orgres.EmpNodeText! };
            await CommonHelper.DeleteEmployee(httpClient, query);

            await CommonHelper.TearDown(dt);
        }

        [TestMethod]
        public async Task DeleteEmp_Integration_Should_Return_OK()
        {
            var dt = await CommonHelper.Setup(orgService, empService, DBContext);

            var org = TestData.GetEmpDTO(0);
            var content = JsonContent.Create(org);
            var add = await httpClient.PostAsync("/api/v1/Emp/AddEmployee", content);
            add.Should().NotBeNull();
            add.StatusCode.Should().Be(HttpStatusCode.OK);

            // Act
            var delete = await httpClient.PutAsync("/api/v1/Emp/DeleteEmployee", content);
            //Assert
            delete.Should().NotBeNull();
            delete.StatusCode.Should().Be(HttpStatusCode.OK);

            await CommonHelper.TearDown(dt);
        }
    }
}
