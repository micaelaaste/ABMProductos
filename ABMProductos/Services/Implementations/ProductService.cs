namespace ABMProductos.Services.Implementations;

using ABMProductos.Models.DTOs.Requests;
using ABMProductos.Models.DTOs.Responses;
using ABMProductos.Repositories.Implementations;
using ABMProductos.Services.Interfaces;
public class ProductService : IProductService
{
    private ProductRepository productRepository = new ProductRepository();

    public ProductForReadDto? GetProductById(int id)
    {
        Product? product = productRepository.GetProductById(id);

        if (product != null)
        {
            ProductForReadDto productDto = new ProductForReadDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };

            return productDto;
        }

        return null;
    }

    public List<ProductForReadDto> GetAllProducts()
    {
        List<Product> products = productRepository.GetAllProducts();

        List<ProductForReadDto> listProductDto = products.Select(p => new ProductForReadDto()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
        }).ToList();

        return listProductDto;
    }

    public ProductForReadDto CreateProduct(ProductForCreateDto dto)
    {
        var id = productRepository.GetAllProducts().Max(p => p.Id) + 1;
        Product? product = new Product()
        {
            Id = id,
            Name = dto.Name,
            Price = dto.Price
        };

        productRepository.AddProduct(product);

        return new ProductForReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    public void UpdateProduct(int id, ProductForUpdateDto dto)
    {
        Product? product = new Product()
        {
            Id = id,
            Name = dto.Name,
            Price = dto.Price
        };
        productRepository.UpdateProduct(product);
    }
    public void DeleteProduct(int id)
    {
        Product? product = productRepository.GetProductById(id);
        if (product != null)
        {
            productRepository.DeleteProduct(product);
        }
    }

    public List<ProductForReadDto> SearchProductsByName(string name)
    {
        List<Product> ? product = productRepository.SearchProductsByName(name);

        return product.Select(p => new ProductForReadDto()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
        }).ToList();
    }
    public ProductStatsDto GetStats()
    {
        List<Product> products = productRepository.GetAllProducts();

        if (!products.Any())
        {
            return new ProductStatsDto
            {
                Total = 0,
                AveragePrice = 0,
                MostExpensiveName = string.Empty
            };
        }

        var mostExpensive = products.OrderByDescending(p => p.Price).First();

        return new ProductStatsDto
        {
            Total = products.Count(),
            AveragePrice = products.Average(p => p.Price),
            MostExpensiveName = mostExpensive.Name
        };
    }
}
