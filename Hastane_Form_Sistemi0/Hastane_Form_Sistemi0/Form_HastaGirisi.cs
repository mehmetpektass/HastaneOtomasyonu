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
    public partial class Form_HastaGirisi : Form
    {
        public Form_HastaGirisi()
        {
            InitializeComponent();
        }

        sqlsorgusu sql = new sqlsorgusu();
      
        //Giriş Yapmayı Sağlar
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar where Hasta_tc=@a1 and Hasta_sifre=@a2", sql.baglanti());
            komut.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@a2", textBox1.Text);
            komut.ExecuteNonQuery();
            SqlDataReader rdr = komut.ExecuteReader();
            if (rdr.Read())
            {
                Form_Hasta_Detay frm = new Form_Hasta_Detay();
                frm.tc = maskedTextBox1.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girdiğiniz Şifre veya TC Numarası Hatalıdır");
            }
            sql.baglanti().Close();
        }

        //Kayıt Panelini Açar
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_KayıtPaneli frm = new Form_KayıtPaneli();
            frm.Show();
        }
    }
}
