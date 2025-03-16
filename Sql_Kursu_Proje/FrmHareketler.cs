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
            SqlCommand l = new SqlCommand("execute Hareketler", bgl.SqlBaglanti());
            SqlDataAdapter da = new SqlDataAdapter(l);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //combo musteir çekme

            SqlCommand g = new SqlCommand("select Musteriid,MusteriAd,MusteriSoyad From Tbl_Musteri", bgl.SqlBaglanti());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(g);
            DataTable dt1 = new DataTable();
            sqlDataAdapter.Fill(dt1);
            cmbMusteri.DisplayMember = "MusteriAd";
            cmbMusteri.ValueMember = "Musteriid";
            
            cmbMusteri.DataSource = dt1;



            //PErosnle Çekme

            SqlCommand p = new SqlCommand("select Personelid,PersonelAdSoyad From Tbl_Personel", bgl.SqlBaglanti());
            SqlDataAdapter da1 = new SqlDataAdapter(p);
            DataTable dt2 = new DataTable();
            da1.Fill(dt2);
            cmbPersonel.DisplayMember = "PersonelAdSoyad";
            cmbPersonel.ValueMember = "Personelid";
            cmbPersonel.DataSource = dt2;



            //ÜRün Çekme

            SqlCommand u = new SqlCommand("select Urunid,UrunAd,UrunMarka from Tbl_Urunler",bgl.SqlBaglanti());
            SqlDataAdapter da2= new SqlDataAdapter(u);
            DataTable dt3= new DataTable();
            da2.Fill(dt3);
            cmbUrun.DisplayMember = "UrunAd";
            cmbUrun.ValueMember = "Urunid";
            cmbMarka.DisplayMember = "UrunMarka";
           
            cmbUrun.DataSource = dt3;
            cmbMarka.DataSource = dt3;

            

        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            SqlCommand satis = new SqlCommand("insert into Tbl_Hareket (Urun,Musteri,Personel,Adet,Tutar,Tarih,Marka) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7)",bgl.SqlBaglanti());
            satis.Parameters.AddWithValue("@a1",cmbUrun.SelectedValue);
            satis.Parameters.AddWithValue("@a2",cmbMusteri.SelectedValue);
            satis.Parameters.AddWithValue("@a3",cmbPersonel.SelectedValue);
            satis.Parameters.AddWithValue("@a7",cmbMarka.SelectedText.ToString());
            satis.Parameters.AddWithValue("@a4",txtAdet.Text);
            satis.Parameters.AddWithValue("@a5",txtFiyat.Text);
            satis.Parameters.AddWithValue("@a6", DateTime.Parse(txtTarih.Text));
            satis.ExecuteNonQuery();
            MessageBox.Show("Satiş Başarıyla Gerçekleştirilmiştir.");
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
