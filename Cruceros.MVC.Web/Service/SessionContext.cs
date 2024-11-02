namespace Cruceros.MVC.Web.Service;

public interface ISessionContext
{
    string GetSessionToken();
    string GetSessionUser();
    void SaveSession(string username, string token);
}

public class SessionContext : ISessionContext
{
    private static KeyValuePair<string, string> _session;

    public SessionContext()
    {
       
    }

    public string GetSessionToken()
    {
        return _session.Value;
    }

    public string GetSessionUser()
    {
        return _session.Key;
    }

    public void SaveSession(string username, string token)
    {
        _session = new KeyValuePair<string, string>(username, token);
    }
}
