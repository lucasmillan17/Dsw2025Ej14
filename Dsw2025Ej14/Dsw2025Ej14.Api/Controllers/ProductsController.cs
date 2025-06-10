using System.Threading.Tasks;
using Dsw2025Ej14.Api.Data;
using Dsw2025Ej14.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        PersistenciaEnMemoria persistencia;
        ProductsController(PersistenciaEnMemoria _persistencia)
        {
            persistencia = _persistencia;
        }
        [HttpGet("products")]        
        public IActionResult ObtenerProductos()
        {
            var products = persistencia.GetProduct();
            return Ok(products);
        }
        [HttpGet("products/{sku}")]
        public IActionResult BuscarProducto(string sku)
        {
            var product = persistencia.GetProduct(sku);
            return Ok(product);
        }
    }
}
