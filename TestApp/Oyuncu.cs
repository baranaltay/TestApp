using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Oyuncu
    {
        public Oyuncu()
        {

        }

        public Oyuncu(Okey _oyun)
        {
            Taslar = _oyun.Taslar.Take(14).ToList();
            _oyun.Taslar.RemoveRange(0, 14);
        }

        public List<Tas> Taslar { get; set; }
    }
}
