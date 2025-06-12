using System.Threading.Tasks;
using Dsw2025Ej14.Api.Data;
using Dsw2025Ej14.Api.Domain;
using Dsw2025Ej14.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        private IPersistenciaEnMemoria _persistencia;
        public ProductsController(IPersistenciaEnMemoria persistencia)
        {
            _persistencia = persistencia;
        }
        [HttpGet("products")]        
        public IActionResult ObtenerProductos()
        {
            try
            {
                var products = _persistencia.GetProduct();
                return Ok(products);
            }
            catch (Exception ex) {
                return StatusCode(204);
            }
            
        }
        [HttpGet("products/{sku}")]
        public IActionResult BuscarProducto(string sku)
        {
            try
            {
                var product = _persistencia.GetProduct(sku);
                return Ok(product);
            }
            catch (Exception ex) {
                return StatusCode(404);
            }
            
        }
    }
}
