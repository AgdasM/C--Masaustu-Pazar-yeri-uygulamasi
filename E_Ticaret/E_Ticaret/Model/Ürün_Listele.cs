using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace E_Ticaret
{
    public class Ürün_Listele
    {
        public string SqlSorgu { get; set; }
        public DataSet ds { get; set; }
       
        public DataSet Listele()
        {
            SqlConnection baglan = new SqlConnection(SQLBaglantı.baglantıAdresi);
            SqlDataAdapter adapter = new SqlDataAdapter(SqlSorgu, baglan);
            ds = new DataSet();
            baglan.Open();
            adapter.Fill(ds, "Sale_tbl");
            
            baglan.Close();
            return ds;

        }
       
    }
}
