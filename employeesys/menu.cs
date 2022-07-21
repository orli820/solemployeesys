using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employeesys
{
    public partial class Frmmenu : Form
    {
        public Frmmenu()
        {
            InitializeComponent();
            entrty en = new entrty();
            labhi.Text = en.Userid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labhi.Text = "";
            frmperson P1 = new frmperson();
            P1.TopLevel = false;
            P1.Parent = this.splitContainer1.Panel2;
            P1.Show();
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() != typeof(frmperson) && f.GetType() != typeof(Frmmenu))
                {
                    f.Close();
                    return;
                }
            }


        }

        private void 差勤紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 個人資料管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labhi.Text = "";
            frmperson P1 = new frmperson();
            P1.TopLevel = false;
            P1.Parent = this.splitContainer1.Panel2;
            P1.Show();
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() != typeof(frmperson) && f.GetType() != typeof(Frmmenu))
                {
                    f.Close();
                    return;
                }
            }
        }
    }
}

