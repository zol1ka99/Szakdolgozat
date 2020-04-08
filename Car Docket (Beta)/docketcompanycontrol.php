<?php

require 'includes/dbh.inc.php';
require 'header.php';

if (isset($_SESSION['userid'])) {

    $limit = 8;
    $sql1 = "SELECT * FROM cegek";
    $result2 = mysqli_query($connection, $sql1);
    $countAutokRows = mysqli_num_rows($result2);
    $pageNumbers = ceil($countAutokRows / $limit);

    if ($pageNumbers != 1) {
        $form = '<div class="dropdown show"><a class="btn btn-primary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Oldal</a><div class="dropdown-menu scrollable-menu" aria-labelledby="dropdownMenuLink">';
        for ($i = 1; $i <= $pageNumbers; $i++) {
            $form .= '<a class="dropdown-item" href="docketcompanycontrol.php?page=' . $i . '">' . $i . '</a>';
        }
        $form .= '</div></div>';
        echo $form;
    }



    if (isset($_GET['page'])) {
        $start = ($_GET['page'] - 1) * $limit;
    } else {
        $start = 0;
    }






    $sql = 'SELECT * FROM cegek LIMIT ' . $start . ',' . $limit . ';';
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
            '<th>Cégnév</th>' .
            '<th>Adószám</th>' .
            '<th>Város</th>' .
            '<th>Utca</th>' .
            '<th>Szám</th>' .
            '<th>Email cím</th>' .
            '<th>Módosít</th>' .
            '<th>Töröl</th>' .
            '</tr>' .
            '</thead>' .
            '<tbody>';


        while ($row = mysqli_fetch_array($result)) {
            $tablazat .= "<tr>
        <td>" . $row['cegnev'] . "</td>
        <td>" . $row['adoszam'] . "</td>
        <td>" . $row['varos'] . "</td>
        <td>" . $row['utca'] . "</td>
        <td>" . $row['szam'] . "</td>
        <td>" . $row['ceg_email_cim'] . "</td>
        <td><button id='bejelentkezesbutton' class='btn btn-success'>Módosítás</button></td>
        <td><button id='" . $row['cegid'] . "' class='btn btn-danger deletecompany'>Törlés</button></td>
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
