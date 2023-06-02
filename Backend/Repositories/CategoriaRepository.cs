using AutoMapper;
using Backend.Data;
using SharedProject.Interface;
using Microsoft.EntityFrameworkCore;
using SharedProject.DTOs;
using SharedProject.Models;

namespace Backend.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public CategoriaRepository(DataContext context, IMapper mapper) : base(context)
        {
            _dataContext = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaViewDTO>> FilterGet(string txt)
        {
            var categorias =await _dataContext.Categorias.Where(x=>x.Descripcion.Contains(txt)).ToListAsync();
            return _mapper.Map<List<CategoriaViewDTO>>(categorias);
        }
    }
}
