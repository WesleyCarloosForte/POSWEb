using SharedProject.DTOs;
using SharedProject.Models;

namespace SharedProject.Interface
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        public Task<IEnumerable<CategoriaViewDTO>> FilterGet(string txt);
    }
}
