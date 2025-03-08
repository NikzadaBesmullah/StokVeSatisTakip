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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand k = new SqlCommand("insert into Tbl_Musteri (MusteriAd,MusteriSoyad,MusteriSehir,MusteriBakiye) values (@a1,@a2,@a3,@a4)",bgl.SqlBaglanti());
            k.Parameters.AddWithValue("@a1",txtAd.Text);
            k.Parameters.AddWithValue("@a2",txtSoyad.Text);
            k.Parameters.AddWithValue("@a3",txtSehir.Text);
            k.Parameters.AddWithValue("@a4",txtBakiye.Text);
            k.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Eklendi");
        }
        public void listele()
        {
            SqlCommand l = new SqlCommand("select * from Tbl_Musteri", bgl.SqlBaglanti());
            SqlDataAdapter da = new SqlDataAdapter(l);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();  //datagridvienun satırları içimde indeksine gore birinci degeri getir
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); 
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand g = new SqlCommand("Update Tbl_Musteri set MusteriAd=@a1,MusteriSoyad=@a2,MusteriSehir=@a3,MusteriBakiye=@a4 where Musteriid=@a5",bgl.SqlBaglanti());
            g.Parameters.AddWithValue("@a1", txtAd.Text);
            g.Parameters.AddWithValue("@a2", txtSoyad.Text);
            g.Parameters.AddWithValue("@a3", txtSehir.Text);
            g.Parameters.AddWithValue("@a4", decimal.Parse(txtBakiye.Text));
            g.Parameters.AddWithValue("@a5", txtid.Text);
            g.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Güncellendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand s = new SqlCommand("delete from Tbl_Musteri where Musteriid=@a1",bgl.SqlBaglanti());
            s.Parameters.AddWithValue("@a1",txtid.Text);
            s.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Silindi");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select * from Tbl_Musteri where MusteriAd=@a1",bgl.SqlBaglanti());
            ara.Parameters.AddWithValue("@a1",txtAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;  
            
        }
    }
}
