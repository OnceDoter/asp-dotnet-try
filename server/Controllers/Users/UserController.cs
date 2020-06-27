using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers.Users
{
    [Authorize]
    public class UserController : ApiController
    {
    }
    
}
