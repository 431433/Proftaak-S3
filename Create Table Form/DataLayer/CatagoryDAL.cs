using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;
namespace DataLayer
{
    internal class CatagoryDAL
    {
        private string connectionString = "server=localhost;user=root;database=test;port=3306;password='';SslMode=none";
        MySqlConnection connection;
        string query = "";

        private List<string> types;
        public CatagoryDAL()
        {
            types = new List<string>();
            types.Add("text");
            types.Add("int");
            types.Add("boolean");


            connection = new MySqlConnection(connectionString);
        }

        public CatagoryDTO GetCatagoryByName(string name)
        {
            CatagoryDTO catagoryDTO = new CatagoryDTO();
            try
            {
                connection.Open();
                query = $"SELECT * FROM `catagory` WHERE name = '{name}'";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    catagoryDTO.Name = reader.GetString(reader.GetOrdinal("name"));
                    catagoryDTO.Id = reader.GetInt32(reader.GetOrdinal("id"));
                }
                connection.Close();
            }
            catch
            {

            }
            return catagoryDTO;
        }
    }
}
