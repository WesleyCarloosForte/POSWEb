using SharedProject.Interface;
using SharedProject.Models;
namespace SharedProject.Interface
{
    public interface IVentaRepository : IRepository<Venta>
    {
        Task<IEnumerable<Venta>> GetComprasWithData();
        Task<Venta> GetComprasWithData(int id);
        Task AddAsync(Venta venta);

    }
}