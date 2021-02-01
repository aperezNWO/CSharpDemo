using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using _4_DataAccess;
using Newtonsoft.Json;

namespace _4_DataAccess
{
    public class Skill_4_2_Consume_Data
    {
        #region "Entities"
        //
        public class ImageOfDay
        {
            public string date { get; set; }
            public string explanation { get; set; }
            public string hdurl { get; set; }
            public string media_type { get; set; }
            public string service_version { get; set; }
            public string title { get; set; }
            public string url { get; set; }
        }
        #endregion

        #region "Auxiliares"
        static string readWebpage(string uri)
        {
            //
            WebClient client = new WebClient();
            //
            return client.DownloadString(uri);
        }
        //
        static ImageOfDay GetImageOfDay(string imageURL)
        {
            //
            string NASAJson = readWebpage(imageURL);
            //
            ImageOfDay result = JsonConvert.DeserializeObject<ImageOfDay>(NASAJson);
            //
            return result;
        }
        //
        #endregion

        #region "Principales"
        // 1.
        public static void ReadWithSqlTest(string[] args)
        {
            //
            Console.WriteLine("[SQL OPERATIONS] - [Listing 4-19,20,21,22,23]");
            //
            _4_0_Database_Test.Run(args);
        }
        // 2.
        internal static async Task AsyncDatabaseTest()
        {
            //
            Console.WriteLine("[Asynchronous Database Access] - [Listing 4-24]");
            //
            string connectionString = ConfigurationManager.ConnectionStrings["Exam70483"].ConnectionString;
            StringBuilder databaseList = new StringBuilder();
            string list = string.Empty;
            //
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //
                connection.Open();
                //
                SqlCommand command = new SqlCommand(@"SELECT * FROM [Table]", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                int recordCount = 0;
                //
                while (await reader.ReadAsync())
                {
                    string separator = (recordCount > 0) ? @"|" : string.Empty;
                    string id = reader["Id"].ToString();
                    string name = reader["Name"].ToString();
                    string row = string.Format("[ID    :  {0}]   " +
                                                     "[Name  :  {1}]{2}", id, name, separator);
                    databaseList.AppendLine(row);
                }
                //
                connection.Close();
                //
            }
            //
            list = databaseList.ToString();
            //
            Console.WriteLine(@"Result of Async Query :{0}{1}", System.Environment.NewLine, list);
            //
        }
        // 3
        public static ImageOfDay JsonTest()
        {
            //
            Console.WriteLine("[Listing 4-25] - [Consume JSON Data]");
            //
            ImageOfDay imageOfDay = GetImageOfDay(
                "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date=2018-05-29");
            //
            if (imageOfDay.media_type != "image")
            {
                imageOfDay.title = "It is not an image today";
            }
            //
            return imageOfDay;
        }

        #endregion
    }
}
