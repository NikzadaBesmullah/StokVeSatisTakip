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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        Baglanti bgl=new Baglanti();    
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            listele();
        }
        public void listele()
        {
            SqlCommand l = new SqlCommand("select * from Tbl_Personel", bgl.SqlBaglanti());
            SqlDataAdapter dr = new SqlDataAdapter(l);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand k = new SqlCommand("insert into Tbl_Personel (PersonelAdSoyad) values (@a1)",bgl.SqlBaglanti());
            k.Parameters.AddWithValue("@a1",txtAd.Text);
            k.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Kaydedildi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand k = new SqlCommand("delete Tbl_Personel  where PersonelAdSoyad=@a1", bgl.SqlBaglanti());
            k.Parameters.AddWithValue("@a1", txtAd.Text);
            k.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Silindi");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand l = new SqlCommand("select * from Tbl_Personel where PersonelAdSoyad=@a1", bgl.SqlBaglanti());
            l.Parameters.AddWithValue("@a1", txtAd.Text);
            SqlDataAdapter dr = new SqlDataAdapter(l);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
