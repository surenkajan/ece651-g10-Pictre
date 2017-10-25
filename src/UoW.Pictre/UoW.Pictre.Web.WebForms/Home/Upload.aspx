<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.Home.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/home.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:FileUpload ID="Pictre_FileUpload1" runat="server" Height="46px" Width="369px"  />
    <asp:Button ID="Pictre_btnUpload" runat="server" Text="Upload" OnClick="Pictre_btnUpload_Click" Width="218px" />
        <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width = "120px">
                <tr>
                    <td align ="center"> 
                        <asp:Image ID="Image1" runat="server" Height="120px" Width="120px" ImageUrl='<%# Eval("Value") %>' />
                    </td>
                </tr>
                <tr>
                    <td align ="center">
                        <%# Eval("Text") %>
                    </td>
                </tr>
            </table>


        </ItemTemplate>
    </asp:DataList>
</asp:Content>
