using Microsoft.AspNetCore.Mvc;

namespace Framework.Controller.Extensions;

[ApiController]    
[ApiResultFilter]
[ApiExplorerSettings(GroupName = "v2")]
[ApiVersion("2.0")]
// [Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseControllerV2 : ControllerBase
{
    public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
}