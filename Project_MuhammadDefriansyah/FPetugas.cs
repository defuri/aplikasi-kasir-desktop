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
    public partial class FPetugas : Form
    {
        public FPetugas()
        {
            InitializeComponent();
        }

        public void tampildatapetugas()
        {
            dgv1.Rows.Clear();
            DB.crud($"select * from tpetugas");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                String idp = baris["idp"].ToString();
                String nm = baris["nama"].ToString();
                String alamat = baris["alamat"].ToString();
                String hak = baris["hak"].ToString();
                dgv1.Rows.Add(idp, nm, alamat, hak);
            }
        }


        private void FPetugas_Load(object sender, EventArgs e)
        {
            tampildatapetugas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogPetugas dp = new DialogPetugas();
            dp.kondisi = "baru";
            dp.label1.Text = "Registrasi Petugas Baru";
            KF.Modal(KF.FMenu, dp);
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            int baris = dgv1.CurrentCell.RowIndex;
            int kolom = dgv1.CurrentCell.ColumnIndex;
            string idpnya = dgv1.Rows[baris].Cells[0].Value.ToString();

            if (baris == null)
            {
                baris = 1;
            }
            if (kolom == 4)
            {
                try
                {
                    DialogPetugas dp = new DialogPetugas();
                    dp.label1.Text = "Ubah Data Petugas";
                    dp.kondisi = "ubah";
                    dp.id = idpnya;
                    DB.crud($"select * from tpetugas where idp ='{idpnya}'");
                    foreach (DataRow data in DB.ds.Tables[0].Rows)
                    {
                        dp.textBox1.Text = data["nama"].ToString();
                        dp.richTextBox1.Text = data["alamat"].ToString();
                        dp.textBox2.Text = data["password"].ToString();
                        dp.comboBox1.Text = data["hak"].ToString();
                    }
                    KF.Modal(KF.FMenu, dp);
                }
                catch (Exception pesan)
                {
                    MessageBox.Show(pesan.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if( kolom == 5)
            {
                try
                {
                    DB.crud($"delete from tpetugas where idp = '{idpnya}'");
                    tampildatapetugas();
                }
                catch (Exception pesan)
                {
                    MessageBox.Show(pesan.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void search()
        {
            dgv1.Rows.Clear();
            DB.crud($"select * from tpetugas where Nama like '%{textBox1.Text}%'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                String idp = baris["idp"].ToString();
                String nm = baris["nama"].ToString();
                String alamat = baris["alamat"].ToString();
                String hak = baris["hak"].ToString();
                dgv1.Rows.Add(idp, nm, alamat, hak);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
