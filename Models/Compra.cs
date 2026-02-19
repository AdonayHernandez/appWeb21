using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appWeb21.Models
{
    // Entidad que representa una compra realizada por un usuario
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required]

        // Fecha de la compra, se establece por defecto al momento de crear la compra
        public DateTime FechaCompra { get; set; } = DateTime.Now;

        // Relación con Usuario
        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public virtual Usuario Usuario { get; set; }

        // Relación con VideoJuego
        [Required]
        public int VideoJuegoId { get; set; }

        [ForeignKey(nameof(VideoJuegoId))]

        // Propiedad de navegación para acceder al videojuego comprado
        public virtual VideoJuego VideoJuego { get; set; }
    }
}

