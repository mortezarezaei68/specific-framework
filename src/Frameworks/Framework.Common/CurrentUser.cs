using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Framework.Common
{
    public class CurrentUser:ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserIp()
        {
            return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }   
        public string GetUserId()
        {
            
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();

            return userId;
        }
        public void SetHttpOnlyUserCookie(string key, string value,DateTimeOffset date,string domain)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value,
                new CookieOptions()
                    {HttpOnly = true, SameSite = SameSiteMode.Lax, Expires = date, Domain = domain, Secure = false});
        }

        public void CleanSecurityCookie(string key,string domain)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(key))
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(key,new CookieOptions()
                {
                    Domain = domain
                });
        }

        public string GetCookieFromRequest(string key)
        {
            var cookieValue=_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(key);
            return cookieValue ? _httpContextAccessor.HttpContext.Request.Cookies[key] : null;
        }
    }
}