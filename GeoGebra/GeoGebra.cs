using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeoGebra
{
    public partial class GeoGebra : Form
    {
        #region Inicijalizacija
        private void GeoGebra_Load(object sender, EventArgs e)
        {
            O = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            k = 1;
            k0 = 1.01;
            l = 7 / k;
            eps = 0.001;
            cnt = 1;
            Korak = 1;
            j1 = -1;
            j2 = -1;
            j3 = -1;
            Tacka.NT = 0;
            Prava.NP = 0;
            Duz.ND = 0;
            Krug.NK = 0;
            for (int i = 0; i < 1000; i++)
            {
                Tacke[i] = null;
                Prave[i] = null;
                Duzi[i] = null;
                Krugovi[i] = null;
                Objekti[4 * i] = null;
                Objekti[4 * i + 1] = null;
                Objekti[4 * i + 2] = null;
                Objekti[4 * i + 3] = null;
            }
            pictureBox1.Image = null;
            duzinaduzitext.Text = "___";
            velicinauglatext.Text = "___";
        }
        #endregion
        #region Promenljive
        public PointF O;
        public double k;
        private double k0;
        private static double l;
        public static double eps;
        public static int Korak;
        private static int cnt;
        private static int j1;
        private static int j2;
        private static int j3;
        private static Tacka B1;
        private static Tacka B2;
        private Tacka[] Tacke = new Tacka[1000];
        private Prava[] Prave = new Prava[1000];
        private Duz[] Duzi = new Duz[1000];
        private Krug[] Krugovi = new Krug[1000];
        private ObjekatInfo[] Objekti = new ObjekatInfo[4000];
        #endregion
        #region Metode
        #region Reset
        public static void Reset(PictureBox pictureBox1, ObjekatInfo[] Objekti)
        {
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                Objekti[i].Oznacen = false;
            pictureBox1.Refresh();
            cnt = 1;
            Korak++;
            j1 = -1;
            j2 = -1;
            j3 = -1;
        }
        #endregion
        #region Undo
        public static void Undo(ObjekatInfo[] Objekti, Tacka[] Tacke, Prava[] Prave, Duz[] Duzi, Krug[] Krugovi, PictureBox pictureBox1, Label duzinaduzitext, Label velicinauglatext)
        {
            if (Tacka.NT + Prava.NP + Duz.ND + Krug.NK == 0)
                return;
            if (cnt != 1)
                Korak++;
            while ((Tacka.NT + Prava.NP + Duz.ND + Krug.NK > 0) && (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak - 1))
            {
                if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Vrsta == 1)
                {
                    Tacke[Tacka.NT - 1] = null;
                    Tacka.NT--;
                    Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK] = null;
                }
                else if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Vrsta == 2)
                {
                    Prave[Prava.NP - 1] = null;
                    Prava.NP--;
                    Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK] = null;
                }
                else if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Vrsta == 3)
                {
                    Duzi[Duz.ND - 1] = null;
                    Duz.ND--;
                    Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK] = null;
                }
                else if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Vrsta == 4)
                {
                    Krugovi[Krug.NK - 1] = null;
                    Krug.NK--;
                    Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK] = null;
                }
            }
            Korak = Math.Max(1, Korak - 1);
            Reset(pictureBox1, Objekti);
            Korak--;
            return;
        }
        #endregion
        #region Označi
        public static void Oznaci(ObjekatInfo[] Objekti, int i, PictureBox pictureBox1)
        {
            Objekti[i].Oznacen = true;
            pictureBox1.Refresh();
            cnt++;
        }
        #endregion
        #region Spawn
        public static void Spawn(Tacka T, Tacka[] Tacke, Prava[] Prave, Duz[] Duzi, Krug[] Krugovi, ObjekatInfo[] Objekti)
        {
            int j = -1;
            double m = double.MaxValue;
            int i11 = NajblizaPrava(T, Prave, Objekti);
            int i12;
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if ((Objekti[i].Vrsta == 2) && (T.Rastojanje(Prave[Objekti[i].Indeks]) < m) && (i != i11) && (Objekti[i].Show))
                {
                    m = T.Rastojanje(Prave[Objekti[i].Indeks]);
                    j = i;
                }
            if (m > l)
                i12 = -1;
            else
                i12 = j;
            j = -1;
            m = double.MaxValue;
            int i21 = NajblizaDuz(T, Duzi, Objekti);
            int i22;
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if ((Objekti[i].Vrsta == 3) && (T.Rastojanje1(Duzi[Objekti[i].Indeks]) < m) && (i != i21) && (Objekti[i].Show))
                {
                    m = T.Rastojanje1(Duzi[Objekti[i].Indeks]);
                    j = i;
                }
            if (m > l)
                i22 = -1;
            else
                i22 = j;
            j = -1;
            m = double.MaxValue;
            int i31 = NajbliziKrug(T, Krugovi, Objekti);
            int i32;
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if ((Objekti[i].Vrsta == 4) && (T.Rastojanje(Krugovi[Objekti[i].Indeks]) < m) && (i != i31) && (Objekti[i].Show))
                {
                    m = T.Rastojanje(Krugovi[Objekti[i].Indeks]);
                    j = i;
                }
            if (m > l)
                i32 = -1;
            else
                i32 = j;
            if (i11 != -1)
            {
                if (i12 != -1)
                {
                    if (Prave[Objekti[i11].Indeks].Presek(Prave[Objekti[i12].Indeks]) != null)
                        DodajTacku(Prave[Objekti[i11].Indeks].Presek(Prave[Objekti[i12].Indeks]), Tacke, Objekti);
                }
                else if (i21 != -1)
                {
                    if (Prave[Objekti[i11].Indeks].Presek(Duzi[Objekti[i21].Indeks]) != null)
                        DodajTacku(Prave[Objekti[i11].Indeks].Presek(Duzi[Objekti[i21].Indeks]), Tacke, Objekti);
                }
                else if (i31 != -1)
                {
                    Tacka[] Tacke1 = new Tacka[2];
                    ObjekatInfo[] Objekti1 = new ObjekatInfo[2];
                    int NTtemp = Tacka.NT;
                    Tacka.NT = 0;
                    int NPtemp = Prava.NP;
                    Prava.NP = 0;
                    int NDtemp = Duz.ND;
                    Duz.ND = 0;
                    int NKtemp = Krug.NK;
                    Krug.NK = 0;
                    Tacke1[0] = null;
                    Objekti1[0] = null;
                    Tacke1[1] = null;
                    Objekti1[1] = null;
                    Prave[Objekti[i11].Indeks].Presek(Krugovi[Objekti[i31].Indeks], Tacke1, Objekti1);
                    Tacka.NT = NTtemp;
                    Prava.NP = NPtemp;
                    Duz.ND = NDtemp;
                    Krug.NK = NKtemp;
                    if (Tacke1[0] == null)
                    {
                        DodajTacku((Prave[Objekti[i11].Indeks].Normala(T)).Presek(Prave[Objekti[i11].Indeks]), Tacke, Objekti);
                        Tacke[NTtemp].Boja = Color.Blue;
                    }
                    else if (Tacke1[1] == null)
                        DodajTacku(Tacke1[0], Tacke, Objekti);
                    else
                    {
                        if (T.Rastojanje(Tacke1[0]) < T.Rastojanje(Tacke1[1]))
                            DodajTacku(Tacke1[0], Tacke, Objekti);
                        else
                            DodajTacku(Tacke1[1], Tacke, Objekti);
                    }
                }
                else
                {
                    DodajTacku((Prave[Objekti[i11].Indeks].Normala(T)).Presek(Prave[Objekti[i11].Indeks]), Tacke, Objekti);
                    Tacke[Tacka.NT - 1].Boja = Color.Blue;
                }
            }
            else if (i21 != -1)
            {
                if (i22 != -1)
                {
                    if (Duzi[Objekti[i21].Indeks].Presek(Duzi[Objekti[i22].Indeks]) != null)
                        DodajTacku(Duzi[Objekti[i21].Indeks].Presek(Duzi[Objekti[i22].Indeks]), Tacke, Objekti);
                }
                else if (i31 != -1)
                {
                    Tacka[] Tacke1 = new Tacka[2];
                    ObjekatInfo[] Objekti1 = new ObjekatInfo[2];
                    int NTtemp = Tacka.NT;
                    Tacka.NT = 0;
                    int NPtemp = Prava.NP;
                    Prava.NP = 0;
                    int NDtemp = Duz.ND;
                    Duz.ND = 0;
                    int NKtemp = Krug.NK;
                    Krug.NK = 0;
                    Tacke1[0] = null;
                    Objekti1[0] = null;
                    Tacke1[1] = null;
                    Objekti1[1] = null;
                    Duzi[Objekti[i21].Indeks].Presek(Krugovi[Objekti[i31].Indeks], Tacke1, Objekti1);
                    Tacka.NT = NTtemp;
                    Prava.NP = NPtemp;
                    Duz.ND = NDtemp;
                    Krug.NK = NKtemp;
                    if (Tacke1[0] == null)
                    {
                        DodajTacku((Duzi[Objekti[i21].Indeks].Normala(T)).Presek(Duzi[Objekti[i21].Indeks]), Tacke, Objekti);
                        Tacke[NTtemp].Boja = Color.Blue;
                    }
                    else if (Tacke1[1] == null)
                        DodajTacku(Tacke1[0], Tacke, Objekti);
                    else
                    {
                        if (T.Rastojanje(Tacke1[0]) < T.Rastojanje(Tacke1[1]))
                            DodajTacku(Tacke1[0], Tacke, Objekti);
                        else
                            DodajTacku(Tacke1[1], Tacke, Objekti);
                    }
                }
                else if ((Duzi[Objekti[i21].Indeks].Normala(T)).Presek(Duzi[Objekti[i21].Indeks]) != null)
                {
                    DodajTacku((Duzi[Objekti[i21].Indeks].Normala(T)).Presek(Duzi[Objekti[i21].Indeks]), Tacke, Objekti);
                    Tacke[Tacka.NT - 1].Boja = Color.Blue;
                }
            }
            else if (i31 != -1)
            {
                if (i32 != -1)
                {
                    Tacka[] Tacke1 = new Tacka[2];
                    ObjekatInfo[] Objekti1 = new ObjekatInfo[2];
                    int NTtemp = Tacka.NT;
                    Tacka.NT = 0;
                    int NPtemp = Prava.NP;
                    Prava.NP = 0;
                    int NDtemp = Duz.ND;
                    Duz.ND = 0;
                    int NKtemp = Krug.NK;
                    Krug.NK = 0;
                    Tacke1[0] = null;
                    Objekti1[0] = null;
                    Tacke1[1] = null;
                    Objekti1[1] = null;
                    Krugovi[Objekti[i31].Indeks].Presek(Krugovi[Objekti[i32].Indeks], Tacke1, Objekti1);
                    Tacka.NT = NTtemp;
                    Prava.NP = NPtemp;
                    Duz.ND = NDtemp;
                    Krug.NK = NKtemp;
                    if (Tacke1[0] == null)
                    {
                        DodajTacku(new Tacka(Krugovi[Objekti[i31].Indeks].Centar.X + (T.X - Krugovi[Objekti[i31].Indeks].Centar.X) * Krugovi[Objekti[i31].Indeks].R / T.Rastojanje(Krugovi[Objekti[i31].Indeks].Centar), Krugovi[Objekti[i31].Indeks].Centar.Y + (T.Y - Krugovi[Objekti[i31].Indeks].Centar.Y) * Krugovi[Objekti[i31].Indeks].R / T.Rastojanje(Krugovi[Objekti[i31].Indeks].Centar), "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Objekti);
                        Tacke[NTtemp].Boja = Color.Blue;
                    }
                    else if (Tacke1[1] == null)
                        DodajTacku(Tacke1[0], Tacke, Objekti);
                    else
                    {
                        if (T.Rastojanje(Tacke1[0]) < T.Rastojanje(Tacke1[1]))
                            DodajTacku(Tacke1[0], Tacke, Objekti);
                        else
                            DodajTacku(Tacke1[1], Tacke, Objekti);
                    }
                }
                else
                {
                    DodajTacku(new Tacka(Krugovi[Objekti[i31].Indeks].Centar.X + (T.X - Krugovi[Objekti[i31].Indeks].Centar.X) * Krugovi[Objekti[i31].Indeks].R / T.Rastojanje(Krugovi[Objekti[i31].Indeks].Centar), Krugovi[Objekti[i31].Indeks].Centar.Y + (T.Y - Krugovi[Objekti[i31].Indeks].Centar.Y) * Krugovi[Objekti[i31].Indeks].R / T.Rastojanje(Krugovi[Objekti[i31].Indeks].Centar), "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Objekti);
                    Tacke[Tacka.NT - 1].Boja = Color.Blue;
                }
            }
            else
                DodajTacku(T, Tacke, Objekti);
            return;
        }
        #endregion
        #region Najbliži
        #region Najbliža Tačka
        public static int NajblizaTacka(Tacka T, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            int j = -1;
            double m = double.MaxValue;
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if ((Objekti[i].Vrsta == 1) && (T.Rastojanje(Tacke[Objekti[i].Indeks]) < m) && (Objekti[i].Show))
                {
                    m = T.Rastojanje(Tacke[Objekti[i].Indeks]);
                    j = i;
                }
            if (m > l)
                return -1;
            return j;
        }
        #endregion
        #region Najbliža Prava
        public static int NajblizaPrava(Tacka T, Prava[] Prave, ObjekatInfo[] Objekti)
        {
            int j = -1;
            double m = double.MaxValue;
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if ((Objekti[i].Vrsta == 2) && (T.Rastojanje(Prave[Objekti[i].Indeks]) < m) && (Objekti[i].Show))
                {
                    m = T.Rastojanje(Prave[Objekti[i].Indeks]);
                    j = i;
                }
            if (m > l)
                return -1;
            return j;
        }
        #endregion
        #region Najbliža Duž
        public static int NajblizaDuz(Tacka T, Duz[] Duzi, ObjekatInfo[] Objekti)
        {
            int j = -1;
            double m = double.MaxValue;
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if ((Objekti[i].Vrsta == 3) && (T.Rastojanje1(Duzi[Objekti[i].Indeks]) < m) && (Objekti[i].Show))
                {
                    m = T.Rastojanje1(Duzi[Objekti[i].Indeks]);
                    j = i;
                }
            if (m > l)
                return -1;
            return j;
        }
        #endregion
        #region Najbliži Krug
        public static int NajbliziKrug(Tacka T, Krug[] Krugovi, ObjekatInfo[] Objekti)
        {
            int j = -1;
            double m = double.MaxValue;
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if ((Objekti[i].Vrsta == 4) && (T.Rastojanje(Krugovi[Objekti[i].Indeks]) < m) && (Objekti[i].Show))
                {
                    m = T.Rastojanje(Krugovi[Objekti[i].Indeks]);
                    j = i;
                }
            if (m > l)
                return -1;
            return j;
        }
        #endregion
        #endregion
        #region Dodaj
        #region Dodaj Tačku
        public static void DodajTacku(Tacka T, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            Tacke[Tacka.NT] = T;
            Tacka.NT++;
            Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1] = new ObjekatInfo(1, Tacka.NT - 1, false, Korak, true);
        }
        #endregion
        #region Dodaj Pravu
        public static void DodajPravu(Prava p, Prava[] Prave, ObjekatInfo[] Objekti)
        {
            if (p.Ime == "-1")
            {
                Korak--;
                return;
            }
            Prave[Prava.NP] = p;
            Prava.NP++;
            Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1] = new ObjekatInfo(2, Prava.NP - 1, false, Korak, true);
        }
        #endregion
        #region Dodaj Duž
        public static void DodajDuz(Duz d, Duz[] Duzi, ObjekatInfo[] Objekti)
        {
            if (d.Ime == "-1")
            {
                Korak--;
                return;
            }
            Duzi[Duz.ND] = d;
            Duz.ND++;
            Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1] = new ObjekatInfo(3, Duz.ND - 1, false, Korak, true);
        }
        #endregion
        #region Dodaj Krug
        public static void DodajKrug(Krug k, Krug[] Krugovi, ObjekatInfo[] Objekti)
        {
            if (k.Ime == "-1")
            {
                Korak--;
                return;
            }
            Krugovi[Krug.NK] = k;
            Krug.NK++;
            Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1] = new ObjekatInfo(4, Krug.NK - 1, false, Korak, true);
        }
        #endregion
        #endregion
        #endregion
        #region Paint
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if (Objekti[i].Vrsta == 3)
                    Duzi[Objekti[i].Indeks].Crtaj(e.Graphics, k, O, Objekti, i, showhide);
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if (Objekti[i].Vrsta == 4)
                    Krugovi[Objekti[i].Indeks].Crtaj(e.Graphics, k, O, Objekti, i, showhide);
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if (Objekti[i].Vrsta == 2)
                    Prave[Objekti[i].Indeks].Crtaj(e.Graphics, k, O, Objekti, i, showhide, pictureBox1);
            for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                if (Objekti[i].Vrsta == 1)
                    Tacke[Objekti[i].Indeks].Crtaj(e.Graphics, k, O, Objekti, i, showhide);
        }
        #endregion
        #region Radio Buttons
        public GeoGebra()
        {
            InitializeComponent();
            showhide.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            pomeraj.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            crtanjetacke.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            crtanjeduzi.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            crtanjeprave.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            presek.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            duzdateduzine.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            ugaodatevelicine.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            sredisteduzi.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            normala.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            paralela.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            simetraladuzi.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            simetralaugla.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            tangente.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            pravilanmnogougao.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            centaritackanakrugu.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            centaripoluprecnik.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            tritacke.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            sestar.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            nalazenjecentra.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            duzinaduzi.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            velicinaugla.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            translacija.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rotacija.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            homotetija.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            refleksija.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            inverzija.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if ((cnt != 1) && (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak))
                Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
            Reset(pictureBox1, Objekti);
            Korak--;
            duzinaduzitext.Text = "___";
            velicinauglatext.Text = "___";
        }
        #endregion
        #region Zoom
        #region Zoom In
        private void zoomin_MouseDown(object sender, MouseEventArgs e)
        {
            zoomintimer.Enabled = true;
        }
        private void zoomintimer_Tick(object sender, EventArgs e)
        {
            O = new PointF((float)(pictureBox1.Width / 2 + (O.X - pictureBox1.Width / 2) * k0), (float)(pictureBox1.Height / 2 + (O.Y - pictureBox1.Height / 2) * k0));
            k = k * k0;
            l = 7 / k;
            pictureBox1.Refresh();
        }
        private void zoomin_MouseUp(object sender, MouseEventArgs e)
        {
            zoomintimer.Enabled = false;
        }
        #endregion
        #region Zoom Out
        private void zoomout_MouseDown(object sender, MouseEventArgs e)
        {
            zoomouttimer.Enabled = true;
        }
        private void zoomouttimer_Tick(object sender, EventArgs e)
        {
            O = new PointF((float)(pictureBox1.Width / 2 + (O.X - pictureBox1.Width / 2) / k0), (float)(pictureBox1.Height / 2 + (O.Y - pictureBox1.Height / 2) / k0));
            k = k / k0;
            l = 7 / k;
            pictureBox1.Refresh();
        }
        private void zoomout_MouseUp(object sender, MouseEventArgs e)
        {
            zoomouttimer.Enabled = false;
        }
        #endregion
        #endregion
        #region Obriši Sve
        private void obrisisve_Click(object sender, EventArgs e)
        {
            GeoGebra_Load(sender, e);
        }
        #endregion
        #region Undo
        private void undo_Click(object sender, EventArgs e)
        {
            Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
        }
        #endregion
        #region Mouse Click
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            #region Osnovni Alati
            #region Show/Hide
            if (showhide.Checked)
            {
                Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                double m = double.MaxValue;
                for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                    if ((Objekti[i].Vrsta == 1) && (T.Rastojanje(Tacke[Objekti[i].Indeks]) < m))
                    {
                        m = T.Rastojanje(Tacke[Objekti[i].Indeks]);
                        j1 = i;
                    }
                if ((j1 != -1) && (m < l))
                {
                    Objekti[j1].Show = !Objekti[j1].Show;
                    pictureBox1.Refresh();
                    return;
                }
                for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                    if ((Objekti[i].Vrsta == 2) && (T.Rastojanje(Prave[Objekti[i].Indeks]) < m))
                    {
                        m = T.Rastojanje(Prave[Objekti[i].Indeks]);
                        j1 = i;
                    }
                if ((j1 != -1) && (m < l))
                {
                    Objekti[j1].Show = !Objekti[j1].Show;
                    pictureBox1.Refresh();
                    return;
                }
                for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                    if ((Objekti[i].Vrsta == 4) && (T.Rastojanje(Krugovi[Objekti[i].Indeks]) < m))
                    {
                        m = T.Rastojanje(Krugovi[Objekti[i].Indeks]);
                        j1 = i;
                    }
                if ((j1 != -1) && (m < l))
                {
                    Objekti[j1].Show = !Objekti[j1].Show;
                    pictureBox1.Refresh();
                    return;
                }
                for (int i = 0; i < Tacka.NT + Prava.NP + Duz.ND + Krug.NK; i++)
                    if ((Objekti[i].Vrsta == 3) && (T.Rastojanje(Duzi[Objekti[i].Indeks]) < m))
                    {
                        m = T.Rastojanje(Duzi[Objekti[i].Indeks]);
                        j1 = i;
                    }
                if ((j1 != -1) && (m < l))
                {
                    Objekti[j1].Show = !Objekti[j1].Show;
                    pictureBox1.Refresh();
                    return;
                }
                return;
            }
            #endregion
            #endregion
            #region Crtanje
            #region Crtanje Tačke
            if (crtanjetacke.Checked)
            {
                Spawn(new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                pictureBox1.Refresh();
                Korak++;
                return;
            }
            #endregion
            #region Crtanje Duži
            if (crtanjeduzi.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j1 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    Duz d;
                    if ((j2 == -1) || (j2 == j1))
                    {

                        Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j2 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    d = new Duz(Tacke[Objekti[j1].Indeks], Tacke[Objekti[j2].Indeks]);
                    DodajDuz(d, Duzi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Crtanje Prave
            if (crtanjeprave.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j1 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    Prava p;
                    if ((j2 == -1) || (j2 == j1))
                    {
                        Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j2 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    p = new Prava(Tacke[Objekti[j1].Indeks], Tacke[Objekti[j2].Indeks], "p" + (Prava.NP + 1).ToString());
                    DodajPravu(p, Prave, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Presek
            if (presek.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaPrava(T, Prave, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajbliziKrug(T, Krugovi, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajblizaDuz(T, Duzi, Objekti);
                            if (j1 == -1)
                                return;
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaPrava(T, Prave, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                    {
                        j2 = NajbliziKrug(T, Krugovi, Objekti);
                        if ((j2 == -1) || (j2 == j1))
                        {
                            j2 = NajblizaDuz(T, Duzi, Objekti);
                            if ((j2 == -1) || (j2 == j1))
                                return;
                        }
                    }
                    if (Objekti[j1].Vrsta == 2)
                    {
                        if ((Objekti[j2].Vrsta == 2) && (Prave[Objekti[j1].Indeks].Presek(Prave[Objekti[j2].Indeks]) != null))
                            DodajTacku(Prave[Objekti[j1].Indeks].Presek(Prave[Objekti[j2].Indeks]), Tacke, Objekti);
                        if ((Objekti[j2].Vrsta == 3) && (Prave[Objekti[j1].Indeks].Presek(Duzi[Objekti[j2].Indeks]) != null))
                            DodajTacku(Prave[Objekti[j1].Indeks].Presek(Duzi[Objekti[j2].Indeks]), Tacke, Objekti);
                        if (Objekti[j2].Vrsta == 4)
                            Prave[Objekti[j1].Indeks].Presek(Krugovi[Objekti[j2].Indeks], Tacke, Objekti);
                    }
                    if (Objekti[j1].Vrsta == 3)
                    {
                        if ((Objekti[j2].Vrsta == 2) && (Duzi[Objekti[j1].Indeks].Presek(Prave[Objekti[j2].Indeks]) != null))
                            DodajTacku(Duzi[Objekti[j1].Indeks].Presek(Prave[Objekti[j2].Indeks]), Tacke, Objekti);
                        if ((Objekti[j2].Vrsta == 3) && (Duzi[Objekti[j1].Indeks].Presek(Duzi[Objekti[j2].Indeks]) != null))
                            DodajTacku(Duzi[Objekti[j1].Indeks].Presek(Duzi[Objekti[j2].Indeks]), Tacke, Objekti);
                        if (Objekti[j2].Vrsta == 4)
                            Duzi[Objekti[j1].Indeks].Presek(Krugovi[Objekti[j2].Indeks], Tacke, Objekti);
                    }
                    if (Objekti[j1].Vrsta == 4)
                    {
                        if (Objekti[j2].Vrsta == 2)
                            Krugovi[Objekti[j1].Indeks].Presek(Prave[Objekti[j2].Indeks], Tacke, Objekti);
                        if (Objekti[j2].Vrsta == 3)
                            Krugovi[Objekti[j1].Indeks].Presek(Duzi[Objekti[j2].Indeks], Tacke, Objekti);
                        if (Objekti[j2].Vrsta == 4)
                            Krugovi[Objekti[j1].Indeks].Presek(Krugovi[Objekti[j2].Indeks], Tacke, Objekti);
                    }
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Duž Date Dužine
            if (duzdateduzine.Checked)
            {
                Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                j1 = NajblizaTacka(T, Tacke, Objekti);
                if (j1 == -1)
                {
                    Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                    j1 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                }
                Oznaci(Objekti, j1, pictureBox1);
                PopUp PopUp = new PopUp("Unesi Dužinu:");
                DialogResult d = PopUp.ShowDialog();
                if ((d == DialogResult.OK) && (double.TryParse(PopUp.s, out double x)))
                {
                    if (double.Parse(PopUp.s) > 2 * GeoGebra.eps)
                        DodajTacku(Tacke[Objekti[j1].Indeks].Translacija(double.Parse(PopUp.s) * Math.Cos(4 * GeoGebra.eps), double.Parse(PopUp.s) * Math.Sin(4 * GeoGebra.eps)), Tacke, Objekti);
                    DodajDuz(new Duz(Tacke[Objekti[j1].Indeks], Tacke[Tacka.NT - 1]), Duzi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
                else
                {
                    if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                        Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                    Reset(pictureBox1, Objekti);
                    Korak--;
                    return;
                }
            }
            #endregion
            #region Ugao Date Veličine
            if (ugaodatevelicine.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j1 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                    {
                        Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j2 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    Oznaci(Objekti, j2, pictureBox1);
                    PopUp PopUp = new PopUp("Unesi Ugao:");
                    DialogResult d = PopUp.ShowDialog();
                    if ((d == DialogResult.OK) && (double.TryParse(PopUp.s, out double x)))
                    {
                        DodajTacku(Tacke[Objekti[j1].Indeks].Rotacija(Tacke[Objekti[j2].Indeks], (double.Parse(PopUp.s)) * 2 * Math.PI / 360), Tacke, Objekti);
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    else
                    {
                        if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                            Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                        Reset(pictureBox1, Objekti);
                        Korak--;
                        return;
                    }
                }
            }
            #endregion
            #endregion
            #region Konstrukcije
            #region Središte Duži
            if (sredisteduzi.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaDuz(T, Duzi, Objekti);
                        if (j1 != -1)
                        {
                            DodajTacku((Duzi[Objekti[j1].Indeks].Tacka1).Homotetija(Duzi[Objekti[j1].Indeks].Tacka2, 0.5), Tacke, Objekti);
                            Reset(pictureBox1, Objekti);
                        }
                        return;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                        return;
                    DodajTacku(Tacke[Objekti[j2].Indeks].Homotetija(Tacke[Objekti[j1].Indeks], 0.5), Tacke, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Normala
            if (normala.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajblizaDuz(T, Duzi, Objekti);
                            if (j1 == -1)
                                return;
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    if (Objekti[j1].Vrsta == 1)
                    {
                        j2 = NajblizaPrava(T, Prave, Objekti);
                        if (j2 != -1)
                            DodajPravu(Prave[Objekti[j2].Indeks].Normala(Tacke[Objekti[j1].Indeks]), Prave, Objekti);
                        else
                        {
                            j2 = NajblizaDuz(T, Duzi, Objekti);
                            if (j2 == -1)
                                return;
                            DodajPravu(Duzi[Objekti[j2].Indeks].Normala(Tacke[Objekti[j1].Indeks]), Prave, Objekti);
                        }
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if (j2 == -1)
                        return;
                    if (Objekti[j1].Vrsta == 2)
                        DodajPravu(Prave[Objekti[j1].Indeks].Normala(Tacke[Objekti[j2].Indeks]), Prave, Objekti);
                    if (Objekti[j1].Vrsta == 3)
                        DodajPravu(Duzi[Objekti[j1].Indeks].Normala(Tacke[Objekti[j2].Indeks]), Prave, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Paralela
            if (paralela.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajblizaDuz(T, Duzi, Objekti);
                            if (j1 == -1)
                                return;
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    if (Objekti[j1].Vrsta == 1)
                    {
                        j2 = NajblizaPrava(T, Prave, Objekti);
                        if (j2 != -1)
                            DodajPravu(Prave[Objekti[j2].Indeks].Paralela(Tacke[Objekti[j1].Indeks]), Prave, Objekti);
                        else
                        {
                            j2 = NajblizaDuz(T, Duzi, Objekti);
                            if (j2 == -1)
                                return;
                            DodajPravu(Duzi[Objekti[j2].Indeks].Paralela(Tacke[Objekti[j1].Indeks]), Prave, Objekti);
                        }
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if (j2 == -1)
                        return;
                    if (Objekti[j1].Vrsta == 2)
                        DodajPravu(Prave[Objekti[j1].Indeks].Paralela(Tacke[Objekti[j2].Indeks]), Prave, Objekti);
                    if (Objekti[j1].Vrsta == 3)
                        DodajPravu(Duzi[Objekti[j1].Indeks].Paralela(Tacke[Objekti[j2].Indeks]), Prave, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Simetrala Duži
            if (simetraladuzi.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaDuz(T, Duzi, Objekti);
                        if (j1 != -1)
                        {
                            DodajPravu(Duzi[Objekti[j1].Indeks].Simetrala(), Prave, Objekti);
                            Reset(pictureBox1, Objekti);
                        }
                        return;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                        return;
                    DodajPravu((new Duz(Tacke[Objekti[j1].Indeks], Tacke[Objekti[j2].Indeks])).Simetrala(), Prave, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Simetrala Ugla
            if (simetralaugla.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajblizaDuz(T, Duzi, Objekti);
                            if (j1 == -1)
                                return;
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    if (Objekti[j1].Vrsta != 1)
                    {
                        j2 = NajblizaPrava(T, Prave, Objekti);
                        if ((j2 == -1) || (j2 == j1))
                        {
                            j2 = NajblizaDuz(T, Duzi, Objekti);
                            if ((j2 == -1) || (j2 == j1))
                                return;
                        }
                        if (Objekti[j1].Vrsta == 2)
                        {
                            if ((Objekti[j2].Vrsta == 2) && (Prave[Objekti[j1].Indeks].SimetralaUgla(Prave[Objekti[j2].Indeks]) != null))
                                DodajPravu(Prave[Objekti[j1].Indeks].SimetralaUgla(Prave[Objekti[j2].Indeks]), Prave, Objekti);
                            if ((Objekti[j2].Vrsta == 3) && (Prave[Objekti[j1].Indeks].SimetralaUgla(Duzi[Objekti[j2].Indeks]) != null))
                                DodajPravu(Prave[Objekti[j1].Indeks].SimetralaUgla(Duzi[Objekti[j2].Indeks]), Prave, Objekti);
                        }
                        if (Objekti[j1].Vrsta == 3)
                        {
                            if ((Objekti[j2].Vrsta == 2) && (Duzi[Objekti[j1].Indeks].SimetralaUgla(Prave[Objekti[j2].Indeks]) != null))
                                DodajPravu(Duzi[Objekti[j1].Indeks].SimetralaUgla(Prave[Objekti[j2].Indeks]), Prave, Objekti);
                            if ((Objekti[j2].Vrsta == 3) && (Duzi[Objekti[j1].Indeks].SimetralaUgla(Duzi[Objekti[j2].Indeks]) != null))
                                DodajPravu(Duzi[Objekti[j1].Indeks].SimetralaUgla(Duzi[Objekti[j2].Indeks]), Prave, Objekti);
                        }
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 != -1) && (j2 != j1))
                        Oznaci(Objekti, j2, pictureBox1);
                    return;
                }
                if(cnt == 3)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j3 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j3 == -1) || (j3 == j2) || (j3 == j1))
                        return;
                    DodajPravu((new Duz(Tacke[Objekti[j1].Indeks], Tacke[Objekti[j2].Indeks])).SimetralaUgla(new Duz(Tacke[Objekti[j2].Indeks], Tacke[Objekti[j3].Indeks])), Prave, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Tangente
            if (tangente.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajbliziKrug(T, Krugovi, Objekti);
                        if (j1 == -1)
                            return;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    if (Objekti[j1].Vrsta == 1)
                    {
                        j2 = NajbliziKrug(T, Krugovi, Objekti);
                        if (j2 == -1)
                            return;
                        Krugovi[Objekti[j2].Indeks].Tangente(Tacke[Objekti[j1].Indeks], Prave, Objekti);
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if (j2 == -1)
                        return;
                    Krugovi[Objekti[j1].Indeks].Tangente(Tacke[Objekti[j2].Indeks], Prave, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Pravilan Mnogougao
            if (pravilanmnogougao.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaDuz(T, Duzi, Objekti);
                        if (j1 != -1)
                        {
                            Oznaci(Objekti, j1, pictureBox1);
                            PopUp PopUp = new PopUp("Unesi Broj Stranica:");
                            DialogResult d = PopUp.ShowDialog();
                            if ((d == DialogResult.OK) && (int.TryParse(PopUp.s, out int x)))
                            {
                                if (int.Parse(PopUp.s) < 3)
                                    return;
                                Duzi[Objekti[j1].Indeks].PravilanMnogougao(int.Parse(PopUp.s), Tacke, Duzi, Objekti);
                                Reset(pictureBox1, Objekti);
                                return;
                            }
                            else
                            {
                                if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                                    Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                                Reset(pictureBox1, Objekti);
                                Korak--;
                                return;
                            }
                        }
                        Spawn(new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j1 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                    {
                        Spawn(new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j2 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    Oznaci(Objekti, j2, pictureBox1);
                    PopUp PopUp = new PopUp("Unesi Broj Stranica:");
                    DialogResult d = PopUp.ShowDialog();
                    if ((d == DialogResult.OK) && (int.TryParse(PopUp.s, out int x)) && (int.Parse(PopUp.s) > 2))
                    {
                        DodajDuz(new Duz(Tacke[Objekti[j1].Indeks], Tacke[Objekti[j2].Indeks]), Duzi, Objekti);
                        Duzi[Duz.ND - 1].PravilanMnogougao(int.Parse(PopUp.s), Tacke, Duzi, Objekti);
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    else
                    {
                        if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                            Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                        Reset(pictureBox1, Objekti);
                        Korak--;
                        return;
                    }
                }
            }
            #endregion
            #endregion
            #region Konstrukcije Krugova
            #region Centar i Tačka Na Krugu
            if (centaritackanakrugu.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j1 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                        pictureBox1.Refresh();
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                    {
                        Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                        j2 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                    }
                    Krug k1 = new Krug(Tacke[Objekti[j1].Indeks], Tacke[Objekti[j2].Indeks], "k" + (Krug.NK + 1).ToString());
                    DodajKrug(k1, Krugovi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Centar i Poluprečnik
            if (centaripoluprecnik.Checked)
            {
                Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                j1 = NajblizaTacka(T, Tacke, Objekti);
                if (j1 == -1)
                {
                    Spawn(new Tacka(T.X, T.Y, "A" + (Tacka.NT + 1).ToString(), Color.Blue), Tacke, Prave, Duzi, Krugovi, Objekti);
                    j1 = Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1;
                }
                Oznaci(Objekti, j1, pictureBox1);
                PopUp PopUp = new PopUp("Unesi Poluprečnik:");
                DialogResult d = PopUp.ShowDialog();
                if ((d == DialogResult.OK) && (double.TryParse(PopUp.s, out double x) && (double.Parse(PopUp.s) > GeoGebra.eps)))
                {
                    DodajKrug(new Krug(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s), "k" + (Krug.NK - 1).ToString()), Krugovi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
                else
                {
                    if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                        Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                    Reset(pictureBox1, Objekti);
                    Korak--;
                    return;
                }
            }
            #endregion
            #region Tri Tačke
            if (tritacke.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 != -1)
                        Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 != -1) && (j2 != j1))
                        Oznaci(Objekti, j2, pictureBox1);
                    return;
                }
                if (cnt == 3)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j3 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j3 == -1) || (j3 == j2) || (j3 == j1))
                        return;
                    Krug k1 = new Krug(Tacke[Objekti[j1].Indeks], Tacke[Objekti[j2].Indeks], Tacke[Objekti[j3].Indeks], "k" + (Krug.NK + 1).ToString());
                    DodajKrug(k1, Krugovi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Šestar
            if (sestar.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaDuz(T, Duzi, Objekti);
                        if (j1 == -1)
                            return;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    if (Objekti[j1].Vrsta == 1)
                    {
                        j2 = NajblizaTacka(T, Tacke, Objekti);
                        if ((j2 == -1) || (j2 == j1))
                        {
                            j2 = NajblizaDuz(T, Duzi, Objekti);
                            if (j2 == -1)
                                return;
                            DodajKrug(new Krug(Tacke[Objekti[j1].Indeks], Duzi[Objekti[j2].Indeks], "k" + (Krug.NK + 1).ToString()), Krugovi, Objekti);
                            Reset(pictureBox1, Objekti);
                            return;
                        }
                        Oznaci(Objekti, j2, pictureBox1);
                        return;
                    }
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if (j2 == -1)
                        return;
                    DodajKrug(new Krug(Tacke[Objekti[j2].Indeks], Duzi[Objekti[j1].Indeks], "k" + (Krug.NK + 1).ToString()), Krugovi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
                if (cnt == 3)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j3 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j3 == -1) || (j3 == j2) || (j3 == j1))
                        return;
                    Krug k1 = new Krug(Tacke[Objekti[j1].Indeks], new Duz(Tacke[Objekti[j2].Indeks], Tacke[Objekti[j3].Indeks]), "k" + (Krug.NK + 1).ToString());
                    DodajKrug(k1, Krugovi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Nalaženje Centra
            if (nalazenjecentra.Checked)
            {
                Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                j1 = NajbliziKrug(T, Krugovi, Objekti);
                if (j1 == -1)
                    return;
                DodajTacku(new Tacka(Krugovi[Objekti[j1].Indeks].Centar.X, Krugovi[Objekti[j1].Indeks].Centar.Y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                Reset(pictureBox1, Objekti);
                return;
            }
            #endregion
            #endregion
            #region Merenje
            #region Dužina Duži
            if (duzinaduzi.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaDuz(T, Duzi, Objekti);
                        if (j1 != -1)
                            duzinaduzitext.Text = (Duzi[Objekti[j1].Indeks].Tacka1.Rastojanje(Duzi[Objekti[j1].Indeks].Tacka2)).ToString();
                        return;
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                    {
                        j2 = -1;
                        return;
                    }
                    duzinaduzitext.Text = Tacke[Objekti[j1].Indeks].Rastojanje(Tacke[Objekti[j2].Indeks]).ToString();
                    Reset(pictureBox1, Objekti);
                    Korak--;
                    return;
                }
            }
            #endregion
            #region Veličina Ugla
            if (velicinaugla.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajblizaDuz(T, Duzi, Objekti);
                            if (j1 == -1)
                                return;
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    if (Objekti[j1].Vrsta != 1)
                    {
                        j2 = NajblizaPrava(T, Prave, Objekti);
                        if ((j2 == -1) || (j2 == j1))
                        {
                            j2 = NajblizaDuz(T, Duzi, Objekti);
                            if ((j2 == -1) || (j2 == j1))
                                return;
                        }
                        velicinauglatext.Text = "___";
                        if (Objekti[j1].Vrsta == 2)
                        {
                            if ((Objekti[j2].Vrsta == 2) && (Prave[Objekti[j1].Indeks].Ugao(Prave[Objekti[j2].Indeks]) != -1))
                                velicinauglatext.Text = Prave[Objekti[j1].Indeks].Ugao(Prave[Objekti[j2].Indeks]).ToString();
                            else if ((Objekti[j2].Vrsta == 3) && (Prave[Objekti[j1].Indeks].Ugao(Duzi[Objekti[j2].Indeks]) != -1))
                                velicinauglatext.Text = Prave[Objekti[j1].Indeks].Ugao(Duzi[Objekti[j2].Indeks]).ToString();
                            else
                                velicinauglatext.Text = "Paralelne su";
                        }
                        else if (Objekti[j1].Vrsta == 3)
                        {
                            if ((Objekti[j2].Vrsta == 2) && (Duzi[Objekti[j1].Indeks].Ugao(Prave[Objekti[j2].Indeks]) != -1))
                                velicinauglatext.Text = Duzi[Objekti[j1].Indeks].Ugao(Prave[Objekti[j2].Indeks]).ToString();
                            else if ((Objekti[j2].Vrsta == 3) && (Duzi[Objekti[j1].Indeks].Ugao(Duzi[Objekti[j2].Indeks]) != -1))
                                velicinauglatext.Text = Duzi[Objekti[j1].Indeks].Ugao(Duzi[Objekti[j2].Indeks]).ToString();
                            else
                                velicinauglatext.Text = "Paralelne su";
                        }
                        Reset(pictureBox1, Objekti);
                        Korak--;
                    }
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 != -1) && (j2 != j1))
                        Oznaci(Objekti, j2, pictureBox1);
                    return;
                }
                if (cnt == 3)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j3 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j3 == -1) || (j3 == j2) || (j3 == j1))
                        return;
                    velicinauglatext.Text = (new Duz(Tacke[Objekti[j1].Indeks], Tacke[Objekti[j2].Indeks])).Ugao(new Duz(Tacke[Objekti[j3].Indeks], Tacke[Objekti[j2].Indeks])).ToString();
                    Reset(pictureBox1, Objekti);
                    Korak--;
                    return;
                }
            }
            #endregion
            #endregion
            #region Transformacije
            #region Translacija
            if (translacija.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajbliziKrug(T, Krugovi, Objekti);
                            if (j1 == -1)
                            {
                                j1 = NajblizaDuz(T, Duzi, Objekti);
                                if (j1 == -1)
                                    return;
                            }
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 != -1) && (j2 != j1))
                        Oznaci(Objekti, j2, pictureBox1);
                    return;
                }
                if (cnt == 3)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j3 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j3 == -1) || (j3 == j2))
                        return;
                    if (Objekti[j1].Vrsta == 1)
                        DodajTacku(Tacke[Objekti[j1].Indeks].Translacija(Tacke[Objekti[j3].Indeks].X - Tacke[Objekti[j2].Indeks].X, Tacke[Objekti[j3].Indeks].Y - Tacke[Objekti[j2].Indeks].Y), Tacke, Objekti);
                    if (Objekti[j1].Vrsta == 2)
                        DodajPravu(Prave[Objekti[j1].Indeks].Translacija(Tacke[Objekti[j3].Indeks].X - Tacke[Objekti[j2].Indeks].X, Tacke[Objekti[j3].Indeks].Y - Tacke[Objekti[j2].Indeks].Y), Prave, Objekti);
                    if (Objekti[j1].Vrsta == 3)
                        DodajDuz(Duzi[Objekti[j1].Indeks].Translacija(Tacke[Objekti[j3].Indeks].X - Tacke[Objekti[j2].Indeks].X, Tacke[Objekti[j3].Indeks].Y - Tacke[Objekti[j2].Indeks].Y, Tacke, Objekti), Duzi, Objekti);
                    if (Objekti[j1].Vrsta == 4)
                        DodajKrug(Krugovi[Objekti[j1].Indeks].Translacija(Tacke[Objekti[j3].Indeks].X - Tacke[Objekti[j2].Indeks].X, Tacke[Objekti[j3].Indeks].Y - Tacke[Objekti[j2].Indeks].Y), Krugovi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Rotacija
            if (rotacija.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajbliziKrug(T, Krugovi, Objekti);
                            if (j1 == -1)
                            {
                                j1 = NajblizaDuz(T, Duzi, Objekti);
                                if (j1 == -1)
                                    return;
                            }
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    PopUp PopUp;
                    DialogResult d;
                    double x;
                    if (Objekti[j1].Vrsta != 1)
                    {
                        j2 = NajblizaTacka(T, Tacke, Objekti);
                        if (j2 == -1)
                            return;
                        Oznaci(Objekti, j2, pictureBox1);
                        PopUp = new PopUp("Unesi Ugao:");
                        d = PopUp.ShowDialog();
                        if ((d == DialogResult.OK) && (double.TryParse(PopUp.s, out x)))
                        {
                            if (Objekti[j1].Vrsta == 2)
                                DodajPravu(Prave[Objekti[j1].Indeks].Rotacija(Tacke[Objekti[j2].Indeks], double.Parse(PopUp.s) * 2 * Math.PI / 360), Prave, Objekti);
                            if (Objekti[j1].Vrsta == 3)
                                DodajDuz(Duzi[Objekti[j1].Indeks].Rotacija(Tacke[Objekti[j2].Indeks], double.Parse(PopUp.s) * 2 * Math.PI / 360, Tacke, Objekti), Duzi, Objekti);
                            if (Objekti[j1].Vrsta == 4)
                                DodajKrug(Krugovi[Objekti[j1].Indeks].Rotacija(Tacke[Objekti[j2].Indeks], double.Parse(PopUp.s) * 2 * Math.PI / 360), Krugovi, Objekti);
                            Reset(pictureBox1, Objekti);
                            return;
                        }
                        else
                        {
                            if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                                Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                            Reset(pictureBox1, Objekti);
                            Korak--;
                            return;
                        }
                    }
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                    {
                        j2 = NajblizaPrava(T, Prave, Objekti);
                        if (j2 == -1)
                        {
                            j2 = NajbliziKrug(T, Krugovi, Objekti);
                            if (j2 == -1)
                            {
                                j2 = NajblizaDuz(T, Duzi, Objekti);
                                if (j2 == -1)
                                    return;
                            }
                        }
                    }
                    Oznaci(Objekti, j2, pictureBox1);
                    PopUp = new PopUp("Unesi Ugao:");
                    d = PopUp.ShowDialog();
                    if ((d == DialogResult.OK) && (double.TryParse(PopUp.s, out x)))
                    {
                        if (Objekti[j2].Vrsta == 1)
                            DodajTacku(Tacke[Objekti[j2].Indeks].Rotacija(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s) * 2 * Math.PI / 360), Tacke, Objekti);
                        if (Objekti[j2].Vrsta == 2)
                            DodajPravu(Prave[Objekti[j2].Indeks].Rotacija(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s) * 2 * Math.PI / 360), Prave, Objekti);
                        if (Objekti[j2].Vrsta == 3)
                            DodajDuz(Duzi[Objekti[j2].Indeks].Rotacija(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s) * 2 * Math.PI / 360, Tacke, Objekti), Duzi, Objekti);
                        if (Objekti[j2].Vrsta == 4)
                            DodajKrug(Krugovi[Objekti[j2].Indeks].Rotacija(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s) * 2 * Math.PI / 360), Krugovi, Objekti);
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    else
                    {
                        if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                            Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                        Reset(pictureBox1, Objekti);
                        Korak--;
                        return;
                    }
                }
            }
            #endregion
            #region Homotetija
            if (homotetija.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajbliziKrug(T, Krugovi, Objekti);
                            if (j1 == -1)
                            {
                                j1 = NajblizaDuz(T, Duzi, Objekti);
                                if (j1 == -1)
                                    return;
                            }
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    PopUp PopUp;
                    DialogResult d;
                    double x;
                    if (Objekti[j1].Vrsta != 1)
                    {
                        j2 = NajblizaTacka(T, Tacke, Objekti);
                        if (j2 == -1)
                            return;
                        Oznaci(Objekti, j2, pictureBox1);
                        PopUp = new PopUp("Unesi Koeficijent:");
                        d = PopUp.ShowDialog();
                        if ((d == DialogResult.OK) && (double.TryParse(PopUp.s, out x)))
                        {
                            if (Objekti[j1].Vrsta == 2)
                                DodajPravu(Prave[Objekti[j1].Indeks].Homotetija(Tacke[Objekti[j2].Indeks], double.Parse(PopUp.s)), Prave, Objekti);
                            if (Objekti[j1].Vrsta == 3)
                                DodajDuz(Duzi[Objekti[j1].Indeks].Homotetija(Tacke[Objekti[j2].Indeks], double.Parse(PopUp.s), Tacke, Objekti), Duzi, Objekti);
                            if (Objekti[j1].Vrsta == 4)
                                DodajKrug(Krugovi[Objekti[j1].Indeks].Homotetija(Tacke[Objekti[j2].Indeks], double.Parse(PopUp.s)), Krugovi, Objekti);
                            Reset(pictureBox1, Objekti);
                            return;
                        }
                        else
                        {
                            if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                                Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                            Reset(pictureBox1, Objekti);
                            Korak--;
                            return;
                        }
                    }
                    j2 = NajblizaTacka(T, Tacke, Objekti);
                    if ((j2 == -1) || (j2 == j1))
                    {
                        j2 = NajblizaPrava(T, Prave, Objekti);
                        if (j2 == -1)
                        {
                            j2 = NajbliziKrug(T, Krugovi, Objekti);
                            if (j2 == -1)
                            {
                                j2 = NajblizaDuz(T, Duzi, Objekti);
                                if (j2 == -1)
                                    return;
                            }
                        }
                    }
                    Oznaci(Objekti, j2, pictureBox1);
                    PopUp = new PopUp("Unesi Koeficijent:");
                    d = PopUp.ShowDialog();
                    if ((d == DialogResult.OK) && (double.TryParse(PopUp.s, out x)))
                    {
                        if (Objekti[j2].Vrsta == 1)
                            DodajTacku(Tacke[Objekti[j2].Indeks].Homotetija(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s)), Tacke, Objekti);
                        if (Objekti[j2].Vrsta == 2)
                            DodajPravu(Prave[Objekti[j2].Indeks].Homotetija(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s)), Prave, Objekti);
                        if (Objekti[j2].Vrsta == 3)
                            DodajDuz(Duzi[Objekti[j2].Indeks].Homotetija(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s), Tacke, Objekti), Duzi, Objekti);
                        if (Objekti[j2].Vrsta == 4)
                            DodajKrug(Krugovi[Objekti[j2].Indeks].Homotetija(Tacke[Objekti[j1].Indeks], double.Parse(PopUp.s)), Krugovi, Objekti);
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    else
                    {
                        if (Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK - 1].Korak == Korak)
                            Undo(Objekti, Tacke, Prave, Duzi, Krugovi, pictureBox1, duzinaduzitext, velicinauglatext);
                        Reset(pictureBox1, Objekti);
                        Korak--;
                        return;
                    }
                }
            }
            #endregion
            #region Refleksija
            if (refleksija.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajbliziKrug(T, Krugovi, Objekti);
                            if (j1 == -1)
                            {
                                j1 = NajblizaDuz(T, Duzi, Objekti);
                                if (j1 == -1)
                                    return;
                            }
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    if (Objekti[j1].Vrsta == 2)
                    {
                        j2 = NajblizaTacka(T, Tacke, Objekti);
                        if (j2 == -1)
                        {
                            j2 = NajblizaPrava(T, Prave, Objekti);
                            if ((j2 == -1) || (j2 == j1))
                            {
                                j2 = NajbliziKrug(T, Krugovi, Objekti);
                                if (j2 == -1)
                                {
                                    j2 = NajblizaDuz(T, Duzi, Objekti);
                                    if (j2 == -1)
                                        return;
                                }
                            }
                        }
                        if (Objekti[j2].Vrsta == 1)
                            DodajTacku(Tacke[Objekti[j2].Indeks].Refleksija(Prave[Objekti[j1].Indeks]), Tacke, Objekti);
                        if (Objekti[j2].Vrsta == 2)
                            DodajPravu(Prave[Objekti[j2].Indeks].Refleksija(Prave[Objekti[j1].Indeks]), Prave, Objekti);
                        if (Objekti[j2].Vrsta == 3)
                            DodajDuz(Duzi[Objekti[j2].Indeks].Refleksija(Prave[Objekti[j1].Indeks], Tacke, Objekti), Duzi, Objekti);
                        if (Objekti[j2].Vrsta == 4)
                            DodajKrug(Krugovi[Objekti[j2].Indeks].Refleksija(Prave[Objekti[j1].Indeks]), Krugovi, Objekti);
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    j2 = NajblizaPrava(T, Prave, Objekti);
                    if (j2 == -1)
                        return;
                    if (Objekti[j1].Vrsta == 1)
                        DodajTacku(Tacke[Objekti[j1].Indeks].Refleksija(Prave[Objekti[j2].Indeks]), Tacke, Objekti);
                    if (Objekti[j1].Vrsta == 3)
                        DodajDuz(Duzi[Objekti[j1].Indeks].Refleksija(Prave[Objekti[j2].Indeks], Tacke, Objekti), Duzi, Objekti);
                    if (Objekti[j1].Vrsta == 4)
                        DodajKrug(Krugovi[Objekti[j1].Indeks].Refleksija(Prave[Objekti[j2].Indeks]), Krugovi, Objekti);
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #region Inverzija
            if (inverzija.Checked)
            {
                if (cnt == 1)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    j1 = NajblizaTacka(T, Tacke, Objekti);
                    if (j1 == -1)
                    {
                        j1 = NajblizaPrava(T, Prave, Objekti);
                        if (j1 == -1)
                        {
                            j1 = NajbliziKrug(T, Krugovi, Objekti);
                            if (j1 == -1)
                                return;
                        }
                    }
                    Oznaci(Objekti, j1, pictureBox1);
                    return;
                }
                if (cnt == 2)
                {
                    Tacka T = new Tacka((e.X - O.X) / k, (O.Y - e.Y) / k, "", Color.Black);
                    if (Objekti[j1].Vrsta == 4)
                    {
                        j2 = NajblizaTacka(T, Tacke, Objekti);
                        if (j2 == -1)
                        {
                            j2 = NajblizaPrava(T, Prave, Objekti);
                            if (j2 == -1)
                            {
                                j2 = NajbliziKrug(T, Krugovi, Objekti);
                                if ((j2 == -1) || (j2 == j1))
                                    return;
                            }
                        }
                        if ((Objekti[j2].Vrsta == 1) && (Krugovi[Objekti[j1].Indeks].Centar.Rastojanje(Tacke[Objekti[j2].Indeks]) > eps))
                            DodajTacku(Krugovi[Objekti[j1].Indeks].Inverzija(Tacke[Objekti[j2].Indeks]), Tacke, Objekti);
                        if (Objekti[j2].Vrsta == 2)
                        {
                            if (Prave[Objekti[j2].Indeks].Pripada(Krugovi[Objekti[j1].Indeks].Centar))
                                DodajPravu(Krugovi[Objekti[j1].Indeks].InverzijaProlazi(Prave[Objekti[j2].Indeks]), Prave, Objekti);
                            else
                                DodajKrug(Krugovi[Objekti[j1].Indeks].InverzijaNeProlazi(Prave[Objekti[j2].Indeks]), Krugovi, Objekti);
                        }
                        if (Objekti[j2].Vrsta == 4)
                        {
                            if (Krugovi[Objekti[j2].Indeks].Pripada(Krugovi[Objekti[j1].Indeks].Centar) == 1)
                                DodajPravu(Krugovi[Objekti[j1].Indeks].InverzijaProlazi(Krugovi[Objekti[j2].Indeks]), Prave, Objekti);
                            else
                                DodajKrug(Krugovi[Objekti[j1].Indeks].InverzijaNeProlazi(Krugovi[Objekti[j2].Indeks]), Krugovi, Objekti);
                        }
                        Reset(pictureBox1, Objekti);
                        return;
                    }
                    j2 = NajbliziKrug(T, Krugovi, Objekti);
                    if (j2 == -1)
                        return;
                    if ((Objekti[j1].Vrsta == 1) && (Krugovi[Objekti[j2].Indeks].Centar.Rastojanje(Tacke[Objekti[j1].Indeks]) > eps))
                        DodajTacku(Krugovi[Objekti[j2].Indeks].Inverzija(Tacke[Objekti[j1].Indeks]), Tacke, Objekti);
                    if (Objekti[j1].Vrsta == 2)
                    {
                        if (Prave[Objekti[j1].Indeks].Pripada(Krugovi[Objekti[j2].Indeks].Centar))
                            DodajPravu(Krugovi[Objekti[j2].Indeks].InverzijaProlazi(Prave[Objekti[j1].Indeks]), Prave, Objekti);
                        else
                            DodajKrug(Krugovi[Objekti[j2].Indeks].InverzijaNeProlazi(Prave[Objekti[j1].Indeks]), Krugovi, Objekti);
                    }
                    Reset(pictureBox1, Objekti);
                    return;
                }
            }
            #endregion
            #endregion
        }
        #endregion
        #region Pomeraj
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((pomeraj.Checked) && (e.Button == MouseButtons.Left))
            {
                B1 = new Tacka(e.X, e.Y, "", Color.Black);
                O = new PointF((float)(O.X + B1.X - B2.X), (float)(O.Y + B1.Y - B2.Y));
                B2 = new Tacka(B1.X, B1.Y, "", Color.Black);
                pictureBox1.Refresh();
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((pomeraj.Checked) && (e.Button == MouseButtons.Left))
                B2 = new Tacka(e.X, e.Y, "", Color.Black);
        }
        #endregion
    }
}