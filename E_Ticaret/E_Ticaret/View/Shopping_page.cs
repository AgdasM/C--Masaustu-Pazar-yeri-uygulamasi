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
    public partial class Shopping_page : Form
    {
        public Shopping_page()
        {
            InitializeComponent();
        }
        
        private void Sipariş_sayfası_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text == null)
                {
                    MessageBox.Show("Lütfen Balance değeri giriniz..");
                     
                }
                int balance = int.Parse(textBox7.Text);
                Ürün_Listele a = new Ürün_Listele();
                a.SqlSorgu="select * from Sale_tbl where Price < '"+balance+"' ";
                DataSet ds = a.Listele();
                dataGridView1.DataSource=ds.Tables["Sale_tbl"];
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            
        }
        private int Buy(int ID)
        {
            try
            {
                int a = 0;
                SqlConnection baglantı = new SqlConnection(SQLBaglantı.baglantıAdresi);
                string sqlsorgu = "delete from Sale_tbl where ID=@ID";
                SqlCommand komut = new SqlCommand(sqlsorgu, baglantı);
                komut.Parameters.AddWithValue("@ID", ID);
                baglantı.Open();
                a =komut.ExecuteNonQuery();
                baglantı.Close();
                return a;
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            
        }
        int balance = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            foreach (DataGridViewRow draw   in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(draw.Cells[0].Value);
                balance = Convert.ToInt32(draw.Cells[2].Value)+balance;
                a =Buy(id);
            }
            if ( a==1)
            {
                MessageBox.Show("İşlem Başalı..");
            }
            else
            {
                MessageBox.Show("İşlem Bşarısız..");
            }
            try
            {
                Ürün_Listele list = new Ürün_Listele();
                list.SqlSorgu="select * from Sale_tbl";
                DataSet ds = list.Listele();
                dataGridView1.DataSource=ds.Tables["Sale_tbl"];
                label4.Text=balance.ToString();
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            
        }
    }
}
