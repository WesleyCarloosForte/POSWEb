using SharedProject.DTOs;
using SharedProject.Interface;
using SharedProject.Models;


    public interface ICompraRepository : IRepository<Compra>
    {
    Task<IEnumerable<Compra>> GetComprasWithData(Func<Compra, bool> action);
        Task AddAsync(Compra compra);
        Task<Compra> GetComprasWithData(int id);
    }