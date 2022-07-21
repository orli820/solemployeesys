using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;



namespace employeesys
{
    public partial  class entrty : Form
        
    {
        private void RA()
        {
            Random random = new Random();
            int r1 = random.Next(1000, 9999);
            labra.Text = r1.ToString();
        }

        

        public entrty()
        {
            InitializeComponent();
            RA();

         
    }
        internal string Userid
        {
            get { return txtid.Text; }
            set { txtid.Text = value; }
        }

        //static private string loginusername;

        private void btnen_Click(object sender, EventArgs e)
        {
            //string conn = "server={.};" +
            //    "uid={ID};" +
            //    "pwd={password};" +
            //    "database={dbem}";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbem;Integrated Security=True";
            //try
            //{
                con.Open();
            //}
            //catch (Sql.Data.SqlClient.SqlException ex)
            //{
            //    switch (ex.nuber)
            //    {
            //        case 0:
            //            txthint.Text = "無法連線到資料庫";
            //            break;
            //        case 1045:
            //            txthint.Text = "使用者帳號或密碼錯誤，請再試一次";
            //            break;
            //    }
            //}
            string id = txtid.Text;
            string password = txtpass.Text;
            string SQL = "select *from account where ID in ('" + id + "')and password in ('" + password + "')";
            SqlCommand cmd = new SqlCommand(SQL,con);
            cmd.Connection = con;
            cmd.CommandText = SQL;
            SqlDataReader reader = cmd.ExecuteReader();
            string nn = txtver.Text;

            if (reader.Read())
            {
                txtid.Text = reader["ID"].ToString();
                txtpass.Text = reader["password"].ToString();
                txthint.Text = "";
                if(nn == labra.Text)
                {
                    MessageBox.Show("Welcome,  " + txtid.Text);
                    Frmmenu m = new Frmmenu();
                    m.Show();
                    
                    
                }
                else
                {
                    txthint.Text = "驗證碼錯誤";
                    RA();
                }

            }
            else if(txtver.Text != labra.Text)
            {
                txthint.Text = "驗證碼錯誤";
                txtver.Text = "";
                txtver.Focus();
                RA();
            }
            else 
            {
                txthint.Text = "帳號或密碼錯誤";
                txtid.Text = "";
                txtid.Focus();
                txtpass.Text = "";
                txtver.Text = "";
                RA();
            }
            con.Close();

            #region
            //    string password = txtpass.Text;
            //    string SQL = "select *from account where ID in ('" + id + "')and password in ('" + password + "')";

            //    SqlCommand cmd = new SqlCommand(SQL, con);
            //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //    DataSet datas = new DataSet();
            //    adp.Fill(datas, "info");
            //    DataTable table = datas.Tables["info"];  //判斷帳號是否存在

            //    if (table.Rows.Count >= 1)
            //    {
            //        loginusername = id;
            //        Thread thread = new Thread(new ThreadStart(delegate ()
            //        {
            //          MessageBox.Show("Welcome,  " + txtid.Text);
            //        }));
            //        thread.Start();
            //    }
            //    else
            //    {
            //        txthint.Text = "帳號或密碼錯誤";
            //        txtid.Text = "";
            //        txtid.Focus();
            //        txtpass.Text = "";
            //    }
            #endregion
        }



        private void btncan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbpass_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RA();
        }
    }

        
    
}
