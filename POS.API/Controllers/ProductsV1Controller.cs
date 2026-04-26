using Microsoft.AspNetCore.Mvc;

namespace POS.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsV1Controller : ControllerBase
{
    // GET api/v1/products
    [HttpGet]
    public IActionResult Get()
    {
        var result = new
        {
            Version = "1.0",
            Products = new[]
            {
                new { Id = 1, Name = "Classic Coffee" }
            }
        };

        return Ok(result);
    }
}