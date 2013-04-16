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
                <td>Familienaam:</td>
                <td>
                    <asp:TextBox ID="txtFamilienaam" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Re Password:</td>
                <td>
                    <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Adress:</td>
                <td>
                    <asp:TextBox ID="txtAdress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>GeboorteDatum:</td>
                <td>
                    <asp:TextBox ID="txtGeboorteDatum" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Geslacht:</td>
                <td>
                    <asp:DropDownList ID="ddlGeslacht" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                        <asp:ListItem>Man</asp:ListItem>
                        <asp:ListItem>Vrouw</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnRegister" runat="server" Text="Registreer"/>
</asp:Content>

