<%@ Page Title="Friend Map" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FriendMap.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.FriendMap.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/FriendMap.css" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="map" class="embed-responsive">
    </div>  
        <img runat=server id="logoImg" alt="" src="" />
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDH3g_mBeCDShD979oR6XMzq63xXiAeBwE&c"></script>
    <script src="../FriendMap/FriendMap.js" type="text/javascript"></script>
</asp:Content>

