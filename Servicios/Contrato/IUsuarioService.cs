using Microsoft.EntityFrameworkCore;
using mercy_developer.Models;

namespace mercy_developer.Servicios.Contrato
{
    public interface IUsuarioService
    {

        Task<Usuario> GetUsuario(string correo, string password);
        Task<Usuario> SaveUsuario(Usuario modelo);

    }
}
