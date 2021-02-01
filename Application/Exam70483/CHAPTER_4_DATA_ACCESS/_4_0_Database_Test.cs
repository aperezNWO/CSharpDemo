using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _4_DataAccess
{
    public class _4_0_Database_Test
    {
        public static void Run(string[] args)
        {
            //
            _4_0_Database_Test.ConnectionTest(args);
            //
        }
        public static void ConnectionTest(string[] args)
        {
            //
            Console.WriteLine("[Read Data with SQL] - [Listing 4-19/20]");
            //
            Console.WriteLine("[Update data in a Database] - [Listing 4-21]");
            //
            Console.WriteLine("[Sql Injection and Database Commands] - [Listing 4-22/23]");
            //
            try
            {
                //
                string connectionString    = ConfigurationManager.ConnectionStrings["Exam70483"].ConnectionString;
                string cmdText             = string.Format(@"Select T.Id, T.Name from [Table] T {0}",(args.Length > 0) ? "where [Name] = @Name" : string.Empty);
                //
                SqlConnection cn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(cmdText, cn);
                //
                if (args.Length > 0)
                {
                    cmd.Parameters.AddWithValue("@name", args[0]);
                }
                //
                cn.Open();
                //
                Console.WriteLine("Openning the database : {0}", cn.Database);
                //
                SqlDataReader reader = cmd.ExecuteReader();
                int recordCount      = 0;
                //
                while (reader.Read())
                {
                    recordCount++;
                    Console.WriteLine(" Id : {0}, Name : {1}",reader["Id"], reader["Name"]);
                }
                //
                reader.Close();
                //
                cn.Close();
                //
                if (recordCount == 0) 
                {
                    Console.WriteLine(" No se encontraron registros");
                }
                //
                Console.WriteLine("Closing the database : {0}", cn.Database);
                //
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error : {0}",ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
