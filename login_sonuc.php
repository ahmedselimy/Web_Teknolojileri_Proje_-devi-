<?php
// Formdan gelen verileri yakala
$gelen_email = isset($_POST['email']) ? $_POST['email'] : '';
$gelen_sifre = isset($_POST['sifre']) ? $_POST['sifre'] : '';

$dogru_email = "b251210005@ogr.sakarya.edu.tr"; 
$dogru_sifre = "b251210005";
// ----------------------------------------------------------------

if ($gelen_email == $dogru_email && $gelen_sifre == $dogru_sifre) {
    // BİLGİLER DOĞRUYSA
    ?>
    <!DOCTYPE html>
    <html lang="tr">
    <head>
        <meta charset="UTF-8">
        <title>Hoşgeldiniz</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
        <link rel="stylesheet" href="style.css">
    </head>
    <body class="d-flex align-items-center justify-content-center" style="height: 100vh;">
        <div class="silik-arkaplan p-5 rounded shadow-lg text-center">
            <h1 class="display-4 fw-bold yesil-gradient">Hoşgeldiniz!</h1>
            <p class="lead mt-3 text-dark"><?php echo $dogru_email; ?></p>
            <p class="text-muted">Giriş işleminiz başarıyla doğrulandı.</p>
            <a href="index.html" class="btn btn-outline-primary mt-4">Ana Sayfaya Dön</a>
        </div>
    </body>
    </html>
    <?php
} else {
    // BİLGİLER YANLIŞSA (Hata mesajıyla geri yönlendir)
    header("Location: login.html?hata=1");
    exit();
}
?>