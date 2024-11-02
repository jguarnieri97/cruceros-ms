using Cruceros.API.Gateway.Dto;
using Cruceros.API.Reservas.Dto;
using Cruceros.MVC.Web.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Cruceros.MVC.Web.Client;

public interface IGatewayClient
{
    void Prueba(string username);
    Task<IEnumerable<HabitacionesHabilitadasDto>> ObtenerHabitacionesHabilitadas(DateTime dateStart, DateTime dateEnd);
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

    public async Task<IEnumerable<HabitacionesHabilitadasDto>> ObtenerHabitacionesHabilitadas(DateTime dateStart, DateTime dateEnd)
    {
        string formattedDateStart = dateStart.ToString("yyyy-MM-dd");
        string formattedDateEnd = dateEnd.ToString("yyyy-MM-dd");

        var response = await _httpClient.GetAsync(BASE_URI + $"ObtenerHabitacionesHabilitadas?dateStart={formattedDateStart}&dateEnd={formattedDateEnd}");
        var json = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<IEnumerable<HabitacionesHabilitadasDto>>(json);
    }
}
