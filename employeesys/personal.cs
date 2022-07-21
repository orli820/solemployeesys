using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employeesys
{
    public partial class frmperson : Form

    {
        public frmperson()
        {
            InitializeComponent();            
        }
        List<int> pks = new List<int>();
        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbem;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select*from employee";
            SqlDataReader reader = cmd.ExecuteReader();
                        
            while (reader.Read())
            {
                pks.Add((int)reader["employee id"]);
                //listBox1.Items.Add(reader["fName"].ToString());
            }

            con.Close();
        }
    }
}
