using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
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
