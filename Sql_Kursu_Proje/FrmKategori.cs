using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql_Kursu_Proje
{
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        Baglanti bgl=new Baglanti();

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            Bilgigetir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand g = new SqlCommand(" update Tbl_Kategori set KategoriAd=@a1 where Kategoriid=@a2",bgl.SqlBaglanti());
            g.Parameters.AddWithValue("@a1",txtKategoriAd.Text);
            g.Parameters.AddWithValue("@a2",txtid.Text);
            g.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Güncellendi");

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Bilgigetir();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into Tbl_Kategori (KategoriAd) values (@a1)",bgl.SqlBaglanti());
            kaydet.Parameters.AddWithValue("@a1",txtKategoriAd.Text);
            kaydet.ExecuteNonQuery();
            MessageBox.Show("Başarıyla eklendi");
        }

        public void Bilgigetir()
        {
            SqlCommand listele = new SqlCommand("select * from Tbl_Kategori", bgl.SqlBaglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtid.Text = row.Cells["Kategoriid"].Value.ToString();
                txtKategoriAd.Text = row.Cells["KategoriAd"].Value.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand s = new SqlCommand("delete from Tbl_Kategori where Kategoriid=@a1",bgl.SqlBaglanti());
            s.Parameters.AddWithValue("@a1",txtid.Text);
            s.ExecuteNonQuery();
            MessageBox.Show("Başaryla Silindi");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

