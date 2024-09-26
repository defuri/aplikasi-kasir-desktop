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
    public partial class FDetailMenu : UserControl
    {
        public FDetailMenu()
        {
            InitializeComponent();
        }

        private void FDetailMenu_Click(object sender, EventArgs e)
        {
            ModalMenu munculkan = new ModalMenu();
            KF.Modal(KF.FMenu, munculkan);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ModalMenu MM = new ModalMenu();
            //MM.label1.Text = this.richTextBox1.Text;
            //MM.label1.Text = this.Name;
            DB.crud("Select * from tmenu where id= '"+this.Name+"'");
            foreach ( DataRow baris in DB.ds.Tables[0].Rows)
            {
                MM.label1.Text = baris["NamaMenu"].ToString();
                MM.richTextBox1.Text = baris["Keterangan"].ToString();
                MM.txtHarga.Text = baris["Harga_Jual"].ToString();
                MM.hargamenu = (int)baris["Harga_Jual"];

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

                MM.Name = baris["id"].ToString();
                MM.pictureBox1.Image = gambar;
                KF.Modal(KF.FMenu, MM);
            }
        }
    }
}
