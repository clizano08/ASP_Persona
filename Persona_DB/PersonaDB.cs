using Persona_DB.Conexion;
using Persona_EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona_DB
{
  public class PersonaDB
    {
        public Persona GetPersonaById(string pId)
        {

            try
            {
                using (DBPersona gDatos = new DBPersona())
                {
                    Persona persona = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetPersonaById";
                    command.Parameters.AddWithValue("@Id", pId);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        persona = new Persona
                        {
                            Id = dataReader.GetString(0),
                            Nombre = dataReader.GetString(1),
                            Correo = dataReader.GetString(2),
                            Telefono = dataReader.GetString(3),
                            Nacimiento = dataReader.GetDateTime(4)

                        };

                    }
                    dataReader.Close();
                    return persona;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<Persona> GetAllPersona()
        {

            try
            {
                using (DBPersona gDatos = new DBPersona())
                {

                    Persona persona = null;
                    List<Persona> personas = new List<Persona>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAllPersona";

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        persona = new Persona
                        {
                            Id = dataReader.GetString(0),
                            Nombre = dataReader.GetString(1),
                            Correo = dataReader.GetString(2),
                            Telefono = dataReader.GetString(3),
                            Nacimiento = dataReader.GetDateTime(4)

                        };
                        personas.Add(persona);
                    }
                    dataReader.Close();
                    return personas;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Persona InsertPersona(Persona pPersona)
        {


            try
            {
                using (DBPersona gDatos = new DBPersona())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spInsertPersona";
                    command.Parameters.AddWithValue("@Id", pPersona.Id);
                    command.Parameters.AddWithValue("@Nombre", pPersona.Nombre);
                    command.Parameters.AddWithValue("@Correo", pPersona.Correo);
                    command.Parameters.AddWithValue("@Telefono", pPersona.Telefono);
                    command.Parameters.AddWithValue("@Nacimiento", pPersona.Nacimiento);
              

                    gDatos.ExecuteNonQuery(ref command);
                }
                Persona persona = GetPersonaById(pPersona.Id);
                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Persona UpdatePersona(Persona pPersona)
        {

            try
            {
                using (DBPersona gDatos = new DBPersona())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdatePersona";
                    command.Parameters.AddWithValue("@Id", pPersona.Id);
                    command.Parameters.AddWithValue("@Nombre", pPersona.Nombre);
                    command.Parameters.AddWithValue("@Correo", pPersona.Correo);
                    command.Parameters.AddWithValue("@Telefono", pPersona.Telefono);
                    command.Parameters.AddWithValue("@Nacimiento", pPersona.Nacimiento);

                    gDatos.ExecuteNonQuery(ref command);

                    Persona persona = GetPersonaById(pPersona.Id);
                    return persona;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool DeletePersona(string pId)
        {
            bool deleted = false;
            try
            {
                using (DBPersona gDatos = new DBPersona())
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeletePersona";
                    command.Parameters.AddWithValue("@Id", pId);


                    gDatos.ExecuteNonQuery(ref command);

                    if (this.GetPersonaById(pId) == null)
                    {
                        deleted = true;
                    }

                    return deleted;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
