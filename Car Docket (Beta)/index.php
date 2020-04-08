<?php
require "header.php";
?>

<body>


    <div class="jumbotron jumbotron-fluid" style="background-image: linear-gradient(to bottom, rgba(255,255,255,0.1) 0%,rgba(255,255,255,0.1) 100%), url(img/teslamodels.jpg)">
        <div id="udvozlo" class="container">
            <h1 class="display-3" style="text-align: center;"><strong>Üdvözöljük a Car Docket Weboldalán!</strong></h1>
            <p class="lead"><strong>Feltöltés folyamatban...</strong></p>
            <hr class="vonal">
        </div>
    </div>

    <?php
    if (isset($_SESSION['userid'])) {
        /*echo '<p class="login-status">Be van jelentkezve</p>';*/
    } else {
        /*echo '<p class="login-status">Nincs bejelentkezve</p>';*/
    }

    /*<div class="errortoast" style="position: relative; min-height: 300px;">*/

    $fullUrl = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";

    if (strpos($fullUrl, "error=emptyfields") == true) {

        echo '<div style="position: absolute; top: 56px; right: 40px;">
                        <div class="toast" data-delay="3000" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">
                        <img src="img/Error.png" style="width: 17px;" class="rounded mr-2" alt="erroricon">
                        <strong class="mr-auto">Hiba</strong>
                        <small class="text-muted">Épp most</small>
                        <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </div>
                        <div class="toast-body">
                            Töltse ki a bejelentkezési adatokat!
                        </div>
                        </div>
                        </div>';
    }
    if (strpos($fullUrl, "error=sqlerror2") == true) {

        echo '<div style="position: absolute; top: 56px; right: 40px;">
                        <div class="toast" data-delay="3000" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">
                        <img src="img/Error.png" style="width: 17px;" class="rounded mr-2" alt="erroricon">
                        <strong class="mr-auto">Hiba</strong>
                        <small class="text-muted">Épp most</small>
                        <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </div>
                        <div class="toast-body">
                            Adatbázis hiba kérjük próbálja meg később!
                        </div>
                        </div>
                        </div>
                        </div>';
    }
    if (strpos($fullUrl, "error=wrongpwd12") == true) {

        echo '<div style="position: absolute; top: 56px; right: 40px;">
                        <div class="toast" data-delay="3000" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">
                        <img src="img/Error.png" style="width: 17px;" class="rounded mr-2" alt="erroricon">
                        <strong class="mr-auto">Hiba</strong>
                        <small class="text-muted">Épp most</small>
                        <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </div>
                        <div class="toast-body">
                            Hibás jelszó!
                        </div>
                        </div>
                        </div>
                        </div>';
    }
    if (strpos($fullUrl, "login=success") == true) {

        echo '<div style="position: absolute; top: 56px; right: 40px;">
                        <div class="toast" data-delay="3000" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">
                        <img src="img/Check.png" style="width: 17px;" class="rounded mr-2" alt="pipaicon">
                        <strong class="mr-auto">Sikerült</strong>
                        <small class="text-muted">Épp most</small>
                        <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </div>
                        <div class="toast-body">
                            Sikeres belépés!
                        </div>
                        </div>
                        </div>
                        </div>';
    }

    if (strpos($fullUrl, "error=wrongpwd1") == true) {

        echo '<div style="position: absolute; top: 56px; right: 40px;">
                        <div class="toast" data-delay="3000" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">
                        <img src="img/Error.png" style="width: 17px;" class="rounded mr-2" alt="pipaicon">
                        <strong class="mr-auto">Hiba</strong>
                        <small class="text-muted">Épp most</small>
                        <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </div>
                        <div class="toast-body">
                            Sikertelen belépés ismeretlen hiba miatt!
                        </div>
                        </div>
                        </div>
                        </div>';
    }

    if (strpos($fullUrl, "error=nouser") == true) {

        echo '<div style="position: absolute; top: 56px; right: 40px;">
                        <div class="toast" data-delay="4000" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">
                        <img src="img/Error.png" style="width: 17px;" class="rounded mr-2" alt="pipaicon">
                        <strong class="mr-auto">Hiba</strong>
                        <small class="text-muted">Épp most</small>
                        <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </div>
                        <div class="toast-body">
                            Sikertelen belépés! A felhasználó nem található.<br>
                            Amennyiben készíteni szeretne egyet, kattintson <a href="signup.php">ide.</a>
                        </div>
                        </div>
                        </div>
                        </div>';
    }

    if (strpos($fullUrl, "error=profilemodifyerror") == true) {
        echo '<div style="position: absolute; top: 56px; right: 40px;">
     <div class="toast" data-delay="3000" role="alert" aria-live="assertive" aria-atomic="true">
     <div class="toast-header">
     <img src="img/Error.png" style="width: 17px;" class="rounded mr-2" alt="pipaicon">
     <strong class="mr-auto">Sikerült</strong>
     <small class="text-muted">Épp most</small>
     <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
         <span aria-hidden="true">&times;</span>
     </button>
     </div>
     <div class="toast-body">
         Jelentkezzen be a funkció eléréséhez!
     </div>
     </div>
     </div>
     </div>';
    }
    ?>

    <div>

    </div>
    <button id="mygotopbutton" title="Go to top">&#129153</button>
    <?php
    require "footer.php";
    ?>