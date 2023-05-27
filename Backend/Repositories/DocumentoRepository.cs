using Backend.Data;
using Backend.Interface;

namespace Backend.Repositories
{
    public class DocumentoRepository : Repository<SharedProject.Models.Documento>, IDocumentoRepository
    {
        public DocumentoRepository(DataContext context) : base(context)
        {
        }
    }
}
