using Persona_DB;
using Persona_EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona_LN
{
    public class PersonaLN
    {
        public Persona GetPersonaById(string pId)
        {
            PersonaDB personaDB = new PersonaDB();
            Persona persona = personaDB.GetPersonaById(pId);
            if (persona != null)
            {
                persona.Edad = this.CalculateAge(persona);
            }            
            return persona;
        }
        public List<Persona> GetAllPersona()
        {
            PersonaDB personaDB = new PersonaDB();
            return personaDB.GetAllPersona();
        }
        public Persona InsertPersona(Persona pPersona)
        {
            PersonaDB personaDB = new PersonaDB();
            return personaDB.InsertPersona(pPersona);
        }
        public Persona UpdatePersona(Persona pPersona)
        {
            PersonaDB personaDB = new PersonaDB();
            return personaDB.UpdatePersona(pPersona);
        }
        public bool DeletePersona(string pId)
        {
            PersonaDB personaDB = new PersonaDB();
            return personaDB.DeletePersona(pId);
        }
        public Persona SavePersona(Persona pPersona)
        {
            PersonaDB personaDB = new PersonaDB();
            Persona persona = new Persona();
            if (this.GetPersonaById(pPersona.Id) != null)
            {
                persona = personaDB.UpdatePersona(pPersona);
            }
            else
            {
                persona = personaDB.InsertPersona(pPersona);
            }
            return persona;
        }
        public string CalculateAge(Persona persona)
        {
            // Crear fechas
            DateTime nacimiento = persona.Nacimiento;
            DateTime hoy = DateTime.Now;

            // Años
            int edadAnos = hoy.Year - nacimiento.Year;
            if (hoy.Month < nacimiento.Month || (hoy.Month == nacimiento.Month &&
            hoy.Day < nacimiento.Day))
                edadAnos--;

            // Meses
            int edadMeses = hoy.Month - nacimiento.Month;
            if (hoy.Day < nacimiento.Day)
                edadMeses--;
            if (edadMeses < 0)
                edadMeses += 12;

            return edadAnos.ToString() + " Años y " + edadMeses.ToString()+" Meses";
        }
    }
}
