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
using System.Reflection.Emit;

namespace Hastane_Form_Sistemi0
{
    public partial class Form_DoktorDetay : Form
    {
        public Form_DoktorDetay()
        {
            InitializeComponent();
        }
        sqlsorgusu sql = new sqlsorgusu();
        public string tc1;

        private void Form_DoktorDetay_Load(object sender, EventArgs e)
        {
            label4.Text = tc1;

            //Doktor AD ve Soyad Çekme 
            SqlCommand Komut_AdSoyad = new SqlCommand("Select * From Tbl_Doktorlar where Doktor_tc=@a1", sql.baglanti());
            Komut_AdSoyad.Parameters.AddWithValue("@a1", label4.Text);
            SqlDataReader sdr = Komut_AdSoyad.ExecuteReader();
            while (sdr.Read())
            {
                label5.Text = sdr[1].ToString();
                label6.Text = sdr[2].ToString();
            }
            sql.baglanti().Close();

            // Randevu Tablosunu Getirme
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Tbl_Randevular0 where Randevu_doktor='" + label5.Text + "' + '" + label7.Text + "' + '" + label6.Text + "' ", sql.baglanti());
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sql.baglanti().Close();
        }

        // Bilgi Güncelleme Sayfasına Yönlendirir
        private void button1_Click(object sender, EventArgs e)
        {
            Form_DoktorBilgiGuncelleme frm = new Form_DoktorBilgiGuncelleme();
            frm.tc2 = label4.Text;
            frm.Show();
        }

        //Duyuru Sayfasına Yönlendirir
        private void button2_Click(object sender, EventArgs e)
        {
            Form_Duyurular frm = new Form_Duyurular();
            frm.Show();
        }

        //Çıkış İşlemi
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Tablodaki Bilgileri TextBox'a Çekme
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
