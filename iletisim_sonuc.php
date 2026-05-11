<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Mesaj</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="style.css">
    <link rel="icon" type="image/png" href="medya/favicon.png">
</head>
<body>

    <!-- NAVBAR kısmı --->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark sticky-top shadow-sm">
        <div class="container">
            
            <a class="navbar-brand" href="index.html">
                <img src="medya/favicon.png" alt="Logo" width="40" height="40" class="d-inline-block align-text-top me-2">
            </a> 

            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            
            <!-- Menü Linkleri -->
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="index.html">Hakkımda</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ozgecmis.html">Özgeçmiş</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="sehrim.html">Şehrim</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="mirasimiz.html">Mirasımız</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ilgialanlarim.html">İlgi Alanlarım</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="iletisim.html">İletişim</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link btn btn-danger text-white ms-2 btn-sm mt-1 mb-1" href="login.html">Giriş Yap</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <main class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="silik-arkaplan p-5 rounded shadow-lg text-center">
                    
                    <?php
                    if ($_SERVER["REQUEST_METHOD"] == "POST") {
                        
                        $ad       = trim(isset($_POST['ad']) ? $_POST['ad'] : '');
                        $email    = trim(isset($_POST['email']) ? $_POST['email'] : '');
                        $telefon  = trim(isset($_POST['telefon']) ? $_POST['telefon'] : '');
                        $cinsiyet = isset($_POST['cinsiyet']) ? $_POST['cinsiyet'] : ''; // durum yerine cinsiyet oldu
                        $konu     = isset($_POST['konu']) ? $_POST['konu'] : '';
                        $mesaj    = trim(isset($_POST['mesaj']) ? $_POST['mesaj'] : '');
                        $onay     = isset($_POST['onay']) ? $_POST['onay'] : '';

                        // PHP BACK-END KONTROLÜ
                        if (empty($ad) || empty($email) || empty($telefon) || empty($cinsiyet) || empty($konu) || empty($mesaj) || empty($onay)) {
                            echo '<h1 class="display-6 fw-bold mb-4 text-danger">Hata: Eksik Veri!</h1>';
                            echo '<div class="alert alert-danger shadow-sm border-0" role="alert">
                                    Güvenlik Uyarısı: Formdaki zorunlu alanlardan bazıları boş gönderildi. Lütfen JavaScript denetimlerini atlamadan tüm alanları doldurun.
                                  </div>';
                            echo '<div class="mt-4"><a href="iletisim.html" class="btn btn-danger px-4 shadow-sm">Forma Geri Dön</a></div>';
                        } 
                        else {
                            echo '<h1 class="display-6 fw-bold mb-4 yesil-gradient">Form Başarıyla İletildi!</h1>';
                            echo '<p class="text-muted mb-5">Mesajınıza en kısa sürede dönüş yapılacaktır.</p>';

                            echo '<div class="table-responsive text-start">
                                    <table class="table table-hover table-bordered border-primary bg-white shadow-sm">
                                        <thead class="table-primary text-center">
                                            <tr><th style="width: 30%;">Form Alanı</th><th>Gelen Veri (POST)</th></tr>
                                        </thead>
                                        <tbody>';
                            
                            echo "<tr><td class='fw-bold text-secondary'>Ad Soyad</td><td>" . htmlspecialchars($ad) . "</td></tr>";
                            echo "<tr><td class='fw-bold text-secondary'>E-Posta</td><td>" . htmlspecialchars($email) . "</td></tr>";
                            echo "<tr><td class='fw-bold text-secondary'>Telefon</td><td>" . htmlspecialchars($telefon) . "</td></tr>";
                            echo "<tr><td class='fw-bold text-secondary'>Cinsiyet</td><td>" . htmlspecialchars($cinsiyet) . "</td></tr>";
                            echo "<tr><td class='fw-bold text-secondary'>Konu</td><td>" . htmlspecialchars($konu) . "</td></tr>";
                            echo "<tr><td class='fw-bold text-secondary'>Mesaj</td><td>" . htmlspecialchars($mesaj) . "</td></tr>";
                            echo "<tr><td class='fw-bold text-secondary'>Kurallar Onayı</td><td><span class='badge bg-success'>" . htmlspecialchars($onay) . "</span></td></tr>";
                            
                            echo '      </tbody>
                                    </table>
                                  </div>';
                            echo '<div class="mt-5"><a href="iletisim.html" class="btn btn-primary px-4 shadow-sm">Yeni Mesaj Gönder</a></div>';
                        }
                    } else {
                        echo '<h1 class="display-6 fw-bold mb-4 text-warning">Geçersiz İstek!</h1>';
                        echo '<p class="text-muted">Bu sayfaya sadece iletişim formu üzerinden POST işlemi ile erişilebilir.</p>';
                        echo '<div class="mt-4"><a href="iletisim.html" class="btn btn-warning px-4 shadow-sm">Forma Git</a></div>';
                    }
                    ?>
                    
                </div>
            </div>
        </div>
    </main>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>