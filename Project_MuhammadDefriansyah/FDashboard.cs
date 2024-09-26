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
    public partial class FDashboard : Form
    {
        public FDashboard()
        {
            InitializeComponent();
        }

        public int pendapatan = 0,
            transaksi = 0;

        private void FDashboard_Load(object sender, EventArgs e)
        {
            // hitung jumlah stok
            DB.crud("SELECT STOK FROM tmenu");
            DataTable dataTable = DB.ds.Tables[0];
            object totalStokObj = dataTable.Compute("SUM(STOK)", string.Empty);
            int totalStok = totalStokObj != DBNull.Value ? Convert.ToInt32(totalStokObj) : 0;
            label8.Text = totalStok + "";

            txtTotalTransaksi.Text = style.totalTransaksi + "";
            txtOmzet.Text = style.omzet + "";

            DB.tampilgrid("SELECT NamaMenu, Stok FROM tmenu;", dataGridView1);

        }
    }
}
