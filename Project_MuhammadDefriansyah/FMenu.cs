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
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
        }

        private void FMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                KF.flogin.Visible = true;
                this.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FDashboard fd = new FDashboard() { TopLevel = false, TopMost = true };
            KF.untukform(fd, panel2);

            panel3.BackColor = Color.White;
            panel4.BackColor = Color.FromArgb(240, 75, 50);
            panel5.BackColor = Color.FromArgb(240, 75, 50);
        }

        public FTransaksi ft = new FTransaksi() { TopLevel = false, TopMost = true };
        private void label3_Click(object sender, EventArgs e)
        {
            ft.lblWelcome.Text = "Selamat datang, " + KF.flogin.namaptg;
            ft.tampildata();
            KF.untukform(ft, panel2);

            panel5.BackColor = Color.White;
            panel3.BackColor = Color.FromArgb(240, 75, 50);
            panel4.BackColor = Color.FromArgb(240, 75, 50);

            ft.refreshData();
        }

        private void petugas_Click(object sender, EventArgs e)
        {
            FPetugas fp = new FPetugas() { TopLevel = false, TopMost = true };
            KF.untukform(fp, panel2);

            panel4.BackColor = Color.White;
            panel3.BackColor = Color.FromArgb(240, 75, 50);
            panel5.BackColor = Color.FromArgb(240, 75, 50);
        }

        private void FMenu_Load(object sender, EventArgs e)
        {
            label2_Click(this, EventArgs.Empty);
        }
    }
}
