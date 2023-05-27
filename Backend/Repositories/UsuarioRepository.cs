using Backend.Data;
using SharedProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UsuarioRepository : Repository<Usuario>,IUsuarioRepository
    {
       private readonly DataContext _context;
    public UsuarioRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetClientesWithData()
    {
        var a = await _context.Usuarios
            .Include(c => c.DatosGenerales)
            .ThenInclude(dg => dg.Documento)
            .ToListAsync();
        return a;
    }

    public async Task<Usuario> GetClientesWithData(int id)
    {
        return await _context.Usuarios
            .Include(c => c.DatosGenerales)
            .ThenInclude(dg => dg.Documento)
             .Where(x => x.Id == id)
             .FirstOrDefaultAsync();
    }

    }

}
