using Azure.Core;
using Cruceros.API.Gateway.Exceptions;
using Cruceros.API.Reservas.Dto;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Cruceros.API.Gateway.Client;

public interface IReservasClient
{
    Task<IEnumerable<ReservasDto>> ObtenerReservas();
    Task RealizarReserva(RealizarReservaDto request);
    Task<bool> VerificarReserva(ValidarReservaDto request);
}

public class ReservasClient : IReservasClient
{
    private HttpClient _httpClient;
    private const string BASE_URI = "https://localhost:7011/auth/api/";

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
}
