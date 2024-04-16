
using Repository.Modelos;

namespace Repository.Interfaces
{
    public interface IPersonaRepository
    {
        bool Add(PersonaDTO persona);
        bool Remove(string cedula);
        bool Update(PersonaDTO persona);
        PersonaDTO Get(string id);
        IEnumerable<PersonaDTO> List();
    }
}
