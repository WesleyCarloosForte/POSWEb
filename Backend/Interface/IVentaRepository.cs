using Backend.Interface;
using SharedProject.Models;
namespace Backend.Interface
{
    public interface IVentaRepository : IRepository<Venta>
    {
        Task<IEnumerable<Venta>> GetComprasWithData();
        Task<Venta> GetComprasWithData(int id);

    }
}