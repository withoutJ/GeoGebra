namespace GeoGebra
{
    partial class GeoGebra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.crtanjetacke = new System.Windows.Forms.RadioButton();
            this.crtanje = new System.Windows.Forms.Label();
            this.crtanjeduzi = new System.Windows.Forms.RadioButton();
            this.crtanjeprave = new System.Windows.Forms.RadioButton();
            this.presek = new System.Windows.Forms.RadioButton();
            this.duzdateduzine = new System.Windows.Forms.RadioButton();
            this.ugaodatevelicine = new System.Windows.Forms.RadioButton();
            this.konstrukcije = new System.Windows.Forms.Label();
            this.sredisteduzi = new System.Windows.Forms.RadioButton();
            this.normala = new System.Windows.Forms.RadioButton();
            this.paralela = new System.Windows.Forms.RadioButton();
            this.simetraladuzi = new System.Windows.Forms.RadioButton();
            this.simetralaugla = new System.Windows.Forms.RadioButton();
            this.tangente = new System.Windows.Forms.RadioButton();
            this.merenja = new System.Windows.Forms.Label();
            this.duzinaduzi = new System.Windows.Forms.RadioButton();
            this.velicinaugla = new System.Windows.Forms.RadioButton();
            this.duzinaduzitext = new System.Windows.Forms.Label();
            this.velicinauglatext = new System.Windows.Forms.Label();
            this.konstrukcijekrugova = new System.Windows.Forms.Label();
            this.centaritackanakrugu = new System.Windows.Forms.RadioButton();
            this.centaripoluprecnik = new System.Windows.Forms.RadioButton();
            this.tritacke = new System.Windows.Forms.RadioButton();
            this.sestar = new System.Windows.Forms.RadioButton();
            this.nalazenjecentra = new System.Windows.Forms.RadioButton();
            this.pravilanmnogougao = new System.Windows.Forms.RadioButton();
            this.transformacije = new System.Windows.Forms.Label();
            this.translacija = new System.Windows.Forms.RadioButton();
            this.rotacija = new System.Windows.Forms.RadioButton();
            this.refleksija = new System.Windows.Forms.RadioButton();
            this.homotetija = new System.Windows.Forms.RadioButton();
            this.inverzija = new System.Windows.Forms.RadioButton();
            this.obrisisve = new System.Windows.Forms.Button();
            this.undo = new System.Windows.Forms.Button();
            this.showhide = new System.Windows.Forms.RadioButton();
            this.pomeraj = new System.Windows.Forms.RadioButton();
            this.zoomin = new System.Windows.Forms.Button();
            this.zoomout = new System.Windows.Forms.Button();
            this.osnovnialati = new System.Windows.Forms.Label();
            this.zoomintimer = new System.Windows.Forms.Timer(this.components);
            this.zoomouttimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(595, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // crtanjetacke
            // 
            this.crtanjetacke.AutoSize = true;
            this.crtanjetacke.Location = new System.Drawing.Point(610, 100);
            this.crtanjetacke.Name = "crtanjetacke";
            this.crtanjetacke.Size = new System.Drawing.Size(92, 17);
            this.crtanjetacke.TabIndex = 1;
            this.crtanjetacke.TabStop = true;
            this.crtanjetacke.Text = "Crtanje Tačke";
            this.crtanjetacke.UseVisualStyleBackColor = true;
            // 
            // crtanje
            // 
            this.crtanje.AutoSize = true;
            this.crtanje.Location = new System.Drawing.Point(600, 80);
            this.crtanje.Name = "crtanje";
            this.crtanje.Size = new System.Drawing.Size(40, 13);
            this.crtanje.TabIndex = 2;
            this.crtanje.Text = "Crtanje";
            // 
            // crtanjeduzi
            // 
            this.crtanjeduzi.AutoSize = true;
            this.crtanjeduzi.Location = new System.Drawing.Point(610, 120);
            this.crtanjeduzi.Name = "crtanjeduzi";
            this.crtanjeduzi.Size = new System.Drawing.Size(82, 17);
            this.crtanjeduzi.TabIndex = 3;
            this.crtanjeduzi.TabStop = true;
            this.crtanjeduzi.Text = "Crtanje Duži";
            this.crtanjeduzi.UseVisualStyleBackColor = true;
            // 
            // crtanjeprave
            // 
            this.crtanjeprave.AutoSize = true;
            this.crtanjeprave.Location = new System.Drawing.Point(610, 140);
            this.crtanjeprave.Name = "crtanjeprave";
            this.crtanjeprave.Size = new System.Drawing.Size(89, 17);
            this.crtanjeprave.TabIndex = 4;
            this.crtanjeprave.TabStop = true;
            this.crtanjeprave.Text = "Crtanje Prave";
            this.crtanjeprave.UseVisualStyleBackColor = true;
            // 
            // presek
            // 
            this.presek.AutoSize = true;
            this.presek.Location = new System.Drawing.Point(610, 160);
            this.presek.Name = "presek";
            this.presek.Size = new System.Drawing.Size(58, 17);
            this.presek.TabIndex = 5;
            this.presek.TabStop = true;
            this.presek.Text = "Presek";
            this.presek.UseVisualStyleBackColor = true;
            // 
            // duzdateduzine
            // 
            this.duzdateduzine.AutoSize = true;
            this.duzdateduzine.Location = new System.Drawing.Point(610, 180);
            this.duzdateduzine.Name = "duzdateduzine";
            this.duzdateduzine.Size = new System.Drawing.Size(106, 17);
            this.duzdateduzine.TabIndex = 6;
            this.duzdateduzine.TabStop = true;
            this.duzdateduzine.Text = "Duž Date Dužine";
            this.duzdateduzine.UseVisualStyleBackColor = true;
            // 
            // ugaodatevelicine
            // 
            this.ugaodatevelicine.AutoSize = true;
            this.ugaodatevelicine.Location = new System.Drawing.Point(610, 200);
            this.ugaodatevelicine.Name = "ugaodatevelicine";
            this.ugaodatevelicine.Size = new System.Drawing.Size(117, 17);
            this.ugaodatevelicine.TabIndex = 7;
            this.ugaodatevelicine.TabStop = true;
            this.ugaodatevelicine.Text = "Ugao Date Veličine";
            this.ugaodatevelicine.UseVisualStyleBackColor = true;
            // 
            // konstrukcije
            // 
            this.konstrukcije.AutoSize = true;
            this.konstrukcije.Location = new System.Drawing.Point(740, 10);
            this.konstrukcije.Name = "konstrukcije";
            this.konstrukcije.Size = new System.Drawing.Size(65, 13);
            this.konstrukcije.TabIndex = 8;
            this.konstrukcije.Text = "Konstrukcije";
            // 
            // sredisteduzi
            // 
            this.sredisteduzi.AutoSize = true;
            this.sredisteduzi.Location = new System.Drawing.Point(750, 30);
            this.sredisteduzi.Name = "sredisteduzi";
            this.sredisteduzi.Size = new System.Drawing.Size(87, 17);
            this.sredisteduzi.TabIndex = 9;
            this.sredisteduzi.TabStop = true;
            this.sredisteduzi.Text = "Središte Duži";
            this.sredisteduzi.UseVisualStyleBackColor = true;
            // 
            // normala
            // 
            this.normala.AutoSize = true;
            this.normala.Location = new System.Drawing.Point(750, 50);
            this.normala.Name = "normala";
            this.normala.Size = new System.Drawing.Size(64, 17);
            this.normala.TabIndex = 10;
            this.normala.TabStop = true;
            this.normala.Text = "Normala";
            this.normala.UseVisualStyleBackColor = true;
            // 
            // paralela
            // 
            this.paralela.AutoSize = true;
            this.paralela.Location = new System.Drawing.Point(750, 70);
            this.paralela.Name = "paralela";
            this.paralela.Size = new System.Drawing.Size(63, 17);
            this.paralela.TabIndex = 11;
            this.paralela.TabStop = true;
            this.paralela.Text = "Paralela";
            this.paralela.UseVisualStyleBackColor = true;
            // 
            // simetraladuzi
            // 
            this.simetraladuzi.AutoSize = true;
            this.simetraladuzi.Location = new System.Drawing.Point(750, 90);
            this.simetraladuzi.Name = "simetraladuzi";
            this.simetraladuzi.Size = new System.Drawing.Size(92, 17);
            this.simetraladuzi.TabIndex = 12;
            this.simetraladuzi.TabStop = true;
            this.simetraladuzi.Text = "Simetrala Duži";
            this.simetraladuzi.UseVisualStyleBackColor = true;
            // 
            // simetralaugla
            // 
            this.simetralaugla.AutoSize = true;
            this.simetralaugla.Location = new System.Drawing.Point(750, 110);
            this.simetralaugla.Name = "simetralaugla";
            this.simetralaugla.Size = new System.Drawing.Size(93, 17);
            this.simetralaugla.TabIndex = 13;
            this.simetralaugla.TabStop = true;
            this.simetralaugla.Text = "Simetrala Ugla";
            this.simetralaugla.UseVisualStyleBackColor = true;
            // 
            // tangente
            // 
            this.tangente.AutoSize = true;
            this.tangente.Location = new System.Drawing.Point(750, 130);
            this.tangente.Name = "tangente";
            this.tangente.Size = new System.Drawing.Size(71, 17);
            this.tangente.TabIndex = 14;
            this.tangente.TabStop = true;
            this.tangente.Text = "Tangente";
            this.tangente.UseVisualStyleBackColor = true;
            // 
            // merenja
            // 
            this.merenja.AutoSize = true;
            this.merenja.Location = new System.Drawing.Point(740, 310);
            this.merenja.Name = "merenja";
            this.merenja.Size = new System.Drawing.Size(45, 13);
            this.merenja.TabIndex = 15;
            this.merenja.Text = "Merenja";
            // 
            // duzinaduzi
            // 
            this.duzinaduzi.AutoSize = true;
            this.duzinaduzi.Location = new System.Drawing.Point(750, 330);
            this.duzinaduzi.Name = "duzinaduzi";
            this.duzinaduzi.Size = new System.Drawing.Size(82, 17);
            this.duzinaduzi.TabIndex = 16;
            this.duzinaduzi.TabStop = true;
            this.duzinaduzi.Text = "Dužina Duži";
            this.duzinaduzi.UseVisualStyleBackColor = true;
            // 
            // velicinaugla
            // 
            this.velicinaugla.AutoSize = true;
            this.velicinaugla.Location = new System.Drawing.Point(750, 350);
            this.velicinaugla.Name = "velicinaugla";
            this.velicinaugla.Size = new System.Drawing.Size(87, 17);
            this.velicinaugla.TabIndex = 17;
            this.velicinaugla.TabStop = true;
            this.velicinaugla.Text = "Veličina Ugla";
            this.velicinaugla.UseVisualStyleBackColor = true;
            // 
            // duzinaduzitext
            // 
            this.duzinaduzitext.AutoSize = true;
            this.duzinaduzitext.Location = new System.Drawing.Point(850, 330);
            this.duzinaduzitext.Name = "duzinaduzitext";
            this.duzinaduzitext.Size = new System.Drawing.Size(25, 13);
            this.duzinaduzitext.TabIndex = 18;
            this.duzinaduzitext.Text = "___";
            // 
            // velicinauglatext
            // 
            this.velicinauglatext.AutoSize = true;
            this.velicinauglatext.Location = new System.Drawing.Point(850, 350);
            this.velicinauglatext.Name = "velicinauglatext";
            this.velicinauglatext.Size = new System.Drawing.Size(25, 13);
            this.velicinauglatext.TabIndex = 19;
            this.velicinauglatext.Text = "___";
            // 
            // konstrukcijekrugova
            // 
            this.konstrukcijekrugova.AutoSize = true;
            this.konstrukcijekrugova.Location = new System.Drawing.Point(740, 180);
            this.konstrukcijekrugova.Name = "konstrukcijekrugova";
            this.konstrukcijekrugova.Size = new System.Drawing.Size(108, 13);
            this.konstrukcijekrugova.TabIndex = 20;
            this.konstrukcijekrugova.Text = "Konstrukcije Krugova";
            // 
            // centaritackanakrugu
            // 
            this.centaritackanakrugu.AutoSize = true;
            this.centaritackanakrugu.Location = new System.Drawing.Point(750, 200);
            this.centaritackanakrugu.Name = "centaritackanakrugu";
            this.centaritackanakrugu.Size = new System.Drawing.Size(143, 17);
            this.centaritackanakrugu.TabIndex = 21;
            this.centaritackanakrugu.TabStop = true;
            this.centaritackanakrugu.Text = "Centar i Tačka Na Krugu";
            this.centaritackanakrugu.UseVisualStyleBackColor = true;
            // 
            // centaripoluprecnik
            // 
            this.centaripoluprecnik.AutoSize = true;
            this.centaripoluprecnik.Location = new System.Drawing.Point(750, 220);
            this.centaripoluprecnik.Name = "centaripoluprecnik";
            this.centaripoluprecnik.Size = new System.Drawing.Size(120, 17);
            this.centaripoluprecnik.TabIndex = 22;
            this.centaripoluprecnik.TabStop = true;
            this.centaripoluprecnik.Text = "Centar i Poluprečnik";
            this.centaripoluprecnik.UseVisualStyleBackColor = true;
            // 
            // tritacke
            // 
            this.tritacke.AutoSize = true;
            this.tritacke.Location = new System.Drawing.Point(750, 240);
            this.tritacke.Name = "tritacke";
            this.tritacke.Size = new System.Drawing.Size(71, 17);
            this.tritacke.TabIndex = 23;
            this.tritacke.TabStop = true;
            this.tritacke.Text = "Tri Tačke";
            this.tritacke.UseVisualStyleBackColor = true;
            // 
            // sestar
            // 
            this.sestar.AutoSize = true;
            this.sestar.Location = new System.Drawing.Point(750, 260);
            this.sestar.Name = "sestar";
            this.sestar.Size = new System.Drawing.Size(55, 17);
            this.sestar.TabIndex = 24;
            this.sestar.TabStop = true;
            this.sestar.Text = "Šestar";
            this.sestar.UseVisualStyleBackColor = true;
            // 
            // nalazenjecentra
            // 
            this.nalazenjecentra.AutoSize = true;
            this.nalazenjecentra.Location = new System.Drawing.Point(750, 280);
            this.nalazenjecentra.Name = "nalazenjecentra";
            this.nalazenjecentra.Size = new System.Drawing.Size(106, 17);
            this.nalazenjecentra.TabIndex = 25;
            this.nalazenjecentra.TabStop = true;
            this.nalazenjecentra.Text = "Nalaženje Centra";
            this.nalazenjecentra.UseVisualStyleBackColor = true;
            // 
            // pravilanmnogougao
            // 
            this.pravilanmnogougao.AutoSize = true;
            this.pravilanmnogougao.Location = new System.Drawing.Point(750, 150);
            this.pravilanmnogougao.Name = "pravilanmnogougao";
            this.pravilanmnogougao.Size = new System.Drawing.Size(123, 17);
            this.pravilanmnogougao.TabIndex = 26;
            this.pravilanmnogougao.TabStop = true;
            this.pravilanmnogougao.Text = "Pravilan Mnogougao";
            this.pravilanmnogougao.UseVisualStyleBackColor = true;
            // 
            // transformacije
            // 
            this.transformacije.AutoSize = true;
            this.transformacije.Location = new System.Drawing.Point(600, 230);
            this.transformacije.Name = "transformacije";
            this.transformacije.Size = new System.Drawing.Size(76, 13);
            this.transformacije.TabIndex = 27;
            this.transformacije.Text = "Transformacije";
            // 
            // translacija
            // 
            this.translacija.AutoSize = true;
            this.translacija.Location = new System.Drawing.Point(610, 250);
            this.translacija.Name = "translacija";
            this.translacija.Size = new System.Drawing.Size(76, 17);
            this.translacija.TabIndex = 28;
            this.translacija.TabStop = true;
            this.translacija.Text = "Translacija";
            this.translacija.UseVisualStyleBackColor = true;
            // 
            // rotacija
            // 
            this.rotacija.AutoSize = true;
            this.rotacija.Location = new System.Drawing.Point(610, 270);
            this.rotacija.Name = "rotacija";
            this.rotacija.Size = new System.Drawing.Size(64, 17);
            this.rotacija.TabIndex = 29;
            this.rotacija.TabStop = true;
            this.rotacija.Text = "Rotacija";
            this.rotacija.UseVisualStyleBackColor = true;
            // 
            // refleksija
            // 
            this.refleksija.AutoSize = true;
            this.refleksija.Location = new System.Drawing.Point(610, 310);
            this.refleksija.Name = "refleksija";
            this.refleksija.Size = new System.Drawing.Size(71, 17);
            this.refleksija.TabIndex = 30;
            this.refleksija.TabStop = true;
            this.refleksija.Text = "Refleksija";
            this.refleksija.UseVisualStyleBackColor = true;
            // 
            // homotetija
            // 
            this.homotetija.AutoSize = true;
            this.homotetija.Location = new System.Drawing.Point(610, 290);
            this.homotetija.Name = "homotetija";
            this.homotetija.Size = new System.Drawing.Size(75, 17);
            this.homotetija.TabIndex = 31;
            this.homotetija.TabStop = true;
            this.homotetija.Text = "Homotetija";
            this.homotetija.UseVisualStyleBackColor = true;
            // 
            // inverzija
            // 
            this.inverzija.AutoSize = true;
            this.inverzija.Location = new System.Drawing.Point(610, 330);
            this.inverzija.Name = "inverzija";
            this.inverzija.Size = new System.Drawing.Size(64, 17);
            this.inverzija.TabIndex = 32;
            this.inverzija.TabStop = true;
            this.inverzija.Text = "Inverzija";
            this.inverzija.UseVisualStyleBackColor = true;
            // 
            // obrisisve
            // 
            this.obrisisve.Location = new System.Drawing.Point(514, 1);
            this.obrisisve.Name = "obrisisve";
            this.obrisisve.Size = new System.Drawing.Size(80, 40);
            this.obrisisve.TabIndex = 33;
            this.obrisisve.Text = "Obriši Sve";
            this.obrisisve.UseVisualStyleBackColor = true;
            this.obrisisve.Click += new System.EventHandler(this.obrisisve_Click);
            // 
            // undo
            // 
            this.undo.Location = new System.Drawing.Point(514, 359);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(80, 40);
            this.undo.TabIndex = 34;
            this.undo.Text = "Undo";
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // showhide
            // 
            this.showhide.AutoSize = true;
            this.showhide.Location = new System.Drawing.Point(610, 30);
            this.showhide.Name = "showhide";
            this.showhide.Size = new System.Drawing.Size(79, 17);
            this.showhide.TabIndex = 35;
            this.showhide.TabStop = true;
            this.showhide.Text = "Show/Hide";
            this.showhide.UseVisualStyleBackColor = true;
            // 
            // pomeraj
            // 
            this.pomeraj.AutoSize = true;
            this.pomeraj.Location = new System.Drawing.Point(610, 50);
            this.pomeraj.Name = "pomeraj";
            this.pomeraj.Size = new System.Drawing.Size(63, 17);
            this.pomeraj.TabIndex = 36;
            this.pomeraj.TabStop = true;
            this.pomeraj.Text = "Pomeraj";
            this.pomeraj.UseVisualStyleBackColor = true;
            // 
            // zoomin
            // 
            this.zoomin.Location = new System.Drawing.Point(41, 1);
            this.zoomin.Name = "zoomin";
            this.zoomin.Size = new System.Drawing.Size(40, 40);
            this.zoomin.TabIndex = 37;
            this.zoomin.Text = "+";
            this.zoomin.UseVisualStyleBackColor = true;
            this.zoomin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomin_MouseDown);
            this.zoomin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zoomin_MouseUp);
            // 
            // zoomout
            // 
            this.zoomout.Location = new System.Drawing.Point(1, 1);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(40, 40);
            this.zoomout.TabIndex = 38;
            this.zoomout.Text = "-";
            this.zoomout.UseVisualStyleBackColor = true;
            this.zoomout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomout_MouseDown);
            this.zoomout.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zoomout_MouseUp);
            // 
            // osnovnialati
            // 
            this.osnovnialati.AutoSize = true;
            this.osnovnialati.Location = new System.Drawing.Point(600, 10);
            this.osnovnialati.Name = "osnovnialati";
            this.osnovnialati.Size = new System.Drawing.Size(69, 13);
            this.osnovnialati.TabIndex = 39;
            this.osnovnialati.Text = "Osnovni Alati";
            // 
            // zoomintimer
            // 
            this.zoomintimer.Interval = 10;
            this.zoomintimer.Tick += new System.EventHandler(this.zoomintimer_Tick);
            // 
            // zoomouttimer
            // 
            this.zoomouttimer.Interval = 10;
            this.zoomouttimer.Tick += new System.EventHandler(this.zoomouttimer_Tick);
            // 
            // GeoGebra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(914, 400);
            this.Controls.Add(this.osnovnialati);
            this.Controls.Add(this.zoomout);
            this.Controls.Add(this.zoomin);
            this.Controls.Add(this.pomeraj);
            this.Controls.Add(this.showhide);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.obrisisve);
            this.Controls.Add(this.inverzija);
            this.Controls.Add(this.homotetija);
            this.Controls.Add(this.refleksija);
            this.Controls.Add(this.rotacija);
            this.Controls.Add(this.translacija);
            this.Controls.Add(this.transformacije);
            this.Controls.Add(this.pravilanmnogougao);
            this.Controls.Add(this.nalazenjecentra);
            this.Controls.Add(this.sestar);
            this.Controls.Add(this.tritacke);
            this.Controls.Add(this.centaripoluprecnik);
            this.Controls.Add(this.centaritackanakrugu);
            this.Controls.Add(this.konstrukcijekrugova);
            this.Controls.Add(this.velicinauglatext);
            this.Controls.Add(this.duzinaduzitext);
            this.Controls.Add(this.velicinaugla);
            this.Controls.Add(this.duzinaduzi);
            this.Controls.Add(this.merenja);
            this.Controls.Add(this.tangente);
            this.Controls.Add(this.simetralaugla);
            this.Controls.Add(this.simetraladuzi);
            this.Controls.Add(this.paralela);
            this.Controls.Add(this.normala);
            this.Controls.Add(this.sredisteduzi);
            this.Controls.Add(this.konstrukcije);
            this.Controls.Add(this.ugaodatevelicine);
            this.Controls.Add(this.duzdateduzine);
            this.Controls.Add(this.presek);
            this.Controls.Add(this.crtanjeprave);
            this.Controls.Add(this.crtanjeduzi);
            this.Controls.Add(this.crtanje);
            this.Controls.Add(this.crtanjetacke);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GeoGebra";
            this.Load += new System.EventHandler(this.GeoGebra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton crtanjetacke;
        private System.Windows.Forms.Label crtanje;
        private System.Windows.Forms.RadioButton crtanjeduzi;
        private System.Windows.Forms.RadioButton crtanjeprave;
        private System.Windows.Forms.RadioButton presek;
        private System.Windows.Forms.RadioButton duzdateduzine;
        private System.Windows.Forms.RadioButton ugaodatevelicine;
        private System.Windows.Forms.Label konstrukcije;
        private System.Windows.Forms.RadioButton sredisteduzi;
        private System.Windows.Forms.RadioButton normala;
        private System.Windows.Forms.RadioButton paralela;
        private System.Windows.Forms.RadioButton simetraladuzi;
        private System.Windows.Forms.RadioButton simetralaugla;
        private System.Windows.Forms.RadioButton tangente;
        private System.Windows.Forms.Label merenja;
        private System.Windows.Forms.RadioButton duzinaduzi;
        private System.Windows.Forms.RadioButton velicinaugla;
        private System.Windows.Forms.Label duzinaduzitext;
        private System.Windows.Forms.Label velicinauglatext;
        private System.Windows.Forms.Label konstrukcijekrugova;
        private System.Windows.Forms.RadioButton centaritackanakrugu;
        private System.Windows.Forms.RadioButton centaripoluprecnik;
        private System.Windows.Forms.RadioButton tritacke;
        private System.Windows.Forms.RadioButton sestar;
        private System.Windows.Forms.RadioButton nalazenjecentra;
        private System.Windows.Forms.RadioButton pravilanmnogougao;
        private System.Windows.Forms.Label transformacije;
        private System.Windows.Forms.RadioButton translacija;
        private System.Windows.Forms.RadioButton rotacija;
        private System.Windows.Forms.RadioButton refleksija;
        private System.Windows.Forms.RadioButton homotetija;
        private System.Windows.Forms.RadioButton inverzija;
        private System.Windows.Forms.Button obrisisve;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.RadioButton showhide;
        private System.Windows.Forms.RadioButton pomeraj;
        private System.Windows.Forms.Button zoomin;
        private System.Windows.Forms.Button zoomout;
        private System.Windows.Forms.Label osnovnialati;
        private System.Windows.Forms.Timer zoomintimer;
        private System.Windows.Forms.Timer zoomouttimer;
    }
}

