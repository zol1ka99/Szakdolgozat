$(document).ready(function () {
    $('.toast').toast('show');


    /*Regisztráció validáció lesz*/
    $('[name=confirm]').keyup(function () {
        let username = $('[name=uid]').val();
        let pwd = $('[name=password]').val();
        let pwdc = $('[name=confirm]').val();
        let email = $('[name=email]').val();
        let emailPattern = /^[\w!#$%&'+=?^`{|}~]+(.[\w!#$%&'+=?^`{|}~]+)*@((([-\w]+.)+[a-zA-Z]{2,4})|(([0-9]{1,3}.){3}[0-9]{1,3}))\z/;
        let userPattern = /^[A-Za-z0-9]*$/;
        if (emailPattern.test(email) && pwd === pwdc && userPattern.test(username)) {
            $("[type=submit]").removeAttr("disabled");
        }
    });
    /*-------------------------------------------------------------------------------------------*/

    /*Az összes tábla törlés funckiói itt vannak*/
    $(document).on('click', '.deleteuser', function () {
        let deleteid = $(this).attr('id');
        //console.log(deleteid);

        if (confirm('Biztosan törölni akarja?')) {
            $.ajax({
                url: 'usercontroldelete.php',
                method: 'post',
                data: { deleteid: deleteid },
                success: function (data) {
                    //console.log(data);
                    location.reload();
                    /*$('#deleteid' + deleteid).hide();*/
                }
            });
        }
    });

    $(document).on('click', '.deletecar', function () {
        let deleteid = $(this).attr('id');
        //console.log(deleteid);

        if (confirm('Biztosan törölni akarja?')) {
            $.ajax({
                url: 'docketcarcontroldelete.php',
                method: 'post',
                data: { deleteid: deleteid },
                success: function (data) {
                    //console.log(data);
                    location.reload();
                    /*$('#deleteid' + deleteid).hide();*/
                }
            });
        }
    });

    $(document).on('click', '.deleteowner', function () {
        let deleteid = $(this).attr('id');
        //console.log(deleteid);

        if (confirm('Biztosan törölni akarja?')) {
            $.ajax({
                url: 'docketownercontroldelete.php',
                method: 'post',
                data: { deleteid: deleteid },
                success: function (data) {
                    //console.log(data);
                    location.reload();
                    /*$('#deleteid' + deleteid).hide();*/
                }
            });
        }
    });

    $(document).on('click', '.deletecompany', function () {
        let deleteid = $(this).attr('id');
        //console.log(deleteid);

        if (confirm('Biztosan törölni akarja?')) {
            $.ajax({
                url: 'docketcompanycontroldelete.php',
                method: 'post',
                data: { deleteid: deleteid },
                success: function (data) {
                    //console.log(data);
                    location.reload();
                    /*$('#deleteid' + deleteid).hide();*/
                }
            });
        }
    });
    /*-------------------------------------------------------------------------------------------*/



    /*Go to top gomb js-e*/
    $(window).scroll(function () {
        var height = $(window).scrollTop();
        if (height > 100) {
            $('#mygotopbutton').fadeIn();
        } else {
            $('#mygotopbutton').fadeOut();
        }
    });
    $("#mygotopbutton").click(function (event) {
        event.preventDefault();
        $("html, body").animate({ scrollTop: 0 }, "slow");
        return false;
    });
});