using Cruceros.API.Gateway.Dto;
using Cruceros.API.Gateway.Exceptions;
using System.Net.Http.Headers;

namespace Cruceros.API.Gateway.Client;

public interface IAutenticationClient
{
    public Task VerifySession(string token);
}

public class AutenticationClient : IAutenticationClient
{
    private HttpClient _httpClient;
    private const string BASE_URI = "https://localhost:7194/auth/api/";

    public AutenticationClient()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task VerifySession(string token)
    {
        try
        {
            var content = JsonContent.Create(new TokenRequestDto(token));
            var response = await _httpClient.PostAsync(BASE_URI + "Token/validate", content);
        }
        catch (Exception e)
        {
            throw new AutenticationClientException(e.Message);
        }
    }
}
