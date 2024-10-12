using Autenticacion.API.Dto;

namespace Autenticacion.API.Service;

public interface IUsuariosService
{
    //public void crearUsuario();
    public LoginResponseDto loginUsuario(LoginRequestDto request);
}

public class UsuariosService : IUsuariosService
{
    public LoginResponseDto loginUsuario(LoginRequestDto request)
    {
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        return new LoginResponseDto("nick", token);
        //throw new NotImplementedException();
    }
}
