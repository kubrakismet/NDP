using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace b161200301
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//ekle
        {
            Arsa arsa = new Arsa();
            Apartman apartman = new Apartman();
            Daire daire = new Daire();
            Konut konut = new Konut();
          
            if(comboBox2.SelectedIndex==0)
            {
                arsa.adSoyad = textBox4.Text;
                arsa.TelNo = textBox5.Text;
                arsa.Ucret = textBox6.Text;
                arsa.Metrekare = textBox2.Text;
                if (checkBox1.Checked == true)
                    arsa.Kira = "satılık";
                else arsa.Kira = ("kiralık");
                arsa.arsaEkle(arsa.Metrekare, arsa.TelNo, arsa.adSoyad, arsa.Ucret, arsa.Kira);


                dataGridView1.Rows.Add();
            }
            if (comboBox2.SelectedIndex==1)
            {
                apartman.adSoyad = textBox4.Text;
                apartman.TelNo = textBox5.Text;
                apartman.Ucret = textBox6.Text;
                apartman.Metrekare = textBox2.Text;
                apartman.Balkon = int.Parse(textBox7.Text);
                apartman.daireSay = int.Parse(textBox8.Text);
                apartman.salonOda=textBox3.Text;
                if (checkBox1.Checked == true)
                    apartman.Kira = "satılık";
                else apartman.Kira = "kiralık";
                apartman.apartmanEkle( apartman.Metrekare,apartman.adSoyad, apartman.TelNo, apartman.Ucret,apartman.Kira, apartman.Balkon, apartman.daireSay,apartman.salonOda);
                
                dataGridView1.Rows.Add(Veriler.lapartman);

            }
            if(comboBox2.SelectedIndex==2)
            {
                daire.adSoyad = textBox4.Text;
                daire.TelNo = textBox5.Text;
                daire.Ucret = textBox6.Text;
                daire.Metrekare = textBox2.Text;
                daire.Balkon = int.Parse(textBox7.Text);
                daire.salonOda = textBox3.Text;
                if (checkBox1.Checked == true)
                    daire.Kira = "satılık";
                else daire.Kira ="kiralık";
                if (checkBox2.Checked == true)
                    daire.Banyo = "banyo var";
                else daire.Banyo = "banyo yok";
                daire.daireEkle(daire.Metrekare,daire.adSoyad,daire.TelNo,daire.Ucret,daire.Kira,daire.Balkon,daire.Banyo,daire.salonOda);

                dataGridView1.Rows.Add(Veriler.ldaire);
            }
            if(comboBox2.SelectedIndex==3)
            {
                konut.adSoyad = textBox4.Text;
                konut.TelNo = textBox5.Text;
                konut.Ucret = textBox6.Text;
                konut.Metrekare = textBox2.Text;
                konut.Balkon = int.Parse(textBox7.Text);
                konut.salonOda = textBox3.Text;
                konut.Kat = int.Parse(textBox9.Text);
                if (checkBox1.Checked == true)
                    konut.Kira = "satılık";
                else konut.Kira = "kiralık";
                konut.konutEkle(konut.Metrekare,konut.adSoyad,konut.TelNo,konut.Ucret,konut.Kira,konut.Balkon,konut.Kat,konut.salonOda);

                dataGridView1.Rows.Add(Veriler.lkonut);
            }
        }
        private void button2_Click(object sender, EventArgs e)//sil
        {
          
        }  
        private void button3_Click(object sender, EventArgs e)//değiştir
        {
            
        }
        private void button4_Click(object sender, EventArgs e)//ara
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Arsa");
            comboBox2.Items.Add("Apartman");
            comboBox2.Items.Add("Daire");
            comboBox2.Items.Add("Konut");
        }
    }
}
