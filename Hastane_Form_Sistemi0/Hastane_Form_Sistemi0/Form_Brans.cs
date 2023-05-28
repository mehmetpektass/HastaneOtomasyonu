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
    public partial class Form_Brans : Form
    {
        public Form_Brans()
        {
            InitializeComponent();
        }

        sqlsorgusu sql = new sqlsorgusu();
        private void Form_Branş_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Tbl_Brans", sql.baglanti());
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //Ekleme İşlemi
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Brans (Brans_ad) values (@a1)", sql.baglanti());
                komut.Parameters.AddWithValue("@a1", textBox2.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Ekleme Başarıyla Gerçekleştirildi", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz,Lütfen Boş alan Bırakmayınız", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Silme İşlemi
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlCommand komut = new SqlCommand("Delete From Tbl_Brans where Brans_id=@a1", sql.baglanti());
                komut.Parameters.AddWithValue("@a1", textBox1.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Silme İşlemi Başarıyla Gerçekleştirildi", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz,Lütfen Boş alan Bırakmayınız", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Güncelleme İşlemi
        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text!="" && textBox2.Text != "")
            {
                SqlCommand komut = new SqlCommand("Update Tbl_Brans set Brans_ad=@a1 where Brans_id=@a2", sql.baglanti());
                komut.Parameters.AddWithValue("@a1", textBox2.Text);
                komut.Parameters.AddWithValue("@a2", textBox1.Text);
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleştirildi", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }
    }
}
