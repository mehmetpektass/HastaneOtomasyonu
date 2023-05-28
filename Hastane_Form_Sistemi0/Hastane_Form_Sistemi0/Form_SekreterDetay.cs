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
    public partial class Form_SekreterDetay : Form
    {
        public Form_SekreterDetay()
        {
            InitializeComponent();
        }

        public string TC;
        sqlsorgusu sql = new sqlsorgusu();

        private void Form_SekreterDetay_Load(object sender, EventArgs e)
        {
            label4.Text = TC;

            //Ad ve Soyad Getirme
            SqlCommand komut = new SqlCommand("Select * from Tbl_Sekreter where Sekreter_tc=@a1", sql.baglanti());
            komut.Parameters.AddWithValue("@a1", label4.Text);
            SqlDataReader sdr = komut.ExecuteReader();
            while (sdr.Read())
            {
                label3.Text = sdr[1].ToString();
            }
            sql.baglanti().Close();

            //Branşları Getirme
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Tbl_Brans ", sql.baglanti());
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            //Doktorları Getirme
            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter("Select (Doktor_ad+' ' +Doktor_soyad) as 'Doktorlar',Doktor_brans as 'Doktor Branş' From Tbl_Doktorlar", sql.baglanti());
            sda2.Fill(dt2);
            dataGridView2.DataSource = dt2;


            //Combobox'a Branş Kaydetme
            SqlCommand komut2 = new SqlCommand("Select Brans_ad from Tbl_Brans", sql.baglanti());
            SqlDataReader sdr2 = komut2.ExecuteReader();
            while (sdr2.Read())
            {
                comboBox1.Items.Add(sdr2[0].ToString());
            }
            sql.baglanti().Close();
        }

        //Randevu Ekleme İşlemi
        private void button6_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != ""  && checkBox1.Checked == true)
            {
                SqlCommand ekle_komutu = new SqlCommand("insert into Tbl_Randevular0(Randevu_tarih,Randevu_saat,Randevu_brans,Randevu_doktor) values (@a1,@a2,@a3,@a4)", sql.baglanti());
                ekle_komutu.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
                ekle_komutu.Parameters.AddWithValue("@a2", maskedTextBox2.Text);
                ekle_komutu.Parameters.AddWithValue("@a3", comboBox1.Text);
                ekle_komutu.Parameters.AddWithValue("@a4", comboBox2.Text);
                ekle_komutu.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Kaydınız Başarıyla Gerçekleşmiştir", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz,Lütfen Boş alan Bırakmayınız", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Branşa Göre Doktor Combobox'ına İsimleri Getirir
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand komut = new SqlCommand("select Doktor_ad,Doktor_soyad From Tbl_Doktorlar where Doktor_brans=@a1", sql.baglanti());
            komut.Parameters.AddWithValue("@a1", comboBox1.Text);
            SqlDataReader sdr = komut.ExecuteReader();
            while (sdr.Read())
            {
                comboBox2.Items.Add(sdr[0] + " " + sdr[1]);
            }
            sql.baglanti().Close();
        }

        //Duyuru Oluşturur
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru_metin) values (@d1)", sql.baglanti());
                komut.Parameters.AddWithValue("@d1", richTextBox1.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Duyuru Oluşturuldu", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alanı Doldurunuz", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Doktor Paneli Açar
        private void button2_Click(object sender, EventArgs e)
        {
            Form_DoktorPaneli frm = new Form_DoktorPaneli();
            frm.Show();
        }

        //Branş Formu Açar
        private void button3_Click(object sender, EventArgs e)
        {
            Form_Brans frm = new Form_Brans();
            frm.Show();
        }

        //randevu Listesi Açar
        private void button4_Click(object sender, EventArgs e)
        {
            Form_RandevuListesi frm = new Form_RandevuListesi();
            frm.Show();
        }

        //Duyuru Formu Açar
        private void button5_Click(object sender, EventArgs e)
        {
            Form_Duyurular frm = new Form_Duyurular();
            frm.Show();
        }
    }
}
