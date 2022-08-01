using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace E_Ticaret
{
    public class Ürün_Ekle
    {
        int earning = 0;
        public string Product { get; set; }
        public int Price { get; set; }
        public string UserName { get; set; }
        public int Earning
        {
            get
            {
                if (Price <500)
                {
                    earning = Price;
                }
                else if (Price <1000)
                {
                    earning =Price-150;
                }
                else if (Price <10000)
                {
                    earning = Price-600;
                }
                
                else
                {
                    earning=Price-1000;
                }

                return earning;
            }
            set { }
        }
        public int Ürün_ekle()
        {
            try
            {
                int kayıtdurumu =0;
                SqlConnection bağlantı = new SqlConnection(SQLBaglantı.baglantıAdresi);
                bağlantı.Open();
                SqlCommand komut = new SqlCommand("insert into Sale_tbl (Product,Price,UserName) values(@Product,@Price,@UserName)",bağlantı);
                komut.Parameters.AddWithValue("@Product", Product);
                komut.Parameters.AddWithValue("@Price", Price);
                komut.Parameters.AddWithValue("@UserName", UserName);
                kayıtdurumu= komut.ExecuteNonQuery();
                bağlantı.Close();
                return kayıtdurumu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            


        }
    }
}
