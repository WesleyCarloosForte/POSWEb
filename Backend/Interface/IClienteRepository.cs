using Backend.Interface;
using SharedProject.Models;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<IEnumerable<Cliente>> GetClientesWithData();
    Task<Cliente> GetClientesWithData(int id);
}