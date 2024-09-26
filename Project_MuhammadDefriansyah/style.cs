using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_MuhammadDefriansyah
{
    class style
    {
        public static int totalTransaksi = 0,
            omzet = 0;


        // ini untuk panel rounded
        public static void pnlRounded(int radius, Panel panel)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddLine(radius, 0, panel.Width - radius, 0);
            path.AddArc(new Rectangle(panel.Width - radius, 0, radius, radius), 270, 90);
            path.AddLine(panel.Width, radius, panel.Width, panel.Height - radius);
            path.AddArc(new Rectangle(panel.Width - radius, panel.Height - radius, radius, radius), 0, 90);
            path.AddLine(panel.Width - radius, panel.Height, radius, panel.Height);
            path.AddArc(new Rectangle(0, panel.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }

        public static void SetRoundedBorder(Control parentControl, string controlName, int radius)
        {
            Control targetControl = FindControlByName(parentControl, controlName);

            if (targetControl == null)
            {
                throw new ArgumentException($"Control dengan nama '{controlName}' tidak ditemukan.");
            }

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // Top left corner
            path.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);

            // Top edge
            path.AddLine(radius, 0, targetControl.Width - radius, 0);

            // Top right corner
            path.AddArc(new Rectangle(targetControl.Width - radius * 2, 0, radius * 2, radius * 2), 270, 90);

            // Right edge
            path.AddLine(targetControl.Width, radius, targetControl.Width, targetControl.Height - radius);

            // Bottom right corner
            path.AddArc(new Rectangle(targetControl.Width - radius * 2, targetControl.Height - radius * 2, radius * 2, radius * 2), 0, 90);

            // Bottom edge
            path.AddLine(targetControl.Width - radius, targetControl.Height, radius, targetControl.Height);

            // Bottom left corner
            path.AddArc(new Rectangle(0, targetControl.Height - radius * 2, radius * 2, radius * 2), 90, 90);

            path.CloseFigure();

            targetControl.Region = new Region(path);
        }

        private static Control FindControlByName(Control parent, string name)
        {
            if (parent.Name == name) return parent;

            foreach (Control child in parent.Controls)
            {
                Control found = FindControlByName(child, name);
                if (found != null) return found;
            }

            return null;
        }

        public static void BtnRounded(int radius, Button button)
        {
            // Membuat path untuk bentuk rounded
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // Menambahkan arc untuk sudut rounded
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddLine(radius, 0, button.Width - radius, 0);
            path.AddArc(new Rectangle(button.Width - radius, 0, radius, radius), 270, 90);
            path.AddLine(button.Width, radius, button.Width, button.Height - radius);
            path.AddArc(new Rectangle(button.Width - radius, button.Height - radius, radius, radius), 0, 90);
            path.AddLine(button.Width - radius, button.Height, radius, button.Height);
            path.AddArc(new Rectangle(0, button.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            // Mengatur region button untuk membuat bentuk rounded
            button.Region = new Region(path);
        }

        public static void formRounded(int radius, Form form)
        {
            // Menghilangkan border default
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White; // Atur warna latar belakang sesuai kebutuhan

            // Mengatur region form untuk membuat bentuk rounded
            form.Paint += (sender, e) =>
            {
                GraphicsPath path = new GraphicsPath();
                path.StartFigure();

                // Menambahkan arc untuk sudut rounded
                path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                path.AddLine(radius, 0, form.Width - radius, 0);
                path.AddArc(new Rectangle(form.Width - radius, 0, radius, radius), 270, 90);
                path.AddLine(form.Width, radius, form.Width, form.Height - radius);
                path.AddArc(new Rectangle(form.Width - radius, form.Height - radius, radius, radius), 0, 90);
                path.AddLine(form.Width - radius, form.Height, radius, form.Height);
                path.AddArc(new Rectangle(0, form.Height - radius, radius, radius), 90, 90);
                path.CloseFigure();

                // Mengatur region form
                form.Region = new Region(path);
            };
        }

        public static void animasiClose(Form form)
        {
            int target = form.Location.Y - 36;
            Timer pewaktu = new Timer();
            pewaktu.Interval = 1;
            pewaktu.Tick += (s, e) =>
            {
                var lokasiAnyar = form.Location;
                lokasiAnyar.Y -= 3; // ituin ntar jadi gini
                form.Location = lokasiAnyar;
                form.Opacity -= .05;

                // ini biar enggak gitu
                if (form.Location.Y <= target)
                {
                    pewaktu.Stop();
                    form.Close();
                }
            };
            // start biar bisa gigituan ntar jadi begini
            pewaktu.Start();
        }
    }
}
