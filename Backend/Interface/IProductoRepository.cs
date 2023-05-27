using SharedProject.Models;

namespace Backend.Interface
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetProductosWithData();
        Task<Producto> GetProductosWithData(int id);
        Task<Producto> GetProductosWithDataInStock();
        Task<Producto> GetProductosWithDataInStock(int id);
        Task SumarStock(int id, decimal cantidad);
        Task RestarStock(int id, decimal cantidad);
    }
}
