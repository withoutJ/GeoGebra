using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeoGebra
{
    #region Prava
    public class Prava
    {
        #region Static
        public static int NP;
        #endregion
        #region Atributi
        protected double k;
        protected double n;
        protected string ime;
        #endregion
        #region Konstruktori
        #region Sa Atributima
        public Prava(double k, double n, string s)
        {
            this.k = k;
            this.n = n;
            this.ime = s;
        }
        #endregion
        #region Sa Dve Tačke
        public Prava(Tacka A, Tacka B, string s)
        {
            if (Math.Abs(B.X - A.X) < GeoGebra.eps)
            {
                this.k = -1;
                this.n = 0;
                this.ime = "-1";
            }
            else
            {
                this.k = (B.Y - A.Y) / (B.X - A.X);
                this.n = B.Y - k * B.X;
                this.ime = s;
            }
        }
        #endregion
        #endregion
        #region Svojstva
        #region Koeficijent
        public double K
        {
            get { return this.k; }
        }
        #endregion
        #region Presek Sa Y Osom
        public double N
        {
            get { return this.n; }
        }
        #endregion
        #region Ime
        public string Ime
        {
            get { return this.ime; }
        }
        #endregion
        #endregion
        #region Metode
        #region Crtaj
        public void Crtaj(Graphics g, double k1, PointF O, ObjekatInfo[] Objekti, int j, RadioButton showhide, PictureBox pictureBox1)
        {
            Pen Olovka;
            if (Objekti[j].Oznacen)
            {
                Olovka = new Pen(Color.Green, 2);
                g.DrawLine(Olovka, 0, (float)(O.Y + this.k * O.X - k1 * this.N), pictureBox1.Width, (float)(O.Y - this.K * pictureBox1.Width + this.k * O.X - k1 * this.N));
                return;
            }
            if (Objekti[j].Show)
            {
                Olovka = new Pen(Color.Black, 2);
                g.DrawLine(Olovka, 0, (float)(O.Y + this.k * O.X - k1 * this.N), pictureBox1.Width, (float)(O.Y - this.K * pictureBox1.Width + this.k * O.X - k1 * this.N));
                return;
            }
            if ((showhide.Checked) && (!Objekti[j].Show))
            {
                Olovka = new Pen(Color.FromArgb(128, Color.Black), 2);
                g.DrawLine(Olovka, 0, (float)(O.Y + this.k * O.X - k1 * this.N), pictureBox1.Width, (float)(O.Y - this.K * pictureBox1.Width + this.k * O.X - k1 * this.N));
                return;
            }
        }
        #endregion
        #region Da Li Tačka Pripada
        public virtual bool Pripada(Tacka T)
        {
            return (T.Rastojanje(this) < GeoGebra.eps);
        }
        #endregion
        #region Normala
        public Prava Normala(Tacka T)
        {
            if (this.K == 0)
                return null;
            return new Prava((-1) / this.K, T.Y + T.X / this.K, "p" + (Prava.NP + 1).ToString());
        }
        #endregion
        #region Paralela
        public Prava Paralela(Tacka T)
        {
            return new Prava(this.K, T.Y - this.k * T.X, "p" + (Prava.NP + 1).ToString());
        }
        #endregion
        #region Ugao
        #region Ugao Sa Pravom
        public double Ugao(Prava p)
        {
            if ((Math.Abs(this.K - p.K) < GeoGebra.eps) && (Math.Abs(this.N - p.N) < GeoGebra.eps))
                return 0;
            if (Math.Abs(this.K - p.K) < GeoGebra.eps)
                return -1;
            return Math.Round(Math.Min(Math.Abs(Math.Atan(this.K) - Math.Atan(p.K)), Math.PI - Math.Abs(Math.Atan(this.K) - Math.Atan(p.K))) * 360 / (2 * Math.PI), 2);
        }
        #endregion
        #region Ugao Sa Duži
        public double Ugao(Duz d)
        {
            if ((Math.Abs(this.K - d.K) < GeoGebra.eps) && (Math.Abs(this.N - d.N) < GeoGebra.eps))
                return 0;
            if (Math.Abs(this.K - d.K) < GeoGebra.eps)
                return -1;
            return Math.Round(Math.Min(Math.Abs(Math.Atan(this.K) - Math.Atan(d.K)), Math.PI - Math.Abs(Math.Atan(this.K) - Math.Atan(d.K))) * 360 / (2 * Math.PI), 2);
        }
        #endregion
        #endregion
        #region Simetrala Ugla
        #region Simetrala Ugla Sa Pravom
        public Prava SimetralaUgla(Prava p)
        {
            if (this.Presek(p) == null)
                return null;
            if (this.K < p.K)
            {
                double k1 = Math.Tan((Math.Atan(this.K) + Math.Atan(p.K)) / 2);
                double n1 = this.Presek(p).Y - k1 * this.Presek(p).X;
                return new Prava(k1, n1, "p" + (Prava.NP + 1).ToString());
            }
            else
            {
                double k2 = Math.Tan(Math.PI / 2 + (Math.Atan(this.K) + Math.Atan(p.K)) / 2);
                double n2 = this.Presek(p).Y - k2 * this.Presek(p).X;
                return new Prava(k2, n2, "p" + (Prava.NP + 1).ToString());
            }
        }
        #endregion
        #region Simetrala Ugla Sa Duži
        public Prava SimetralaUgla(Duz d)
        {
            if (this.Presek(d) == null)
                return null;
            if (this.K < d.K)
            {
                double k1 = Math.Tan((Math.Atan(this.K) + Math.Atan(d.K)) / 2);
                double n1 = this.Presek(d).Y - k1 * this.Presek(d).X;
                return new Prava(k1, n1, "p" + (Prava.NP + 1).ToString());
            }
            else
            {
                double k2 = Math.Tan(Math.PI / 2 + (Math.Atan(this.K) + Math.Atan(d.K)) / 2);
                double n2 = this.Presek(d).Y - k2 * this.Presek(d).X;
                return new Prava(k2, n2, "p" + (Prava.NP + 1).ToString());
            }
        }
        #endregion
        #endregion
        #region Presek
        #region Presek Sa Pravom
        public virtual Tacka Presek(Prava p)
        {
            if (Math.Abs(this.K - p.K) < GeoGebra.eps)
                return null;
            return new Tacka((p.N - this.N) / (this.K - p.K), (this.K * p.N - p.K * this.N) / (this.K - p.K), "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
        }
        #endregion
        #region Presek Sa Duži
        public virtual Tacka Presek(Duz d)
        {
            if ((Math.Abs(this.K - d.K) > GeoGebra.eps) && ((d.N - this.N) / (this.K - d.K) - Math.Min(d.Tacka1.X, d.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(d.Tacka1.X, d.Tacka2.X) - (d.N - this.N) / (this.K - d.K) > -2 * GeoGebra.eps))
                return new Tacka((d.N - this.N) / (this.K - d.K), (this.K * d.N - d.K * this.N) / (this.K - d.K), "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
            return null;
        }
        #endregion
        #region Presek Sa Krugom
        public virtual void Presek(Krug s, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            if (s.Centar.Rastojanje(this) - s.R > GeoGebra.eps)
                return;
            double a = 1 + this.K * this.K;
            double b = -2 * s.Centar.X + 2 * this.K * this.N - 2 * this.K * s.Centar.Y;
            double c = s.Centar.X * s.Centar.X + this.N * this.N + s.Centar.Y * s.Centar.Y - 2 * this.N * s.Centar.Y - s.R * s.R;
            if (Math.Abs(s.Centar.Rastojanje(this) - s.R) < GeoGebra.eps)
            {
                double x = (-b) / (2 * a);
                double y = this.K * x + this.N;
                GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                return;
            }
            if (s.R - s.Centar.Rastojanje(this) > GeoGebra.eps)
            {
                double x = ((-b) + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                double y = this.K * x + this.N;
                GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                x = ((-b) - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                y = this.K * x + this.N;
                GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                return;
            }
        }
        #endregion
        #endregion
        #region Transformacije
        #region Translacija
        public Prava Translacija(double tx, double ty)
        {
            return new Prava((new Tacka(0, this.N, "", Color.Black)).Translacija(tx, ty), (new Tacka(1, this.N + this.K, "", Color.Black)).Translacija(tx, ty), "p" + (Prava.NP + 1).ToString());
        }
        #endregion
        #region Rotacija
        public Prava Rotacija(Tacka T, double Fi)
        {
            return new Prava((new Tacka(0, this.N, "", Color.Black)).Rotacija(T, Fi), (new Tacka(1, this.N + this.K, "", Color.Black)).Rotacija(T, Fi), "p" + (Prava.NP + 1).ToString());
        }
        #endregion
        #region Homotetija
        public Prava Homotetija(Tacka T, double k1)
        {
            return new Prava((new Tacka(0, this.N, "", Color.Black)).Homotetija(T, k1), (new Tacka(1, this.N + this.K, "", Color.Black)).Homotetija(T, k1), "p" + (Prava.NP + 1).ToString());
        }
        #endregion
        #region Refleksija
        public Prava Refleksija(Prava p)
        {
            return new Prava((new Tacka(0, this.N, "", Color.Black)).Refleksija(p), (new Tacka(1, this.N + this.K, "", Color.Black)).Refleksija(p), "p" + (Prava.NP + 1).ToString());
        }
        #endregion
        #endregion
        #endregion
    }
    #endregion
    #region Duz
    public class Duz : Prava
    {
        #region Static
        public static int ND;
        #endregion
        #region Atributi
        private Tacka A;
        private Tacka B;
        #endregion
        #region Konstruktori
        #region Sa Dve Tačke
        public Duz(Tacka A, Tacka B) : base(A, B, A.Ime + B.Ime)
        {
            if (Math.Abs(B.X - A.X) < GeoGebra.eps)
            {
                this.k = -1;
                this.n = 0;
                this.ime = "-1";
                this.A = null;
                this.B = null;
            }
            else
            {
                this.k = (B.Y - A.Y) / (B.X - A.X);
                this.n = B.Y - k * B.X;
                this.ime = A.Ime + B.Ime;
                this.A = A;
                this.B = B;
            }
        }
        #endregion
        #endregion
        #region Svojstva
        #region Prva Tačka
        public Tacka Tacka1
        {
            get { return this.A; }
        }
        #endregion
        #region Druga Tačka
        public Tacka Tacka2
        {
            get { return this.B; }
        }
        #endregion
        #endregion
        #region Metode
        #region Crtaj
        public void Crtaj(Graphics g, double k, PointF O, ObjekatInfo[] Objekti, int j, RadioButton showhide)
        {
            Pen Olovka;
            if (Objekti[j].Oznacen)
            {
                Olovka = new Pen(Color.Green, 2);
                g.DrawLine(Olovka, (float)(O.X + k * this.Tacka1.X), (float)(O.Y - k * this.Tacka1.Y), (float)(O.X + k * this.Tacka2.X), (float)(O.Y - k * this.Tacka2.Y));
                return;
            }
            if (Objekti[j].Show)
            {
                Olovka = new Pen(Color.Black, 2);
                g.DrawLine(Olovka, (float)(O.X + k * this.Tacka1.X), (float)(O.Y - k * this.Tacka1.Y), (float)(O.X + k * this.Tacka2.X), (float)(O.Y - k * this.Tacka2.Y));
            }
            if ((showhide.Checked) && (!Objekti[j].Show))
            {
                Olovka = new Pen(Color.FromArgb(128, Color.Black), 2);
                g.DrawLine(Olovka, (float)(O.X + k * this.Tacka1.X), (float)(O.Y - k * this.Tacka1.Y), (float)(O.X + k * this.Tacka2.X), (float)(O.Y - k * this.Tacka2.Y));
            }
            return;
        }
        #endregion
        #region Da Li Tačka Pripada
        public override bool Pripada(Tacka T)
        {
            return ((T.Rastojanje(this) < GeoGebra.eps) && (T.X - Math.Min(this.Tacka1.X, this.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(this.Tacka1.X, this.Tacka2.X) - T.X > -2 * GeoGebra.eps));
        }
        #endregion
        #region Simetrala Duži
        public Prava Simetrala()
        {
            return this.Normala(new Tacka((this.Tacka1.X + this.Tacka2.X) / 2, (this.Tacka1.Y + this.Tacka2.Y) / 2, "A" + (Tacka.NT + 1).ToString(), Color.Black));
        }
        #endregion
        #region Pravilan Mnogougao
        public void PravilanMnogougao(int n1, Tacka[] Tacke, Duz[] Duzi, ObjekatInfo[] Objekti)
        {
            Duz d = this;
            double Fi = Math.PI - 2 * Math.PI / n1;
            for (int i = 1; i < n1; i++)
            {
                GeoGebra.DodajDuz(new Duz(d.Tacka2.Rotacija(d.Tacka1, Fi), d.Tacka1), Duzi, Objekti);
                GeoGebra.DodajTacku(Duzi[Duz.ND - 1].Tacka1, Tacke, Objekti);
                d = new Duz(d.Tacka2.Rotacija(d.Tacka1, Fi), d.Tacka1);
            }
            Tacke[Tacka.NT - 1] = null;
            Tacka.NT--;
            Objekti[Tacka.NT + Prava.NP + Duz.ND + Krug.NK] = null;
            return;
        }
        #endregion
        #region Presek
        #region Presek Sa Pravom
        public override Tacka Presek(Prava p)
        {
            return p.Presek(this);
        }
        #endregion
        #region Presek Sa Duži
        public override Tacka Presek(Duz d)
        {
            if ((Math.Abs(this.K - d.K) > GeoGebra.eps) && ((d.N - this.N) / (this.K - d.K) - Math.Min(this.Tacka1.X, this.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(this.Tacka1.X, this.Tacka2.X) - (d.N - this.N) / (this.K - d.K) > -2 * GeoGebra.eps) && ((d.N - this.N) / (this.K - d.K) - Math.Min(d.Tacka1.X, d.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(d.Tacka1.X, d.Tacka2.X) - (d.N - this.N) / (this.K - d.K) > -2 * GeoGebra.eps))
                return new Tacka((d.N - this.N) / (this.K - d.K), (this.K * d.N - d.K * this.N) / (this.K - d.K), "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
            return null;
        }
        #endregion
        #region Presek Sa Krugom
        public override void Presek(Krug s, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            if (s.Centar.Rastojanje(this) - s.R > GeoGebra.eps) return;
            double a = 1 + this.K * this.K;
            double b = -2 * s.Centar.X + 2 * this.K * this.N - 2 * this.K * s.Centar.Y;
            double c = s.Centar.X * s.Centar.X + this.N * this.N + s.Centar.Y * s.Centar.Y - 2 * this.N * s.Centar.Y - s.R * s.R;
            if (Math.Abs(s.Centar.Rastojanje(this) - s.R) < GeoGebra.eps)
            {
                double x = (-b) / (2 * a);
                double y = this.K * x + this.N;
                if ((x - Math.Min(this.Tacka1.X, this.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(this.Tacka1.X, this.Tacka2.X) - x > -2 * GeoGebra.eps))
                    GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                return;
            }
            if (s.R - s.Centar.Rastojanje(this) > GeoGebra.eps)
            {
                double x = ((-b) + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                double y = this.K * x + this.N;
                if ((x - Math.Min(this.Tacka1.X, this.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(this.Tacka1.X, this.Tacka2.X) - x > -2 * GeoGebra.eps))
                    GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                x = ((-b) - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                y = this.K * x + this.N;
                if ((x - Math.Min(this.Tacka1.X, this.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(this.Tacka1.X, this.Tacka2.X) - x > -2 * GeoGebra.eps))
                    GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                return;
            }
        }
        #endregion
        #endregion
        #region Transformacije
        #region Translacija
        public Duz Translacija(double tx, double ty, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            GeoGebra.DodajTacku(this.Tacka1.Translacija(tx, ty), Tacke, Objekti);
            GeoGebra.DodajTacku(this.Tacka2.Translacija(tx, ty), Tacke, Objekti);
            return new Duz(Tacke[Tacka.NT - 2], Tacke[Tacka.NT - 1]);
        }
        #endregion
        #region Rotacija
        public Duz Rotacija(Tacka T, double Fi, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            GeoGebra.DodajTacku(this.Tacka1.Rotacija(T, Fi), Tacke, Objekti);
            GeoGebra.DodajTacku(this.Tacka2.Rotacija(T, Fi), Tacke, Objekti);
            return new Duz(Tacke[Tacka.NT - 2], Tacke[Tacka.NT - 1]);
        }
        #endregion
        #region Homotetija
        public Duz Homotetija(Tacka T, double k1, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            GeoGebra.DodajTacku(this.Tacka1.Homotetija(T, k1), Tacke, Objekti);
            GeoGebra.DodajTacku(this.Tacka2.Homotetija(T, k1), Tacke, Objekti);
            return new Duz(Tacke[Tacka.NT - 2], Tacke[Tacka.NT - 1]);
        }
        #endregion
        #region Refleksija
        public Duz Refleksija(Prava p, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            GeoGebra.DodajTacku(this.Tacka1.Refleksija(p), Tacke, Objekti);
            GeoGebra.DodajTacku(this.Tacka2.Refleksija(p), Tacke, Objekti);
            return new Duz(Tacke[Tacka.NT - 2], Tacke[Tacka.NT - 1]);
        }
        #endregion
        #endregion
        #endregion
    }
    #endregion
}