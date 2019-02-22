using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Bank
    {
        class Szamla {
            public string Nev { get; set; }
            public string SzamlaSzam { get; set; }
            public ulong Osszeg { get; set; }

            public Szamla(string nev, string szamlaszam) {
                Nev = nev;
                SzamlaSzam = szamlaszam;
                Osszeg = 0;
            }
        }

        List<Szamla> szamlak = new List<Szamla>();

        internal void EgyenlegFeltolt(string szamlaszam, ulong osszeg)
        {
            Keres(szamlaszam).Osszeg += osszeg;
        }

        public void UjSzamla(string nev, string szamlaSzam) {
            var sz = new Szamla(nev,szamlaSzam);

            szamlak.Add(sz);
        }

        Szamla Keres(string szamlaszam) {
            foreach (var sz in szamlak)
            {
                if (sz.SzamlaSzam.Equals(szamlaszam))
                {
                    return sz;
                }
            }
            throw new HibasSzamlaszamException(szamlaszam);
        }

        public bool Utal(string honnan, string hova, ulong osszeg) {
            var forrasSzamla = Keres(honnan);
            var celSzamla = Keres(hova);

            if (forrasSzamla.Osszeg < osszeg) {
                return false;
            }
            forrasSzamla.Osszeg -= osszeg;
            celSzamla.Osszeg += osszeg;
            return true;
        }

        public ulong Egyenleg(string szamlaszam) {
            return Keres(szamlaszam).Osszeg;
        }
    }
}
