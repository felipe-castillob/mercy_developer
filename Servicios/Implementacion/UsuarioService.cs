using Microsoft.EntityFrameworkCore;
using mercy_developer.Models;
using mercy_developer.Servicios.Contrato;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace mercy_developer.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly MercyDeveloperContext _dbContext;
        public UsuarioService(MercyDeveloperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string password)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Password == password)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
