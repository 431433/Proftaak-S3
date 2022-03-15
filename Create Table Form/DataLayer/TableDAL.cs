using MySql.Data;
using MySql.Data.MySqlClient;
using InterfaceLayer.Interfaces;
using InterfaceLayer.DTO_s;

namespace DataLayer
{

    public class TableDAL : ITable
    {
        private string connectionString = "server=localhost;user=root;database=test;port=3306;password='';SslMode=none";
        MySqlConnection connection;
        string query = "";

        private List<string> types;
        public TableDAL()
        {
            types = new List<string>();
            types.Add("text");
            types.Add("int");
            types.Add("boolean");
            
            
            connection = new MySqlConnection(connectionString);
        }

        public int CreateTable(TableDTO table)
        {
            try
            {
                connection.Open();
                string query = $" CREATE TABLE {table.Name} (id int, name text";
                foreach(RowDTO row in table.Rows)
                {
                    if (types.Contains(row.Type))
                    {
                        query += $", {row.Name} {row.Type} ";
                    }
                }
                query += ")";
                var cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int EditTable(TableDTO tableDTO)
        {
            throw new NotImplementedException();
        }

        public TableDTO GetTabbleByName(string name)
        {
            TableDTO tableDTO = new TableDTO();
            tableDTO.Name = name;
            tableDTO.Rows = new List<RowDTO>();
            try
            {
                connection.Open();
                query = "SELECT COLUMN_NAME, COLUMN_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = @name";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("name", name);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tableDTO.Rows.Add(new RowDTO() { Name = reader.GetString(0), Type = reader.GetString(1) });
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Shit");
            }
            return tableDTO;
        }


    }
}