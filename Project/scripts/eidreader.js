// JScript File

function getIDData() {
    var strTemp;
    var strTemp2;
    var strTemp3;
    // schrijf een Script om de data in controls te plaatsen
    // Volgende methodes kunt u gebruiken
    document.getElementById('inhoud_txtNaam').value = document.BEIDApplet.getName();
    document.getElementById('inhoud_txtVoornaam').value = document.BEIDApplet.getFirstName1();
    document.getElementById('inhoud_txtStraat').value = document.BEIDApplet.getStreet();
    document.getElementById('inhoud_txtHuisnr').value = document.BEIDApplet.getStreetNumber();
    document.getElementById('inhoud_txtPost').value = document.BEIDApplet.getZip();
    document.getElementById('inhoud_txtStad').value = document.BEIDApplet.getMunicipality();
    document.getElementById('inhoud_txtGebDat').value = document.BEIDApplet.getDateOfBirth();



}
function EmptyScreen() {
    var strTemp = "";
    document.getElementById('txtNaam').value = strTemp;
    document.getElementById('txtVoornaam').value = strTemp;
    document.getElementById('drpGeslacht').value = strTemp;
    document.getElementById('txtAdres').value = strTemp;
    document.getElementById('txtPostcode').value = strTemp;
    document.getElementById('txtGemeente').value = strTemp;
    document.getElementById('txtLand').value = strTemp;
}

function ReadCard() {
    var retval;
    EmptyScreen();
    document.getElementById('StatusField').innerHTML = "Reading Card, please wait...";
    retval = document.BEIDApplet.InitLib(null);
    if (retval == 0) {
        document.getElementById('StatusField').innerHTML = "Reading Identity, please wait...";
        getIDData();
        document.getElementById('StatusField').innerHTML = "Reading Picture, please wait...";
        document.BEIDApplet.GetPicture();
        document.BEIDApplet.ExitLib();
        document.getElementById('StatusField').innerHTML = "Done";
    }
    else {
        document.getElementById('StatusField').innerHTML = "Error Reading Card";
    }
}