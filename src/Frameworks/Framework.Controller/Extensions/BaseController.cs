using Microsoft.AspNetCore.Mvc;

namespace Framework.Controller.Extensions
{
    [ApiController]    
    [ApiResultFilter]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class BaseController : ControllerBase
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }
}