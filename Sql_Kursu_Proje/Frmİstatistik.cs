using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql_Kursu_Proje
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();  
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            SqlCommand g1 = new SqlCommand("Execute PersonelSatis", bgl.SqlBaglanti());
            SqlDataReader dra = g1.ExecuteReader();
            while (dra.Read())
            {
                chart1.Series["Personel"].Points.AddXY(dra[0], dra[1]);

            }

            SqlCommand m = new SqlCommand("Execute MusteriAlis",bgl.SqlBaglanti());
            SqlDataReader dra2 = m.ExecuteReader();
            while (dra2.Read())
            {
                chart2.Series["Musteri"].Points.AddXY(dra2[0], dra2[1]);
            }
            
            SqlCommand ma = new SqlCommand("Execute SatilanUrun",bgl.SqlBaglanti());
            SqlDataReader dra3 = ma.ExecuteReader();
            while (dra3.Read())
            {
                chart4.Series["Urun"].Points.AddXY(dra3[0], dra3[1]);
            }
        }
    }
}
