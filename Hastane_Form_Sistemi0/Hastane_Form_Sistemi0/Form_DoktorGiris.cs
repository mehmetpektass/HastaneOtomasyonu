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
    public partial class Form_DoktorGiris : Form
    {
        public Form_DoktorGiris()
        {
            InitializeComponent();
        }

        sqlsorgusu sql = new sqlsorgusu();

        //Giriş İşlemi
        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where Doktor_tc=@a1 and Doktor_sifre=@a2", sql.baglanti());
            komut.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@a2", textBox1.Text);
            SqlDataReader sdr = komut.ExecuteReader();
            if (sdr.Read())
            {
                Form_DoktorDetay frm = new Form_DoktorDetay();
                frm.tc1 = maskedTextBox1.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girdiğiniz TC Kimlik Numarası Veya Şifre Hatalıdır", "YILDIZ HASTANESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sql.baglanti().Close();
        }
    }
}
