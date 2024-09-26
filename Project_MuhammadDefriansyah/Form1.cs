using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_MuhammadDefriansyah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DB.crud("select * from tmenu");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public string idptg, namaptg;

        private void Form1_Load(object sender, EventArgs e)
        {
            style.pnlRounded(30, panel1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            } else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            DB.crud($"select * from tpetugas where idp = '{user}' and Password = '{password}'");
            int data = DB.ds.Tables[0].Rows.Count;
            if (data == 1)
            {
                DataRow baris = DB.ds.Tables[0].Rows[0];
                namaptg = baris["Nama"].ToString();
                idptg = baris["idp"].ToString();
                KF.FMenu.Visible = true;
                this.Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show(this, "User / Password salah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
