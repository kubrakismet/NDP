using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b161200301
{
    class Konut:Emlak
    {
        public void konutGuncelle(int id, string metrekare, string adsoyad, string telNo, string ucret, string kira, int balkon, int kat, string salon)
        {
            this.ID = id = 0;
            this.adSoyad = adsoyad;
            this.Metrekare = metrekare;
            this.TelNo = telNo;
            this.Ucret = ucret;
            this.Kira = kira;
            this.Balkon = balkon;
            this.salonOda = salon;
            this.Kat = kat;
        }
        public void konutEkle(string metrekare, string adsoyad, string telNo, string ucret, string kira, int balkon, int kat, string salon)
        {
            this.ID = IDs() + 1;
            this.adSoyad = adsoyad;
            this.Metrekare = metrekare;
            this.TelNo = telNo;
            this.Ucret = ucret;
            this.Kira = kira;
            this.Balkon = balkon;
            this.salonOda = salon;
            this.Kat = kat;
        }
        public int IDs()
        {
            if (Veriler.lkonut.Count == 0)
                return ID;
            else return Veriler.lkonut.Max(i => ID);
        }
    }
}
