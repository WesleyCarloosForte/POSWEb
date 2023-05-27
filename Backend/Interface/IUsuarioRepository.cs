using Backend.Interface;
using SharedProject.Models;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<IEnumerable<Usuario>> GetClientesWithData();
    Task<Usuario> GetClientesWithData(int id);
}
