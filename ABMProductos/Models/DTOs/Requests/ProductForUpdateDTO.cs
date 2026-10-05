using System.ComponentModel.DataAnnotations;

namespace ABMProductos.Models.DTOs.Requests;
public class ProductForUpdateDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [Range(3, 100)]
    public string Name { get; set; } = string.Empty;
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
    public decimal Price { get; set; }
}
