<nav id="navigacios" class="navbar navbar-expand-lg navbar-dark bg-dark">
    <a class="navbar-brand" href="index.php">Főoldal</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav ml-auto">
            <li class="nav-item dropdown my-2 my-lg-0">
                <a class="nav-link dropdown-toggle" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" href="#">
                    Adatbázisok kezelése
                </a>
                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <a class="dropdown-item" href="docketcarcontrol.php">Autók adatbázisa</a>
                    <a class="dropdown-item" href="docketownercontrol.php">Tulajdonosok adatbázisa</a>
                    <a class="dropdown-item" href="docketcompanycontrol.php">Cégek adatbázisa</a>
                </div>
            </li>
            <li class="nav-item dropdown my-2 my-lg-0">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Profil
                </a>
                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <a class="dropdown-item" href="useredit.php">Profil szerkesztése</a>
                    <a class="dropdown-item" href="#">Üzenetek</a>
                </div>
            </li>
            <li class="nav-item">
                <form action="includes/logout.inc.php" method="post">
                    <button style="border-radius: 0.8rem" class="btn btn-danger" type="submit" name="logout-submit">Kijelentkezés</button>
                </form>
            </li>


        </ul>

    </div>
</nav>