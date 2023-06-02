using AutoMapper;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using SharedProject.DTOs;
using SharedProject.Interface;
using SharedProject.Models;

namespace Backend.Repositories
{
    public class DocumentoRepository : Repository<Documento>, IDocumentoRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public DocumentoRepository(DataContext context, IMapper mapper) : base(context)
        {
            _dataContext = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DocumentoViewDTO>> FilterGet(string txt)
        {
            var documentos = await _dataContext.Documentos.Where(x => x.Descripcion.Contains(txt)).Take(100).ToListAsync();
            return _mapper.Map<List<DocumentoViewDTO>>(documentos);
        }

    }
}
