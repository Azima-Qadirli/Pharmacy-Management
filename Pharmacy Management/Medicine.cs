using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management
{
    public class Medicine:Entity
    {
        public Medicine(string name,decimal price,string purpose,string shelf):base(name,price,purpose,shelf)
        {

        }
    }
}
