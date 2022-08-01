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
    public partial class SellerLogin : Form
    {
        public SellerLogin()
        {
            InitializeComponent();
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            BuyerLogin geçiş = new BuyerLogin();
            geçiş.Show();
            this.Hide();
        }
        
        
        private void Giriş_Click(object sender, EventArgs e)
        {
           
            User_Login_class baglantı=new User_Login_class();
            baglantı.username = textBox1.Text;
            baglantı.password=textBox2.Text;
            baglantı.membership=label3.Text;
            baglantı.Users_Login();
            Seller_Management seller = new Seller_Management();
            seller.label1.Text=textBox1.Text;
            seller.Show();
            this.Hide();
        }

        private void Üye_ol_Click(object sender, EventArgs e)
        {
            RegisteSeller geciş = new RegisteSeller();
            geciş.Show();
            this.Hide();
        }
    }
}
