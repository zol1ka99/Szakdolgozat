<?php

if (isset($_POST['login-submit'])) {
    require 'includes/dbh.inc.php';

    $mailuid = $_POST['useruid'];
    $password = $_POST['pwd'];

    if (empty($mailuid) || empty($password)) {
        header("Location: index.php?error=emptyfields");
        exit();
    } else {
        $sql = "SELECT * FROM felhasznalok WHERE felhasznalonev=? OR emailcimfelhasznalo=?;";
        $stmt = mysqli_stmt_init($connection);
        if (!mysqli_stmt_prepare($stmt, $sql)) {
            header("Location: index.php?error=sqlerror2"); //404error.phpra cserélni és ötletes hiba oldalt csinálni
            exit();
        } else {
            mysqli_stmt_bind_param($stmt, "ss", $mailuid, $mailuid);
            mysqli_stmt_execute($stmt);
            $result = mysqli_stmt_get_result($stmt);
            if ($row = mysqli_fetch_assoc($result)) {

                if ($password == $row['jelszo']) {
                    $pwdCheck = true;
                }
                if ($pwdCheck == false) {
                    header("Location: index.php?error=wrongpwd12");
                    exit();
                } else if ($pwdCheck == true) {
                    session_start();
                    $_SESSION['userid'] = $row['id'];
                    $_SESSION['useruid'] = $row['felhasznalonev'];

                    header("Location: index.php?login=success");
                    exit();
                } else {
                    header("Location: index.php?error=wrongpwd1");
                }
            } else {
                header("Location: index.php?error=nouser");
            }
        }
    }
} else {
    header("Location: index.php");
    exit();
}

require "footer.php";
