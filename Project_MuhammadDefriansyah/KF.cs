using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Project_MuhammadDefriansyah
{
    class KF
    {
        public static Form1 flogin = new Form1();
        public static FMenu FMenu = new FMenu();

        public static int UtamaX, UtamaY, Lebarform, Tinggiform, LokasiModalX, LokasiModalY;
        static Timer waktu;
        static Form modalnya;
        static Boolean jalan;
        public static void Modal(Form FormUtama, Form modal)
        {
            modalnya = modal;
            modal.ShowInTaskbar = false;
            modal.FormBorderStyle = FormBorderStyle.None;
            modal.Load += (s, e) => animasimodal(modalnya, true);
            Form bg = new Form();
            bg.ShowInTaskbar = false;
            bg.Owner = FormUtama;
            bg.StartPosition = FormStartPosition.Manual;
            bg.FormBorderStyle = FormBorderStyle.None;
            bg.Opacity = .85d;
            bg.BackColor = Color.Black;
            bg.Location = FormUtama.Location;
            modal.Owner = bg;
            UtamaX = FormUtama.Location.X;
            UtamaY = FormUtama.Location.Y;
            Lebarform = FormUtama.Size.Width;
            Tinggiform = FormUtama.Size.Height;
            bg.Size = FormUtama.Size;
            bg.Show();
            modal.ShowDialog();
            bg.Dispose();

        }

        public static void animasimodal(Form modal, Boolean jalankan)
        {
            if (jalankan == true)
            {
                modal.Opacity = 0;
            }
            else
            {
                modal.Opacity = 100;
            }
            jalan = jalankan;
            waktu = new Timer();
            waktu.Enabled = true;
            waktu.Interval = 1;
            waktu.Tick += aksitimer;
            LokasiModalY = UtamaY + Tinggiform / 2 - modal.Height / 2;
            LokasiModalX = UtamaX + Lebarform / 2 - modal.Width / 2;
        }
        private static void aksitimer(object sender, EventArgs e)
        {
            modalanimasi(modalnya, jalan);
        }

        private static void modalanimasi(Form modal, Boolean jalankan)
        {
            if (jalankan == true)
            {
                int lokasiy = UtamaY += 20;
                if (modal.Opacity >= 1)
                {
                    modal.Opacity = 1;
                }
                else
                {
                    modal.Opacity += .05;
                }
                modal.Location = new Point(LokasiModalX, lokasiy);
                if (lokasiy >= LokasiModalY)
                {
                    modal.Opacity = 1;
                    modal.Location = new Point(LokasiModalX, LokasiModalY);
                    waktu.Stop();
                }
            }
            else
            {
                modal.Opacity = 100;
                modal.Location = new Point(LokasiModalX, LokasiModalY);
            }
        }

        public static void untukform(Form panelkontent, Panel kepanel)
        {
            kepanel.Controls.Clear();
            kepanel.Controls.Add(panelkontent);
            panelkontent.FormBorderStyle = FormBorderStyle.None;
            panelkontent.Dock = DockStyle.Fill;
            panelkontent.Show();
        }

    }
}
