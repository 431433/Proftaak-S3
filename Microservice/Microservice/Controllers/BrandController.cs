using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Microservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private string connectionstring;
        private string query;
        private string password;
        private MySqlConnection connection;

        public BrandController()
        {
            query = "";
            connectionstring = "server=sql11.freemysqlhosting.net;user=sql11482087;database=sql11482087;port=3306;password='xrxtmewYrj';SslMode=none";
            //connectionstring = $"Server=studmysql01.fhict.local;Uid=dbi437675;Database=dbi437675;Pwd={password};";
            connection = new MySqlConnection(connectionstring);
        }


        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            List<Brand> brands = new List<Brand>();
            try
            {
                connection.Open();
                query = "SELECT brands.Id, brands.Name, country.English FROM brands INNER JOIN country ON brands.Country = country.Id;";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Brand brand = new Brand();
                    brand.Id = reader.GetInt32(0);
                    brand.Name = reader.GetString(1);
                    brand.Country = reader.GetString(2);
                    brands.Add(brand);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return brands;

        }
    }
}
