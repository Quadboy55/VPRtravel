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
    document.getElementById('inhoud_txtNaam').value = strTemp;
    document.getElementById('inhoud_txtVoornaam').value = strTemp;
    document.getElementById('inhoud_txtStraat').value = strTemp;
    document.getElementById('inhoud_txtHuisnr').value = strTemp;
    document.getElementById('inhoud_txtPost').value = strTemp;
    document.getElementById('inhoud_txtStad').value = strTemp;
    document.getElementById('inhoud_txtGebDat').value = strTemp;
}

function ReadCard() {
    var retval;
    EmptyScreen();
    document.getElementById('inhoud_StatusField').innerHTML = "Reading Card, please wait...";
    retval = document.BEIDApplet.InitLib(null);
    if (retval == 0) {
        document.getElementById('inhoud_StatusField').innerHTML = "Reading Identity, please wait...";
        getIDData();
        document.getElementById('inhoud_StatusField').innerHTML = "Reading Picture, please wait...";
        document.BEIDApplet.GetPicture();
        document.getElementById('inhoud_StatusField').innerHTML = "Done";
        document.BEIDApplet.ExitLib();
        
    }
    else {
        document.getElementById('inhoud_StatusField').innerHTML = "Error Reading Card";
    }
}