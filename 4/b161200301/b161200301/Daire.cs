using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b161200301
{
    class Daire:Emlak
    {
        public void daireGuncelle(int id, string metrekare, string adsoyad, string telNo, string ucret, string kira, int balkon, string banyo, string salon)
        {
            this.ID = id = 0;
            this.adSoyad = adsoyad;
            this.Metrekare = metrekare;
            this.TelNo = telNo;
            this.Ucret = ucret;
            this.Kira = kira;
            this.Balkon = balkon;
            this.salonOda = salon;
            this.Banyo = banyo;
        }
        public void daireEkle(string metrekare, string adsoyad, string telNo, string ucret, string kira, int balkon, string banyo, string salon)
        {
            this.ID = IDs() + 1;
            this.adSoyad = adsoyad;
            this.Metrekare = metrekare;
            this.TelNo = telNo;
            this.Ucret = ucret;
            this.Kira = kira;
            this.Balkon = balkon;
            this.salonOda = salon;
            this.Banyo = banyo;
        }
        public int IDs()
        {
            if (Veriler.ldaire.Count == 0)
                return ID;
            else return Veriler.ldaire.Max(i => ID);
        }
    }
}
