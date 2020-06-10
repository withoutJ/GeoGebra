namespace GeoGebra
{
    public class ObjekatInfo
    {
        #region Atributi
        private int vrsta;
        private int idx;
        private bool oznacen;
        private int korak;
        private bool show;
        #endregion
        #region Konstruktori
        #region Sa Atributima
        public ObjekatInfo(int vrsta, int idx, bool oznacen, int korak, bool show)
        {
            this.vrsta = vrsta;
            this.idx = idx;
            this.oznacen = oznacen;
            this.korak = korak;
            this.show = show;
        }
        #endregion
        #endregion
        #region Svojstva
        #region Vrsta
        public int Vrsta
        {
            get { return this.vrsta; }
            set { this.vrsta = value; }
        }
        #endregion
        #region Indeks
        public int Indeks
        {
            get { return this.idx; }
            set { this.idx = value; }
        }
        #endregion
        #region Označen
        public bool Oznacen
        {
            get { return this.oznacen; }
            set { this.oznacen = value; }
        }
        #endregion
        #region Korak
        public int Korak
        {
            get { return this.korak; }
            set { this.korak = value; }
        }
        #endregion
        #region Show
        public bool Show
        {
            get { return this.show; }
            set { this.show = value; }
        }
        #endregion
        #endregion 
    }
}