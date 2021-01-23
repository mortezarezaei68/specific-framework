using Microsoft.AspNetCore.Mvc;

namespace Framework.Controller.Extensions
{
    [ApiController]    
    [ApiResultFilter]    
    [Route("v{version:apiVersion}/[area]/[controller]")]
    public class BaseController : ControllerBase
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }
}