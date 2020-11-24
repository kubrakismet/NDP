using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b161200301
{
    class Apartman:Emlak
    {
        public void apartmanGuncelle(int id, string metrekare, string adsoyad, string telNo, string ucret, string kira, int balkon, int daire, string salon)
        {
            this.ID = id = 0;
            this.adSoyad = adsoyad;
            this.Metrekare = metrekare;
            this.TelNo = telNo;
            this.Ucret = ucret;
            this.Kira = kira;
            this.Balkon = balkon;
            this.salonOda = salon;
            this.daireSay = daire;
        }
        public void apartmanEkle(string metrekare, string adsoyad, string telNo, string ucret, string kira, int balkon, int daire, string salon)
        {
            this.ID = IDs() + 1;
            this.adSoyad = adsoyad;
            this.Metrekare = metrekare;
            this.TelNo = telNo;
            this.Ucret = ucret;
            this.Kira = kira;
            this.Balkon = balkon;
            this.salonOda = salon;
            this.daireSay = daire;
        }
        public int IDs()
        {
            if (Veriler.lapartman.Count == 0)
                return ID;
            else return Veriler.lapartman.Max(i => ID);
        }
    }
}
