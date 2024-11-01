using Cruceros.API.Reservas.Dto;
using System.Net.Http.Headers;

namespace Cruceros.API.Gateway.Client;

public interface IReservasClient
{
    Task<IEnumerable<ReservasDto>> ObtenerReservas();
    Task RealizarReserva();
    Task VerificarReserva();
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

    public Task RealizarReserva()
    {
        throw new NotImplementedException();
    }

    public Task VerificarReserva()
    {
        throw new NotImplementedException();
    }
}
