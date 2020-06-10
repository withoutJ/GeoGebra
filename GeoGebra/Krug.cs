using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeoGebra
{
    public class Krug
    {
        #region Static
        public static int NK;
        #endregion
        #region Atributi
        private Tacka C;
        private double r;
        private string ime;
        #endregion
        #region Konstruktori
        #region Sa Atributima
        public Krug(Tacka Centar, double R, string ime)
        {
            this.C = Centar;
            this.r = R;
            this.ime = ime;
        }
        #endregion
        #region Centar i Tačka Na Krugu
        public Krug(Tacka A, Tacka B, string ime)
        {
            if (A.Rastojanje(B) < GeoGebra.eps)
            {
                this.C = null;
                this.r = 0;
                this.ime = "-1";
            }
            else
            {
                this.C = A;
                this.r = A.Rastojanje(B);
                this.ime = ime;
            }
        }
        #endregion
        #region Šestar
        public Krug(Tacka A, Duz d, string ime)
        {
            this.C = A;
            this.r = d.Tacka1.Rastojanje(d.Tacka2);
            this.ime = ime;
        }
        #endregion
        #region Tri Tačke Na Krugu
        public Krug(Tacka A1, Tacka A2, Tacka A3, string ime)
        {
            Duz a = new Duz(A1, A2);
            Duz b = new Duz(A2, A3);
            if ((Math.Abs(b.K - a.K) < GeoGebra.eps) || (a.Ime == "-1") || (b.Ime == "-1"))
            {
                this.C = null;
                this.r = 0;
                this.ime = "-1";
            }
            else
            {
                this.C = b.Simetrala().Presek(a.Simetrala());
                this.r = C.Rastojanje(A1);
                this.ime = ime;
            }
        }
        #endregion
        #endregion
        #region Svojstva
        #region Centar
        public Tacka Centar
        {
            get { return this.C; }
        }
        #endregion
        #region Poluprečnik
        public double R
        {
            get { return this.r; }
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
        public void Crtaj(Graphics g, double k, PointF O, ObjekatInfo[] Objekti, int j, RadioButton showhide)
        {
            Pen Olovka;
            if (Objekti[j].Oznacen)
            {
                Olovka = new Pen(Color.Green, 2);
                g.DrawEllipse(Olovka, (float)(O.X + k * this.Centar.X - k * this.R), (float)(O.Y - k * this.Centar.Y - k * this.R), (float)(2 * k * this.R), (float)(2 * k * this.R));
                return;
            }
            if (Objekti[j].Show)
            {
                Olovka = new Pen(Color.Black, 2);
                g.DrawEllipse(Olovka, (float)(O.X + k * this.Centar.X - k * this.R), (float)(O.Y - k * this.Centar.Y - k * this.R), (float)(2 * k * this.R), (float)(2 * k * this.R));
            }
            if ((showhide.Checked) && (!Objekti[j].Show))
            {
                Olovka = new Pen(Color.FromArgb(128, Color.Black), 2);
                g.DrawEllipse(Olovka, (float)(O.X + k * this.Centar.X - k * this.R), (float)(O.Y - k * this.Centar.Y - k * this.R), (float)(2 * k * this.R), (float)(2 * k * this.R));
            }
            return;
        }
        #endregion
        #region Da Li Tačka Pripada
        public int Pripada(Tacka A)
        {
            if (this.R - A.Rastojanje(this.C) > GeoGebra.eps)
                return 2;
            if (Math.Abs(A.Rastojanje(this.C) - this.R) < GeoGebra.eps)
                return 1;
            else
                return 0;
        }
        #endregion
        #region Tangente
        public void Tangente(Tacka T, Prava[] Prave, ObjekatInfo[] Objekti)
        {
            if (this.Pripada(T) == 2)
                return;
            double a = this.R * this.R - this.Centar.X * this.Centar.X - T.X * T.X + 2 * T.X * this.Centar.X;
            double b = 2 * T.X * T.Y + 2 * this.Centar.X * this.Centar.Y - 2 * this.Centar.Y * T.X - 2 * T.Y * this.Centar.X;
            double c = this.R * this.R - this.Centar.Y * this.Centar.Y - T.Y * T.Y + 2 * this.Centar.Y * T.Y;
            if (this.Pripada(T) == 1)
            {
                double k = (-b) / (2 * a);
                double n = T.Y - k * T.X;
                GeoGebra.DodajPravu(new Prava(k, n, "p" + (Prava.NP + 1).ToString()), Prave, Objekti);
                return;
            }
            if (this.Pripada(T) == 0)
            {
                double k = ((-b) + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                double n = T.Y - k * T.X;
                GeoGebra.DodajPravu(new Prava(k, n, "p" + (Prava.NP + 1).ToString()), Prave, Objekti);
                k = ((-b) - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                n = T.Y - k * T.X;
                GeoGebra.DodajPravu(new Prava(k, n, "p" + (Prava.NP + 1).ToString()), Prave, Objekti);
                return;
            }
        }
        #endregion
        #region Inverzija
        #region Inverzija Tačke
        public Tacka Inverzija(Tacka T)
        {
            double k1 = (this.Centar.Y - T.Y) / (this.Centar.X - T.X);
            if (this.Centar.X < T.X)
                return new Tacka(this.Centar.X + (this.R * this.R / this.Centar.Rastojanje(T)) * (Math.Cos(Math.Atan(k1))), this.Centar.Y + (this.R * this.R / this.Centar.Rastojanje(T)) * (Math.Sin(Math.Atan(k1))), "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
            else
                return new Tacka(this.Centar.X - (this.R * this.R / this.Centar.Rastojanje(T)) * (Math.Cos(Math.Atan(k1))), this.Centar.Y - (this.R * this.R / this.Centar.Rastojanje(T)) * (Math.Sin(Math.Atan(k1))), "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
        }
        #endregion
        #region Inverzija Prave Koja Prolazi Kroz Centar
        public Prava InverzijaProlazi(Prava p)
        {
            return new Prava(p.K, p.N, (Prava.NP + 1).ToString());
        }
        #endregion
        #region Inverzija Prave Koja Ne Prolazi Kroz Centar
        public Krug InverzijaNeProlazi(Prava p)
        {
            return new Krug(this.Centar, this.Inverzija(new Tacka(0, p.N, "", Color.Black)), this.Inverzija(new Tacka(1, p.K + p.N, "", Color.Black)), "k" + (Krug.NK + 1).ToString());
        }
        #endregion
        #region Inverzija Kruga Koji Prolazi Kroz Centar
        public Prava InverzijaProlazi(Krug k1)
        {
            return new Prava(this.Inverzija(this.Centar.Rotacija(k1.Centar, Math.PI / 2)), this.Inverzija(this.Centar.Rotacija(k1.Centar, -Math.PI / 2)), "p" + (Prava.NP + 1).ToString());
        }
        #endregion
        #region Inverzija Kruga Koji Ne Prolazi Kroz Centar
        public Krug InverzijaNeProlazi(Krug k1)
        {
            return new Krug(this.Inverzija(new Tacka(k1.Centar.X - k1.R, k1.Centar.Y, "", Color.Black)), this.Inverzija(new Tacka(k1.Centar.X + k1.R, k1.Centar.Y, "", Color.Black)), this.Inverzija(new Tacka(k1.Centar.X, k1.Centar.Y - k1.R, "", Color.Black)), "k" + (Krug.NK + 1).ToString());
        }
        #endregion
        #endregion
        #region Presek
        #region Presek Sa Pravom
        public void Presek(Prava p, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            if (this.Centar.Rastojanje(p) - this.R > GeoGebra.eps)
                return;
            double a = 1 + p.K * p.K;
            double b = -2 * this.Centar.X + 2 * p.K * p.N - 2 * p.K * this.Centar.Y;
            double c = this.Centar.X * this.Centar.X + p.N * p.N + this.Centar.Y * this.Centar.Y - 2 * p.N * this.Centar.Y - this.R * this.R;
            if (Math.Abs(this.Centar.Rastojanje(p) - this.R) < GeoGebra.eps)
            {
                double x = (-b) / (2 * a);
                double y = p.K * x + p.N;
                GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                return;
            }
            if (this.R - this.Centar.Rastojanje(p) > GeoGebra.eps)
            {
                double x = ((-b) + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                double y = p.K * x + p.N;
                GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                x = ((-b) - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                y = p.K * x + p.N;
                GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                return;
            }
        }
        #endregion
        #region Presek Sa Duži
        public void Presek(Duz d, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            if (this.Centar.Rastojanje(d) - this.R > GeoGebra.eps)
                return;
            double a = 1 + d.K * d.K;
            double b = -2 * this.Centar.X + 2 * d.K * d.N - 2 * d.K * this.Centar.Y;
            double c = this.Centar.X * this.Centar.X + d.N * d.N + this.Centar.Y * this.Centar.Y - 2 * d.N * this.Centar.Y - this.R * this.R;
            if (Math.Abs(this.Centar.Rastojanje(d) - this.R) < GeoGebra.eps)
            {
                double x = (-b) / (2 * a);
                double y = d.K * x + d.N;
                if ((x - Math.Min(d.Tacka1.X, d.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(d.Tacka1.X, d.Tacka2.X) - x > -2 * GeoGebra.eps))
                    GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                return;
            }
            if (this.R - this.Centar.Rastojanje(d) > GeoGebra.eps)
            {
                double x = ((-b) + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                double y = d.K * x + d.N;
                if ((x - Math.Min(d.Tacka1.X, d.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(d.Tacka1.X, d.Tacka2.X) - x > -2 * GeoGebra.eps))
                    GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                x = ((-b) - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                y = d.K * x + d.N;
                if ((x - Math.Min(d.Tacka1.X, d.Tacka2.X) > -2 * GeoGebra.eps) && (Math.Max(d.Tacka1.X, d.Tacka2.X) - x > -2 * GeoGebra.eps))
                    GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                return;
            }
        }
        #endregion
        #region Presek Sa Krugom
        public void Presek(Krug k1, Tacka[] Tacke, ObjekatInfo[] Objekti)
        {
            if (Math.Abs(this.Centar.Y - k1.C.Y) < GeoGebra.eps)
            {
                if (Math.Abs(this.Centar.X - k1.C.X) < GeoGebra.eps)
                    return;
                double x = (this.R * this.R - k1.R * k1.R + k1.Centar.X * k1.Centar.X - this.Centar.X * this.Centar.X) / (2 * (k1.Centar.X - this.Centar.X));
                double b = (-2) * this.Centar.Y;
                double c = (x - this.Centar.X) * (x - this.Centar.X) - this.R * this.R;
                if (b * b - 4 * c < 0)
                    return;
                if (b * b - 4 * c < GeoGebra.eps)
                    GeoGebra.DodajTacku(new Tacka(x, (-b) / 2, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                else
                {
                    double y = (-b + Math.Sqrt(b * b - 4 * c)) / 2;
                    GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                    y = (-b - Math.Sqrt(b * b - 4 * c)) / 2;
                    GeoGebra.DodajTacku(new Tacka(x, y, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray), Tacke, Objekti);
                    return;
                }
            }
            double k = (this.Centar.X - k1.Centar.X) / (k1.Centar.Y - this.Centar.Y);
            double n = (this.R * this.R - k1.R * k1.R + k1.Centar.X * k1.Centar.X - this.Centar.X * this.Centar.X + k1.Centar.Y * k1.Centar.Y - this.Centar.Y * this.Centar.Y) / (2 * (k1.Centar.Y - this.Centar.Y));
            Prava p = new Prava(k, n, "");
            this.Presek(p, Tacke, Objekti);
        }
        #endregion
        #endregion
        #region Transformacije
        #region Translacija
        public Krug Translacija(double tx, double ty)
        {
            return new Krug(this.Centar.Translacija(tx, ty), this.R, "k" + (NK + 1).ToString());
        }
        #endregion
        #region Rotacija
        public Krug Rotacija(Tacka T, double Fi)
        {
            return new Krug(this.Centar.Rotacija(T, Fi), this.R, "k" + (NK + 1).ToString());
        }
        #endregion
        #region Homotetija
        public Krug Homotetija(Tacka T, double k1)
        {
            return new Krug(this.Centar.Homotetija(T, k1), this.R * k1, "k" + (NK + 1).ToString());
        }
        #endregion
        #region Refleksija
        public Krug Refleksija(Prava p)
        {
            return new Krug(this.Centar.Refleksija(p), this.R, "k" + (NK + 1).ToString());
        }
        #endregion
        #endregion
        #endregion
    }
}