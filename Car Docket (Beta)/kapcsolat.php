<?php
require "header.php";
?>

<script type="text/javascript">
        function sendEmail() {
            var name = $("#name");
            var email = $("#email");
            var subject = $("#subject");
            var body = $("#body");

            if (isNotEmpty(name) && isNotEmpty(email) && isNotEmpty(subject) && isNotEmpty(body)) {
                $.ajax({
                   url: 'form-to-email.php',
                   method: 'POST',
                   dataType: 'json',
                   data: {
                       name: name.val(),
                       email: email.val(),
                       subject: subject.val(),
                       body: body.val()
                   }, success: function (response) {
                        if (response.status == "success")
                            alert('Email elküldve!');
                        else {
                            alert('Kérjük probálja újra!');
                            console.log(response);
                        }
                   }
                });
            }
        }

        function isNotEmpty(caller) {
            if (caller.val() == "") {
                caller.css('border', '1px solid red');
                return false;
            } else
                caller.css('border', '');

            return true;
        }
    </script>

    <div id="egesz-oldal-kapcsolat" style="background-image: url(img/teslamodels.jpg)">

        <div class="container contact">
            <div class="row">
                <div class="col-md-3">
                    <div class="contact-info">
                        <img src="img/contact-image.png" alt="image" />
                        <h2>Írjon nekünk!</h2>
                        <h4>Minden javaslatra nyitottak vagyunk!</h4>
                    </div>
                </div>
                <div class="col-md-9">
                <form method="post" name="myemailform" action="form-to-email.php">
                    <div class="contact-form">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="name">Név:</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="name" name="name" placeholder="Írja be a nevét" name="name">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email cím:</label>
                            <div class="col-sm-10">
                                <input type="email" class="form-control" id="email" name="email" placeholder="Írja be az email címét" name="email">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="comment">Megjegyzés:</label>
                            <div class="col-sm-10">
                                <textarea class="form-control" rows="5" id="body" name="body"></textarea>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button name="submit" type="submit" onclick="sendEmail()" class="btn btn-default">Küldés!</button>
                            </div>
                        </div>
</form>
</div>
</div>
</div>
</div>
</div>

<?php

$fullUrl = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";

if (strpos($fullUrl, "success=sendemailtrue") == true) {
    echo '<div style="position: absolute; top: 56px; right: 40px;">
 <div class="toast" data-delay="3000" role="alert" aria-live="assertive" aria-atomic="true">
 <div class="toast-header">
 <img src="img/Check.png" style="width: 17px;" class="rounded mr-2" alt="pipaicon">
 <strong class="mr-auto">Sikerült</strong>
 <small class="text-muted">Épp most</small>
 <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
     <span aria-hidden="true">&times;</span>
 </button>
 </div>
 <div class="toast-body">
     Sikeres küldés!
 </div>
 </div>
 </div>
 </div>';
}

if (strpos($fullUrl, "error=sendemailfalse") == true) {
    echo '<div style="position: absolute; top: 56px; right: 40px;">
 <div class="toast" data-delay="3000" role="alert" aria-live="assertive" aria-atomic="true">
 <div class="toast-header">
 <img src="img/Error.png" style="width: 17px;" class="rounded mr-2" alt="pipaicon">
 <strong class="mr-auto">Sikerült</strong>
 <small class="text-muted">Épp most</small>
 <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
     <span aria-hidden="true">&times;</span>
 </button>
 </div>
 <div class="toast-body">
     Sikertelen küldés!
 </div>
 </div>
 </div>
 </div>';
}


require "footer.php";
?>