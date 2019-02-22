using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class HibasSzamlaszamException : Exception
    {
        public HibasSzamlaszamException(string szamlaszam)
            :base("Hibás számlaszám: " + szamlaszam)
        {
            
        }
    }
}
