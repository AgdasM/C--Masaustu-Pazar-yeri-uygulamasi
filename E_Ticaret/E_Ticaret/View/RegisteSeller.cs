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
namespace E_Ticaret
{
    public partial class RegisteSeller : Form
    {
        public RegisteSeller()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        
        public int User_Register(UserSeller seller)
        {
            try
            {
                int kayıtDurumu = 0;
                SqlConnection bağlantı = new SqlConnection(SQLBaglantı.baglantıAdresi);
                bağlantı.Open();
                SqlCommand komut = new SqlCommand("insert into Users_tbl(TCNo,Name,SurName,UserName,Password,Gender,TelNo,Membership) Values (@TCNo,@Name,@SurName,@UserName,@Password,@Gender,@TelNo,'Seller')", bağlantı);

                komut.Parameters.AddWithValue("@TCNo", seller.TCNo);
                komut.Parameters.AddWithValue("@Name", seller.Name);
                komut.Parameters.AddWithValue("@SurName", seller.SurName);
                komut.Parameters.AddWithValue("@UserName", seller.UserName);
                komut.Parameters.AddWithValue("@Password", seller.Password);
                komut.Parameters.AddWithValue("@Gender", seller.Gender);
                komut.Parameters.AddWithValue("@TelNo", seller.TelNo);
                //komut.Parameters.AddWithValue("@Price", seller.Price);
                //komut.Parameters.AddWithValue("@Product", seller.Product);
                kayıtDurumu=komut.ExecuteNonQuery();
                bağlantı.Close();

                return kayıtDurumu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
                throw;
            }
            
        }
        UserSeller seller = new UserSeller();
        private void Register_Click(object sender, EventArgs e)
        {
            
            seller.TCNo=textBox1.Text;
            seller.Name=textBox2.Text;
            seller.SurName=textBox3.Text;
            seller.UserName=textBox4.Text;
            seller.Password=textBox5.Text;
            seller.Gender=comboBox1.Text;
            seller.TelNo=textBox6.Text;
            //seller.Price=int.Parse(textBox7.Text);
            //seller.Product=textBox8.Text;
            int kayıtcntrl = User_Register(seller);
            if (kayıtcntrl==-1)
            {
                MessageBox.Show("Kayıt İşlemi Gerçekleştirilemedi");
                return;
            }
            else
            {
                MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirildi");
                SellerLogin geçis = new SellerLogin();
                geçis.Show();
                this.Hide();
                return;
            }
        }
        
        private void RegisteSeller_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <11)
            {
                MessageBox.Show("Tc Kimlik No 11 Haneli Olmalı");
                textBox1.Text="";
                textBox1.Focus();
            }
            Format_Control g3 = new Format_Control();
            g3.TcNo=textBox1.Text;
            g3.harfkontrol();
            textBox1.Text=g3.TcNo;

            User_Login_class u2 = new User_Login_class();
            u2.TcNo=textBox1.Text;
            int kayıtdurumu = u2.User_control();
            if (kayıtdurumu==1)
            {
                MessageBox.Show("Kayıtlı Üye");
                textBox1.Text="";

            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            Format_Control g4 = new Format_Control();
            bool telcntrl = g4.PhoneFormatControl(textBox6.Text);
            if (telcntrl==false)
            {
                MessageBox.Show("Telefon hatalı");
                textBox6.Text="";
                textBox6.Focus();
            }
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
