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
    public partial class Form_SekreterGiris : Form
    {
        public Form_SekreterGiris()
        {
            InitializeComponent();
        }

        sqlsorgusu sql = new sqlsorgusu();

        //Giriş Yapma İşlemi
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Sekreter where Sekreter_tc=@a1 and Sekreter_sifre=@a2", sql.baglanti());
            komut.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@a2", textBox1.Text);
            SqlDataReader sdr = komut.ExecuteReader();
            if (sdr.Read())
            {
                Form_SekreterDetay frm = new Form_SekreterDetay();
                frm.TC = maskedTextBox1.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC Numarası veya Şifre", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
