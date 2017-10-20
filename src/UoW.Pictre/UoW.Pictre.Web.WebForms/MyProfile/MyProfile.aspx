<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.MyProfile.MyProfile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/myprofile.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>Profile Information</h2>
    <div id="MyProfilePicture" style="overflow-x:auto;">
        <img src="../Content/Images/favicon_p_color.png" style="width:200px;height:200px;" />
    </div>
    <div id="ProfileInformation" style="overflow-x:auto;">
        <table id="Table1" class="table">
            <tr>
                <td>
                    <asp:Label ID="MyProfileNameLabel" runat="server"><b>Name</b></asp:Label>
                </td>
                <td>
                    <asp:Label ID="MyProfileName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MyProfileDOBLabel" runat="server"><b>Date of Birth</b></asp:Label>
                </td>
                <td>
                    <asp:Label ID="MyProfileDOB" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MyProfileGenderLabel" runat="server" ><b>Gender</b></asp:Label>
                </td>
                <td>
                    <asp:Label ID="MyProfileGender" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MyProfileEmailLabel" runat="server"><b>Email</b></asp:Label>
                </td>
                <td>
                    <asp:Label ID="MyProfileEmail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
          
    </div>
</asp:Content>
