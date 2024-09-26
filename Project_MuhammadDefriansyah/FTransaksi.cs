using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_MuhammadDefriansyah
{
    public partial class FTransaksi : Form
    {
        public FTransaksi()
        {
            InitializeComponent();
        }

        public void refreshData()
        {
            DB.crud("SELECT id FROM tmenu");

            foreach (DataRow data in DB.ds.Tables[0].Rows)
            {
                var idValue = data["id"];
                style.SetRoundedBorder(this, $"{idValue}", 15);
            }
        }

        public void keranjang()
        {
            foreach (Control item in flowLayoutPanel2.Controls)
            {
                style.SetRoundedBorder(flowLayoutPanel2, item.Name, 15);
            }
        }

        public void tampilkeranjang()
        {
            lblTotal.Text = "" + 0;
            flowLayoutPanel2.Controls.Clear();
            string idp = KF.flogin.idptg;
            DB.crud($"call ambilkeranjang('{idp}')");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                Image gambar;

                try
                {
                    byte[] imageData = (byte[])baris["pic"];
                    MemoryStream ms = new MemoryStream(imageData);
                    gambar = Image.FromStream(ms);

                }
                catch (Exception)
                {

                    gambar = null;
                }

                string idmenu = baris["id"].ToString();
                string nama = baris["NamaMenu"].ToString();
                string subtotal = baris["subtotal"].ToString();
                string total = baris["total"].ToString();
                lblTotal.Text = total;

                MenuKeranjang MK = new MenuKeranjang();
                MK.Name = idmenu;
                MK.pictureBox1.Image = gambar;
                MK.label1.Text = nama;
                MK.lblTotal.Text = subtotal;
                flowLayoutPanel2.Controls.Add(MK);
            }
        }

        public void tampildata()
        {
            flowLayoutPanel1.Controls.Clear();
            DB.crud("select * from tmenu");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                Image gambar;

                try
                {
                byte[] imageData = (byte[])baris["pic"];
                MemoryStream ms = new MemoryStream(imageData);
                gambar = Image.FromStream(ms);

                }
                catch (Exception)
                {

                    gambar = null;
                }

                FDetailMenu FD = new FDetailMenu();
                FD.Name = baris["id"].ToString();
                Console.WriteLine(baris["id"].ToString());
                FD.pictureBox1.Image = gambar;
                FD.richTextBox1.Text = baris["NamaMenu"].ToString();
                FD.richTextBox2.Text = baris["Keterangan"].ToString();
                FD.label1.Text = baris["Harga_Jual"].ToString();
                flowLayoutPanel1.Controls.Add(FD);
            }
        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int totals = Convert.ToInt32(lblTotal.Text);
                int bayars = Convert.ToInt32(txtBayar.Text);
                int kembali = bayars - totals;
                if(kembali < 0)
                {
                    kembali = 0;
                }
                lblKembali.Text = "" + kembali;

            }
            catch (Exception)
            {
                lblKembali.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idp = KF.flogin.idptg;
            string bayar = txtBayar.Text;
            DB.crud($"call masuktrans('{idp}','{bayar}')");
            DB.crud($"delete from tkeranjang where idp ='{idp}'");
            flowLayoutPanel2.Controls.Clear();
            // tambah omzet
            style.omzet += Convert.ToInt32(lblTotal.Text);
            lblTotal.Text = "0";
            txtBayar.Text = "0";
            lblKembali.Text = "0";

            // jumlah transaksi
            style.totalTransaksi++;
        }

        private void FTransaksi_Load(object sender, EventArgs e)
        {
            style.pnlRounded(20, panel9);

            style.BtnRounded(13, button2);
        }

        private void txtBayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            DB.crud($"select * from tmenu WHERE NamaMenu like '%{textBox1.Text}%'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                Image gambar;

                try
                {
                    byte[] imageData = (byte[])baris["pic"];
                    MemoryStream ms = new MemoryStream(imageData);
                    gambar = Image.FromStream(ms);

                }
                catch (Exception)
                {

                    gambar = null;
                }

                FDetailMenu FD = new FDetailMenu();
                FD.Name = baris["id"].ToString();
                Console.WriteLine(baris["id"].ToString());
                FD.pictureBox1.Image = gambar;
                FD.richTextBox1.Text = baris["NamaMenu"].ToString();
                FD.richTextBox2.Text = baris["Keterangan"].ToString();
                FD.label1.Text = baris["Harga_Jual"].ToString();
                flowLayoutPanel1.Controls.Add(FD);
            }

            foreach (DataRow data in DB.ds.Tables[0].Rows)
            {
                var idValue = data["id"];
                style.SetRoundedBorder(this, $"{idValue}", 15);
            }
        }
    }
}
