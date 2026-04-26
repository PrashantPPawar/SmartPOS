using Microsoft.AspNetCore.Mvc;

namespace POS.API.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsV2Controller : ControllerBase
{
    // GET api/v2/products
    [HttpGet]
    public IActionResult Get()
    {
        var result = new
        {
            Version = "2.0",
            Products = new[]
            {
                new { Id = 1, Name = "Classic Coffee", Price = 2.99m },
                new { Id = 2, Name = "Espresso", Price = 1.99m }
            }
        };

        return Ok(result);
    }

    // Example: a new v2-only endpoint
    // GET api/v2/products/summary
    [HttpGet("summary")]
    public IActionResult GetSummary()
    {
        var summary = new
        {
            Version = "2.0",
            TotalProducts = 2,
            Cheapest = "Espresso"
        };

        return Ok(summary);
    }
}