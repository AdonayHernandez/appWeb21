using System.ComponentModel.DataAnnotations;

namespace appWeb21.Models
{
    // Entidad que representa un usuario registrado en la plataforma
    public class Usuario
    {
        [Key]
        // Identificador único del usuario, se genera automáticamente
        public int Id { get; set; }

        [Required]
        [StringLength(100)]

        // Nombre del usuario, se requiere y tiene un límite de 100 caracteres
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]

        // Correo electrónico del usuario, se requiere, debe ser una dirección de correo válida
        // y tiene un límite de 150 caracteres
        public string Email { get; set; }

        [Required]
        [StringLength(255)]

        // Contraseña del usuario, se requiere y tiene un límite de 255 caracteres
        public string Password { get; set; }

        [Required]

        // Fecha de registro del usuario, se establece por defecto al momento de crear el usuario
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Propiedad de navegación para acceder a las compras realizadas por el usuario
        public ICollection<Compra> Compras { get; set; }
    }
}
