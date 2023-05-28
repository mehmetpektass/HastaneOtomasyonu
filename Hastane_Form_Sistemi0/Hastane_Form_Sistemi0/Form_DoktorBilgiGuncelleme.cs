using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Form_Sistemi0
{
    public partial class Form_DoktorBilgiGuncelleme : Form
    {
        public Form_DoktorBilgiGuncelleme()
        {
            InitializeComponent();
        }

        sqlsorgusu sql = new sqlsorgusu();
        public string tc2;

        private void Form_DoktorBilgiGüncelleme_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = tc2;

            //Geri Kalan Doktor Bilgilerini Getirme 
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where Doktor_tc=@a1", sql.baglanti());
            komut.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
            SqlDataReader sdr = komut.ExecuteReader();
            while (sdr.Read())
            {
                textBox1.Text = sdr[1].ToString();
                textBox2.Text = sdr[2].ToString();
                comboBox1.Text = sdr[3].ToString();
                textBox3.Text = sdr[5].ToString();
            }
            sql.baglanti().Close();

            //Combobox'a Branşları Getirme 
            SqlCommand komut1 = new SqlCommand("Select Brans_ad from Tbl_Brans", sql.baglanti());
            SqlDataReader sdr1 = komut1.ExecuteReader();
            while (sdr1.Read())
            {
                comboBox1.Items.Add(sdr1[0].ToString());
            }
            sql.baglanti().Close();
        }

        //Güncelleme İşlemi
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set Doktor_ad=@a1,Doktor_soyad=@a2,Doktor_brans=@a3,Doktor_sifre=@a4 where Doktor_tc=@a5", sql.baglanti());
                komut.Parameters.AddWithValue("@a1", textBox1.Text);
                komut.Parameters.AddWithValue("@a2", textBox2.Text);
                komut.Parameters.AddWithValue("@a3", comboBox1.Text);
                komut.Parameters.AddWithValue("@a4", textBox3.Text);
                komut.Parameters.AddWithValue("@a5", maskedTextBox1.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
