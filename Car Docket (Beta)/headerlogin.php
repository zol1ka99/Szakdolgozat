<nav id="navigacios" class="navbar navbar-expand-lg navbar-dark bg-dark">
    <a class="navbar-brand" href="index.php">Főoldal</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav ml-auto">
            <li class="nav-item">
                <a class="nav-link" href="info.php">Információk</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="kapcsolat.php">Kapcsolat</a>
            </li>
            <li class="nav-item">
                <a href="signup.php" class="signup nav-link">Regisztráció</a>
            </li>
        </ul>
        <form action="login.inc.php" method="post">
            <input style="border-radius: 0.4rem" type="text" name="useruid" placeholder=" Felhasználónév/Email">
            <input style="border-radius: 0.4rem"  type="password" name="pwd" placeholder=" Jelszó...">
            <button style="border-radius: 0.8rem" id="bejelentkezesbutton" class="btn btn-primary" type="submit" name="login-submit">Bejelentkezés</button>
        </form>
    </div>
</nav>