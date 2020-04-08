<?php
if (isset($_POST['signup-submit'])) 
{
    require 'dbh.inc.php';

    $username = $_POST['uid'];
    $email = $_POST['email'];
    $password = $_POST['password'];
    $passwordRepeat = $_POST['confirm'];

    if (empty($username) || empty($email) || empty($password) || empty($passwordRepeat))
    {
        header("Location: ../signup.php?error=emptyfields&uid=".$username."&email=".$email);
        exit();
    }
    else if (!filter_var($email, FILTER_VALIDATE_EMAIL) && !preg_match("/^[a-zA-Z0-9]*$/", $username))
    {
        header("Location: ../signup.php?error=invalidmailuid");
        exit();
    }
    else if (!filter_var($email, FILTER_VALIDATE_EMAIL)) 
    {
        header("Location: ../signup.php?error=invalidmail&uid=".$username);
        exit();
    }
    else if (!preg_match("/^[a-zA-Z0-9]*$/", $username)) 
    {
        header("Location: ../signup.php?error=invaliduid&mail=".$email);
        exit();
    }
    else if ($password !== $passwordRepeat) 
    {
        header("Location: ../signup.php?error=passwordcheck&uid=".$username."&mail=".$email);
        exit();
    }
    else 
    {
        $sql = "SELECT * FROM felhasznalok WHERE felhasznalonev=?";
        $stmt = mysqli_stmt_init($connection);
        if (!mysqli_stmt_prepare($stmt, $sql)) 
        {
            header("Location: ../signup.php?error=sqlerror0");
            exit();
        }
        else
        {
            mysqli_stmt_bind_param($stmt, "s", $username);
            mysqli_stmt_execute($stmt);
            mysqli_stmt_store_result($stmt);
            $resultCheck = mysqli_stmt_num_rows($stmt);
            if ($resultCheck > 0) 
            {
                header("Location: ../signup.php?error=usertaken&mail=".$email);
                exit();
            }
            else
            {
                $sql = "INSERT INTO felhasznalok (id, felhasznalonev, jelszo, emailcimfelhasznalo) VALUES (NULL, ?, ?, ?)";
                $stmt = mysqli_stmt_init($connection);
                if (!mysqli_stmt_prepare($stmt, $sql)) 
                {
                    header("Location: ../signup.php?error=sqlerror1");
                    exit();
                }
                else
                {
                    //$hashedPwd = password_hash($password, PASSWORD_DEFAULT); //jelszó hashelése de nem használom mert az asztali nem kezeli

                    mysqli_stmt_bind_param($stmt, "sss", $username, $password, $email);
                    mysqli_stmt_execute($stmt);
                    header("Location: ../signup.php?signup=success");
                    exit();
                }
            }
        }
    }
    mysqli_stmt_close($stmt);
    mysqli_close($connection);

}
else
{
     header("Location: ../signup.php");
     exit();
}
