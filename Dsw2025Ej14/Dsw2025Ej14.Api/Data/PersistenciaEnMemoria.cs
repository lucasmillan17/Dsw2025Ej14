using Dsw2025Ej14.Api.Domain;
using Dsw2025Ej14.Api.Interfaces;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Dsw2025Ej14.Api.Data
{
    public class PersistenciaEnMemoria : IPersistenciaEnMemoria
    {
        private List<Product>? _products = [];
        public PersistenciaEnMemoria()
        {
            loadProducts();
        }
        public void loadProducts()
        {
            var json = File.ReadAllText("products.json");
            _products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            }) ?? [];
        }

        public Product GetProduct(string sku)
        {
            return _products?.Find(p => p.Sku == sku);
        }
        public IEnumerable<Product>? GetProduct()
        {
            return _products?.Where(p => p.IsActive) ?? Enumerable.Empty<Product>();
        }
    }
}
