using CommonTestHelper;
using Contracts.Models;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using static CommonTestHelper.CommonHelper;



namespace IntegrationTests
{
    [TestClass]
    public class EmpIntegrationTests : BaseIntegrationTest
    {
        [TestMethod]
        public async Task GetEmployees_Integration_Should_Return_OK()
        {
            // Arrange - in base test
            var data = await Setup();

            var uri = QueryHelpers.AddQueryString("/api/v1/Emp/GetEmployeesByLevel", "level", 0.ToString());
            using (HttpResponseMessage response = await httpClient.GetAsync(uri!))
            {
                await CheckResponse(response);
            }
            await TearDown(data);
        }


        [TestMethod]
        public async Task AddEmp_Integration_Should_Return_OK()
        {
            var dt = await Setup(false);

            // Arrange
            var empdt = TestData.GetEmpDTO(0, "Eu", null, "CEO");
            var content = JsonContent.Create(empdt);

            // Act          
            var add = await httpClient.PostAsync("/api/v1/Emp/AddEmployee", content);

            //Assert
            add.Should().NotBeNull();
            add.StatusCode.Should().Be(HttpStatusCode.OK);

            // Remove the object to leave the DB in the same state  
            await DeleteEmployee(httpClient, new Dictionary<string, string>
            {
                ["id"] = await add.Content.ReadAsStringAsync()
            });
            await TearDown(dt);
        }


        [TestMethod]
        public async Task UpdateEmp_Integration_Should_Return_OK()
        {
            // Arrange
            var dt = await Setup();

            var emp = await TestParams.DBContext.Employees.Where(e => e.EmpNodeAsText == dt.empId).FirstOrDefaultAsync();
            emp.Name = "TestDataNameUpdate";
            var empDto = TestParams.mapper.Map<EmpDTO>(emp);
            var content = JsonContent.Create(empDto);

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
            var empres = JsonConvert.DeserializeObject<EmpDTO>(contentString);
            empres.Should().NotBeNull();
            empres!.Name.Should().Be(emp.Name);

            // Remove the objects to leave the DB in the same state  
            await TearDown(dt);
        }

        [TestMethod, Ignore("Still a concurrency issue")]
        public async Task DeleteEmp_Integration_Should_Return_OK()
        {
            var dt = await Setup();
            var emp = await TestParams.DBContext.Employees.Where(e => e.EmpNodeAsText == dt.empId).FirstOrDefaultAsync();

            //Act
            await DeleteEmployee(httpClient, new Dictionary<string, string>
            {
                ["id"] = dt.empId
            });
            //Assert
            var dele = await TestParams.DBContext.Employees.Where(e => e.EmpNode.ToString() == dt.empId).FirstOrDefaultAsync();
            dele.Should().BeNull();

            await TearDown(dt, false);
        }
    }
}
