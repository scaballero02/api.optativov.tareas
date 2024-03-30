using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public bool add(PersonaDTO persona)
        {
            try
            {
                if (_personaRepository.Add(persona))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool update(PersonaDTO persona)
        {
            try
            {
                if (_personaRepository.Update(persona))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool remove(string cedula)
        {
            try
            {
                if (_personaRepository.Remove(cedula))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PersonaDTO get(string id)
        {
            try
            {
                return _personaRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<PersonaDTO> list()
        {
            try
            {
                return _personaRepository.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
