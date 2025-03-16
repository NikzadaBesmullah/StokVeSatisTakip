using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql_Kursu_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand s= new SqlCommand("Execute UrunStok",bgl.SqlBaglanti());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(s);
            DataTable dt = new DataTable(); 
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;


            //grafik

            SqlCommand g = new SqlCommand("Execute KategoriGrafik", bgl.SqlBaglanti());
            SqlDataReader dr = g.ExecuteReader();
            while (dr.Read()) 
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);    

            }


            //
            SqlCommand g1 = new SqlCommand("select MusteriSehir, count(*) from Tbl_Musteri group by MusteriSehir", bgl.SqlBaglanti());
            SqlDataReader dra = g1.ExecuteReader();
            while (dra.Read())
            {
                chart2.Series["Sehirler"].Points.AddXY(dra[0], dra[1]);

            }

        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            Urunler u = new Urunler();  
            u.Show();   
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteri frm = new FrmMusteri();
            frm.Show();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            FrmKategori frm = new FrmKategori();
            frm.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            FrmPersonel frm = new FrmPersonel();
            frm.Show();
        }

        private void btnislemler_Click(object sender, EventArgs e)
        {
            FrmHareketler frm = new FrmHareketler();        
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik fa= new Frmİstatistik();
            fa.Show();
        }
    }
}
