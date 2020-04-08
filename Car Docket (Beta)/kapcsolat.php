<?php
require "header.php";
?>


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
                            <label class="control-label col-sm-2" for="fname">Vezetéknév:</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="fname" name="fname" placeholder="Írja be a vezetéknevét" name="fname">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="lname">Keresztnév:</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="lname" name="lname" placeholder="Írja be a keresztnevét" name="lname">
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
                                <textarea class="form-control" rows="5" id="comment" name="comment"></textarea>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button name="submit" type="submit" class="btn btn-default">Küldés!</button>
                            </div>
                        </div>
</form>
</div>
</div>
</div>
</div>
</div>

<?php
require "footer.php";
?>