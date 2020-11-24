using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b161200301
{
     class Emlak
    {
        private int id = 0;
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        private string adsoyad=null;
        public string adSoyad
        {
            set { adsoyad = value; }
            get { return adsoyad; }
        }
        private string tel=null;
        public string TelNo
        {
            set { tel = value; }
            get { return tel; }
        }
        private string ucret = null;
        public string Ucret
        {
            set { ucret = value; }
            get { return ucret; }
        }
        private string kira = null;
        public string Kira
        {
            set { kira = value; }
            get { return kira; }
        }
        private string metre=null;
        public string Metrekare
        {
            set { metre = value; }
            get { return metre; }
        }
        private string salon=null;
        public string salonOda
        {
            set { salon = value; }
            get { return salon; }
        }
        private int balkon=0;
        public int Balkon
         {
            set { balkon = value; }
            get { return balkon; }
        }
        private string banyo=null;
        public string Banyo
        {
            set { banyo = value; }
            get { return banyo; }
        }
        private int kat=0;
        public int Kat
        {
            set { kat = value; }
            get { return kat; }
        }
        private int daire=0;
        public int daireSay
        {
            set { daire = value; }
            get { return daire; }
        }


    }
}
