using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Kursu_Proje
{
    public class Baglanti
    {
        public SqlConnection SqlBaglanti()
        {
            SqlConnection bgl = new SqlConnection("Data Source=NIKZADA-BES;Initial Catalog=SatisVT;Integrated Security=True;");
            bgl.Open();
            return bgl;
        }

    }
}
