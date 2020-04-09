<?php

require 'includes/dbh.inc.php';
require 'header.php';


if (isset($_SESSION['userid'])) {
    $userid = $_SESSION['userid'];
    $sql = "SELECT felhasznalonev FROM felhasznalok WHERE id = '$userid'";
    $res = $connection->query($sql);
    $row = $res->fetch_row();
    if ($row[0] == "admin") {
        $sql = 'SELECT * FROM felhasznalok WHERE felhasznalonev != "admin"';
        $stmt = mysqli_stmt_init($connection);
        if (!mysqli_stmt_prepare($stmt, $sql)) {
            header("Location: usercontrol.php?error=sqlerror");
            exit();
        } else {
            mysqli_stmt_execute($stmt);
            $result = mysqli_stmt_get_result($stmt);
            $tablazat = '<table class="table table-responsive w-100 d-block d-md-table table-striped table-bordered table-hover" id="dataTables-example">' .
                '<thead>' .
                '<tr>' .
                '<th>Azonosító</th>' .
                '<th>Felhasználónév</th>' .
                //'<th>Jelszó</th>' .
                '<th>Email cím</th>' .
                //'<th>Módosít</th>' .
                '<th>Töröl</th>' .
                '</tr>' .
                '</thead>' .
                '<tbody>';


            while ($row = mysqli_fetch_array($result)) {
                $tablazat .= "<tr id='" . $row['id'] . "'>
            <td>" . $row['id'] . "</td>
            <td>" . $row['felhasznalonev'] . "</td>
            <td>" . $row['emailcimfelhasznalo'] . "</td>
            <td><button name'torol' id='" . $row['id'] . "' class='btn btn-danger deleteuser'>Törlés</button></td>
          </tr>";
            }
            $tablazat .= '</tbody>' .
                '</table>';
            echo $tablazat;
        }


        require 'footer.php';
    }
    else
    {
        header("Location: index.php?error=usercontrolerror");
    }


}
else
{
    header("Location: index.php?error=profilemodifyerror");
}
