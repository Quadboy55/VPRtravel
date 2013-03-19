<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
    <div class="blueberry">
        <ul class="slides">
            <li>
                <img src="Banner/img_algemeen/trein1.jpg" /></li>
            <li>
                <img src="Banner/img_algemeen/trein2.jpg" /></li>
        </ul>
        <!-- Optional, see options below -->
        <ul class="pager">
            <li><a href="#"><span></span></a></li>
            <li><a href="#"><span></span></a></li>
        </ul>
        <!-- Optional, see options below -->
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">
</asp:Content>

