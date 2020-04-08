<?php

$servername = "localhost";
$dBUsername = "root";
$dbPassword = "";
$dBName = "autonyilvantartas";

$connection = mysqli_connect($servername, $dBUsername, $dbPassword, $dBName);

if (!$connection) 
{
    //die("Csatlakozás az adatbázishoz sikertelen".mysqli_connect_error());
    //header("Location: 404error.php");
}

?>