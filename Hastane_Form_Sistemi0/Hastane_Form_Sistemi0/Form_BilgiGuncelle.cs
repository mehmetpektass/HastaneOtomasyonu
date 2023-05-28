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
    public partial class Form_BilgiGuncelle : Form
    {
        public Form_BilgiGuncelle()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlsorgusu sql = new sqlsorgusu();

        private void Form_BilgiGüncelle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar where Hasta_tc=@a1", sql.baglanti());
            komut.Parameters.AddWithValue("@a1", TCno);
            SqlDataReader sdr = komut.ExecuteReader();
            while (sdr.Read())
            {
                textBox1.Text = sdr[1].ToString();
                textBox2.Text = sdr[2].ToString();
                maskedTextBox2.Text = sdr[4].ToString();
                textBox3.Text = sdr[5].ToString();
                comboBox1.Text = sdr[6].ToString();
            }
            sql.baglanti().ToString();
        }

        //Güncelleme Onay Butonu
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar set Hasta_ad=@a1,Hasta_soyad=@a2,Hasta_telefon=@a3,Hasta_sifre=@a4,Hasta_cinsiyet=@a5 where Hasta_tc=@a6", sql.baglanti());
                komut2.Parameters.AddWithValue("@a1", textBox1.Text);
                komut2.Parameters.AddWithValue("@a2", textBox2.Text);
                komut2.Parameters.AddWithValue("@a3", maskedTextBox2.Text);
                komut2.Parameters.AddWithValue("@a4", textBox3.Text);
                komut2.Parameters.AddWithValue("@a5", comboBox1.Text);
                komut2.Parameters.AddWithValue("@a6", maskedTextBox1.Text);
                komut2.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Güncelleme Başarıyla Gerçekleşmiştir", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz,Lütfen Boş alan Bırakmayınız", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
