using AutoMapper;
using Backend.Data;
using SharedProject.Interface;
using Microsoft.EntityFrameworkCore;
using SharedProject.DTOs;
using SharedProject.Models;

namespace Backend.Repositories
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public RolRepository(DataContext context, IMapper mapper) : base(context)
        {
            _dataContext = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolViewDTO>> FilterGet(string txt)
        {
            var roles = await _dataContext.Roles.Where(x => x.Descripcion.Contains(txt)).ToListAsync();
            return _mapper.Map<List<RolViewDTO>>(roles);
        }
    }
}
