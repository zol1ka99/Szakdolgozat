<?php
require "header.php";
?>

<div id="egesz-oldal-kapcsolat" class="" style="background-image: url(img/teslamodels.jpg)">
    <h1 id="regisztracioszoveg" style="text-align: center">Regisztráció</h1>



    <?php
    if (isset($_GET['error'])) {
        if ($_GET['error'] == "emptyfields") {
            echo '<div id="alert" class="alert alert-danger alert-dismissible fade show">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <p class"signuperror">Töltsön ki minden mezőt!</p>
                            </div>';
        } else if ($_GET['error'] == "invalidmailuid") {
            echo '<div id="alert" class="alert alert-danger alert-dismissible">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <p class"signuperror">Helytelen felhasználó és email cím!</p>
                            </div>';
        } else if ($_GET['error'] == "invaliduid") {
            echo '<div id="alert" class="alert alert-danger alert-dismissible">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <p class"signuperror">Helytelen felhasználónév!</p>
                            </div>';
        } else if ($_GET['error'] == "invalidmail") {
            echo '<div id="alert" class="alert alert-danger alert-dismissible">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <p class"signuperror">Érvénytelen email cím!</p>
                            </div>';
        } else if ($_GET['error'] == "passwordcheck") {
            echo '<div id="alert" class="alert alert-danger alert-dismissible">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <p class"signuperror">Nem egyeznek a jelszavak!</p>
                            </div>';
        } else if ($_GET['error'] == "usertaken") {
            echo '<div id="alert" class="alert alert-danger alert-dismissible">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <p class"signuperror">Felhasználónév foglalt</p>
                            </div>';
        }
    }
    if (isset($_GET['signup'])) {
        if ($_GET['signup'] == "success") {
            echo '<div style="position: absolute; top: 56px; right: 40px;">
                    <div class="toast" data-delay="5000" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="toast-header">
                    <img src="img/Check.png" style="width: 17px;" class="rounded mr-2" alt="erroricon">
                    <strong class="mr-auto">Hiba</strong>
                    <small class="text-muted">Épp most</small>
                    <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    </div>
                    <div class="toast-body">
                        Sikeres regisztráció!
                    </div>
                    </div>
                    </div>';
        }
    }





    ?>








    <form class="form-signup container col-md-4 col-sm-8" action="includes/signup.inc.php" method="post">
        <div class="form-group">
            <input id="regisztracioform" class="form-control" type="text" name="uid" placeholder="Felhasználónév" required>
            <input id="regisztracioform" class="form-control" type="email" name="email" placeholder="Email cím" required>
            <input id="regisztracioform" class="form-control" type="password" name="password" placeholder="Jelszó" required>
            <input id="regisztracioform" class="form-control" type="password" name="confirm" placeholder="Jelszó újra" required>
            <button style="border-radius: 0.8rem" id="regisztraciobutton" class="btn btn-primary" type="submit" name="signup-submit">Regisztrálok</button>
        </div>
    </form>
</div>

<?php
require "footer.php";
?>