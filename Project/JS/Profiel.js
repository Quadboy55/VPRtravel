
$(document).ready(function () {
    //$("#popshow").hide();
    //$("#pop").click(function () {
    //    if ($("#popshow").css('display') == "none") {
    //        $("#popshow").show();
    //    }
    //    else {
    //        $("#popshow").hide();
    //    }
    //});

    $("#inhoud_txtDate").datepicker();

    if ($("#hdValCal").val() == 0) {
        $("#popshow").toggle();
    }
    
    $("#pop").click(function () {
        $("#popshow").toggle();
    });

    $("#inhoud_CalDatum").click(function () {
        $("#popshow").toggle();
    });

    $("#inhoud_cal").click(function () {
        showCalPop();
    });
   

    function showCalPop() {
        $("#popshow").toggle();
        if ($("#hdValCal").val() == 0) {
            $("#hdValCal").val(1);
        }

    }

    //$("#inhoud_cal").click(function () {
    //    if ($("#popshow").css('display') == "none") {
    //        $("#popshow").show();
    //    }
    //    else {
    //        $("#popshow").hide();
    //    }
    //});

    $("#btnProfiel").click(function () {
        $("#btnProfiel").removeClass("active");
        $("#btnHistoriek").removeClass("active");
        $("#btnRitten").removeClass("active");
        $("#btnProfiel").addClass("active");

        $("#Profiel").show();
        $("#Historiek").hide();
        $("#Ritten").hide();

    });

    $("#btnHistoriek").click(function () {
        $("#btnProfiel").removeClass("active");
        $("#btnHistoriek").removeClass("active");
        $("#btnRitten").removeClass("active");
        $("#btnHistoriek").addClass("active");


        $("#Profiel").hide();
        $("#Historiek").show();
        $("#Ritten").hide();

    });

    $("#btnRitten").click(function () {
        $("#btnProfiel").removeClass("active");
        $("#btnHistoriek").removeClass("active");
        $("#btnRitten").removeClass("active");
        $("#btnRitten").addClass("active");


        $("#Profiel").hide();
        $("#Historiek").hide();
        $("#Ritten").show();

    });

});



