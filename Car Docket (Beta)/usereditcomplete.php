<?php
session_start();
require 'includes/dbh.inc.php';


if (isset($_POST['submit'])) {
   $id = $_SESSION['userid'];
   $felhasznev = trim($_POST['felhasznev']);
   $pwd = trim($_POST['pwd']);
   $pwdc = trim($_POST['pwdc']);
   $email = trim($_POST['email']);

   if ($pwd == $pwdc) {
      $sql = "UPDATE felhasznalok SET felhasznalonev = '$felhasznev' , jelszo = '$pwd' , emailcimfelhasznalo = '$email' WHERE felhasznalok.id = $id";
      $query = mysqli_query($connection, $sql);
      var_dump($sql);

      header("Location: useredit.php?mofidy=success");
   } else {
      header("Location: useredit.php?error=sqlerror");
   }
} else {
   header("Location: index.php?error=notloggedin");
}
