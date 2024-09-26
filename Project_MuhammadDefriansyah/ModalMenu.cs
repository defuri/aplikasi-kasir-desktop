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
    public partial class ModalMenu : Form
    {
        public ModalMenu()
        {
            InitializeComponent();
        }
        public int hargamenu;


        private void label2_Click(object sender, EventArgs e)
        {
            style.animasiClose(this);
        }

        public int konter = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            konter++;
            textBox1.Text = "" + konter;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (konter > 1)
            {
                konter--;
                textBox1.Text = "" + konter;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                konter = Convert.ToInt32(textBox1.Text);
                    if (konter < 1)
                    {
                        konter = 1;
                        textBox1.Text = "" + konter;
                    }

            }
            catch (Exception)
            {

                konter = 1;
            }
            txtHarga.Text = "" + konter * hargamenu;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idp = KF.flogin.idptg;
            string idm = this.Name;
            string qty = textBox1.Text;
            DB.crud($"call MasukKeranjang('{idp}','{idm} ','{qty} ')");

            //MenuKeranjang MK = new MenuKeranjang();
            //KF.FMenu.ft.flowLayoutPanel2.Controls.Add(MK);
            KF.FMenu.ft.tampilkeranjang();
            KF.FMenu.ft.keranjang();
            style.animasiClose(this);
            //MessageBox.Show(this.Name);
        }
    }
}
