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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        Baglanti bgl= new Baglanti();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand g= new SqlCommand("select * from  Tbl_Admin where AdminAd=@p1 and AdminSifre=@p2",bgl.SqlBaglanti());
            g.Parameters.AddWithValue("@p1",txtAd.Text);
            g.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader reader = g.ExecuteReader();
           if(reader.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
            }
           else
            {
                MessageBox.Show("Hatalı Şifre Veya Kullanıcı Adı Girdiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand y = new SqlCommand("Update Tbl_Admin set AdminSifre=@a2 where AdminAd=@a1",bgl.SqlBaglanti());
            y.Parameters.AddWithValue("@a1",textBox2.Text);
            y.Parameters.AddWithValue("@a2",textBox1.Text);
            y.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Güncellenmiştir");

        }
    }
}
