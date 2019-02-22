using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.test
{
    [TestFixture]
    public class BankTeszt
    {
        [Test]
        public void UjSzamlaEgyenlegNulla() {
            Bank b = new Bank();
            b.UjSzamla("Tesztnév","1234");
            Assert.AreEqual(0,b.Egyenleg("1234"));
        }

        [Test]
        public void PenzBetesz() {
            Bank b = new Bank();
            b.UjSzamla("Tesztnév", "1234");
            b.EgyenlegFeltolt("1234",5000);

            Assert.AreEqual(5000, b.Egyenleg("1234"));
        }

        [Test]
        public void TestSikertelenulUtalas() {
            Bank b = new Bank();
            b.UjSzamla("Tesztnév", "1234");
            b.UjSzamla("Tesztnév2", "5678");
            var sikeres = b.Utal("1234", "5678", 10000);

            Assert.AreEqual(0, b.Egyenleg("1234"));
            Assert.AreEqual(0, b.Egyenleg("5678"));
            Assert.IsFalse(sikeres);
        }

        [Test]
        public void UtalasNemLetezoSzamlara() {
            Bank b = new Bank();
            b.UjSzamla("Tesztnév", "1234");
            b.UjSzamla("Tesztnév2", "5678");
            var sikeres = b.Utal("1234", "9999", 10000);

            Assert.AreEqual(0, b.Egyenleg("1234"));
            Assert.AreEqual(0, b.Egyenleg("5678"));
            Assert.IsFalse(sikeres);
        }

        [Test]
        public void NemLetezoSzamlaEgyenleg() {
            Bank b = new Bank();
            Assert.Throws<HibasSzamlaszamException>( () => { var egyenleg = b.Egyenleg("1234"); } );
            
        }
    }
}
