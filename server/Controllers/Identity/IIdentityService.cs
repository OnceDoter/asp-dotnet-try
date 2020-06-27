namespace WebApplication1.Controllers.Identity
{
    public interface IIdentityService
    {
        public string GenerateJwtToken(string userId, string userName, AppSettings appSettings);
    }
}
