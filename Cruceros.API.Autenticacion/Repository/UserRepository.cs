using Cruceros.API.Autenticacion.Exceptions;
using Cruceros.Data.Entidades;

namespace Cruceros.API.Autenticacion.Repository;

public interface IUserRepository
{
    void CrearUsuario(Usuario usuario);
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
}
