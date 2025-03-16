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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();  
        private void Urunler_Load(object sender, EventArgs e)
        {
            Listele();
            SqlCommand b= new SqlCommand("select Kategoriid,KategoriAd from Tbl_Kategori ",bgl.SqlBaglanti());
           SqlDataAdapter dataAdapter = new SqlDataAdapter(b);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable); 
            comboBox1.DisplayMember = "KategoriAd";
            comboBox1.ValueMember = "Kategoriid";
            comboBox1.DataSource = dataTable;   
        

           
        }
        public void Listele()
        {
            SqlCommand l = new SqlCommand("execute Urunler2",bgl.SqlBaglanti());
            SqlDataAdapter da = new SqlDataAdapter(l);  
            DataTable dt = new DataTable();
           da.Fill(dt);
            dataGridView1.DataSource = dt;  
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand k = new SqlCommand("insert into Tbl_Urunler (UrunAd,UrunMarka,Kategori,UrunAlisFiyati,UrunSatisFiyati,UrunStok) values (@a1,@a2,@a3,@a4,@a5,@a6)",bgl.SqlBaglanti());
            k.Parameters.AddWithValue("@a1", txtAd.Text);
            k.Parameters.AddWithValue("@a2", txtMarka.Text);
            k.Parameters.AddWithValue("@a3", comboBox1.SelectedValue);
            k.Parameters.AddWithValue("@a4", txtAlis.Text);
            k.Parameters.AddWithValue("@a5", txtSatis.Text);
            k.Parameters.AddWithValue("@a6", txtStok.Text);
            k.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Eklendi");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();  //datagridvienun satırları içimde indeksine gore birinci degeri getir
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAlis.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSatis.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtKar.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand g= new SqlCommand("Update Tbl_Urunler set UrunAd=@a1, UrunMarka=@a2, Kategori=@a3, UrunAlisFiyati=@a4, UrunSatisFiyati=@a5, UrunStok=@a6 where Urunid=@a7",bgl.SqlBaglanti());
            g.Parameters.AddWithValue("@a1",txtAd.Text);
            g.Parameters.AddWithValue("@a2",txtMarka.Text);
            g.Parameters.AddWithValue("@a3",comboBox1.Text);
            g.Parameters.AddWithValue("@a4",txtAlis.Text);
            g.Parameters.AddWithValue("@a5",txtSatis.Text);
            g.Parameters.AddWithValue("@a6",txtStok.Text);
            g.Parameters.AddWithValue("@a7",txtid.Text);
            g.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Güncellendi");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from Tbl_Urunler where Urunid=@a1",bgl.SqlBaglanti());
            sil.Parameters.AddWithValue("@a1",txtid.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Silindi");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select * from Tbl_Urunler where UrunAd=@a1", bgl.SqlBaglanti());
            ara.Parameters.AddWithValue("@a1", txtAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
