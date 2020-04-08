<?php
ini_set("SMTP", "ssl://smtp.gmail.com");
ini_set("smtp_port", "465");
ini_set("sendmail_from", 'email');

if (isset($_POST['fname']) && isset($_POST['lname']) && isset($_POST['email']) && isset($_POST['comment'])) {
    $fname = $_POST['fname'];
    $lname = $_POST['lname'];
    $email = $_POST['email'];
    $comment = $_POST['comment'];
    $to = 'martonzoli99@gmail.com';
    $subject = "Új javaslat érkezett";
    $body = '<html>
                <body>
                    <h2>Visszajelzés cardocket.hu</h2>
                    <hr>
                    <p>Name<br>' . $fname . $lname . '</p>
                    <p>Email<br>' . $email . '</p>
                </body>
            </html>';

    $headers = "Feladó: " . $fname . $lname . "<" . $email . ">\r\n";
    $headers = "Válasz: " . $email . '\r\n';

    $send = mail($to, $subject, $body, $headers);
    if ($send) {
        echo '<br>';
        echo 'Köszönjük hogy felvetted velünk a kapcsolatot';
    } else {
        echo 'error';
    }
}
