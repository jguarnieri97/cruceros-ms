using Autenticacion.API.Dto;
using Autenticacion.API.Repository;
using Autenticacion.Data.Entidades;

namespace Autenticacion.API.Service;

public interface IUserService
{
    public void crearUsuario(RegisterRequestDto request);
    public LoginResponseDto loginUsuario(LoginRequestDto request);
}

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void crearUsuario(RegisterRequestDto request)
    {
        _userRepository.CrearUsuario(buildUser(request));
    }

    public LoginResponseDto loginUsuario(LoginRequestDto request)
    {
        /*var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        return new LoginResponseDto("nick", token);*/
        throw new NotImplementedException();
    }

    private Usuario buildUser(RegisterRequestDto requestDto)
    {
        return new Usuario(
                requestDto.userName,
                requestDto.email,
                requestDto.firstName,
                requestDto.lastName,
                requestDto.password
            );
    }
}
