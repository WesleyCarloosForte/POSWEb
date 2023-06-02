using SharedProject.Interface;
using SharedProject.Models;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<IEnumerable<Cliente>> GetClientesWithData(Func<Cliente, bool> condition = null);
    Task<Cliente> GetClientesWithData(int id);
}