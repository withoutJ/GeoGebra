using System;
using System.Windows.Forms;

namespace GeoGebra
{
    public partial class PopUp : Form
    {
        #region Konstruktori
        public PopUp(string Info)
        {
            InitializeComponent();
            tekst.Text = Info;
        }
        #endregion
        #region Promenljive
        public static string s;
        #endregion
        #region Potvrdi Click
        private void potvrdi_Click(object sender, EventArgs e)
        {
            s = textBox1.Text;
            return;
        }
        #endregion
    }
}