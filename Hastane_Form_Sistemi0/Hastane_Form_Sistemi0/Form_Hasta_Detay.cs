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
using System.Data.SqlClient;

namespace Hastane_Form_Sistemi0
{
    public partial class Form_Hasta_Detay : Form
    {
        public Form_Hasta_Detay()
        {
            InitializeComponent();
        }

        sqlsorgusu sql = new sqlsorgusu();
        public string tc;
        private void Form_Hasta_Detay_Load(object sender, EventArgs e)
        {
            label4.Text = tc;

            //Labellara Ad ve Soyad Çekme
            SqlCommand komut = new SqlCommand("Select Hasta_ad,Hasta_soyad from Tbl_Hastalar where Hasta_tc=@a1", sql.baglanti());
            komut.Parameters.AddWithValue("@a1", label4.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr[0].ToString();
                label6.Text = dr[1].ToString();
            }
            sql.baglanti().Close();

            //Geçmiş Randevularu Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Tbl_Randevular0 where Hasta_Tc=" + tc + "", sql.baglanti());
            sda.Fill(dt);
            dataGridView2.DataSource = dt;


            //Branş Çekme
            SqlCommand komut2 = new SqlCommand("Select Brans_ad From Tbl_Brans", sql.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0].ToString());
            }
            sql.baglanti().Close();
        }

        //Doktor Combobox'ına İsimleri Çekme
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select Doktor_ad,Doktor_soyad from Tbl_Doktorlar where Doktor_brans=@a1", sql.baglanti());
            komut3.Parameters.AddWithValue("@a1", comboBox1.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3[0] + " " + dr3[1]);
            }
            sql.baglanti();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Tbl_Randevular0 where Randevu_brans='" + comboBox1.Text + "'" + " and Randevu_doktor='" + comboBox2.Text + "' and Randevu_durum=0", sql.baglanti());
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

       

        //Randevu Güncelleme İşlemi
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Update Tbl_Randevular0 set Randevu_durum=1,Hasta_tc=@a1,Sikayet=@a2 where Randevu_id=@a3", sql.baglanti());
                komut.Parameters.AddWithValue("@a1", label4.Text);
                komut.Parameters.AddWithValue("@a2", richTextBox1.Text);
                komut.Parameters.AddWithValue("@a3", textBox1.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Randevu işlemi Başarıyla Gerçekleşmiştir", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {

            }
        }

        //Tablodaki Bilgileri TextBox'a Çekme
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        //Bilgi Güncelleme Sayfasına Yönlendirir
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_BilgiGuncelle frm = new Form_BilgiGuncelle();
            frm.TCno = label4.Text.ToString();
            frm.Show();
        }
    }
}
