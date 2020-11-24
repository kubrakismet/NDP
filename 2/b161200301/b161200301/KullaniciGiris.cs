using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b161200301
{
    class KullaniciGiris
    {
        public int X { get; }
        public int Y { get; }
        private KullaniciGiris(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static KullaniciGiris ConsoleIleYarat()
        {
            Console.WriteLine();
            int xInt, yInt;
            Console.Write("Yeni X değeri (500 ile 999 arası): "); string xStr = Console.ReadLine();
            if (!int.TryParse(xStr, out xInt))
            {
                Console.WriteLine("Hatalı bir değer girdiniz");
                return null;
            }
            Console.Write("Yeni Y değeri (1000 ile 1499 arası): "); string yStr = Console.ReadLine();
            if (!int.TryParse(yStr, out yInt))
            {
                Console.WriteLine("Hatalı bir değer girdiniz");
                return null;
            }
            if (degerlerUygunMu(xInt, yInt))
                return new KullaniciGiris(xInt, yInt);
            else
            {
                Console.WriteLine("X değeri {0} ve {1} sayıları arasında, Y değeri {2} ve {3} sayıları arasıdna olmalıdır.", App.MinX, App.MaxX, App.MinY, App.MaxY);
                return null;
            }
        }
        public static KullaniciGiris BilinenDegerlerleYarat(int x, int y)
        {
            if (degerlerUygunMu(x, y))
                return new KullaniciGiris(x, y);
            else
                return null;
        }
        private static bool degerlerUygunMu(int x, int y)
        {
            return (App.MinX <= x && App.MaxX >= x) && (App.MinY <= y && App.MaxY >= y);
        }
    }
}
