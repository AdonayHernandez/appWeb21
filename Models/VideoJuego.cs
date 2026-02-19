using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appWeb21.Models
{
    // Entidad que representa un videojuego disponible en la plataforma
    public class VideoJuego
    {
        [Key]

        // Identificador único del videojuego, se genera automáticamente
        public int Id { get; set; }

        [Required]
        [StringLength(150)]

        // Título del videojuego, se requiere y tiene un límite de 150 caracteres
        public string Titulo { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]

        // Precio del videojuego, se requiere y se almacena con formato decimal con 2 decimales
        public decimal Precio { get; set; }

        [Required]
        [StringLength(100)]

        // Categoría del videojuego, se requiere y tiene un límite de 100 caracteres
        public string Categoria { get; set; }

        [StringLength(500)]

        // Descripción del videojuego, tiene un límite de 500 caracteres
        public string Descripcion { get; set; }

        // Propiedad de navegación para acceder a las compras realizadas de este videojuego
        public ICollection<Compra> Compras { get; set; }
    }
}
