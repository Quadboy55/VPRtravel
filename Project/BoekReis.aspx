<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="BoekReis.aspx.cs" Inherits="BoekReis" %>


<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script src="JS/Profiel.js"></script>

            <p>u heeft gekozen voor reis:</p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <div id="zoek" class="zoek">

                <asp:RadioButtonList ID="radList" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Vertrekken</asp:ListItem>
                    <asp:ListItem>Aankomen</asp:ListItem>
                </asp:RadioButtonList>
                <strong>
                    <asp:Label ID="Label2" runat="server" Text="Dag: "></asp:Label>
                </strong>


                <asp:TextBox ID="txtDate" runat="server" />


                <br />
                <strong>
                    <asp:Label ID="Label3" runat="server" Text="Tijdstip: "></asp:Label></strong>
                <asp:DropDownList ID="drpUur" runat="server" CssClass="btn dropdown-toggle" OnSelectedIndexChanged="drpUur_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />

                <asp:Button ID="btnZoek" Enabled="false" runat="server" Text="Zoek" CssClass="btn btn-primary" OnClick="btnZoek_Click" />

            </div>
            <asp:GridView ID="grdRitten" runat="server" Visible="false"></asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <input id="hdValCal" type="hidden" value="0" />
</asp:Content>

