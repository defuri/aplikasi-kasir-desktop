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
    public partial class MenuKeranjang : UserControl
    {
        public MenuKeranjang()
        {
            InitializeComponent();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string idmenu = this.Name;
            string idp = KF.flogin.idptg;
            DB.crud($"delete from tkeranjang where idp={idp} and idm={idmenu}");
            KF.FMenu.ft.tampilkeranjang();
        }
    }
}
