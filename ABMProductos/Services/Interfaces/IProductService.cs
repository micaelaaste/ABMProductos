namespace ABMProductos.Services.Interfaces;

using ABMProductos.Models.DTOs.Requests;
using ABMProductos.Models.DTOs.Responses;
public interface IProductService
{
    ProductForReadDto? GetProductById(int id);
    List<ProductForReadDto> GetAllProducts();
    ProductForReadDto CreateProduct(ProductForCreateDto dto);
    void UpdateProduct(int id, ProductForUpdateDto dto);
    void DeleteProduct(int id);
    ProductStatsDto GetStats();
}
