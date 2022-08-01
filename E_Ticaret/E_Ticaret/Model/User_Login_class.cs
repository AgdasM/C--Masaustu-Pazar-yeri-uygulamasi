using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace E_Ticaret
{
    public class User_Login_class
    {
        public string username { get; set; }
        public string password { get; set; }
        public string membership { get; set; }
        public string TcNo { get; set; }
        public void Users_Login()
        {
            try
            {
                SqlConnection bağlantı = new SqlConnection(SQLBaglantı.baglantıAdresi);

                bağlantı.Open();
                SqlCommand komut = new SqlCommand("select * from Users_tbl where UserName='"+this.username+"' and Password='"+this.password+"'and Membership='"+this.membership+"' ", bağlantı);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Tebrikler Giriş Başarılı");


                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
                }


                bağlantı.Close();
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            
        }

        public int  User_control()
        {
            int kayıtdurumu = 0;
            SqlConnection bağlantı = new SqlConnection(SQLBaglantı.baglantıAdresi);

            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select * from Users_tbl where TCNo='"+this.TcNo+"' ", bağlantı);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                
                kayıtdurumu=1;

            }

            
            bağlantı.Close();
            return kayıtdurumu;

        }
      
    }
}
