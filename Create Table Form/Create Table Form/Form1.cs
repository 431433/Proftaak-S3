using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Create_Table_Form
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;user=root;database=test;port=3306;password='';SslMode=none";
        MySqlConnection connection;
        public Form1()
        {
            connection = new MySqlConnection(connectionString);
            InitializeComponent();
            comboBox1.Items.Add("Boolean");
            comboBox1.Items.Add("Text");
            comboBox1.Items.Add("Int");
            comboBox2.Items.Add("Boolean");
            comboBox2.Items.Add("Text");
            comboBox2.Items.Add("Int");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = $" CREATE TABLE {textBox6.Text}  ({textBox1.Text} {comboBox1.SelectedItem},  {textBox2.Text} {comboBox2.SelectedItem}";
                query += ")";
                var cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
            return;
        }

        private void gb2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
