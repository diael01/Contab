using Contracts.Models;

namespace CommonTestHelper
{
  public static class TestData
  {
    public static ClientDTO GetClientDTO()
    {
      ClientDTO cli = new ClientDTO();
      cli.Id = 0;
      cli.Name = "TestCliName";
      cli.Ip = "TestIP";
      return cli;
    }
  }
}
