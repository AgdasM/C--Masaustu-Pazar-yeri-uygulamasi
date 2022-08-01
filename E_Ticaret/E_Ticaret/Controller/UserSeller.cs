using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret
{
    public class UserSeller:User
    {
        
        public int Price { get; set; }
        public string Product { get; set; }
        public string Tax_Number { get; set; }


    }
}
