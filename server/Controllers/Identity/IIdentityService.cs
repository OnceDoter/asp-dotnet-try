namespace WebApplication1.Controllers
{
    public interface IIdentityService
    {
        public string GenerateJwtToken(string userId, string userName, AppSettings appSettings);
    }
}
