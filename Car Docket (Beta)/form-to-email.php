<?php
    use PHPMailer\PHPMailer\PHPMailer;

    if (isset($_POST['name']) && isset($_POST['email'])) {
        $name = $_POST['name'];
        $email = $_POST['email'];
        //$subject = $_POST['subject'];
        $body = $_POST['body'];

        require_once "PHPMailer/PHPMailer.php";
        require_once "PHPMailer/SMTP.php";
        require_once "PHPMailer/Exception.php";

        $mail = new PHPMailer();

        //SMTP Settings
        $mail->isSMTP();
        $mail->Host = "smtp.gmail.com";
        $mail->SMTPAuth = true;
        $mail->Username = "mzmoddingteam@gmail.com";
        $mail->Password = '99modders';
        $mail->Port = 465; //587
        $mail->SMTPSecure = "ssl"; //tls

        //Email Settings
        $mail->isHTML(true);
        $mail->setFrom($email, $name);
        $mail->addAddress("mzmoddingteam@gmail.com");
        $mail->addReplyTo($email, $name);
        //$mail->Subject = $subject;
        $mail->Body = $email;
        $mail->Body = $body;

        if ($mail->send()) {
            $status = "success";
            $response = "Email elküldve!";
            header("Location: kapcsolat.php?success=sendemailtrue");
        } else {
            $status = "failed";
            $response = "Valami hiba történt: <br><br>" . $mail->ErrorInfo;
            header("Location: kapcsolat.php?error=sendemailfalse");
        }

        //exit(json_encode(array("status" => $status, "response" => $response)));
        
    }
?>