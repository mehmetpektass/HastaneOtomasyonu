using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Form_Sistemi0
{
    public partial class SistemGirisEkranı : Form
    {
        public SistemGirisEkranı()
        {
            InitializeComponent();
        }

        //Hasta Panelini Açar
        private void Button1_Click(object sender, EventArgs e)
        {
            Form_HastaGirisi frm = new Form_HastaGirisi();
            frm.Show();
        }

        //Doktor Panelini Açar
        private void button2_Click(object sender, EventArgs e)
        {
            Form_DoktorGiris frm = new Form_DoktorGiris();
            frm.Show();
        }

        //Sekreter Panelini Açar
        private void button3_Click(object sender, EventArgs e)
        {
            Form_SekreterGiris frm = new Form_SekreterGiris();
            frm.Show();
        }
    }
}
