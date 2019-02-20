using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeslekiIngSinav
{
    class SoruIslem
    {
        public  string soru, silinen;
        public  int puan = 0;
        VeriIletisim veri = new VeriIletisim();
        public string SoruVer()
        {
            string Cumle = veri.CumleVer();
            string[] parcali = Cumle.Split(' ');
            Random rnd = new Random();
            int silinecek = rnd.Next(parcali.Length - 1);
            while (parcali[silinecek].Length < 3) silinecek = rnd.Next(parcali.Length - 1);
            silinen = parcali[silinecek];
            parcali[silinecek] = "........";
            string sonuc = "";
            int sayac = 0;
            foreach (string item in parcali)
            {
                if (sayac % 4 == 0) sonuc += "\n";
                sonuc += item+" ";
                sayac++;
            }
            return sonuc;
        }
    }
}
