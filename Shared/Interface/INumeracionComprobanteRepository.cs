using SharedProject.DTOs;
using SharedProject.Models;

namespace SharedProject.Interface
{
    public interface INumeracionComprobanteRepository:IRepository<NumeracionComprobante>
    {
        Task SumarComprobante(int id);
        Task<IEnumerable<NumeracionComprobante>> GetValid();
        public Task<IEnumerable<NumeracionComprobante>> FilterGet(string txt);
    }
}
