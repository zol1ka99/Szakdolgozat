<?php

require 'header.php';
require 'includes/dbh.inc.php';

if (isset($_SESSION['userid'])) {
    $userid = $_SESSION['userid'];
    $sql = "SELECT felhasznalonev, jelszo, emailcimfelhasznalo FROM felhasznalok WHERE id = '$userid'";
    $res = $connection->query($sql);
    $row = $res->fetch_assoc();

    $felhasznev = $row['felhasznalonev'];
    $pwd = $row['jelszo'];
    $email = $row['emailcimfelhasznalo'];



} else 
{
    header("Location: index.php?error=profilemodifyerror");
}



?>

<div id="egesz-oldal-kapcsolat" style="background-image: url(img/teslamodels.jpg)">

    <div class="container contact">
        <div class="row">
            <div class="col-md-3">
                <div class="contact-info">
                    <img id="useravatar" style="filter: invert(100%); width: 125px;" src="img/avatar.png" alt="image" />
                    <h2>Profil adatok</h2>
                    <h4>Itt szerkesztheti a profilja adatait!</h4>
                </div>
            </div>
            <div class="col-md-9">
                <form method="post" name="profilemodify" action="usereditcomplete.php">
                    <div class="contact-form">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="felhasznev">Felhasználónév:</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" value="<?php echo $felhasznev; ?>" id="felhasznev" name="felhasznev" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="pwd">Jelszó:</label>
                            <div class="col-sm-10">
                                <input type="password" class="form-control" value="<?php echo $pwd; ?>" id="pwd" name="pwd" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="pwdc">Jelszó újra:</label>
                            <div class="col-sm-10">
                                <input type="password" class="form-control" id="pwdc" name="pwdc" placeholder="Módosításkor írja ide az új jelszót!" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email cím:</label>
                            <div class="col-sm-10">
                                <input type="email" class="form-control" value="<?php echo $email; ?>" id="email" name="email" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button name="submit" type="submit" class="btn btn-default">Módosítás!</button>
                            </div>
                        </div>
                </form>
            </div>
        </div>
    </div>
</div>
</div>

<?php
   $fullUrl = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";

   if (strpos($fullUrl, "mofidy=success") == true)
   {
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
        Sikeres módosítás!
    </div>
    </div>
    </div>
    </div>';
   }

   if (strpos($fullUrl, "error=sqlerror") == true)
   {
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
        Sikertelen módosítás!
    </div>
    </div>
    </div>
    </div>';
   }







require 'footer.php';
?>