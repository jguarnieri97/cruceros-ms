namespace Cruceros.MVC.Web.Service;

public interface ISessionContext
{
    string GetSession(string username);
    void SaveSession(string username, string token);
}

public class SessionContext : ISessionContext
{
    private static List<KeyValuePair<string, string>> _sessions;

    public SessionContext()
    {
        if (_sessions == null)
        {
            _sessions = new List<KeyValuePair<string, string>>();
        }
    }

    public string GetSession(string username)
    {
        var user = _sessions.FirstOrDefault(x => x.Key == username);
        return user.Value;
    }

    public void SaveSession(string username, string token)
    {
        _sessions.Add(new KeyValuePair<string, string>(username, token));
    }
}
