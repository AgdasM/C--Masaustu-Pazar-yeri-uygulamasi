using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Ticaret
{
    public partial class Seller_Management : Form
    {
        public Seller_Management()
        {
            InitializeComponent();
        }
        Ürün_Ekle ekle = new Ürün_Ekle();
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int kayıtdurumu = 0;

                ekle.UserName=label1.Text;
                ekle.Price=int.Parse(textBox7.Text);
                ekle.Product=textBox8.Text;
                kayıtdurumu= ekle.Ürün_ekle();
                if (kayıtdurumu==1)
                {
                    MessageBox.Show("İşlem Başarılı..");
                    string userst = label1.Text;
                    Ürün_Listele list = new Ürün_Listele();
                    list.SqlSorgu="select * from Sale_tbl where UserName = '"+userst+"'";
                    DataSet ds = list.Listele();
                    dataGridView1.DataSource=ds.Tables["Users_tbl"];

                }
                else
                {
                    MessageBox.Show("İşlem Bşarısız..");
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            
                
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ekle.Price=int.Parse(textBox7.Text);
            label11.Text= ekle.Earning.ToString();
        }

        private void Seller_Management_Load(object sender, EventArgs e)
        {

        }
    }
}
