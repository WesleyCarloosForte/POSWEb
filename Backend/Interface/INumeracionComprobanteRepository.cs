using SharedProject.Models;

namespace Backend.Interface
{
    public interface INumeracionComprobanteRepository:IRepository<NumeracionComprobante>
    {
        Task SumarComprobante(int id);
        Task<IEnumerable<NumeracionComprobante>> GetValid();
    }
}
