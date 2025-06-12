using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api.Interfaces
{
    public interface IPersistenciaEnMemoria
    {
        IEnumerable<Product> GetProduct();
        Product GetProduct(string sku);
        void loadProducts();
    }
}