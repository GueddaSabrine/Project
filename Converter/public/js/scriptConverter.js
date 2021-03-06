$(document).ready(function () {

    $("button[type='reset']").click(function(){
        $("#msg").fadeOut(1000);
    });

    $("#msg").dblclick(function(){
        $(this).fadeOut(1000);
    });

});