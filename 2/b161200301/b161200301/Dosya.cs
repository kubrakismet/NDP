using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace b161200301
{
    class Dosya
    {
        private const string dosyaAdi = "veriler.txt";

        private readonly List<Satir> satirlar = new List<Satir>();
        public ReadOnlyCollection<Satir> Satirlar { get; private set; }

        private Dosya() 
        {
            Satirlar = new ReadOnlyCollection<Satir>(satirlar); //ReadOnly Collection, yalnızca okunabilir collection anlamına geliyor.readonly yaptık, bir kere oluştuktan sonra ezilemez.
                                                               //Satirlar ise public ve ReadOnly Collection olduğu için Add, Clear vb metotları yok, sadece gizlediğimiz listedeki değerlerin okunmasını sağlıyor.
        }
        public static Dosya YeniDosyaYarat() // bu factory metot, amaç random sayı ile dosya yaratmak
        {
            Dosya dosya = new Dosya();
            Random r = new Random();
            int satirSayisi = RandomUretici.GetInstance().Next(App.MinSatirSayisi, App.MaxSatirSayisi); //RandomUretici sınıfının static GetInstance() metotu ile üretilmiş tek örneğiini alıyor ve onun next metotunu kullanıyoruz.
            for (int i = 0; i < satirSayisi; i++)                                                       //random sayı üretmek için bu sınıftan üretmeye gerek yok. o yüzden singleton şablonunu kullandık. dosya üret dediğimizde, satırlar da üretiliyor.
                dosya.satirlar.Add(Satir.RandomSayilarlaYarat());
            return dosya;
        }
        public static Dosya KayitliDosyayiAc(out string error) //diskten dosya okumak.
        {
            string icerik = null;
            try
            {
                icerik = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + dosyaAdi);
                error = null;
                string[] satirlar = icerik.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                Dosya dosya = new Dosya(); 
                foreach (string satirStr in satirlar)
                    dosya.satirlar.Add(Satir.DosyadanSatirYarat(satirStr));
                return dosya;
            }
            catch (Exception e)
            {
                error = e.ToString();
                return null;
            }
        }
        public bool Kaydet(out string error)
        {
            StringBuilder icerik = new StringBuilder();
            foreach (Satir item in Satirlar)
                icerik.Append(item.SatirMetniYarat()).Append(Environment.NewLine); //her satır kendini metne çevirmeyi biliyor. yeni satır ile birlikte dosyayı yazdırıyoruz.
            try
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + dosyaAdi, icerik.ToString());
                error = null;
                return true;
            }
            catch (Exception e)
            {
                error = e.ToString();
                return false;
            }
        }
    }
}
