using Azure;
using Azure.Core;
using Cruceros.API.Gateway.Exceptions;
using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Reservas.Dto;
using Cruceros.Data.Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Cruceros.API.Gateway.Client;

public interface IReservasClient
{
    Task<IEnumerable<ReservasDto>> ObtenerReservas();
    Task RealizarReserva(RealizarReservaDto request);
    Task<bool> VerificarReserva(ValidarReservaDto request);
    Task<IEnumerable<ReservasDto>> GetReservasBetweenDates(DateTime dateStart, DateTime dateEnd);
}

public class ReservasClient : IReservasClient
{
    private HttpClient _httpClient;
    private const string BASE_URI = "https://localhost:7011/api/";

    public ReservasClient()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public Task<IEnumerable<ReservasDto>> ObtenerReservas()
    {
        throw new NotImplementedException();
    }

    public async Task RealizarReserva(RealizarReservaDto request)
    {
        try
        {
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync(BASE_URI + "Reservas/RealizarReserva", content);
        }
        catch (Exception e)
        {
            throw new ReservasClientException(e.Message);
        }
    }

    public async Task<bool> VerificarReserva(ValidarReservaDto request)
    {
        try
        {
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync(BASE_URI + "Reservas/VerificarReserva", content);
            if(response.IsSuccessStatusCode) return true;
            else return false;
        }
        catch (Exception e)
        {
            throw new ReservasClientException(e.Message);
        }
    }

    public async Task<IEnumerable<ReservasDto>> GetReservasBetweenDates(DateTime dateStart, DateTime dateEnd)
    {
        string formattedDateStart = dateStart.ToString("yyyy-MM-dd");
        string formattedDateEnd = dateEnd.ToString("yyyy-MM-dd");

        var response = await _httpClient.GetAsync(BASE_URI + $"Reservas/ObtenerEntreFechas?dateStart={formattedDateStart}&dateEnd={formattedDateEnd}");
        var json = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<IEnumerable<ReservasDto>>(json);
    }
}
