namespace Framework.Infra.Common
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