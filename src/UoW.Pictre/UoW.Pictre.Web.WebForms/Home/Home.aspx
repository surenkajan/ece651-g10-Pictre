<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.Home.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/home.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/uploadp.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/displayD.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Home/uploadpic.js" type="text/javascript"></script>


    <script type="text/javascript">   
        function ShowImagePreview(input) {
            console.log(input);
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrv.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>




    <asp:Button ID="bckgrndModal" CssClass="btn btn-default btn-lg" runat="server" Height=50px Width="200px" Text="Upload Photo" Style="border-radius: 4px;margin-top:20px;margin-left:500px;"  />

    <hr />

    <div class="container">
  <h2>Modal Example</h2>
  <!-- Trigger the modal with a button -->
  <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Upload Photo</button>

  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
            <asp:Image ID="ImgPrv" Height="150px" Width="200px" runat="server" Style="border: dashed; border-radius: 4px; border-width: 1px; border-style: inset;" /><br />


        </div>
        <div class="modal-body">
            
            <div contenteditable="true" data-ph="Say something about this photo... " id="secondlvl" class="form-control">
                
            </div>
          <p>Some text in the modal.</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
  
</div>



<div id="MyProfilePicture" style="overflow-x:auto;">
        <table >
            <tr>
                <td style="vertical-align:top;width:280px;">
 
                    </td>
            

            <td style="vertical-align:top; height:100px;width:660px; background-color:white" >
                    <div id="FriendContainer" class="FriendContainerclass" style="height: auto;"></div>  
           <%--    <div id="rect" class="rect" style="height: 650px; border-radius: 8px; position: relative;">
        <div id="usernameDiv" style="height: 50px; display: block; border-bottom-style: inset;">
            <img class ="img-circle" src="../Content/Images/dog.jpg" />
        </div>
        <div id="userpicDiv" style="height: 350px; display: block; border-bottom-style: inset;">

        </div>
        <span class="material-icons cloud" onclick="likecounter()"></span>
        <span style="position: relative; font-size: 30px; margin-left: 15px;" class="fa" onclick="addcomment()">&#xf0e5;</span>
        <div id="likeres" style="height: 20px"></div>
        <div id="commenttxtbox" style="display: none; height: 50px; margin-top: 140px; bottom: 0px; border-top-style: inset;">
            <asp:TextBox ID="inputtxt" runat="server" CssClass="content" Style="min-width: 595px !important; height: 48px; border-color: transparent"></asp:TextBox>

        </div> 

    </div> --%>
                
               
            </td>   
     
            
                


               
            <td>

                </td>
            </tr>
            
        </table>

    </div>









   



   <%-- %> <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <%--  <div id="Pictre_ImageButton1" runat="server" Height="120px" Width="120px" ImageUrl='<%# Eval("Value") %>'
                >Say Hi</div> 
            <table border="0" cellpadding="0" cellspacing="0" width="120px">
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="Pictre_ImageButton1" runat="server" Height="120px" Width="120px" ImageUrl='<%# Eval("Value") %>'
                            alt="The caption for this image goes here..." Style="cursor: pointer" OnClientClick="return Pictre_LoadDiv(this.src,alt);" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <%# Eval("Text") %>
                    </td>
                </tr>
            </table>
            


        </ItemTemplate>
    </asp:DataList> --%>

   
  <%--  <div id="rect" style="height: 650px; border-radius: 8px; position: relative;">
        <div id="usernameDiv" style="height: 50px; display: block; border-bottom-style: inset;"></div>
        <div id="userpicDiv" style="height: 350px; display: block; border-bottom-style: inset;">

        </div>
        <span class="material-icons cloud" onclick="likecounter()"></span>
        <span style="position: relative; font-size: 30px; margin-left: 15px;" class="fa" onclick="addcomment()">&#xf0e5;</span>
        <div id="likeres" style="height: 20px"></div>
        <div id="commenttxtbox" style="display: none; height: 50px; margin-top: 140px; bottom: 0px; border-top-style: inset;">
            <asp:TextBox ID="inputtxt" runat="server" CssClass="content" Style="min-width: 595px !important; height: 48px; border-color: transparent"></asp:TextBox>

        </div> 

    </div> --%>

    <div id="divBackground" class="pictremodal">
    </div>

  <%-- <div id="uploadwin1" class="divImage1">
        <div id="firstlvl">
            <span class="butclose" onclick="cancel()">&times;</span>
            <asp:Image ID="ImgPrv" Height="150px" Width="200px" runat="server" Style="border: dashed; border-radius: 4px; border-width: 1px; border-style: inset;" /><br />

            <div contenteditable="true" data-ph="Say something about this photo... " id="secondlvl" class="form-control">
                
            </div>
            <div id="tagDiv"  class="tagorCheckin" data-placeholder="Tag your friends..." contenteditable="true" style="white-space:nowrap;overflow:hidden;text-overflow:ellipsis"></div>

            <div id="fourthlvl">
                <label class="file-upload">
                    <span><strong>Upload Image</strong></span>
                    <asp:FileUpload ID="FileUpload2" runat="server" onchange="ShowImagePreview(this)"></asp:FileUpload>
                </label>
                <asp:Button ID="TagFriend" runat="server" Text="Tag Friend" Style="border-radius: 6px; background-color: #e7e7e7; color: black; width: 32%;" OnClientClick="return showthirdDiv()" />
                <asp:Button ID="CheckInButton" runat="server" Text="CheckIn" Style="border-radius: 6px; background-color: #e7e7e7; color: black; width: 32%;" />

            </div>
        </div>
    </div> --%>

    <div id="divImage1" class="divImage1">
        <span class="butclose" onclick="Pictre_HideDiv()">&times;</span>
        <%--  <img id="imgFull" alt="the one" src="" style="display:none; height:500px;width:590px" /> --%>
        <div id="pcaption"></div>
    </div>
    <%-- 
 <div id="divImage" class = "info">
    <table style="height: 100%; width: 100%">
        <tr>
            <td valign="middle" align="center">
                <img id="imgLoader" alt=""
                 src="images/loader.gif" />
                <img id="imgFull" alt="The first one!" src="" 
                 style="display: none;
                height: 500px;width: 590px" />
            </td>
        </tr>
        <tr>
           <td align = "center" align ="top">
                <div id ="caption"></div>
           </td>
        </tr>
        <tr>
            <td align="center" valign="bottom">
                <input id="btnClose" type="button" value="close"
                 onclick="Pictre_HideDiv()"/>
            </td>
        </tr>
    </table>
</div> --%>
</asp:Content>
