using SharedProject.Models;

namespace SharedProject.Interface
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        Task<IEnumerable<Proveedor>> GetClientesWithData(Func<Proveedor,bool> condiction=null);
        Task<Proveedor> GetClientesWithData(int id);
    }

}