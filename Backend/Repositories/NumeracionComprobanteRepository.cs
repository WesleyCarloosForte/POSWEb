using Backend.Data;
using SharedProject.Interface;
using SharedProject.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Backend.Repositories
{
    public class NumeracionComprobanteRepository : Repository<NumeracionComprobante>,INumeracionComprobanteRepository
    {
        private IMapper _mapper;
        private readonly DataContext _context;
        public NumeracionComprobanteRepository(DataContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context= context;
        }
        public async Task<IEnumerable<NumeracionComprobante>> GetValid()
        {
            return await _context.NumeracionComprobantes.Where(x => x.FinVigencia >= DateTime.Now.Date && x.NumeroActual <= x.NumeroFinal).ToListAsync();
        }

       public async Task SumarComprobante(int id)
        {
            var value = await _context.NumeracionComprobantes.FirstOrDefaultAsync(x => x.Id == id);
            if (value != null)
            {
                value.NumeroActual += 1;
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NumeracionComprobante>> FilterGet(string txt)
        {
            return await _context.NumeracionComprobantes.Where(x=>x.Descripcion.Contains(txt)).ToListAsync();
        }
    }
}
