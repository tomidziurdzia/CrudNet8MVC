using System.ComponentModel.DataAnnotations;

namespace CrudNet8MVC.Models;

public class Contact
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nombre es obligatorio")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "Telefono es obligatorio")]
    public string Telefono { get; set; }
    
    [Required(ErrorMessage = "Celular es obligatorio")]
    public string Celular { get; set; }
    
    [Required(ErrorMessage = "Email es obligatorio")]
    public string Email { get; set; }
    
    public DateTime FechaCreacion { get; set; }
}