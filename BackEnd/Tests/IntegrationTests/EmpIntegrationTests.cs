using CommonTestHelper;
using Contracts.Models;
using Contracts.Utils;
using Contracts.Validation;
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
            EmpData data = null;
            try
            {
                // Arrange - in base test
                data = await SetupEmp();

                var uri = QueryHelpers.AddQueryString("/api/v1/Emp/GetEmployeesByLevel", "level", 0.ToString());
                using (HttpResponseMessage response = await httpClient.GetAsync(uri!))
                {
                    await CheckResponse(response);
                }
            } finally
            {
                await TearDownEmp(data);
            }
        }

        [TestMethod]
        public async Task AddEmp_Integration_Should_Return_OK()
        {
            EmpData data = null;
            try
            {
                data = await SetupOrg();

                // Arrange
                var empdt = TestData.GetEmpDTO(data, 0, "Eu");
                new EmpDTOValidator().ValidateAndThrow(empdt);
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
            } finally
            {
                await TearDownOrg(data);
            }
        }

        [TestMethod]
        public async Task UpdateEmp_Integration_Should_Return_OK()
        {
            EmpData data = null;
            try
            {
                data = await SetupEmp();

                var emp = await TestParams.DBContext.Employees.Where(e => e.EmpNodeText == data.empId).FirstOrDefaultAsync();
                emp.LastName = "TestDataNameUpdate";
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
                Utils.GetEmployeeLastName(empres!.LastName).Should().Be(emp.LastName);

                // Remove the objects to leave the DB in the same state  
            } finally
            {
                await TearDownEmp(data);
            }
        }

        [TestMethod]
        public async Task DeleteEmp_Integration_Should_Return_OK()
        {
            EmpData data = null;
            try
            {
                data = await SetupEmp();

                var emp = await TestParams.DBContext.Employees.Where(e => e.EmpNodeText == data.empId).FirstOrDefaultAsync();

                //Act
                await DeleteEmployee(httpClient, new Dictionary<string, string>
                {
                    ["id"] = data.empId
                });
                //Assert
                var dele = await TestParams.DBContext.Employees.Where(e => e.EmpNode.ToString() == data.empId).FirstOrDefaultAsync();
                dele.Should().BeNull();

            } finally
            {
                await TearDownEmp(data);
            };
        }
    }
}
