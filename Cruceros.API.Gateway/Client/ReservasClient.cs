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


    public async Task RealizarReserva(RealizarReservaDto request)
    {
        try
        {
            Console.WriteLine($"Servicio: Gateway - INFO - Realizando reserva: {request}");
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync(BASE_URI + "Reservas/RealizarReserva", content);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            Console.WriteLine($"Servicio: Gateway - INFO - Habitación reservada con éxito!");
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
            Console.WriteLine($"Servicio: Gateway - INFO - Validando reserva solicitada: {request}");
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync(BASE_URI + "Reservas/VerificarReserva", content);
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("Servicio: Gateway - INFO - Validación exitosa!");
                return true;
            }
            else
            {
                Console.WriteLine("Servicio: Gateway - ERROR - Ya existe una reserva. Intente con otras fechas.");
                return false;
            }
        }
        catch (Exception e)
        {
            throw new ReservasClientException(e.Message);
        }
    }

    public async Task<IEnumerable<ReservasDto>> GetReservasBetweenDates(DateTime dateStart, DateTime dateEnd)
    {
        Console.WriteLine($"Servicio: Gateway - INFO - Obteniendo reservas del recurso Reservas/RealizarReserva entre fechas: {dateStart} - {dateEnd}");

        string formattedDateStart = dateStart.ToString("yyyy-MM-dd");
        string formattedDateEnd = dateEnd.ToString("yyyy-MM-dd");

        var response = await _httpClient.GetAsync(BASE_URI + $"Reservas/ObtenerEntreFechas?dateStart={formattedDateStart}&dateEnd={formattedDateEnd}");
        var json = await response.Content.ReadAsStringAsync();

        Console.WriteLine("Servicio: Gateway - INFO - Reservas obtenidas");

        return JsonConvert.DeserializeObject<IEnumerable<ReservasDto>>(json);
    }
}
