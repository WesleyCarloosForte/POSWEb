using SharedProject.DTOs;

namespace SharedProject.Interface
{
    public interface IDocumentoRepository:IRepository<SharedProject.Models.Documento>
    {
        public Task<IEnumerable<DocumentoViewDTO>> FilterGet(string txt);
    }
}
