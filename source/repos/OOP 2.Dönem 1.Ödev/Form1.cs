/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2014-2015 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:01
**				ÖĞRENCİ ADI............:AHMED SELİM YILMAZ
**				ÖĞRENCİ NUMARASI.......:B251210005
**              DERSİN ALINDIĞI GRUP...:B GRUBU
****************************************************************************/

namespace OOP_2.Dönem_1.Ödev
{
    public partial class Form1 : Form
    {

        enum Araclar { Kalem, Silgi, Dikdortgen, Kare, Cember, Elips, Ucgen, Cizgi, ParalelKenar } //Aletlerimizin listesi

        bool sekilCiziliyor = false; // Mouse'u basılı tutup sürüklerken şeklin önizlemesini görmek için
        bool cizimYapiliyor = false; // Kalem modundayken serbest çizim yapıp yapmadığımızı anlıyor

        Point baslangicNoktasi; // Tıkladığımız ilk yeri tutan değişken
        Point bitisNoktasi;     // Mouse'u sürüklerken gittiği en son yeri tutan değişken

        Color gecerliRenk = Color.Black; // Kalem ve kenarlık rengimiz (Varsayılan siyah)
        Color dolguRengi = Color.Transparent; // Dolgu rengimiz (Varsayılan şeffaf)
        float kalemKalinligi = 3f; // Kalem kalınlığı

        Rectangle cizilecekSekil; // Çizdiğimiz şekillerin sığacağı o hayali kutu (Sınırlar)
        Araclar seciliArac = Araclar.Kalem; // Program ilk açıldığında direkt kalem seçili gelsin

        Bitmap dijitalTuval = null!; // Çizimlerin silinmemesi için arka planda tuttuğumuz asıl resim kağıdımız
        Graphics tuvalGrafigi = null!;

        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized; // Program açılır açılmaz tam ekran olsun

            cizimPanel.Dock = DockStyle.Fill; // Kullandığımız panel tam ekran olsun

            // Ekran büyüyüp küçülürse tuval de ona göre esnesin diye event bağlıyoruz
            cizimPanel.SizeChanged += cizimPanel_SizeChanged;

            // Form ilk yüklendiğinde tuvali oluşturması için fonksiyonu bir kere elden çağırıyoruz
            cizimPanel_SizeChanged(null, EventArgs.Empty);

            cizimPanel.BackgroundImageLayout = ImageLayout.None;
            cizimPanel.Paint += cizimPanel_Paint;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ekranda fareyi sürüklerken şekillerin titrememesi için gerekli kodlar
            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                         ?.SetValue(cizimPanel, true, null);
        }

        // --- MOUSE TIKLANDIĞINDA ÇALIŞAN KISIM ---
        private void cizimPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return; // Sadece sol tıka tepki vermeli

            baslangicNoktasi = e.Location; // Tıkladığımız ilk noktayı tutuyoruz
            bitisNoktasi = e.Location;

            if (seciliArac == Araclar.Kalem || seciliArac == Araclar.Silgi)
            {
                cizimYapiliyor = true; // Kalem veya silgi seçiliyse serbest çizim moduna geç
            }
            else
            {
                // Kalem değilse şekil çizimine geçiyoruz
                sekilCiziliyor = true;
                cizilecekSekil = new Rectangle(baslangicNoktasi, Size.Empty);
            }
        }

        // --- MOUSE SÜRÜKLENDİĞİNDE ÇALIŞAN KISIM (ÖNİZLEME/KALEM) ---
        private void cizimPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!cizimYapiliyor && !sekilCiziliyor) return; // Fare basılı değilse hiçbir şey yapma

            // Eğer Kalem VEYA Silgi seçiliyse ve fareye basılı tutuluyorsa
            if ((seciliArac == Araclar.Kalem || seciliArac == Araclar.Silgi) && cizimYapiliyor)
            {
                // Akıllı Kontrol: Araç silgiyse rengi arka plan rengi yap, değilse kendi seçtiğimiz rengi (örn: siyah) al
                Color cizimRengi = (seciliArac == Araclar.Silgi) ? cizimPanel.BackColor : gecerliRenk;

                // Silgiyle ince ince uğraşmayalım diye silgi kalınlığını normal kalemin 2 katı yapıyoruz
                float kalinlik = (seciliArac == Araclar.Silgi) ? kalemKalinligi * 2 : kalemKalinligi;

                // Ayarladığımız bu akıllı renk ve kalınlıkla çizgimizi çekiyoruz
                using (Pen kalem = new(cizimRengi, kalinlik) { StartCap = System.Drawing.Drawing2D.LineCap.Round, EndCap = System.Drawing.Drawing2D.LineCap.Round })
                {
                    tuvalGrafigi.DrawLine(kalem, baslangicNoktasi, e.Location);
                }

                baslangicNoktasi = e.Location; // Çizgiler uca uca eklensin diye son noktayı güncelliyoruz
                cizimPanel.Invalidate(); // Ekranı tazele
            }
            else if (sekilCiziliyor)
            {
                bitisNoktasi = e.Location; // Düz çizgi aracımız için son noktayı güncelliyoruz

                // Şekiller ters yöne (yukarı veya sola) çizildiğinde C# sapıtmasın diye mutlak değerlerini alıyoruz
                int genislik = Math.Abs(e.X - baslangicNoktasi.X);
                int yukseklik = Math.Abs(e.Y - baslangicNoktasi.Y);
                int x = Math.Min(baslangicNoktasi.X, e.X);
                int y = Math.Min(baslangicNoktasi.Y, e.Y);

                // KARE VE ÇEMBER KONTROLÜ (En ve Boy eşit olmak zorunda!)
                if (seciliArac == Araclar.Kare || seciliArac == Araclar.Cember)
                {
                    int kenar = Math.Max(genislik, yukseklik); // En büyük kenarı baz alalım ki küçülmesin
                    genislik = kenar;
                    yukseklik = kenar;
                    // Fareyi ters çekersek de şekil düzgün büyüsün diye ufak bir matematik hilesi:
                    x = e.X < baslangicNoktasi.X ? baslangicNoktasi.X - kenar : baslangicNoktasi.X;
                    y = e.Y < baslangicNoktasi.Y ? baslangicNoktasi.Y - kenar : baslangicNoktasi.Y;
                }

                cizilecekSekil = new Rectangle(x, y, genislik, yukseklik); // Hayali sınır kutumuzu güncelledik
                cizimPanel.Invalidate(); // Paint olayını tetikleyip ekrana güncel önizlemeyi yansıtıyoruz
            }
        }

        // --- MOUSE BİRAKILDIĞINDA ÇALIŞAN KISIM (KALICI KAYIT) ---
        private void cizimPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            cizimYapiliyor = false;

            if (sekilCiziliyor)
            {
                using (SolidBrush firca = new(dolguRengi))
                using (Pen kalem = new(gecerliRenk, kalemKalinligi))
                {
                    // Hangi araç seçiliyse o şekli kalıcı tuvalin üstüne resmediyoruz
                    switch (seciliArac)
                    {
                        case Araclar.Dikdortgen:
                        case Araclar.Kare:
                            if (dolguRengi != Color.Transparent) tuvalGrafigi.FillRectangle(firca, cizilecekSekil);
                            tuvalGrafigi.DrawRectangle(kalem, cizilecekSekil);
                            break;

                        case Araclar.Elips:
                        case Araclar.Cember:
                            if (dolguRengi != Color.Transparent) tuvalGrafigi.FillEllipse(firca, cizilecekSekil);
                            tuvalGrafigi.DrawEllipse(kalem, cizilecekSekil);
                            break;

                        case Araclar.Cizgi:
                            tuvalGrafigi.DrawLine(kalem, baslangicNoktasi, bitisNoktasi);
                            break;

                        case Araclar.Ucgen:
                            // Üçgen için 3 tane köşe noktası belirliyoruz (Üst orta, Sol alt, Sağ alt)
                            Point[] ucgenNoktalari = [
                                new(cizilecekSekil.Left + (cizilecekSekil.Width / 2), cizilecekSekil.Top),
                                new(cizilecekSekil.Left, cizilecekSekil.Bottom),
                                new(cizilecekSekil.Right, cizilecekSekil.Bottom)
                            ];
                            if (dolguRengi != Color.Transparent) tuvalGrafigi.FillPolygon(firca, ucgenNoktalari);
                            tuvalGrafigi.DrawPolygon(kalem, ucgenNoktalari);
                            break;

                        case Araclar.ParalelKenar:
                            // Paralelkenarın o yamuk duruşunu vermek için genişliğin 4'te 1'i kadar kaydırma (offset) yapıyoruz
                            int sapma = cizilecekSekil.Width / 4;
                            Point[] paralelNoktalari = [
                                new(cizilecekSekil.Left + sapma, cizilecekSekil.Top), // Sol üst
                                new(cizilecekSekil.Right, cizilecekSekil.Top),       // Sağ üst
                                new(cizilecekSekil.Right - sapma, cizilecekSekil.Bottom), // Sağ alt
                                new(cizilecekSekil.Left, cizilecekSekil.Bottom)      // Sol alt
                            ];
                            if (dolguRengi != Color.Transparent) tuvalGrafigi.FillPolygon(firca, paralelNoktalari);
                            tuvalGrafigi.DrawPolygon(kalem, paralelNoktalari);
                            break;
                    }
                }
                sekilCiziliyor = false; // Şekil bitti, moddan çıkıyoruz
                cizimPanel.Invalidate(); // Ekrandaki geçici önizlemeleri temizle ve kalıcı resmi göster
            }
        }

        // --- EKRANA ÇİZDİRME KISMI (SADECE ÖNİZLEME İÇİN) ---
        private void cizimPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sekilCiziliyor && seciliArac != Araclar.Kalem)
            {
                using SolidBrush firca = new(dolguRengi);
                using Pen kalem = new(gecerliRenk, kalemKalinligi) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }; // Önizleme belli olsun diye kesikli (Dash) çizgi yaptık
                                                                                                                            // Burada asıl tuvale değil, formun ön yüzeyine anlık yansıtma yapıyoruz (MouseUp'taki mantığın aynısı)
                switch (seciliArac)
                {
                    case Araclar.Dikdortgen:
                    case Araclar.Kare:
                        if (dolguRengi != Color.Transparent) e.Graphics.FillRectangle(firca, cizilecekSekil);
                        e.Graphics.DrawRectangle(kalem, cizilecekSekil);
                        break;

                    case Araclar.Elips:
                    case Araclar.Cember:
                        if (dolguRengi != Color.Transparent) e.Graphics.FillEllipse(firca, cizilecekSekil);
                        e.Graphics.DrawEllipse(kalem, cizilecekSekil);
                        break;

                    case Araclar.Cizgi:
                        e.Graphics.DrawLine(kalem, baslangicNoktasi, bitisNoktasi);
                        break;

                    case Araclar.Ucgen:
                        Point[] ucgenNoktalari = [
                                new(cizilecekSekil.Left + (cizilecekSekil.Width / 2), cizilecekSekil.Top),
                                new(cizilecekSekil.Left, cizilecekSekil.Bottom),
                                new(cizilecekSekil.Right, cizilecekSekil.Bottom)
                            ];
                        if (dolguRengi != Color.Transparent) e.Graphics.FillPolygon(firca, ucgenNoktalari);
                        e.Graphics.DrawPolygon(kalem, ucgenNoktalari);
                        break;

                    case Araclar.ParalelKenar:
                        int sapma = cizilecekSekil.Width / 4;
                        Point[] paralelNoktalari = [
                                new(cizilecekSekil.Left + sapma, cizilecekSekil.Top),
                                new(cizilecekSekil.Right, cizilecekSekil.Top),
                                new(cizilecekSekil.Right - sapma, cizilecekSekil.Bottom),
                                new(cizilecekSekil.Left, cizilecekSekil.Bottom)
                            ];
                        if (dolguRengi != Color.Transparent) e.Graphics.FillPolygon(firca, paralelNoktalari);
                        e.Graphics.DrawPolygon(kalem, paralelNoktalari);
                        break;
                }
            }
        }

        // --- EKRAN BOYUTLANDIĞINDA ÇALIŞAN KISIM (SÜNME/BÜYÜME) ---
        private void cizimPanel_SizeChanged(object? sender, EventArgs e)
        {
            if (cizimPanel.Width <= 0 || cizimPanel.Height <= 0) return; // Program alta alındığında vs çökmeyi engeller

            Bitmap eskiTuval = dijitalTuval; // Eski çizdiklerimiz kaybolmasın diye yedeğe alıyoruz

            dijitalTuval = new Bitmap(cizimPanel.Width, cizimPanel.Height); // Yeni dev tuvalimizi oluşturduk
            tuvalGrafigi = Graphics.FromImage(dijitalTuval);

            if (eskiTuval != null)
            {
                // Yedeği aldık ve yeni büyük ekranın boyutlarına yayarak tekrar yapıştırdık
                tuvalGrafigi.DrawImage(eskiTuval, 0, 0, cizimPanel.Width, cizimPanel.Height);
                eskiTuval.Dispose(); // Eski tuvali çöpe at ki RAM şişmesin
            }

            cizimPanel.BackgroundImage = dijitalTuval;
        }

        // --- AYAR VE BUTON TIKLAMA KISIMLARI ---

        private void renkButon_Click(object sender, EventArgs e)
        {
            using ColorDialog renkPenceresi = new();
            if (renkPenceresi.ShowDialog() == DialogResult.OK) gecerliRenk = renkPenceresi.Color;
        }

        private void dolguRenkButon_Click_1(object sender, EventArgs e)
        {
            using ColorDialog renkPenceresi = new();
            if (renkPenceresi.ShowDialog() == DialogResult.OK) dolguRengi = renkPenceresi.Color;
        }

        private void boyutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boyutComboBox.SelectedItem != null && float.TryParse(boyutComboBox.SelectedItem.ToString(), out float parsed))
            {
                kalemKalinligi = parsed;
            }
        }

        private void dolguSilButon_Click(object sender, EventArgs e)
        {
            dolguRengi = Color.Transparent; // İçi boş şekil çizmek isteyenler için dolguyu şeffaflıyoruz
        }

        private void kalemButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.Kalem;

        }

        private void silgiButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.Silgi;

        }

        private void dikdortgenButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.Dikdortgen;

        }
        private void kareButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.Kare;

        }
        private void cemberButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.Cember;

        }
        private void elipsButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.Elips;

        }
        private void ucgenButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.Ucgen;

        }
        private void cizgiButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.Cizgi;

        }
        private void paralelKenarButon_Click(object sender, EventArgs e)
        {
            seciliArac = Araclar.ParalelKenar;

        }

        private void temizleButon_Click(object sender, EventArgs e)
        {
            // Tuvalimizi arkaplan rengine boyayarak temizliyoruz
            tuvalGrafigi.Clear(cizimPanel.BackColor);

            // Ekranı tazelemek için paneli yeniden çiziyoruz
            cizimPanel.Invalidate();
        }

        private void kaydetButon_Click(object sender, EventArgs e)
        {
            // Kullanıcıya dosyayı nereye kaydedeceğini soran pencereyi hazırlıyoruz
            using SaveFileDialog kaydetPenceresi = new();
            {
                // Hangi formatlarda kayıt yapabileceğini belirliyoruz
                kaydetPenceresi.Filter = "PNG Resmi (*.png)|*.png|JPEG Resmi (*.jpg)|*.jpg|Bitmap Resmi (*.bmp)|*.bmp";
                kaydetPenceresi.Title = "Kaydet"; // Pencere başlığı
                kaydetPenceresi.DefaultExt = "png"; // Varsayılan olarak PNG seçili gelsin (arkaplanı şeffaf tutabilir)

                // Eğer kullanıcı pencerede "Kaydet" tuşuna basarsa (iptal etmezse)
                if (kaydetPenceresi.ShowDialog() == DialogResult.OK)
                {
                    // Arka plandaki dijital tuvalimizi kullanıcının seçtiği yere ve isme kaydediyoruz!
                    dijitalTuval.Save(kaydetPenceresi.FileName);

                    // Havalı bir bilgi mesajı
                    MessageBox.Show("Çizimin başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void yukleButon_Click(object sender, EventArgs e)
        {
            // Kullanıcıya bilgisayarından resim seçtiren pencereyi hazırlıyoruz
            using OpenFileDialog yuklePenceresi = new();
            // Sadece resim dosyalarını görebilsin
            yuklePenceresi.Filter = "Resim Dosyaları|*.png;*.jpg;*.jpeg;*.bmp";
            yuklePenceresi.Title = "Bilgisayardan Resim Yükle";

            // Kullanıcı bir resim seçip "Aç" derse
            if (yuklePenceresi.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Seçilen resmi geçici olarak hafızaya alıyoruz
                    using (Image yuklenenResim = Image.FromFile(yuklePenceresi.FileName))
                    {
                        // Önce elimizdeki mevcut tuvali temizliyoruz ki eski çizimlerle karışmasın
                        tuvalGrafigi.Clear(cizimPanel.BackColor);

                        // Yüklenen resmi, sol üst köşeden (0,0) başlayarak bizim tuvalin tam ortasına/üzerine çizdiriyoruz
                        // Not: Resmi bizim panelin boyutlarına sündürerek sığdırmak istersen DrawImage(yuklenenResim, 0, 0, cizimPanel.Width, cizimPanel.Height) yapabilirsin.
                        tuvalGrafigi.DrawImage(yuklenenResim, 0, 0, cizimPanel.Width, cizimPanel.Height);
                    }

                    // Ekrana yansıt!
                    cizimPanel.Invalidate();
                }
                catch (Exception ex)
                {
                    // Bozuk bir dosya seçerse program çökmesin diye koruma kalkanı
                    MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}