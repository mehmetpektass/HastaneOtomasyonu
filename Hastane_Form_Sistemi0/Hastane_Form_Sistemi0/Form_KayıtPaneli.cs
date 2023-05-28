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
    public partial class Form_KayıtPaneli : Form
    {
        public Form_KayıtPaneli()
        {
            InitializeComponent();
        }

        sqlsorgusu sql = new sqlsorgusu();

        //Kaydetme  İşlemi Yapar
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand ekle_komutu = new SqlCommand("insert into Tbl_Hastalar (Hasta_ad,Hasta_soyad,Hasta_tc,Hasta_telefon,Hasta_sifre,Hasta_cinsiyet) values (@a1,@a2,@a3,@a4,@a5,@a6)", sql.baglanti());
            ekle_komutu.Parameters.AddWithValue("@a1", textBox1.Text);
            ekle_komutu.Parameters.AddWithValue("@a2", textBox2.Text);
            ekle_komutu.Parameters.AddWithValue("@a3", maskedTextBox1.Text);
            ekle_komutu.Parameters.AddWithValue("@a4", maskedTextBox2.Text);
            ekle_komutu.Parameters.AddWithValue("@a5", textBox3.Text);
            ekle_komutu.Parameters.AddWithValue("@a6", comboBox1.Text);
            ekle_komutu.ExecuteNonQuery();
            sql.baglanti().Close();
            MessageBox.Show("Kaydınız Başarıyla Gerçekleşmiştir  Şifreniz: " + textBox3.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //TextBox'ları Temizler
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }
    }
}
