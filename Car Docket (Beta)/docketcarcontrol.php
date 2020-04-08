<?php

require 'includes/dbh.inc.php';
require 'header.php';

if (isset($_SESSION['userid'])) {
    
    $limit = 8;
    $sql1 = "SELECT * FROM cars";
    $result2 = mysqli_query($connection, $sql1);
    $countAutokRows = mysqli_num_rows($result2);
    $pageNumbers = ceil($countAutokRows / $limit);

    if ($pageNumbers != 1) {
        $form = '<div class="dropdown show"><a class="btn btn-primary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Oldal</a><div class="dropdown-menu scrollable-menu" aria-labelledby="dropdownMenuLink">';
        for ($i = 1; $i <= $pageNumbers; $i++) {
            $form .= '<a class="dropdown-item" href="docketcarcontrol.php?page=' . $i . '">' . $i . '</a>';
        }
        $form .= '</div></div>';
        echo $form;
    }



    if (isset($_GET['page'])) {
        $start = ($_GET['page'] - 1) * $limit;
    } else {
        $start = 0;
    }


    $sql = 'SELECT * FROM cars INNER JOIN tulajdonosok ON cars.tulid = tulajdonosok.tulid LIMIT ' . $start . ',' . $limit . ';';
    $stmt = mysqli_stmt_init($connection);
    if (!mysqli_stmt_prepare($stmt, $sql)) {
        header("Location: docketcarcontrol.php?error=sqlerror");
        exit();
    } else {
        mysqli_stmt_execute($stmt);
        $result = mysqli_stmt_get_result($stmt);
        $tablazat = '<table class="table table-responsive w-100 d-block d-md-table table-striped table-bordered table-hover" id="dataTables-example">' .
            '<thead>' .
            '<tr>' .
            //'<th>Azonosító</th>' .
            '<th>Márka</th>' .
            '<th>Típus</th>' .
            '<th>Gyártási év</th>' .
            '<th>Vételár</th>' .
            '<th>Rendszám</th>' .
            '<th>Kilóméteróraállás</th>' .
            '<th>Alvázszám</th>' .
            '<th>Gépkocsi típusa</th>' .
            '<th>Üzemanyag</th>' .
            '<th>Sebességváltó típusa</th>' .
            '<th>Tulajdonos neve</th>' .
            //'<th>Módosít</th>' .
            '<th>Töröl</th>' .
            '</tr>' .
            '</thead>' .
            '<tbody>';



        while ($row = mysqli_fetch_array($result)) {
            $tablazat .= "<tr>
        <td>" . $row['marka'] . "</td>
        <td>" . $row['tipus'] . "</td>
        <td>" . $row['gyartasi_ev'] . "</td>
        <td>" . $row['vetelar'] . " Ft</td>
        <td>" . $row['rendszam'] . "</td>
        <td>" . $row['kilometeroraallas'] . "</td>
        <td>" . $row['alvazszam'] . "</td>
        <td>" . $row['gepkocsi_tipusa'] . "</td>
        <td>" . $row['uzemanyag'] . "</td>
        <td>" . $row['sebessegvalto_tipusa'] . "</td>
        <td>" . $row['tulajdonos_nev'] . "</td>
        <td><button id='" . $row['id'] . "' class='btn btn-danger deletecar'>Törlés</button></td>
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

