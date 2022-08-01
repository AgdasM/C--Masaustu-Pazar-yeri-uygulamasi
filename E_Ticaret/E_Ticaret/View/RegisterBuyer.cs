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
    public partial class RegisterBuyer : Form
    {
        public RegisterBuyer()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public int User_Register(UserBuyer buyer)
        {
            try
            {
                int kayıtDurumu = 0;
                SqlConnection bağlantı = new SqlConnection(SQLBaglantı.baglantıAdresi);
                bağlantı.Open();
                SqlCommand komut = new SqlCommand("insert into Users_tbl(TCNo,Name,SurName,UserName,Password,Gender,TelNo,Membership) Values (@TCNo,@Name,@SurName,@UserName,@Password,@Gender,@TelNo,'Buyer')", bağlantı);
           
                komut.Parameters.AddWithValue("@TCNo", buyer.TCNo);
                komut.Parameters.AddWithValue("@Name", buyer.Name);
                komut.Parameters.AddWithValue("@SurName", buyer.SurName);
                komut.Parameters.AddWithValue("@UserName", buyer.UserName);
                komut.Parameters.AddWithValue("@Password", buyer.Password);
                komut.Parameters.AddWithValue("@Gender", buyer.Gender);
                komut.Parameters.AddWithValue("@TelNo", buyer.TelNo);
                //komut.Parameters.AddWithValue("@Balance", buyer.Balance);
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
        private void Register_Click(object sender, EventArgs e)
        {
            UserBuyer buyer = new UserBuyer();
            buyer.TCNo= textBox1.Text;
            buyer.Name=textBox2.Text;
            buyer.SurName=textBox3.Text;
            buyer.UserName=textBox4.Text;
            buyer.Password=textBox5.Text;
            buyer.Gender=comboBox1.Text;
            buyer.TelNo=textBox6.Text;
            //buyer.Balance=int.Parse(textBox7.Text);
            int kayıtcntrl = User_Register(buyer);
            if (kayıtcntrl==-1)
            {
                MessageBox.Show("Kayıt İşlemi Gerçekleştirilemedi");
                return;
            }
            else
            {
                MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirildi");
                BuyerLogin geçis = new BuyerLogin();
                geçis.Show();
                this.Hide();
                return;
            }



        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            Format_Control g1 = new Format_Control();
            bool telcntrl = g1.PhoneFormatControl(textBox6.Text);
            if (telcntrl==false)
            {
                MessageBox.Show("Telefon hatalı");
                textBox6.Text="";
                textBox6.Focus();
            }
         
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <11)
            {
                MessageBox.Show("Tc Kimlik No 11 Haneli Olmalı");
                textBox1.Text="";
                textBox1.Focus();
            }
            Format_Control g2 = new Format_Control();
            g2.TcNo=textBox1.Text;
            g2.harfkontrol();
            textBox1.Text=g2.TcNo;
            User_Login_class u1 = new User_Login_class();
            u1.TcNo=textBox1.Text;
            int kayıtdurumu = u1.User_control();
            if (kayıtdurumu==1)
            {
                MessageBox.Show("Kayıtlı Üye");
                textBox1.Text="";

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
