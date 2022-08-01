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
using E_Ticaret;

namespace E_Ticaret
{
    public partial class BuyerLogin : Form
    {
        public BuyerLogin()
        {
            InitializeComponent();
        }
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Login_class baglantı = new User_Login_class();
            baglantı.username = textBox1.Text;
            baglantı.password=textBox2.Text;
            baglantı.membership=label3.Text;
            baglantı.Users_Login();
            Shopping_page gecis = new Shopping_page();
            gecis.label2.Text=textBox1.Text;
            gecis.Show();
            this.Hide();

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SellerLogin geciş = new SellerLogin();
            geciş.Show();
            this.Hide();
        }

        private void Üye_ol_Click(object sender, EventArgs e)
        {
            RegisterBuyer gecis = new RegisterBuyer();
            gecis.Show();
            this.Hide();
        }
    }
}
