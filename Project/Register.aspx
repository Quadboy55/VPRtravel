<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
    <div class="slider-wrapper theme-dark">
        <div id="slider" class="nivoSlider">
            <a href="#">
                <img src="Banner/img_algemeen/trein1.png" alt="" /></a>
            <a href="#">
                <img src="Banner/img_algemeen/trein2.png" alt="" /></a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">
    <asp:Button ID="btnEID" runat="server" Text="Gegevens ophalen via eID" CssClass="btn btn-warning" OnClick="btnEID_Click"/>
    <asp:Label ID="StatusField" runat="server" Text="Status"></asp:Label>
    <br />
    <br />

    <div id="registration">
        <table class="register">
            <tr>
                <td>Voornaam:</td>
                <td>
                    <asp:TextBox ID="txtVoornaam" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="valVrNaam" runat="server" ErrorMessage="Geef een geldige voornaam in" ValidationExpression="[a-zA-Z-]+" ControlToValidate="txtVoornaam" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valVrNaamIng" runat="server" ErrorMessage="Geef uw naam in" ControlToValidate="txtVoornaam" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Naam:</td>
                <td>
                    <asp:TextBox ID="txtNaam" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="valNaam" runat="server" ErrorMessage="Geef een geldige naam in" ValidationExpression="[a-zA-Z -]+" ControlToValidate="txtNaam" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valNaamIng" runat="server" ErrorMessage="Geef uw naam in" ControlToValidate="txtNaam" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="valEmail" runat="server" ErrorMessage="Geef een geldig e-mailadres in" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" ControlToValidate="txtEmail" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valEmailIng" runat="server" ErrorMessage="Geef uw e-mailadres in" ControlToValidate="txtEmail" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Straat:</td>
                <td>
                    <asp:TextBox ID="txtStraat" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="valStraat" runat="server" ErrorMessage="Geef een geldige straatnaam in" ValidationExpression="[a-zA-Z -]+" ControlToValidate="txtStraat" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valStraatIng" runat="server" ErrorMessage="Geef uw straat in" ControlToValidate="txtStraat" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>Huisnr.:</td>
                <td>
                    <asp:TextBox ID="txtHuisnr" runat="server" MaxLength="3"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="valHuisn" runat="server" ErrorMessage="Geef een geldig huisnummer in" ValidationExpression="[0-9]+" ControlToValidate="txtHuisnr" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valHuisnIng" runat="server" ErrorMessage="Geef uw huisnummer in" ControlToValidate="txtHuisnr" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Postcode:</td>
                <td>
                    <asp:TextBox ID="txtPost" runat="server" MaxLength="4"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="valPostc" runat="server" ErrorMessage="Geef een geldige postcode in" ValidationExpression="[0-9]{4}" ControlToValidate="txtPost" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valPostcIng" runat="server" ErrorMessage="Geef uw postcode in" ControlToValidate="txtPost" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Stad:</td>
                <td>
                    <asp:TextBox ID="txtStad" runat="server"></asp:TextBox>
                </td>
                 <td>
                    <asp:RegularExpressionValidator ID="valStad" runat="server" ErrorMessage="Geef een geldig stadsnaam in" ValidationExpression="[a-zA-Z -]+" ControlToValidate="txtStad" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="ValStadIng" runat="server" ErrorMessage="Geef uw stad in" ControlToValidate="txtStad" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Geboortedatum:</td>
                <td>
                    <asp:TextBox ID="txtGebDat" runat="server"></asp:TextBox>
                </td>
                 <td>
                    <asp:RegularExpressionValidator ID="valDateFormat" runat="server" ErrorMessage="Geef een geldige datum in zoals 27/10/2000" ValidationExpression="[0-9]{2}\/[0-9]{2}\/[0-9]{4}" ControlToValidate="txtGebDat" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valDatIng" runat="server" ErrorMessage="Geef uw geboortedatum in" ControlToValidate="txtGebDat" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                     <asp:CustomValidator ID="valGeldigeDatum" runat="server" ErrorMessage="Geef een geldige datum in." CssClass="error" ControlToValidate="txtGebDat" OnServerValidate="valGeldigeDatum_ServerValidate" ValidationGroup="register" Display="Dynamic"></asp:CustomValidator>
                     <asp:CustomValidator ID="val18Jaar" runat="server" ErrorMessage="Uw moet 18 zijn om deze site te kunnen gebruiken" CssClass="error" ControlToValidate="txtGebDat" OnServerValidate="val18Jaar_ServerValidate" ValidationGroup="register" ></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Login:</td>
                <td>
                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                </td>
                 <td>
                    <asp:RequiredFieldValidator ID="valLogin" runat="server" ErrorMessage="Geef en gebruikersnaam in" ControlToValidate="txtLogin" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                     <asp:CustomValidator ID="valLoginUniek" runat="server" ErrorMessage="Deze gebruikersnaam is reeds in gebruik." ControlToValidate="txtLogin" CssClass="error" ValidationGroup="register" Display="Dynamic" OnServerValidate="valLoginUniek_ServerValidate"></asp:CustomValidator>
                 </td>
            </tr>
            <tr>
                <td>Passwoord:</td>
                <td>
                    <asp:TextBox ID="txtPasswoord" runat="server" TextMode="Password" MaxLength="20" ControlToCompare="txtPasswoord"></asp:TextBox>
                </td>
                 <td>
                    <asp:RequiredFieldValidator ID="valPas1" runat="server" ErrorMessage="Geef uw wachtwoord in" ControlToValidate="txtPasswoord" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>Opnieuw Passwoord:</td>
                <td>
                    <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                </td>
                 <td>
                    <asp:RequiredFieldValidator ID="valPas2" runat="server" ErrorMessage="Geef uw wachtwoord in" ControlToValidate="txtRePassword" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="valPasComp" runat="server" ErrorMessage="Wachtwoorden zijn niet identiek" ControlToValidate="txtRePassword" ControlToCompare="txtPasswoord" CssClass="error"></asp:CompareValidator>
                 </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnReg" runat="server" Text="Registreer" CssClass="btn btn-primary" OnClick="btnReg_Click" ValidationGroup="register" />


    <asp:Panel ID="pnlAppletIE" runat="server" Height="100px" Width="50px" Visible="false">
                                    <applet
                                      codebase = "."
                                      archive  = "scripts/eidlib.jar"
                                      name     = "BEIDApplet"
                                      width    = "0"
                                      height   = "0"
                                      type     = "application/x-java-applet;version=1.5.0"
                                      code     = "be.belgium.eid.BEID_Applet.class"
                                    >   
                                </applet>
                                <script type="text/javascript" src="scripts/eidreader.js"></script>
                                <script type="text/javascript">ReadCard();</script>
 </asp:Panel>
 <asp:Panel ID="pnlAppletFF" runat="server" Height="100px" Width="50px" Visible="false">
                                    <applet
                                      codebase = "."
                                      archive  = "scripts/eidlib.jar"
                                      name     = "BEIDApplet"
                                      width    = "0"
                                      height   = "0"
                                      type     = "application/x-java-applet;version=1.5.0"
                                      classid  = "java:be.belgium.eid.BEID_Applet.class"
                                    >
                                </applet>
                                <script type="text/javascript" src="scripts/eidreader.js"></script>
                                <script type="text/javascript">ReadCard();</script> 
 </asp:Panel>
</asp:Content>

