/************************************************************
**				   SAKARYA ÜNİVERİSTESİ                   
**		BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ        
**		 BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ          
**		    NESNEYE DAYALI PROGRAMLAMA DERSİ                   
**			    2017-2018 BAHAR DÖNEMİ                     
**                                                       
**		    ÖDEV NUMARASI.........: 1                
**		   	ÖĞRENCİ ADI...........: KÜBRA KISMET     
**			ÖĞRENCİ NUMARASI......: B161200301       
**                                                       
************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//dosya islemleri icin kütüphane
namespace b161200301
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) { } 
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e)
        {
           FileStream dosyayaz = new FileStream("veriler.txt", FileMode.Append);
           StreamWriter dosya = new StreamWriter(dosyayaz);    
            string ad, soyad,tel;
            ad = textBox1.Text;
            soyad = textBox2.Text;
            tel =textBox4.Text;

            if (radioButton10.Checked) dosya.Write('k');
            else if (radioButton2.Checked) dosya.Write('m');
            else if (radioButton3.Checked) dosya.Write('y');

            if (radioButton4.Checked) dosya.Write('k');
            else if (radioButton5.Checked) dosya.Write('m');
            else if (radioButton6.Checked) dosya.Write('y');

            if (radioButton7.Checked) dosya.Write('k');
            else if (radioButton8.Checked) dosya.Write('m');
            else if (radioButton9.Checked) dosya.Write('y');

            dosya.WriteLine(" " + ad + " " + soyad + " " + tel);
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            dosya.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FileStream dosyaoku = new FileStream("veriler.txt", FileMode.Open,FileAccess.Read);
            StreamReader oku = new StreamReader(dosyaoku); 
            string yazi = oku.ReadLine();
            int font = 0;
            while (yazi != null) 
            {
                string[] satirlar = yazi.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); //dizi bölme secenekleri boşluk girilene kadar
                for(int i=0;i<satirlar.Length;i++)
                { 
                string satir = satirlar[i];
                StringOkumaYardimcisi yardimci = new StringOkumaYardimcisi(satir);
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < 3; j++)
                    sb.Append(yardimci.KarakterOku());

                RenkSaglayici renkSaglayici = new RenkSaglayici(sb.ToString());
                bool satirBasi = true;
                while (!yardimci.SonaErisildi)
                {
                    if (!satirBasi)
                    {
                        richTextBox1.AppendText(" ");
                        richTextBox1.Select(0, 0);
                    }
                    else
                        satirBasi = false;
                    yardimci.BosluklariAtla();
                    int baslangic = richTextBox1.Text.Length;
                    string metin = yardimci.BoslugaKadarOku();
                    int uzunluk = metin.Length;
                    richTextBox1.AppendText(metin);
                    richTextBox1.Select(baslangic, uzunluk);
                    richTextBox1.SelectionColor = renkSaglayici.RenkVer();
                }
                if (i < satirlar.Length - 1)
                    richTextBox1.AppendText(Environment.NewLine);
                }
                if (font % 2 == 0)
                {
                    richTextBox1.SelectionFont = new Font("Arial", 8, FontStyle.Bold);
                    richTextBox1.AppendText(Environment.NewLine);
                }
                else
                    richTextBox1.AppendText(Environment.NewLine);

                font++;
                yazi = oku.ReadLine();
            }
            oku.Close();
        }
        class RenkSaglayici
        {
            Color[] colors;
            int sayac = 0;
            int bolen = 1;

            public RenkSaglayici(string renkKodu) : this(renkKoduCoz(renkKodu)) { }

            private static Color[] renkKoduCoz(string renkKodu)
            {
                if (renkKodu.Length == 3)
                {
                    Color[] sonuc = new Color[3];
                    int i = 0;
                    foreach (char kod in renkKodu)
                    {
                        switch (kod)
                        {
                            case 'k': sonuc[i] = Color.Red;   break;
                            case 'm': sonuc[i] = Color.Blue;  break;
                            case 'y': sonuc[i] = Color.Green; break;
                            default:  throw new Exception("Desteklenmeyen renk kodu");
                        }
                        i++;
                    }  return sonuc;
                }
                else
                    throw new Exception("Desteklenmeyen renk kodu");
            }
            public RenkSaglayici(Color[] colors)
            {
                if (colors == null)
                    this.colors = colors = new Color[3] { Color.Red, Color.Blue, Color.Green };
                else
                    this.colors = colors;
                this.bolen = colors.Length;
            }
            public Color RenkVer()
            {
                Color sonuc = colors[sayac];
                sayac++;
                sayac = sayac % bolen;
                return sonuc;
            }
        }
        class StringOkumaYardimcisi
        {
            private string metin;
            public bool SonaErisildi { get; private set; }
            public int Index { get; private set; }

            public StringOkumaYardimcisi(string okunacakMetin)
            {  this.metin = okunacakMetin;  }
            public char Gozetle()//metnin index bakıyor sadece arttırım yok
            { return metin[Index]; }

            public char KarakterOku()
            {
                if (SonaErisildi)
                    return default(char);
                char sonuc = metin[Index];
                Index++;
                if (Index == metin.Length)//sona erişildi mi
                    SonaErisildi = true;
                return sonuc;
            }
            public string BoslugaKadarOku()
            {
                StringBuilder sb = new StringBuilder();

                while (!SonaErisildi)
                {
                    char c = Gozetle();
                    if (char.IsWhiteSpace(c))//whitespace boşluk
                        break;
                    else
                        sb.Append(KarakterOku());
                }
                return sb.ToString();
            }
            public void BosluklariAtla()
            {
                while (!SonaErisildi)
                {
                    char c = Gozetle();
                    if (char.IsWhiteSpace(c))
                        KarakterOku();
                    else break;
                }
            }           
        }

    }
}
