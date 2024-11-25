using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mayin_Tarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MayinTarlasi MayinTarlamiz;
        List<Mayin> Mayins;
        Image resim = Image.FromFile(@"mayın.jpg");
        int BulunanTemizAlan;
        private void Form1_Load(object sender, EventArgs e)
        {
            yeni_oyun_baslat();
            //MayinlaariGöster();
        }
        private void yeni_oyun_baslat()
        {
            MayinTarlamiz = new MayinTarlasi(new Size(400, 400), 60);
            panel1.Size = MayinTarlamiz.Buyuklugu;
            BulunanTemizAlan = 0;
            MayinEKle();
        }
        public void MayinEKle()
        {
            for (int x = 0; x < panel1.Width; x = x + 20)
            {
                for (int y = 0; y < panel1.Height; y = y + 20)
                {
                    ButonEkle(new Point(x, y));
                }
            }
        }
        public void ButonEkle(Point K)
        {
            Button btu = new Button();
            btu.Name = K.X +"" + K.Y ;
            btu.Size = new Size(20, 20);
            btu.Location = K;
            btu.Click += new EventHandler(Buton_click);
            btu.MouseUp += new MouseEventHandler(btu_MouseUp);
            panel1.Controls.Add(btu);
        }
        void btu_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = (sender as Button);
            if (e.Button == MouseButtons.Right)
            {
                btn.Text = "!";

            }
        }
        public void Buton_click(object sender,EventArgs e)
        {
            Button btn = (sender as Button);
            Mayin mayin = MayinTarlamiz.MayinAlKonuma(btn.Location);
            Mayins = new List<Mayin>();
            if (mayin.MayinVarMi)
            {
                MessageBox.Show("Kaybettiniz");
                MayinlaariGöster();
            }
            else
            {
                int x = EtraftakiMayinSayisi(mayin);
                if ( x == 0)
                {
                    Mayins.Add(mayin);
                    for (int i = 0; i < Mayins.Count; i++)
                    {
                        Mayin mayinn = Mayins[i];
                        if (mayinn != null)
                        {
                            if (mayinn.Bakildi == false&&mayinn.MayinVarMi==false)
                            {
                                Button button = (Button)panel1.Controls.Find(mayinn.KonumAl.X + "" + mayinn.KonumAl.Y, false)[0];
                                if (EtraftakiMayinSayisi(Mayins[i]) == 0)
                                {
                                    button.Enabled = false;
                                    CevredekileriListeyeEkle(mayinn);
                                }
                                else
                                {
                                    button.Text = EtraftakiMayinSayisi(mayinn).ToString();
                                }
                                BulunanTemizAlan++;
                                mayinn.Bakildi = true;
                            }
                        }
                    }
                }
                else
                {
                    btn.Text = x.ToString();
                    BulunanTemizAlan++;
                }
            }
            if (BulunanTemizAlan >= MayinTarlamiz.ToplamAlan - MayinTarlamiz.ToplamMayinSayisi)
            {
                MessageBox.Show("Kazandınız");
            }

        }
        public int EtraftakiMayinSayisi(Mayin mayin)
        {
            int sayi = 0;
            if (mayin.KonumAl.X > 0)
            {
                if (MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X - 20, mayin.KonumAl.Y)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (mayin.KonumAl.Y > 0)
            {
                if (MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X, mayin.KonumAl.Y - 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (mayin.KonumAl.X > 0 && mayin.KonumAl.Y > 0)
            {
                if (MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X - 20, mayin.KonumAl.Y - 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (mayin.KonumAl.Y < panel1.Height - 20)
            {
                if (MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X, mayin.KonumAl.Y + 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (mayin.KonumAl.X < panel1.Width - 20)
            {
                if (MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X + 20, mayin.KonumAl.Y)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (mayin.KonumAl.X <panel1.Width - 20 && mayin.KonumAl.Y < panel1.Height - 20)
            {
                if (MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X + 20, mayin.KonumAl.Y + 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (mayin.KonumAl.X > 0 && mayin.KonumAl.Y < panel1.Height - 20)
            {
                if (MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X - 20, mayin.KonumAl.Y + 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (mayin.KonumAl.X > panel1.Width - 20 && mayin.KonumAl.Y > 0)
            {
                if (MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X + 20, mayin.KonumAl.Y - 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            return sayi;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            yeni_oyun_baslat();
        }
        public void CevredekileriListeyeEkle(Mayin mayin)
        {
            bool k1 = false;
            bool k2 = false;
            bool k3 = false;
            bool k4 = false;
            if (mayin.KonumAl.X > 0)
            {
                Mayins.Add(MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X - 20, mayin.KonumAl.Y)));
                k1 = true;
            }
            if (mayin.KonumAl.Y > 0)
            {
                Mayins.Add(MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X , mayin.KonumAl.Y - 20)));
                k2 = true;
            }
            if (mayin.KonumAl.X < panel1.Width)
            {
                Mayins.Add(MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X + 20, mayin.KonumAl.Y)));
                k3 = true;
            }
            if (mayin.KonumAl.Y < panel1.Height)
            {
                Mayins.Add(MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X , mayin.KonumAl.Y + 20)));
                k4 = true;
            }
            if (k1 && k2)
            {
                Mayins.Add(MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X - 20, mayin.KonumAl.Y - 20)));
            }
            if (k2 && k3)
            {
                Mayins.Add(MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X + 20, mayin.KonumAl.Y - 20)));
            }
            if (k2 && k4)
            {
                Mayins.Add(MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X + 20, mayin.KonumAl.Y + 20)));
            }
            if (k1 && k4)
            {
                Mayins.Add(MayinTarlamiz.MayinAlKonuma(new Point(mayin.KonumAl.X - 20, mayin.KonumAl.Y + 20)));
            }
        }
        public void MayinlaariGöster()
        {
            foreach (Mayin item in MayinTarlamiz.GetMayins)
            {
                if (item.MayinVarMi)
                {
                    Button btn = (Button)panel1.Controls.Find(item.KonumAl.X + "" + item.KonumAl.Y, false)[0];
                    btn.BackgroundImage = resim;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                panel1.Controls.Clear();
                yeni_oyun_baslat();
        }
    }
    public class Mayin
    {
        Point Konum;
        bool dolu;
        bool bakildi;
        public Mayin(Point k)
        {
            dolu = false;
            Konum = k;
        }
        public Point KonumAl
        {
            get { return Konum; }
        }
        public bool MayinVarMi
        {
            get { return dolu; }
            set { dolu = value; }
        }
        public bool Bakildi
        {
            get { return bakildi; }
            set { bakildi = value; }
        }
    }
    public class MayinTarlasi
    {
        Size Buyukluk;
        List<Mayin> Mayinlar;
        int DoluMayinSayisi;
        Random random = new Random();
        public MayinTarlasi (Size buyukluk,int mayinsayisi)
        {
            DoluMayinSayisi = mayinsayisi;
            Buyukluk = buyukluk;
            Mayinlar = new List<Mayin>();
            for (int x = 0; x < buyukluk.Width; x=x+20)
            {
                for (int y = 0; y < buyukluk.Height; y=y+20)
                {
                    Mayin mayin = new Mayin(new Point(x, y));
                    MayinEkle(mayin);
                }
            }
            MayinlariDoldur();
        }
        public Size Buyuklugu
        {
            get
            {
                return Buyukluk;
            }
        }
        public void MayinEkle(Mayin m)
        {
            Mayinlar.Add(m);
        }
        
        public Mayin MayinAlKonuma(Point Konum)
        {
            foreach (Mayin item in Mayinlar)
            {
                if (item.KonumAl == Konum)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Mayin> GetMayins
        {
            get { return Mayinlar; }
        }
        private void MayinlariDoldur()
        {
            int sayi = 0;
            while (sayi<DoluMayinSayisi)
            {
                int i = random.Next(0, Mayinlar.Count);
                Mayin item = Mayinlar[i];
                if (item.MayinVarMi == false)
                {
                    item.MayinVarMi = true;
                    sayi++;
                }
            }
        }
        public int ToplamMayinSayisi
        {
            get
            {
                return DoluMayinSayisi;
            }
        }
        public int ToplamAlan
        {
            get
            {
                return (Buyukluk.Width * Buyukluk.Height) / 400;
            }
        }
    }
}
