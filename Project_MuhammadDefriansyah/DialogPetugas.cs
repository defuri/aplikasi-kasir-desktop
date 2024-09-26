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
    public partial class DialogPetugas : Form
    {
        public DialogPetugas()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            style.animasiClose(this);
        }

        public string kondisi;
        public string id;

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (kondisi == "baru")
                {
                    DB.crud($"INSERT INTO `tpetugas` (`idp`, `Nama`, `Alamat`, `Password`, `Hak`) VALUES (NULL, '{textBox1.Text}', '{richTextBox1.Text}', '{textBox2.Text}', '{comboBox1.Text}');");

                }
                else
                {
                    DB.crud($"update tpetugas set nama ='{textBox1.Text}', alamat ='{richTextBox1.Text}', password ='{textBox2.Text}', hak ='{comboBox1.Text}' where idp = '{id}'");

                }
                this.Close();
                FPetugas fp = new FPetugas() { TopLevel = false, TopMost = true };
                KF.untukform(fp, KF.FMenu.panel2);
            }
            catch (Exception pesan)
            {
                MessageBox.Show(pesan.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
;        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("admin");
            comboBox1.Items.Add("petugas");
        }

        private void DialogPetugas_Load(object sender, EventArgs e)
        {
            style.formRounded(15, this);
        }
    }
}
