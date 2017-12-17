using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Tas : IEquatable<Tas>
    {
        public Tas()
        {

        }

        public Tas(Renkler renk, int sayi, TasTipi tip)
        {
            Renk = renk;
            Sayi = sayi;
            Tip = tip;
        }

        public bool isUsed { get; set; } = false;
        public TasTipi Tip { get; set; }
        public Renkler Renk { get; set; }
        private int _sayi;
        public int Sayi
        {
            get
            {
                return _sayi;
            }
            set
            {
                if (value > 13)
                    value = value - 13;

                if (value < 1)
                    value = value + 13;

                _sayi = value;
            }
        }

        public override string ToString()
        {
            string _isUsed = isUsed ? "Used" : "";
            string _tasState = Tip == TasTipi.okey || Tip == TasTipi.sahteOkey ? Tip.ToString() : "";
            return $"{Renk.ToString()} {Sayi} {_tasState} {_isUsed}";
        }

        public bool Equals(Tas other)
        {
            if (Tip == other.Tip && Renk == other.Renk && Sayi == other.Sayi)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hashTip = Tip.GetHashCode();
            int hashRenk = Renk.GetHashCode();
            int hashSayi = Sayi.GetHashCode();

            return hashTip ^ hashRenk ^ hashSayi;
        }
    }
}
