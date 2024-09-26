using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Project_MuhammadDefriansyah
{
    class DB
    {
        public static MySqlConnection koneksi = new MySqlConnection("server=127.0.0.1; username=root; password = ; database=db_mdefri");
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand perintah;

        public static void crud(string sqlnya)
        {

            Console.WriteLine(sqlnya);
            ds.Tables.Clear();
            perintah = new MySqlCommand(sqlnya, koneksi);
            da = new MySqlDataAdapter(perintah);
            da.Fill(ds);
        }

        public static void DgCepat(DataGridView dgv)
        {
            var dg = dgv.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance |
            BindingFlags.NonPublic);
            dg.SetValue(dgv, true, null);
        }

        public static void tampilgrid(String sql, DataGridView gridapa)
        {
            Console.WriteLine(sql);
            DgCepat(gridapa);
            DB.crud(sql);
            gridapa.DataSource = DB.ds.Tables[0];
            gridapa.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            gridapa.Font = new Font("Tahoma", 10F, FontStyle.Regular);
            gridapa.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridapa.ColumnHeadersHeight = 50;
            //digunakan untuk mengecek bila datagridview ada gambar
            foreach (DataGridViewColumn kolom in gridapa.Columns)
            {
                kolom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (kolom.GetType() == typeof(DataGridViewImageColumn))
                {
                    ((DataGridViewImageColumn)kolom).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
        }
    }
}
