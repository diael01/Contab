namespace Services
{
    public interface IAuthorizationApiService
    {
        Task<Permissions> GetPermissions(int userId, int applicationId);
    }
}