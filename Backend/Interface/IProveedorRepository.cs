using SharedProject.Models;

namespace Backend.Interface
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        Task<IEnumerable<Proveedor>> GetClientesWithData();
        Task<Proveedor> GetClientesWithData(int id);
    }

}