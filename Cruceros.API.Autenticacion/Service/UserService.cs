using Cruceros.API.Autenticacion.Dto;
using Cruceros.API.Autenticacion.Repository;
using Cruceros.Data.Entidades;

namespace Cruceros.API.Autenticacion.Service;

public interface IUserService
{
    public void crearUsuario(RegisterRequestDto request);
    public LoginResponseDto loginUsuario(LoginRequestDto request);
}

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private ITokenService _tokenService;

    public UserService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public void crearUsuario(RegisterRequestDto request)
    {
        _userRepository.CrearUsuario(buildUser(request));
    }

    public LoginResponseDto loginUsuario(LoginRequestDto request)
    {
        var user = _userRepository.Login(request.Email, request.Password);
        var token = _tokenService.createToken(user.UserName);

        return new LoginResponseDto(user.UserName, token);
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
