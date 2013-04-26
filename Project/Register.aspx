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
    <p>hier komt de registratie</p>
    <div id="registration">
        <table class="register">
            <tr>
                <td>Voornaam:</td>
                <td>
                    <asp:TextBox ID="txtVoornaam" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="valVrNaam" runat="server" ErrorMessage="Geef een geldige voornaam in" ValidationExpression="[a-zA-Z -]+" ControlToValidate="txtVoornaam" ValidationGroup="register" Display="Dynamic" CssClass="error"></asp:RegularExpressionValidator>
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
            </tr>
            <tr>
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
            </tr>
            <tr>
                <td>Stad:</td>
                <td>
                    <asp:TextBox ID="txtStad" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Geboortedatum:</td>
                <td>
                    <asp:Calendar ID="CalGeboortedatum" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
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
    <asp:Button ID="btnReg" runat="server" Text="Registreer" CssClass="btn btn-primary" OnClick="btnReg_Click" ValidationGroup="register" />

</asp:Content>

