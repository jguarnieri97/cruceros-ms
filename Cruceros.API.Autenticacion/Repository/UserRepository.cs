using Cruceros.API.Autenticacion.Exceptions;
using Cruceros.Data.Entidades;

namespace Cruceros.API.Autenticacion.Repository;

public interface IUserRepository
{
    void CrearUsuario(Usuario usuario);
    Usuario Login(string email, string password);
}

public class UserRepository : IUserRepository
{
    private CrucerosContext _context;

    public UserRepository(CrucerosContext context)
    {
        _context = context;
    }

    public void CrearUsuario(Usuario usuario)
    {
        try
        {
            this._context.Usuarios.Add(usuario);
            this._context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new UserRepositoryException(ex.Message);
        }
    }

    public Usuario Login(string email, string password)
    {
        var user = from u in this._context.Usuarios
                   where u.Email == email && u.Password == password
                   select u;

        if (user == null) throw new UserNotFoundException($"El usuario con email '{email}' no se encontró");
        return user.First();
    }
}
