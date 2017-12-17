using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class Analyzer
    {
        private static int siraliSayi = 0;
        private static int renkliSayi = 0;

        public static int Analyze(Oyuncu oyuncu)
        {
            return Sirali(oyuncu) + Renkli(oyuncu);
        }
        private static int Sirali(Oyuncu oyuncu)
        {
            siraliSayi = 0;

            //var _istaka = oyuncu.Taslar
            //    .OrderBy(tas => tas.Renk)
            //    .ThenBy(tas => tas.Sayi)
            //    .ToList();

            //for (int i = 0; i < _istaka.Count - 1; i++)
            //{
            //    if (_istaka[i].Sayi == _istaka[i + 1].Sayi - 1 && _istaka[i].Renk == _istaka[i + 1].Renk)
            //    {
            //        siraliSayi++;
            //    }
            //}

            var _istaka = oyuncu.Taslar
                .Distinct()
                .Where(tas => tas.isUsed == false)
                .OrderBy(tas => tas.Sayi)
                .GroupBy(tas => tas.Renk)
                .Select(tas => tas.ToList())
                .ToList();

            foreach (var liste in _istaka)
            {
                var result = liste.GroupWhile((x, y) => y.Sayi == x.Sayi + 1)
                 .Select(x => x)
                 .ToList();

                foreach (var potansiyelPuanlar in result)
                {
                    //var _okeyTasi = potansiyelPuanlar.FirstOrDefault(tas => tas.isUsed == false && tas.Tip == TasTipi.okey);

                    //if (_okeyTasi != null)
                    //{
                    //    if (potansiyelPuanlar.Count() == 2)
                    //    {
                    //        foreach (var kesinPuanlar in potansiyelPuanlar)
                    //        {
                    //            int _index = liste.FindIndex(tas => tas.isUsed == false && tas.Tip == TasTipi.okey);
                    //            liste.Move(_index, )
                    //        }
                    //    }
                    //}
                    

                    if (potansiyelPuanlar.Count() >= 3)
                    {
                        foreach (var kesinPuanlar in potansiyelPuanlar)
                        {
                            kesinPuanlar.isUsed = true;
                        }
                        siraliSayi += potansiyelPuanlar.Count();
                    }
                }
            }

            return siraliSayi;
        }
        private static int Renkli(Oyuncu oyuncu)
        {
            renkliSayi = 0;

            var _istaka = oyuncu.Taslar
                .Distinct()
                .Where(tas => tas.isUsed == false)
                .GroupBy(tas => tas.Sayi)
                .Select(tas => tas.ToList())
                .ToList();

            foreach (var potansiyelPuanlar in _istaka)
            {
                if (potansiyelPuanlar.Count >= 3)
                {
                    foreach (var kesinPuanlar in potansiyelPuanlar)
                    {
                        kesinPuanlar.isUsed = true;
                    }
                    renkliSayi += potansiyelPuanlar.Count;
                }
            }

            return renkliSayi;
        }


    }
}
