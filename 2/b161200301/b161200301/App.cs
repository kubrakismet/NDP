using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b161200301
{
    class App
    {
        public const int MinSatirSayisi = 11;
        public const int MaxSatirSayisi = 99;
        public const int MinX = 500;
        public const int MaxX = 999;
        public const int MinY = 1000;
        public const int MaxY = 1499;
        public const int MinS = 1;
        public const int MaxS = 5;

        public void Basla()
        {
            string err;
            KullaniciGiris kg = null;
            Dosya dosya = Dosya.YeniDosyaYarat();
           
            if (dosya.Kaydet(out err)) 
                Console.WriteLine("Dosya oluşturuldu ve kayıt edildi");
            else
            {
                Console.WriteLine("Dosya oluşturuldu ve kayıt edilemedi:");
                Console.WriteLine(err);
            }
            dosya.Kaydet(out err);
            kg = KullaniciGiris.ConsoleIleYarat();
            dosya = Dosya.KayitliDosyayiAc( out err);
           if(dosya!=null)
            {
                SonucUretici sonuc = new SonucUretici(dosya, kg);
                List<Satir> TekrarEdenSatirlar = sonuc.Bul(out err);
                Console.WriteLine("En fazla tekrar eden 's' değeri için, 's' ve 'fark' listesi: ");
                foreach (Satir item in TekrarEdenSatirlar)
                    Console.WriteLine( item.s+"-"+ item.FormulSonucu);
            }
        }

    }
}
