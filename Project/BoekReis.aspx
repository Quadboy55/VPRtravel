<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="BoekReis.aspx.cs" Inherits="BoekReis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">
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
        <asp:Calendar ID="CalDatum" runat="server" CssClass="table-condensed" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="CalDatum_SelectionChanged" Width="220px">
            <DayHeaderStyle CssClass="dow" BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle CssClass="next" Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayStyle CssClass="day" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle CssClass="day active" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle CssClass="switch" BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>

        <strong>
            <asp:Label ID="Label3" runat="server" Text="Tijdstip: "></asp:Label></strong>
        <asp:DropDownList ID="drpUur" runat="server" CssClass="btn dropdown-toggle"></asp:DropDownList>
        <br />
        <br />

        <asp:Button ID="btnZoek" runat="server" Text="Zoek" CssClass="btn btn-primary" />

    </div>
</asp:Content>

