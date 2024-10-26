using Cruceros.MVC.Web.Service;
using System.Net.Http.Headers;

namespace Cruceros.MVC.Web.Client;

public interface IGatewayClient
{
    void Prueba(string username);
}

public class GatewayClient : IGatewayClient
{

    private HttpClient _httpClient;
    private ISessionContext _sessionContext;
    private const string BASE_URI = "https://localhost:7104/api/Crucero/";

    public GatewayClient(ISessionContext sessionContext)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _sessionContext = sessionContext;
    }

    public async void Prueba(string username)
    {
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _sessionContext.GetSession(username));


        await _httpClient.GetAsync(BASE_URI + "prueba");
    }
}
