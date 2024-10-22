using Cruceros.MVC.Web.Dto;
using Cruceros.MVC.Web.Exceptions;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Cruceros.MVC.Web.Client;

public interface IAutenticationClient
{
    public void RegisterUser(RegisterUserDto request);
    public Task<LoginResponseDto> LoginUser(LoginRequestDto request);
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

    public async void RegisterUser(RegisterUserDto request)
    {
        try 
        {
            var content = JsonContent.Create(request);
            await _httpClient.PostAsync(BASE_URI + "Usuarios/crear", content);
        } 
        catch (Exception e) 
        {
            throw new AutenticationClientException(e.Message);    
        }
    }

    public async Task<LoginResponseDto> LoginUser(LoginRequestDto request)
    {
        try
        {
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync(BASE_URI + "Usuarios/login", content);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponseDto>(json);
        }
        catch (Exception e)
        {
            throw new AutenticationClientException(e.Message);
        }
    }
}
