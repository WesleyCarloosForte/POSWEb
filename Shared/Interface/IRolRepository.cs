using SharedProject.DTOs;
using SharedProject.Models;

namespace SharedProject.Interface
{
    public interface IRolRepository : IRepository<Rol>
    {
        public Task<IEnumerable<RolViewDTO>> FilterGet(string txt);
    }
}
