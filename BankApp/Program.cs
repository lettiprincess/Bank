using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Bank b = new Bank();
            b.UjSzamla("Béla","1111");
            b.UjSzamla("John", "2222");
            b.Utal("1234", "1111",10000);
            Console.WriteLine(b.Egyenleg("1234"));
            Console.WriteLine(b.Egyenleg("1111"));

            Console.ReadLine();

        }
    }
}
