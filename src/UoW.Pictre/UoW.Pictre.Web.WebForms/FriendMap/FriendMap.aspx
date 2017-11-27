<%@ Page Title="Friend Map" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FriendMap.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.FriendMap.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/FriendMap.css" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <input id="pac-input" class="form-control" type="text" placeholder="Search Place" style="margin-top: 5px;margin-right:10px;">
    <div id="map" class="embed-responsive">
    </div>  
    <div id="myModalnew" class="modalnew">
        <span class="closenew">×</span>
        <img class="modal-contentnew" id="img01" style="margin-top:100px">
        <div id="caption"></div>
    </div>
        <img runat=server id="logoImg" alt="" src="" />
        <script src="../Content/js/PictreBDelegate.js"></script>
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDH3g_mBeCDShD979oR6XMzq63xXiAeBwE&v=3&libraries=places"></script>
    <script src="../FriendMap/FriendMap.js" type="text/javascript"></script>
</asp:Content>

