namespace appWeb21.Models
{

    // Modelo de vista para representar la información de error en la aplicación
    public class ErrorViewModel
    {

        // Propiedad que almacena el identificador de la solicitud actual,
        // se utiliza para rastrear errores específicos
        public string? RequestId { get; set; }

        // Propiedad que indica si se debe mostrar el identificador de la solicitud,
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
