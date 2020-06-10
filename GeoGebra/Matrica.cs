using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeoGebra
{
    #region Matrica
    public class Matrica
    {
        #region Atributi
        protected double[,] mat;
        #endregion
        #region Konsturktori
        #region Sa Atributima
        public Matrica(double[,] m)
        {
            this.mat = m;
        }
        #endregion
        #endregion
        #region Svojstva
        #region Matrica
        public double[,] Mat
        {
            get { return this.mat; }
            set { this.mat = value; }
        }
        #endregion
        #endregion
        #region Operatori
        #region Množenje
        public static double[,] operator *(Matrica m1, Matrica m2)
        {
            if (m1.mat.GetLength(1) != m2.mat.GetLength(0)) return null;
            double[,] res = new double[m1.mat.GetLength(0), m2.mat.GetLength(1)];
            for (int i = 0; i < m1.mat.GetLength(0); i++)
                for (int j = 0; j < m2.mat.GetLength(1); j++)
                {
                    double s = 0;
                    for (int k = 0; k < m1.mat.GetLength(1); k++)
                        s += m1.Mat[i, k] * m2.Mat[k, j];
                    res[i, j] = s;
                }
            return res;
        }
        #endregion
        #endregion
    }
    #endregion
    #region Tacka
    public class Tacka : Matrica
    {
        #region Static
        public static int NT;
        #endregion
        #region Atributi
        private string ime;
        private Color boja;
        #endregion
        #region Konstruktori
        #region Sa Atributima
        public Tacka(double[,] m, string i, Color b) : base(new double[3, 1] { { m[0, 0] }, { m[1, 0] }, { 1 } })
        {
            this.ime = i;
            this.boja = b;
        }
        #endregion
        #region Sa Koordinatama
        public Tacka(double x, double y, string i, Color b) : base(new double[3, 1] { { x }, { y }, { 1 } })
        {
            this.ime = i;
            this.boja = b;
        }
        #endregion
        #endregion
        #region Svojstva
        #region Ime
        public string Ime
        {
            get { return this.ime; }
            set { this.ime = value; }
        }
        #endregion
        #region Boja
        public Color Boja
        {
            get { return this.boja; }
            set { this.boja = value; }
        }
        #endregion
        #region X Koordinata
        public double X
        {
            get { return this.Mat[0, 0]; }
        }
        #endregion
        #region Y Koordinata
        public double Y
        {
            get { return this.Mat[1, 0]; }
        }
        #endregion
        #endregion
        #region Metode
        #region Crtaj
        public void Crtaj(Graphics g, double k, PointF O, ObjekatInfo[] Objekti, int j, RadioButton showhide)
        {
            if (Objekti[j].Oznacen)
            {
                if (this.boja == Color.DarkGray)
                {
                    g.FillEllipse(new SolidBrush(Color.Green), (float)(O.X + k * this.Mat[0, 0] - 3), (float)(O.Y - k * this.Mat[1, 0] - 3), 6, 6);
                    g.DrawEllipse(new Pen(Color.Black, 1), (float)(O.X + k * this.Mat[0, 0] - 3), (float)(O.Y - k * this.Mat[1, 0] - 3), 6, 6);
                    return;
                }
                g.FillEllipse(new SolidBrush(Color.Green), (float)(O.X + k * this.Mat[0, 0] - 4), (float)(O.Y - k * this.Mat[1, 0] - 4), 8, 8);
                g.DrawEllipse(new Pen(Color.Black, 1), (float)(O.X + k * this.Mat[0, 0] - 4), (float)(O.Y - k * this.Mat[1, 0] - 4), 8, 8);
                return;
            }
            if (Objekti[j].Show)
            {
                if (this.boja == Color.DarkGray)
                {
                    g.FillEllipse(new SolidBrush(boja), (float)(O.X + k * this.Mat[0, 0] - 3), (float)(O.Y - k * this.Mat[1, 0] - 3), 6, 6);
                    g.DrawEllipse(new Pen(Color.Black, 1), (float)(O.X + k * this.Mat[0, 0] - 3), (float)(O.Y - k * this.Mat[1, 0] - 3), 6, 6);
                    return;
                }
                g.FillEllipse(new SolidBrush(boja), (float)(O.X + k * this.Mat[0, 0] - 4), (float)(O.Y - k * this.Mat[1, 0] - 4), 8, 8);
                g.DrawEllipse(new Pen(Color.Black, 1), (float)(O.X + k * this.Mat[0, 0] - 4), (float)(O.Y - k * this.Mat[1, 0] - 4), 8, 8);
            }
            if ((showhide.Checked) && (!Objekti[j].Show))
            {
                if (this.boja == Color.DarkGray)
                {
                    g.FillEllipse(new SolidBrush(Color.FromArgb(128, boja)), (float)(O.X + k * this.Mat[0, 0] - 3), (float)(O.Y - k * this.Mat[1, 0] - 3), 6, 6);
                    g.DrawEllipse(new Pen(Color.FromArgb(128, Color.Black), 1), (float)(O.X + k * this.Mat[0, 0] - 3), (float)(O.Y - k * this.Mat[1, 0] - 3), 6, 6);
                    return;
                }
                g.FillEllipse(new SolidBrush(Color.FromArgb(128, boja)), (float)(O.X + k * this.Mat[0, 0] - 4), (float)(O.Y - k * this.Mat[1, 0] - 4), 8, 8);
                g.DrawEllipse(new Pen(Color.FromArgb(128, Color.Black), 1), (float)(O.X + k * this.Mat[0, 0] - 4), (float)(O.Y - k * this.Mat[1, 0] - 4), 8, 8);
            }
            return;
        }
        #endregion
        #region Rastojanje
        #region Rastojanje Od Tačke
        public double Rastojanje(Tacka T)
        {
            return Math.Sqrt((this.X - T.X) * (this.X - T.X) + (this.Y - T.Y) * (this.Y - T.Y));
        }
        #endregion
        #region Rastojanje Od Prave
        public double Rastojanje(Prava p)
        {
            return this.Rastojanje(p.Presek(p.Normala(this)));
        }
        #endregion
        #region Rastojanje Od Prave Na Kojoj Leži Duž
        public double Rastojanje(Duz d)
        {
            return this.Rastojanje((new Prava(d.K, d.N, "")).Presek((new Prava(d.K, d.N, "")).Normala(this)));
        }
        #endregion
        #region Rastojanje Od Duži
        public double Rastojanje1(Duz d)
        {
            if (d.Pripada((new Prava(d.K, d.N, "")).Presek((new Prava(d.K, d.N, "")).Normala(this))))
                return this.Rastojanje((new Prava(d.K, d.N, "")).Presek((new Prava(d.K, d.N, "")).Normala(this)));
            return Math.Min(this.Rastojanje(d.Tacka1), this.Rastojanje(d.Tacka2));
        }
        #endregion
        #region Rastojanje Od Kruga
        public double Rastojanje(Krug k)
        {
            return Math.Abs(k.R - this.Rastojanje(k.Centar));
        }
        #endregion
        #endregion
        #region Transformacije
        #region Translacija
        public Tacka Translacija(double tx, double ty)
        {
            return new Tacka((new Translacija(tx, ty)) * this, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
        }
        #endregion
        #region Rotacija
        public Tacka Rotacija(Tacka T, double Fi)
        {
            return new Tacka((new Rotacija(T, Fi)) * this, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
        }
        #endregion
        #region Homotetija
        public Tacka Homotetija(Tacka T, double k1)
        {
            return new Tacka((new Homotetija(T, k1)) * this, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
        }
        #endregion
        #region Refleksija
        public Tacka Refleksija(Prava p)
        {
            return new Tacka((new Refleksija(p)) * this, "A" + (Tacka.NT + 1).ToString(), Color.DarkGray);
        }

        #endregion
        #endregion
        #endregion
    }
    #endregion
    #region Transformacije
    #region Translacija
    public class Translacija : Matrica
    {
        #region Konstruktori
        public Translacija(double tx, double ty) : base(new double[3, 3] { { 1, 0, tx }, { 0, 1, ty }, { 0, 0, 1 } }) { }
        #endregion
    }
    #endregion
    #region Rotacija
    public class Rotacija : Matrica
    {
        #region Konstruktori
        public Rotacija(Tacka T, double Fi) : base(new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } })
        {
            this.mat = (new Matrica((new Translacija(T.X, T.Y)) * (new Matrica(new double[3, 3] { { Math.Cos(Fi), (-1) * Math.Sin(Fi), 0 }, { Math.Sin(Fi), Math.Cos(Fi), 0 }, { 0, 0, 1 } })))) * (new Translacija(-T.X, -T.Y));
        }
        #endregion
    }
    #endregion
    #region Homotetija
    public class Homotetija : Matrica
    {
        #region Konstruktori
        public Homotetija(Tacka T, double k) : base(new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } })
        {
            this.mat = (new Matrica((new Translacija(T.X, T.Y)) * (new Matrica(new double[3, 3] { { k, 0, 0 }, { 0, k, 0 }, { 0, 0, 1 } })))) * (new Translacija(-T.X, -T.Y));
        }
        #endregion
    }
    #endregion
    #region Refleksija
    public class Refleksija : Matrica
    {
        #region Konstruktori
        public Refleksija(Prava p) : base(new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } })
        {
            this.mat = (new Matrica((new Matrica((new Matrica((new Translacija(0, p.N)) * (new Rotacija(new Tacka(0, 0, "", Color.Black), Math.Atan(p.K))))) * (new Matrica(new double[3, 3] { { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } })))) * (new Rotacija(new Tacka(0, 0, "", Color.Black), Math.Atan(-p.K))))) * (new Translacija(0, -p.N));
        }
        #endregion
    }
    #endregion
    #endregion
}