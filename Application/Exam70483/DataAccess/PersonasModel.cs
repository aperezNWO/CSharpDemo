using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Exam70483Web.Models.Entity;

namespace Exam70483Library.DataAccess
{
    public class PersonasModel
    {
        #region "Campos"
        private static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        #endregion

        #region "Metodos"   
        //
        public static string Build_6_Tsql_SelectPersona()
        {
            return @"   SELECT 
                             Id_Column
                            ,[NombreCompleto]
                            ,[ProfesionOficio]
                        FROM
                            [dbo].[Persona]
                        ORDER BY 
                            Id_Column ";
        }
        //
        public static List<PersonaEntity> Submit_6_Tsql_SelectPersona(SqlConnection connection)
        {
            //
            string tsql = Build_6_Tsql_SelectPersona();
            //
            List<PersonaEntity> ObjCustomer = new List<PersonaEntity>();

            using (var command = new SqlCommand(tsql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //
                        string id              = Convert.ToString(reader["ID_Column"]);
                        string nombreCompleto  = (string)reader["NombreCompleto"];
                        string profesionOficio = (string)reader["ProfesionOficio"];
                        //
                        PersonaEntity Obj      = new PersonaEntity();
                        //
                        Obj.ID = id;
                        Obj.NombreCompleto = nombreCompleto;
                        Obj.ProfesionOficio = profesionOficio;
                        //
                        ObjCustomer.Add(Obj);

                    }
                }
            }
            return ObjCustomer;
        }
        //
        public static DataTable           ListadoPersonasDataTable()
        {
            //
            string tsql              = Build_6_Tsql_SelectPersona();
            //
            DataTable maestroListado = new DataTable();
            //
            try
            {
                //
                using (var connection = new SqlConnection(constring))
                {
                    using (var command = new SqlCommand(tsql, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(maestroListado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //
            return maestroListado;
        }

        public static List<PersonaEntity> ListadoPersonas()
        {
              //
              List<PersonaEntity> listPersona = new List<PersonaEntity>();
              //
              try
              {
                  //
                  using (var connection = new SqlConnection(constring))
                  {
                      //
                      connection.Open();
                      //
                      listPersona = PersonasModel.Submit_6_Tsql_SelectPersona(connection);
                  }
                  //
                  return listPersona;
              }
              catch (SqlException e)
              {
                  throw e;
              }
          }
        #endregion
    }
}
