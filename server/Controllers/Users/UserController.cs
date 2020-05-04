namespace WebApplication1.Controllers.Users
{
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class UserController : ApiController
    {
    }
    
}
