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
    public partial class Form_DoktorPaneli : Form
    {
        public Form_DoktorPaneli()
        {
            InitializeComponent();
        }

        sqlsorgusu sql = new sqlsorgusu();
        private void Form_DoktorPaneli_Load(object sender, EventArgs e)
        {
            //Doktorları Tabloya Ekleme
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Tbl_Doktorlar", sql.baglanti());
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            // Combobox'a Branşları  Ekleme
            SqlCommand komut1 = new SqlCommand("Select Brans_ad from Tbl_Brans", sql.baglanti());
            SqlDataReader sdr1 = komut1.ExecuteReader();
            while (sdr1.Read())
            {
                comboBox1.Items.Add(sdr1[0].ToString());
            }
            sql.baglanti().Close();
        }

        //Ekleme İşlemi
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Doktorlar (Doktor_ad,Doktor_soyad,Doktor_brans,doktor_tc,Doktor_sifre) values (@a1,@a2,@a3,@a4,@a5)", sql.baglanti());
                komut.Parameters.AddWithValue("@a1", textBox1.Text);
                komut.Parameters.AddWithValue("@a2", textBox2.Text);
                komut.Parameters.AddWithValue("@a3", comboBox1.Text);
                komut.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@a5", textBox3.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirilmiştir", " YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz,Lütfen Boş alan Bırakmayınız", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Tablodaki Bilgileri TextBox'a Çekme
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        //Silme İşlemi
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("Delete from Tbl_Doktorlar where Doktor_tc=@a1", sql.baglanti());
                komut.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Silme İşlemi Başarıyla Gerçekleştirilmiştir", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz,Lütfen Boş alan Bırakmayınız", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Güncelleme İşlemi
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set Doktor_ad=@a1,Doktor_soyad=@a2,Doktor_brans=@a3,Doktor_sifre=@a5 where Doktor_tc=@a4", sql.baglanti());
                komut.Parameters.AddWithValue("@a1", textBox1.Text);
                komut.Parameters.AddWithValue("@a2", textBox2.Text);
                komut.Parameters.AddWithValue("@a3", comboBox1.Text);
                komut.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@a5", textBox3.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz,Lütfen Boş alan Bırakmayınız", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
