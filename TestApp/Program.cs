
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Okey _oyun = Okey.YeniBasla();

            Dictionary<Oyuncu, int> _puanlama = new Dictionary<Oyuncu, int>();

            foreach (Oyuncu oyuncu in _oyun.Oyuncular)
            {
                int _puan = Analyzer.Analyze(oyuncu);
                _puanlama.Add(oyuncu, _puan);
            }

            //Ekrana yazdir
            Console.WriteLine("Puanlar: \n");
            Console.WriteLine($"Gösterge: {_oyun.Gosterge.ToString()} \n");

            int _oyuncuSayisi = 1;
            foreach (var puan in _puanlama)
            {
                Console.Write("------");
                Console.Write($"Oyuncu {_oyuncuSayisi} ({puan.Key.Taslar.Count} taş): {puan.Value} puan");
                Console.WriteLine("------");

                foreach (var tas in puan.Key.Taslar)
                {
                    Console.WriteLine($"{tas.ToString()}");
                }
                
                _oyuncuSayisi++;
            }
            //Ekrana yazdir
            Console.ReadKey();
        }
    }
}
