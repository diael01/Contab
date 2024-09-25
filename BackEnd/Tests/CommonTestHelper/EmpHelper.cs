
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace CommonTestHelper
{
    public static class EmpHelper
    {
        public static async Task DeleteEmployee(HttpClient httpClient, Dictionary<string, string> query)
        {
            var uri = QueryHelpers.AddQueryString("/api/v1/Emp/DeleteEmployee", query!);
            var remove = await httpClient.DeleteAsync(uri);
            remove.Should().NotBeNull();
            remove.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
