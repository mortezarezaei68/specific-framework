using Microsoft.AspNetCore.Mvc;

namespace Framework.Controller.Extensions
{
    [ApiController]    
    [ApiResultFilter]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseControllerV1 : ControllerBase
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }
}