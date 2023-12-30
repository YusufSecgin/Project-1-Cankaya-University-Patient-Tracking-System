using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fatih_Çelih
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("ID", 100); //bu kelime uzunlugu olarak kaç harf olacagını belırleyen kod
            listView1.Columns.Add("Ad-Soyad", 100);
            listView1.Columns.Add("Numara", 100);
            listView1.Columns.Add("Tc", 100);
            listView1.Columns.Add("Doktoru", 100);

            listView2.View = View.Details;
            listView2.Columns.Add("ID", 100);
            listView2.Columns.Add("Ad-Soyad", 100);
            listView2.Columns.Add("Numara", 100);
            listView2.Columns.Add("Tc", 100);
            listView2.Columns.Add("Reçetesi", 100);
            listView2.Columns.Add("Doktoru", 100);
            listView2.Columns.Add("Tanısı", 100);

            comboBox3.Items.Add("Ahmet");
            comboBox3.Items.Add("Ayşe");
            comboBox3.Items.Add("Mehmet");

            comboBox4.Items.Add("Ahmet");
            comboBox4.Items.Add("Ayşe");
            comboBox4.Items.Add("Mehmet");
        }

        int sayac = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            sayac++; // sayaç id yerine kullanılıyor
            string ad = Convert.ToString(textBox1.Text); // tetboxdan veri alıp ad değişkenine atadı.
            string numara = Convert.ToString(textBox2.Text);
            string tc = Convert.ToString(textBox3.Text);

           

            ListViewItem veriekle = new ListViewItem(new[] { sayac.ToString(), ad, numara, tc, comboBox3.SelectedItem.ToString() });// list içine verileri ekler
            listView1.Items.Add(veriekle); //list içine girdiğimiz verileri kayıt eder

            comboBox1.Items.Add(tc); // tcler combovoxa eklendi.
            comboBox2.Items.Add(tc);
        }

        string combotutucu;
        private void button2_Click(object sender, EventArgs e)
        {
            string secilenhastatc=""; int combodegersil; string yazilanhastatc=""; bool deger=false; int combodegersil2;
            
            if (comboBox1.SelectedIndex != -1)
            {
               secilenhastatc = comboBox1.SelectedItem.ToString(); deger = true;
            }// seçilen hastayı değişkene ata
            else  yazilanhastatc = comboBox1.Text; 
            ListViewItem hasta = null; // hastaya ailt listeyi boşalt
            ListViewItem recete = null;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    hasta = item;
                    break;
                }
            }

            if (hasta != null)
            {
               
                string ad = Convert.ToString(textBox4.Text);
                string numara = Convert.ToString(textBox5.Text);
                string tc = Convert.ToString(textBox6.Text);

                hasta.SubItems[1].Text = ad;
                hasta.SubItems[2].Text = numara;
                hasta.SubItems[3].Text = tc;
                hasta.SubItems[4].Text = comboBox4.SelectedItem.ToString();
                MessageBox.Show("Hasta Bilgileri Güncellendi", "Başarılı", MessageBoxButtons.OK);
                comboBox1.Items.Add(tc);
                comboBox2.Items.Add(tc);
                if (recete == null)
                {
                    if (comboBox1.SelectedIndex != -1)
                    {
                        combodegersil = comboBox2.FindStringExact(comboBox1.SelectedItem.ToString());
                        comboBox2.Items.RemoveAt(combodegersil);
                    }
                    else
                    {
                        combodegersil = comboBox2.FindStringExact(comboBox1.Text.ToString());
                        comboBox2.Items.RemoveAt(combodegersil);
                    }
                    if (deger==true)
                    {
                        comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex != -1)
                        {
                            combodegersil2 = comboBox1.FindStringExact(comboBox1.SelectedItem.ToString());
                            comboBox1.Items.RemoveAt(combodegersil2);
                        }
                        else
                        {
                            combodegersil2 = comboBox1.FindStringExact(comboBox1.Text.ToString());
                            comboBox1.Items.RemoveAt(combodegersil2);
                            comboBox1.Text = "";
                        }

                        }
                }
            }
            else
            {
                MessageBox.Show("Hasta Güncellenemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    recete = item;
                    break;
                }
            }
            if (recete != null)
            {

                string ad = Convert.ToString(textBox4.Text);
                string numara = Convert.ToString(textBox5.Text);
                string tc = Convert.ToString(textBox6.Text);
                recete.SubItems[1].Text = ad;
                recete.SubItems[2].Text = numara;
                recete.SubItems[3].Text = tc;
                recete.SubItems[5].Text = hasta.SubItems[4].Text;
               
            }
        }
        string ad; string numara; string tc;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenhastatc = comboBox1.SelectedItem.ToString();
            string yazilanhastatc = comboBox1.Text;
            ListViewItem hasta = null;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    hasta = item;
                    break;
                }
            }

            if (hasta != null)
            {

                ad = hasta.SubItems[1].Text;
                numara = hasta.SubItems[2].Text;
                tc = hasta.SubItems[3].Text;
                

            }
         textBox4.Text =Convert.ToString(ad);    
         textBox5.Text =Convert.ToString(numara);    
         textBox6.Text =Convert.ToString(tc);    

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        int resayac = 0;
        bool recetevarmi = false;
        private void button3_Click(object sender, EventArgs e)
        {
            resayac++; string secilenhastatc = ""; string yazilanhastatc = ""; 
            if (comboBox2.SelectedIndex!=-1)
            {
                secilenhastatc = comboBox2.SelectedItem.ToString();
            }
            else yazilanhastatc = comboBox2.Text;
            ListViewItem hasta = null;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    hasta = item;
                    break;
                }
            }

            if (hasta != null)
            {
                recetevarmi = true;
                string ad = hasta.SubItems[1].Text;
                string numara = hasta.SubItems[2].Text;
                string tc = hasta.SubItems[3].Text;
                string recete=Convert.ToString(textBox7.Text);
                ListViewItem veriekle2 = new ListViewItem(new[] { resayac.ToString(), ad, numara, tc, recete, hasta.SubItems[4].Text,"" });
                listView2.Items.Add(veriekle2);
                MessageBox.Show("Receçe Başarıyla yazıldı", "Başarılı", MessageBoxButtons.OK);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string yazilanhastatc = ""; string secilenhastatc = "";
            if (comboBox2.SelectedIndex != -1)
            {
                secilenhastatc = comboBox2.SelectedItem.ToString();
            }
            else yazilanhastatc = comboBox2.Text;
            ListViewItem hasta = null;
            ListViewItem yhasta = null;
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    hasta = item;
                    break;
                }
            }
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                   yhasta = item;
                    break;
                }
            }


            if (hasta != null)
            {

               
                string grecete = Convert.ToString(textBox8.Text);
                hasta.SubItems[4].Text = grecete;
                hasta.SubItems[5].Text = yhasta.SubItems[4].Text;
                MessageBox.Show("Hasta reçetesi Güncellendi", "Başarılı", MessageBoxButtons.OK);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string yazilanhastatc = ""; string secilenhastatc = "";
            if (comboBox2.SelectedIndex != -1)
            {
                secilenhastatc = comboBox2.SelectedItem.ToString();
            }
            else yazilanhastatc = comboBox2.Text;
            ListViewItem hasta = null;
            ListViewItem yhasta = null;
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    hasta = item;
                    break;
                }
            }
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    yhasta = item;
                    break;
                }
            }


            if (hasta != null)
            {

                hasta.SubItems[5].Text = yhasta.SubItems[4].Text;
                hasta.SubItems[6].Text = textBox9.Text;
                MessageBox.Show("Hastaya Tanı Koyuldu", "Başarılı", MessageBoxButtons.OK);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string yazilanhastatc = ""; string secilenhastatc = "";
            if (comboBox2.SelectedIndex != -1)
            {
                secilenhastatc = comboBox2.SelectedItem.ToString();
            }
            else yazilanhastatc = comboBox2.Text;
            ListViewItem hasta = null;
            ListViewItem yhasta = null;
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    hasta = item;
                    break;
                }
            }
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[3].Text == secilenhastatc || item.SubItems[3].Text == yazilanhastatc)
                {
                    yhasta = item;
                    break;
                }
            }


            if (hasta != null)
            {


                string tani = Convert.ToString(textBox10.Text);
                hasta.SubItems[6].Text = tani;
                MessageBox.Show("Hastanın tanısı Güncellendi", "Başarılı", MessageBoxButtons.OK);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            int c1 = comboBox2.FindStringExact(comboBox1.SelectedItem.ToString());
            comboBox2.Items.RemoveAt(c1);
            comboBox1.Items.RemoveAt(c1);
            comboBox2.Text = ""; comboBox1.Text = "";
            listView1.Items.RemoveAt(selectedIndex);
            if (recetevarmi==true)
            {
                listView2.Items.RemoveAt(selectedIndex);
            }
        }
    }
}
