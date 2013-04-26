<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" Runat="Server">
     <div class="slider-wrapper theme-dark">
        <div id="slider" class="nivoSlider">
            <a href="#"><img src="Banner/img_algemeen/trein1.png" alt=""/></a>
            <a href="#"><img src="Banner/img_algemeen/trein2.png" alt=""/></a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" Runat="Server">
    <p>hier komt de registratie</p>
    <div id="registration">
        <table class="register">
            <tr>
                <td>Voornaam:</td>
                <td>
                    <asp:TextBox ID="txtVoornaam" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>Naam:</td>
                <td>
                    <asp:TextBox ID="txtNaam" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>Straat:</td>
                <td>
                    <asp:TextBox ID="txtStraat" runat="server"></asp:TextBox>
                </td>
                <td>Huisnr.:</td>
                <td>
                    <asp:TextBox ID="txtHuisnr" runat="server" MaxLength="3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Postcode:</td>
                <td>
                    <asp:TextBox ID="txtPost" runat="server" MaxLength="4"></asp:TextBox>
                </td>
                <td>Stad:</td>
                <td>
                    <asp:TextBox ID="txtStad" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Login:</td>
                <td>
                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Passwoord:</td>
                <td>
                    <asp:TextBox ID="txtPasswoord" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Opnieuw Passwoord:</td>
                <td>
                    <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnReg" runat="server" Text="Registreer" CssClass="btn btn-primary" OnClick="btnReg_Click" CausesValidation="False"/>
    <asp:Button ID="btnRegis" runat="server" CausesValidation="False" OnClick="btnRegis_Click" Text="Button" />
</asp:Content>

