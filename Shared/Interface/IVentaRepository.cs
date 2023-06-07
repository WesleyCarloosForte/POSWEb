using SharedProject.Interface;
using SharedProject.Models;
namespace SharedProject.Interface
{
    public interface IVentaRepository : IRepository<Venta>
    {
        Task<IEnumerable<Venta>> GetComprasWithData(Func<Venta,bool> action);
        Task<Venta> GetComprasWithData(int id);
        Task AddAsync(Venta venta);

    }
}