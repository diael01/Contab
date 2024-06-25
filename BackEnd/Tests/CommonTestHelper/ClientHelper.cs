
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace CommonTestHelper
{
  public static class ClientHelper
  {
    public static async void DeleteClient(HttpClient ClientDTO, Dictionary<string, string> query)
    {
      var uri = QueryHelpers.AddQueryString("/api/v1/ClientDTO/DeleteClientDTO", query!);
      var remove = await ClientDTO.GetAsync(uri);
      remove.Should().NotBeNull();
      remove.StatusCode.Should().Be(HttpStatusCode.OK);
    }
  }
}
