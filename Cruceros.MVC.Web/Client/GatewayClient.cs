using Cruceros.API.Gateway.Dto;
using Cruceros.MVC.Web.Exceptions;
using Cruceros.MVC.Web.Models;
using Cruceros.MVC.Web.Service;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Cruceros.MVC.Web.Client;

public interface IGatewayClient
{
    Task<IEnumerable<HabitacionesHabilitadasDto>> ObtenerHabitacionesHabilitadas(DateTime dateStart, DateTime dateEnd);
    Task RegistrarReserva(ReservarHabitacionModel reserva);
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

    public async Task<IEnumerable<HabitacionesHabilitadasDto>> ObtenerHabitacionesHabilitadas(DateTime dateStart, DateTime dateEnd)
    {
        string formattedDateStart = dateStart.ToString("yyyy-MM-dd");
        string formattedDateEnd = dateEnd.ToString("yyyy-MM-dd");
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _sessionContext.GetSessionToken());

        var response = await _httpClient.GetAsync(BASE_URI + $"ObtenerHabitacionesHabilitadas?dateStart={formattedDateStart}&dateEnd={formattedDateEnd}");
        var json = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<IEnumerable<HabitacionesHabilitadasDto>>(json);
    }

    
    public async Task RegistrarReserva(ReservarHabitacionModel request)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _sessionContext.GetSessionToken());

            var content = JsonContent.Create(request);
            await _httpClient.PostAsync(BASE_URI + "ReservarHabitacion", content);
        }
        catch (Exception e)
        {
            throw new AutenticationClientException(e.Message);
        }
    }
}
