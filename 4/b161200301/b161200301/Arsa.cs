using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b161200301
{
    class Arsa:Emlak
    {
        public int IDs()
        {
            if (Veriler.larsa.Count == 0)
                return ID;
            else return Veriler.larsa.Max(i => ID);
        }
        public void arsaEkle(string metrekare, string adsoyad, string telNo, string ucret, string kira)
        {
            this.ID = IDs()+1;
            this.adSoyad = adsoyad;
            this.Metrekare = metrekare;
            this.TelNo = telNo;
            this.Ucret = ucret;
            this.Kira = kira;
        }
       public void arsaGuncelle(int id,string metrekare, string adsoyad,string telNo,string ucret,string kira)
        {
            this.ID = id=0;
            this.adSoyad = adsoyad;
            this.Metrekare = metrekare;
            this.TelNo = telNo;
            this.Ucret = ucret;
            this.Kira = kira;
        }
    }
}
