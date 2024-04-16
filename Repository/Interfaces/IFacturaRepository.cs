using Repository.Modelos;

namespace Repository.Interfaces
{
    public interface IFacturaRepository
    {
        bool Add(FacturaDTO factura);
        bool Remove(int id);
        bool Update(FacturaDTO factura);
        FacturaDTO Get(int id);
        IEnumerable<FacturaDTO> List();
    }
}
