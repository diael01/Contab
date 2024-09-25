using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace CommonTestHelper
{
    public static class OrgHelper
    {
        public static async Task DeleteNode(HttpClient httpClient, Dictionary<string, string> query)
        {
            var uri = QueryHelpers.AddQueryString("/api/v1/Org/DeleteNode", query!);
            var remove = await httpClient.DeleteAsync(uri);
            remove.Should().NotBeNull();
            remove.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
