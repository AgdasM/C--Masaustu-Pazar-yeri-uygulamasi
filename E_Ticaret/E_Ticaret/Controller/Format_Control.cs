using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace E_Ticaret
{
    public class Format_Control
    {
        public string TcNo { get; set; }
        public bool PhoneFormatControl(string Telefon)
        {
            string RegexDesen = @"^(05(\d{9}))$";
            Match Eslesme = Regex.Match(Telefon, RegexDesen, RegexOptions.IgnoreCase);
            return Eslesme.Success;
        }
        public void harfkontrol()
        {
            foreach (char item in TcNo)
            {
                if (!char.IsNumber(item))
                {
                    MessageBox.Show("tc kimlik numarası alanına sadece rakam girilebilir");
                    TcNo="";
                }
            }
        }
    }
}
