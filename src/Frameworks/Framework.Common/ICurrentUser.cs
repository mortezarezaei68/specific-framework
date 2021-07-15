using System;
using Microsoft.AspNetCore.Http;

namespace Framework.Common
{
    public interface ICurrentUser
    {
        string GetUserIp();
        string GetUserId();
        void SetHttpOnlyUserCookie(string key, string value, DateTimeOffset date,string domain);
        void CleanSecurityCookie(string key,string domain);
        string GetCookieFromRequest(string key);
    }
}