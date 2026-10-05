
using ABMProductos.Models.DTOs.Requests;
using ABMProductos.Models.DTOs.Responses;
using ABMProductos.Services.Implementations;
using ABMProductos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ABMProductos.Controllers;

[ApiController]
[Route("api/[products]")]

public class ProductsController : ControllerBase
{
    private ProductService _productService = new ProductService();

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        List<ProductForReadDto> productsDto = _productService.GetAllProducts();

        return Ok(productsDto);
    }

    [HttpGet("{id:int}")] 
    public IActionResult GetProductById(int id)
    {
        ProductForReadDto? productsDto = _productService.GetProductById(id);

        return Ok(productsDto);
    }

    [HttpPost]
    public IActionResult Create(ProductForCreateDto productForCreateDto)
    {
        ProductForReadDto? productDto = _productService.CreateProduct(productForCreateDto);

        return Ok(productDto);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id, ProductForUpdateDto productForUpdateDto)
    {
        _productService.UpdateProduct(id, productForUpdateDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]

    public IActionResult DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);

        return NoContent();
    }

    [HttpGet("search")]

    public IActionResult SearchProductByName([FromQuery] string name)
    {
        var product = _productService.SearchProductsByName(name);

        return Ok(product);

    }

    [HttpGet("stats")]
    public IActionResult GetStats()
    {
        var stats = _productService.GetStats();
        return Ok(stats);
    }
}
