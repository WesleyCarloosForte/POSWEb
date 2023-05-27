using Backend.Data;
using Backend.Interface;
using SharedProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class NumeracionComprobanteRepository : Repository<NumeracionComprobante>,INumeracionComprobanteRepository
    {
        private readonly DataContext _context;
        public NumeracionComprobanteRepository(DataContext context) : base(context)
        {
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
    }
}
