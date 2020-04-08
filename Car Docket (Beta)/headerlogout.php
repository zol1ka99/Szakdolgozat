<?php
require 'includes/dbh.inc.php';


if (isset($_SESSION['userid'])) {
    $userid = $_SESSION['userid'];
    $sql = "SELECT felhasznalonev FROM felhasznalok WHERE id = '$userid'";
    $res = $connection -> query($sql);
    $row = $res -> fetch_row();
    if ($row[0] == "admin") 
    {
        require 'headerlogoutadmin.php';
    } 
    else {
    require 'headerlogoutnotadmin.php';
    }
}
?>