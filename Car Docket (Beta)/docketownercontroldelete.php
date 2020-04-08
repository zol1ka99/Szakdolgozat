<?php 

require 'includes/dbh.inc.php';

$id = $_POST['deleteid'];
$query = mysqli_query($connection,"DELETE FROM tulajdonosok WHERE tulid=$id");