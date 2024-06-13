using BCrypt.Net;

namespace mercy_developer.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    // Método para establecer la contraseña encriptada
    public void EncriptarPassword(string password)
    {
        Password = BCrypt.Net.BCrypt.HashPassword(password);
    }

    // Método para verificar la contraseña
    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, Password);
    }
}
