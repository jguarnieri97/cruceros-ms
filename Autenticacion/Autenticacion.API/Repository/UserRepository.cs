using Autenticacion.API.Exceptions;
using Autenticacion.Data.Entidades;

namespace Autenticacion.API.Repository;

public interface IUserRepository
{
    void CrearUsuario(Usuario usuario);
}

public class UserRepository : IUserRepository
{
    private PrograWeb3Context _context;

    public UserRepository(PrograWeb3Context context)
    {
        _context = context;
    }

    public void CrearUsuario(Usuario usuario)
    {
        try
        {
            this._context.Usuarios.Add(usuario);
            this._context.SaveChanges();
        } catch (Exception ex) 
        {
            throw new UserRepositoryException(ex.Message);
        }
    }
}
