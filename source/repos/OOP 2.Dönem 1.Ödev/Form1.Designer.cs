namespace OOP_2.Dönem_1.Ödev
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            renkButon = new Button();
            boyutComboBox = new ComboBox();
            label1 = new Label();
            colorDialog1 = new ColorDialog();
            cizimPanel = new Panel();
            kontrolPanel = new Panel();
            temizleButon = new Button();
            dolguSilButon = new Button();
            dolguRenkButon = new Button();
            silgiButon = new Button();
            kalemButon = new Button();
            kaydetButon = new Button();
            yukleButon = new Button();
            ucgenButon = new Button();
            elipsButon = new Button();
            paralelKenarButon = new Button();
            cizgiButon = new Button();
            cemberButon = new Button();
            kareButon = new Button();
            dikdortgenButon = new Button();
            kontrolPanel.SuspendLayout();
            SuspendLayout();
            // 
            // renkButon
            // 
            renkButon.Location = new Point(395, 41);
            renkButon.Name = "renkButon";
            renkButon.Size = new Size(94, 29);
            renkButon.TabIndex = 0;
            renkButon.Text = "ÇizimRengi";
            renkButon.UseVisualStyleBackColor = true;
            renkButon.Click += renkButon_Click;
            // 
            // boyutComboBox
            // 
            boyutComboBox.FormattingEnabled = true;
            boyutComboBox.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "20", "30", "40", "50" });
            boyutComboBox.Location = new Point(113, 10);
            boyutComboBox.Name = "boyutComboBox";
            boyutComboBox.Size = new Size(150, 28);
            boyutComboBox.TabIndex = 1;
            boyutComboBox.Text = "Varsayılan: 3";
            boyutComboBox.SelectedIndexChanged += boyutComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 13);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 2;
            label1.Text = "Kalem Boyutu:";
            // 
            // cizimPanel
            // 
            cizimPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cizimPanel.BackColor = Color.White;
            cizimPanel.BorderStyle = BorderStyle.Fixed3D;
            cizimPanel.Cursor = Cursors.Cross;
            cizimPanel.Location = new Point(0, 90);
            cizimPanel.Name = "cizimPanel";
            cizimPanel.Size = new Size(841, 402);
            cizimPanel.TabIndex = 3;
            cizimPanel.MouseDown += cizimPanel_MouseDown;
            cizimPanel.MouseMove += cizimPanel_MouseMove;
            cizimPanel.MouseUp += cizimPanel_MouseUp;
            // 
            // kontrolPanel
            // 
            kontrolPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            kontrolPanel.Controls.Add(temizleButon);
            kontrolPanel.Controls.Add(dolguSilButon);
            kontrolPanel.Controls.Add(dolguRenkButon);
            kontrolPanel.Controls.Add(silgiButon);
            kontrolPanel.Controls.Add(kalemButon);
            kontrolPanel.Controls.Add(kaydetButon);
            kontrolPanel.Controls.Add(yukleButon);
            kontrolPanel.Controls.Add(renkButon);
            kontrolPanel.Controls.Add(label1);
            kontrolPanel.Controls.Add(ucgenButon);
            kontrolPanel.Controls.Add(elipsButon);
            kontrolPanel.Controls.Add(paralelKenarButon);
            kontrolPanel.Controls.Add(cizgiButon);
            kontrolPanel.Controls.Add(cemberButon);
            kontrolPanel.Controls.Add(kareButon);
            kontrolPanel.Controls.Add(dikdortgenButon);
            kontrolPanel.Controls.Add(boyutComboBox);
            kontrolPanel.Location = new Point(0, 0);
            kontrolPanel.Name = "kontrolPanel";
            kontrolPanel.Size = new Size(841, 84);
            kontrolPanel.TabIndex = 0;
            // 
            // temizleButon
            // 
            temizleButon.Location = new Point(431, 11);
            temizleButon.Name = "temizleButon";
            temizleButon.Size = new Size(94, 29);
            temizleButon.TabIndex = 14;
            temizleButon.Text = "Temizle";
            temizleButon.UseVisualStyleBackColor = true;
            temizleButon.Click += temizleButon_Click;
            // 
            // dolguSilButon
            // 
            dolguSilButon.Location = new Point(599, 41);
            dolguSilButon.Name = "dolguSilButon";
            dolguSilButon.Size = new Size(137, 29);
            dolguSilButon.TabIndex = 0;
            dolguSilButon.Text = "DolguRengiKaldır";
            dolguSilButon.UseVisualStyleBackColor = true;
            dolguSilButon.Click += this.dolguSilButon_Click;
            // 
            // dolguRenkButon
            // 
            dolguRenkButon.Location = new Point(495, 41);
            dolguRenkButon.Name = "dolguRenkButon";
            dolguRenkButon.Size = new Size(98, 29);
            dolguRenkButon.TabIndex = 13;
            dolguRenkButon.Text = "DolguRengi";
            dolguRenkButon.UseVisualStyleBackColor = true;
            dolguRenkButon.Click += dolguRenkButon_Click_1;
            // 
            // silgiButon
            // 
            silgiButon.Location = new Point(395, 11);
            silgiButon.Name = "silgiButon";
            silgiButon.Size = new Size(30, 30);
            silgiButon.TabIndex = 12;
            silgiButon.Text = "\U0001f9fd";
            silgiButon.UseVisualStyleBackColor = true;
            silgiButon.Click += silgiButon_Click;
            // 
            // kalemButon
            // 
            kalemButon.Location = new Point(359, 11);
            kalemButon.Name = "kalemButon";
            kalemButon.Size = new Size(30, 30);
            kalemButon.TabIndex = 4;
            kalemButon.Text = "✎";
            kalemButon.UseVisualStyleBackColor = true;
            kalemButon.Click += kalemButon_Click;
            // 
            // kaydetButon
            // 
            kaydetButon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            kaydetButon.Location = new Point(735, 11);
            kaydetButon.Name = "kaydetButon";
            kaydetButon.Size = new Size(94, 29);
            kaydetButon.TabIndex = 11;
            kaydetButon.Text = "Kaydet";
            kaydetButon.UseVisualStyleBackColor = true;
            kaydetButon.Click += kaydetButon_Click;
            // 
            // yukleButon
            // 
            yukleButon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            yukleButon.Location = new Point(735, 41);
            yukleButon.Name = "yukleButon";
            yukleButon.Size = new Size(94, 29);
            yukleButon.TabIndex = 10;
            yukleButon.Text = "Yükle";
            yukleButon.UseVisualStyleBackColor = true;
            yukleButon.Click += yukleButon_Click;
            // 
            // ucgenButon
            // 
            ucgenButon.Location = new Point(299, 41);
            ucgenButon.Name = "ucgenButon";
            ucgenButon.Size = new Size(30, 30);
            ucgenButon.TabIndex = 9;
            ucgenButon.Text = "△";
            ucgenButon.UseVisualStyleBackColor = true;
            ucgenButon.Click += ucgenButon_Click;
            // 
            // elipsButon
            // 
            elipsButon.Location = new Point(269, 41);
            elipsButon.Name = "elipsButon";
            elipsButon.Size = new Size(30, 30);
            elipsButon.TabIndex = 8;
            elipsButon.Text = "⬭";
            elipsButon.UseVisualStyleBackColor = true;
            elipsButon.Click += elipsButon_Click;
            // 
            // paralelKenarButon
            // 
            paralelKenarButon.Location = new Point(359, 41);
            paralelKenarButon.Name = "paralelKenarButon";
            paralelKenarButon.Size = new Size(30, 30);
            paralelKenarButon.TabIndex = 7;
            paralelKenarButon.Text = "▱";
            paralelKenarButon.UseVisualStyleBackColor = true;
            paralelKenarButon.Click += paralelKenarButon_Click;
            // 
            // cizgiButon
            // 
            cizgiButon.Location = new Point(329, 41);
            cizgiButon.Name = "cizgiButon";
            cizgiButon.Size = new Size(30, 30);
            cizgiButon.TabIndex = 6;
            cizgiButon.Text = "━";
            cizgiButon.UseVisualStyleBackColor = true;
            cizgiButon.Click += cizgiButon_Click;
            // 
            // cemberButon
            // 
            cemberButon.Location = new Point(329, 11);
            cemberButon.Name = "cemberButon";
            cemberButon.Size = new Size(30, 30);
            cemberButon.TabIndex = 5;
            cemberButon.Text = "○";
            cemberButon.UseVisualStyleBackColor = true;
            cemberButon.Click += cemberButon_Click;
            // 
            // kareButon
            // 
            kareButon.Location = new Point(299, 11);
            kareButon.Name = "kareButon";
            kareButon.Size = new Size(30, 30);
            kareButon.TabIndex = 3;
            kareButon.Text = "◻";
            kareButon.UseVisualStyleBackColor = true;
            kareButon.Click += kareButon_Click;
            // 
            // dikdortgenButon
            // 
            dikdortgenButon.Location = new Point(269, 11);
            dikdortgenButon.Name = "dikdortgenButon";
            dikdortgenButon.Size = new Size(30, 30);
            dikdortgenButon.TabIndex = 2;
            dikdortgenButon.Text = "▭";
            dikdortgenButon.UseVisualStyleBackColor = true;
            dikdortgenButon.Click += dikdortgenButon_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 490);
            Controls.Add(kontrolPanel);
            Controls.Add(cizimPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Paint v2";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            kontrolPanel.ResumeLayout(false);
            kontrolPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button renkButon;
        private ComboBox boyutComboBox;
        private Label label1;
        private ColorDialog colorDialog1;
        private Panel cizimPanel;
        private Panel kontrolPanel;
        private Button ucgenButon;
        private Button elipsButon;
        private Button paralelKenarButon;
        private Button cizgiButon;
        private Button cemberButon;
        private Button kareButon;
        private Button dikdortgenButon;
        private Button kaydetButon;
        private Button yukleButon;
        private Button silgiButon;
        private Button kalemButon;
        private Button dolguRenkButon;
        private Button dolguSilButon;
        private Button temizleButon;
    }
}
