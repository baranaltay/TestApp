using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Okey
    {
        #region Variables
        public List<Tas> Taslar { get; private set; }
        public Tas Gosterge { get; private set; }
        private Tas _okey { get; set; }
        public List<Oyuncu> Oyuncular { get; set; }
        private static readonly Random rnd = new Random();
        #endregion

        #region Methods
        public static Okey YeniBasla()
        {
            Okey _oyun = new Okey();
            _oyun.GetTaslar();
            _oyun.GostergeSec();
            _oyun.Dagit();
            _oyun.OyuncuTaslariSirala();
            return _oyun;
        }
        private void GetTaslar()
        {
            int ToplamTasSayisi = 106;
            List<Tas> _taslar = new List<Tas>(ToplamTasSayisi);

            for (int tasTekrarSayaci = 0; tasTekrarSayaci < 2; tasTekrarSayaci++)
            {
                for (int renkSayisi = 0; renkSayisi < 4; renkSayisi++)
                {
                    Renkler _renk = (Renkler)renkSayisi;
                    for (int tasSayisi = 0; tasSayisi < 13; tasSayisi++)
                    {
                        _taslar.Add(new Tas(_renk, tasSayisi + 1, TasTipi.normal));
                    }
                }
                _taslar.Add(new Tas(Renkler.kirmizi, -1, TasTipi.sahteOkey));
            }

            _taslar.Shuffle();

            Taslar = _taslar;
        }
        private void GostergeSec()
        {
            Renkler _randomRenk = (Renkler)rnd.Next(0, 4);
            int _randomSayi = rnd.Next(1, 14);

            Gosterge = new Tas(_randomRenk, _randomSayi, TasTipi.normal);
            _okey = new Tas(_randomRenk, _randomSayi + 1, TasTipi.normal);

            foreach (Tas _sahteOkey in Taslar.Where(x => x.Tip == TasTipi.sahteOkey)) //sahte okeylerin icinde don
            {
                _sahteOkey.Sayi = Gosterge.Sayi;
                _sahteOkey.Renk = Gosterge.Renk;
            }

            foreach (Tas _okey in Taslar.Where(x => x.Sayi == _okey.Sayi && x.Renk == _okey.Renk))
            {
                _okey.Tip = TasTipi.okey;
            }
        }
        private void Dagit()
        {
            Oyuncular = new List<Oyuncu>();
            for (int oyuncuSayisi = 0; oyuncuSayisi < 4; oyuncuSayisi++)
                Oyuncular.Add(new Oyuncu(this));

            int _randomIndex = rnd.Next(0, 4);

            Tas _fazlalik = Taslar.Take(1).First();
            Taslar.RemoveAt(0);

            Oyuncular[_randomIndex].Taslar.Add(_fazlalik);
        }
        private void OyuncuTaslariSirala()
        {
            for (int i = 0; i < Oyuncular.Count; i++)
            {
                Oyuncular[i].Taslar = Oyuncular[i].Taslar.OrderBy(x => x.Renk).ThenBy(x => x.Sayi).ToList();
            }
        }
        #endregion
    }

}
