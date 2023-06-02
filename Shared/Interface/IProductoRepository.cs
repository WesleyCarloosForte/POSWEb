using SharedProject.Models;

namespace SharedProject.Interface
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetProductosWithDataFilter(Func<Producto,bool> condiction =null);
        Task<Producto> GetProductoWithData(int id);
        Task<Producto> GetProductoWithDataInStock(Func<Producto, bool> condiction = null);
        Task<Producto> GetProductosWithDataInStock(int id);
        Task SumarStock(int id, decimal cantidad);
        Task RestarStock(int id, decimal cantidad);
    }
}
