﻿
$(document).ready(function () {
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 3e94022... Revert "1 fout opgelost in profiel"
    $("#popshow").hide();
    $("#pop").click(function () {
       if ($("#popshow").css('display') == "none") {
           $("#popshow").show();
        }
        else {
            $("#popshow").hide();
        }
    });

    $("#inhoud_txtDate").datepicker();

    if ($("#hdValCal").val() == 0) {
        $("#popshow").toggle();
    }
    
=======
    //$("#popshow").hide();
    //$("#pop").click(function () {
    //    if ($("#popshow").css('display') == "none") {
    //        $("#popshow").show();
    //    }
    //    else {
    //        $("#popshow").hide();
    //    }
    //});
>>>>>>> datepicker verwijderd
    
    $("#pop").click(function () {
        $("#popshow").toggle();
    });

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



