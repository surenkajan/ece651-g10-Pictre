﻿<%@ Page Title="MyProfile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.MyProfile.MyProfile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/myprofile.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/uploadp.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/displayDiv.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Content/js/PictreBDelegate.js"></script>
    <script src="/MyProfile/MyProfile_Picture.js" type="text/javascript"></script>
    <%--<h3><%: Title %>My Profile</h3>--%>
    <table>
    <tr>
        <td style=" width: 1000px"">
        <asp:Label ID="MyProfileHeading" font-size="20pt" runat="server" Text=""></asp:Label>
        <asp:Label ID="MyProfileHeading1" font-size="20pt" runat="server">'s Profile</asp:Label>
        </td>
        <td>
            
        <asp:Button runat="server" Text="+ Add Friend"  CssClass="btn btn-default" ID="Btn_addFriend" OnClick="Btn_addFriend_Click"  style="font-weight:bold"  BackColor="DarkBlue"/>
         <asp:Label ID="Label1" runat="server" Text="Added as friend!" class="man-ast-field"></asp:Label> 
        </td>
    </tr>
    </table>
    <hr />
    <div id="MyProfilePicture" style="overflow-x:auto;">
        <table >
            <tr>
                <td style="vertical-align:top">
                    <div style="margin: 0 auto;">
                    <table style="align-self:auto">
                  <tr>
            
                
                <td>
                     <%--<img src="../Content/Images/dog.jpg" style="width:200px;height:200px;" />--%>
                     <asp:Image runat="server" ID="ImagePreview"  Height="164px" Width="125px" style="border-radius: 6px;"/>

                </td>
            </tr>
            <tr>
           <td>
                    <asp:Label ID="MyProfileNameLabel" runat="server"><b>Name </b></asp:Label>
               <asp:Label ID="MyProfileName"  runat="server"  Text=""></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MyProfileDOBLabel" runat="server"><b>DOB: </b></asp:Label>
                      <asp:Label ID="MyProfileDOB" runat="server" Text=""></asp:Label>
                </td>
              
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MyProfileEmailLabel" runat="server"><b>Email: </b></asp:Label>
                    <asp:Label ID="MyProfileEmail" runat="server" Text=""></asp:Label>
                </td>
              
            </tr>

        
    
   </table>
                        </div>
                    </td>
            

            <td style="vertical-align: top; height: 100px; width: 660px; background-color: white" >
               <div id="FriendContainer" class="FriendContainerclass" style="height: auto;"></div>
            </td>   
     
            
                


               
                <td style="vertical-align: top;">
<table style="margin-left:100px">
    <tr>
        <td style="vertical-align:top">
                    
 <h3 style="color:black;"><span class="end">
    <img src="../Content/Images/Friends-PNG-Photos.png" style="width:30px;height:30px"; /></span> Friends</h3>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

<ContentTemplate>
<asp:gridview ID="grdData" runat="server" 
AutoGenerateColumns="False" CellPadding="4" PageSize="5"
ForeColor="#333333" GridLines="None" Width="250" AllowPaging="True"
OnPageIndexChanging="grdData_PageIndexChanging" OnSelectedIndexChanged="grdData_SelectedIndexChanged"  EmptyDataText="No Friends Found!!!">
<pagersettings mode="NextPreviousFirstLast"
            nextpagetext="Next"
            previouspagetext="Prev" />
            <alternatingrowstyle BackColor="White" ForeColor="#284775"></alternatingrowstyle>
            <columns>
           <asp:ImageField DataImageUrlField="ImageUrl" ItemStyle-Width="5px"  ControlStyle-Width="100" ControlStyle-Height = "100" > 
                                    <ControlStyle Height="100px" Width="100px"></ControlStyle>
                 <ItemStyle Width="5px"></ItemStyle>
                 </asp:ImageField>
            
                
                
                 <asp:HyperLinkField DataNavigateUrlFields="Uid"  DataNavigateUrlFormatString="MyProfile.aspx?Uid={0}" DataTextField="Profile_Name"  />
            </columns> 
            <editrowstyle BackColor="#999999"></editrowstyle>
            <footerstyle BackColor="#5D7B9D" Font-Bold="True" 

            ForeColor="White"></footerstyle>
            <headerstyle BackColor="#5D7B9D" Font-Bold="True" 

            ForeColor="White"></headerstyle>
            <pagerstyle BackColor="#284775" ForeColor="White" 

            HorizontalAlign="Center"></pagerstyle>
            <rowstyle BackColor="#F7F6F3" ForeColor="#333333"></rowstyle>
            <selectedrowstyle BackColor="#E2DED6" Font-Bold="True" 

            ForeColor="#333333"></selectedrowstyle>
            <sortedascendingcellstyle BackColor="#E9E7E2"></sortedascendingcellstyle>
            <sortedascendingheaderstyle BackColor="#506C8C"></sortedascendingheaderstyle>
            <sorteddescendingcellstyle BackColor="#FFFDF8"></sorteddescendingcellstyle>
            <sorteddescendingheaderstyle BackColor="#6F8DAE"></sorteddescendingheaderstyle>
        </asp:gridview>
    </ContentTemplate>
    </asp:UpdatePanel>
</td>
        </tr>
    </table>
                </td>
            </tr>
            
        </table>

    </div>

    <div id="myModalnew" class="modalnew">
        <span class="closenew">×</span>
        <img class="modal-contentnew" id="img01" style="margin-top:100px">
        <div id="caption"></div>
    </div>
    
    <div id="LikesModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
 <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;  </button>
        <h4 class="modal-title" id="myModalLabel"><span class="glyphicon glyphicon-heart-empty"></span> View Likes</h4>
      </div>
      <div class="modal-body">
        <div id="likes-modal-container" style="overflow:auto;">
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

          <!-- Modal -->
    <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document" style="margin-top:200px;width:400px">
            <div class="modal-content">
                <div class="modal-body">     
                    <button type="button" class="close" data-dismiss="modal" onclick="location.reload()">&times;</button>
                   <p style="font-size:18px;margin-top:20px"><strong> Are you sure you want to delete the photo? </strong></p>
                </div>
                <div class="modal-footer">
        <button id="ModalDeleteButton" type="button" class="btn btn-default" data-dismiss="modal">Delete</button>
      </div>
            </div>
        </div>
    </div>

</asp:Content>
