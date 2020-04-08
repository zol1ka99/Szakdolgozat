<?php

require 'includes/dbh.inc.php';
require 'header.php';

if (isset($_SESSION['userid'])) {

    $limit = 8;
    $sql1 = "SELECT * FROM tulajdonosok";
    $result2 = mysqli_query($connection, $sql1);
    $countAutokRows = mysqli_num_rows($result2);
    $pageNumbers = ceil($countAutokRows / $limit);

    if ($pageNumbers != 1) {
        $form = '<div class="dropdown show"><a class="btn btn-primary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Oldal</a><div class="dropdown-menu scrollable-menu" aria-labelledby="dropdownMenuLink">';
        for ($i = 1; $i <= $pageNumbers; $i++) {
            $form .= '<a class="dropdown-item" href="docketownercontrol.php?page=' . $i . '">' . $i . '</a>';
        }
        $form .= '</div></div>';
        echo $form;
    }



    if (isset($_GET['page'])) {
        $start = ($_GET['page'] - 1) * $limit;
    } else {
        $start = 0;
    }





    $sql = 'SELECT * FROM tulajdonosok INNER JOIN cegek ON tulajdonosok.cegid = cegek.cegid LIMIT ' . $start . ',' . $limit . ';';
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
            //'<th>Azonosító</th>' .
            '<th>Tulajdonos Neve</th>' .
            '<th>Tulajdonos személyiigazolvány száma</th>' .
            '<th>Jogosítvány azonosító</th>' .
            '<th>Email cím</th>' .
            '<th>Telefonszám</th>' .
            '<th>Cévnév</th>' .
            '<th>Módosít</th>' .
            '<th>Töröl</th>' .
            '</tr>' .
            '</thead>' .
            '<tbody>';


        while ($row = mysqli_fetch_array($result)) {
            $tablazat .= "<tr>
        <td>" . $row['tulajdonos_nev'] . "</td>
        <td>" . $row['tulajdonos_szemelyiigszam'] . "</td>
        <td>" . $row['jogositvany_azon'] . "</td>
        <td>" . $row['email_cim'] . "</td>
        <td>" . $row['telefonszam'] . "</td>
        <td>" . $row['cegnev'] . "</td>
        <td><button id='bejelentkezesbutton' class='btn btn-success'>Módosítás</button></td>
        <td><button id='" . $row['tulid'] . "' class='btn btn-danger deleteowner'>Törlés</button></td>
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
    header("Location: index.php?error=profilemodifyerror");
}

