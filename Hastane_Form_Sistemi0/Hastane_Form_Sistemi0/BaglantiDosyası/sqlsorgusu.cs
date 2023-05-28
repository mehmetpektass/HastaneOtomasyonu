using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane_Form_Sistemi0
{
    internal class sqlsorgusu
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglantim = new SqlConnection("Data Source=LAPTOP-AEH3Q08K\\MSSQLSERVER1;Initial Catalog=hastane_sistemi_vertabanı;Integrated Security=True");
            baglantim.Open();
            return baglantim;
        }
    }
}
