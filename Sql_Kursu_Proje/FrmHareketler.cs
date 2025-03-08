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
    public partial class FrmHareketler : Form
    {
        public FrmHareketler()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();
        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            SqlCommand k= new SqlCommand("SELECT dbo.Tbl_Musteri.MusteriAd, dbo.Tbl_Musteri.MusteriSoyad, dbo.Tbl_Musteri.MusteriSehir, dbo.Tbl_Personel.PersonelAdSoyad, dbo.Tbl_Urunler.UrunAd, dbo.Tbl_Urunler.UrunMarka, dbo.Tbl_Kategori.KategoriAd, \r\n                  dbo.Tbl_Hareket.Hareketid\r\nFROM     dbo.Tbl_Hareket INNER JOIN\r\n                  dbo.Tbl_Musteri ON dbo.Tbl_Hareket.Musteri = dbo.Tbl_Musteri.Musteriid INNER JOIN\r\n                  dbo.Tbl_Personel ON dbo.Tbl_Hareket.Personel = dbo.Tbl_Personel.Personelid INNER JOIN\r\n                  dbo.Tbl_Urunler ON dbo.Tbl_Hareket.Urun = dbo.Tbl_Urunler.Urunid INNER JOIN\r\n                  dbo.Tbl_Kategori ON dbo.Tbl_Urunler.Kategori = dbo.Tbl_Kategori.Kategoriid\r\nWHERE  (dbo.Tbl_Musteri.MusteriSehir = 'istanbul')", bgl.SqlBaglanti());
            SqlDataAdapter da = new SqlDataAdapter(k);   
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;  
        }
    }
}
