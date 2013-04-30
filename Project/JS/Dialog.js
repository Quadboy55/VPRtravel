$(window).load(function () {
    $('#slider').nivoSlider();


});

function zoek(){
    $("#zoek").slideToggle();
}




$(document).ready(function (e) {
    if ($("#hdValue").val() == 0) {
        $("#ModalLogReg").modal({
            show: 'true'
        });
    }

    if ($("#inhoud_hdFilter").val() == 0) {
        $("#zoek").toggle();
    }
    

});
