using SharedProject.Interface;
using SharedProject.Models;


    public interface ICompraRepository : IRepository<Compra>
    {
        Task<IEnumerable<Compra>> GetComprasWithData();
        Task<Compra> GetComprasWithData(int id);
    }