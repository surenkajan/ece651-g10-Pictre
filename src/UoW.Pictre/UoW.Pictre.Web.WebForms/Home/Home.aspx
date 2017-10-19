<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.Home.Home" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/home.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pictreHome" class="pictre-home">
        <div id="pictreHomeSearchDiv" class="pictre-Home-Search-Div">

        </div>
        <div id="pictreUploadDiv" class="pictre-upload-div">

        </div>
        <div id="pictreFriendsDiv" class="pictre-friends-div">

        </div>
    </div>

</asp:Content>
