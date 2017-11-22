<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UoW.Pictre.Web.WebForms.Home.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/pictreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/home.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/uploadp.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/displayDiv.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/font-awesome.min.css">
    <link href="/Content/css/jquery.tagit.css" rel="stylesheet" type="text/css" />
    <link href="/Content/css/tagit.ui-zendesk.css" rel="stylesheet" type="text/css" />
    <style>
        .pac-container {
            z-index: 1051 !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Content/js/PictreBDelegate.js"></script>
    <script src="/Home/uploadpic.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDH3g_mBeCDShD979oR6XMzq63xXiAeBwE&libraries=places&callback=initAutocomplete"
        async defer></script>


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

        function bandw() {
            console.log("kaala");
            document.getElementById("MainContent_ImgPrv").style.filter = "grayscale(100%)";
            //$('#<%=ImgPrv.ClientID%>').style.filter = "grayscale(100%)";
            return false;
        }

        function brightness() {

            document.getElementById("MainContent_ImgPrv").style.filter = "brightness(200%)";
            return false;
        }

        function contrast() {

            document.getElementById("MainContent_ImgPrv").style.filter = "contrast(200%)";
            return false;
        }

        function saturate() {

            document.getElementById("MainContent_ImgPrv").style.filter = "saturate(8)";
            return false;
        }

        function opacity() {

            document.getElementById("MainContent_ImgPrv").style.filter = "opacity(30%)";
            return false;
        }

    </script>


    <!-- The real deal -->
    <script src="/Home/tag-it.js" type="text/javascript" charset="utf-8"></script>

    <script>
        $(function () {
            var userEmail = $('#pictre_hdnf_CurrentUserEmailID').val();

            var editor = {
                setSource: function () {
                    return GetFriendsListService(userEmail);
                }
            }

            $.when(editor.setSource()).then(function (friends) {
                var sampleTags = [];

                for (index in friends) {
                    sampleTags.push(friends[index].FullName);
                }

                $('#myULTags').tagit({
                    availableTags: sampleTags, // this param is of course optional. it's for autocomplete.
                    // configure the name of the input field (will be submitted with form), default: item[tags]
                    itemName: 'item',
                    fieldName: 'tags',
                    allowSpaces: true
                });

            });

        });

        function initAutocomplete() {

            autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('pac-input')),
                { types: ['geocode'] });

            autocomplete.addListener('place_changed', fillInAddress);
        }

        function fillInAddress() {
            var place = autocomplete.getPlace();
            console.log(place);
        }

    </script>

    <div class="container">
        <!-- Trigger the modal with a button -->
        <button type="button" class="btn btn-default btn-lg" data-toggle="modal" data-target="#myModal" style="margin-left: 470px; width: 200px; margin-top: 20px"><span class="glyphicon glyphicon-picture"></span>&nbsp;Upload Photo</button>

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content Style="border-radius: 6px; background-color: #e7e7e7; color: black; width: 32%;"-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <asp:Image ID="ImgPrv" Height="150px" Width="200px" runat="server" Style="border: dashed; border-radius: 4px; border-width: 1px; border-style: inset; margin-top: 40px; float: left" /><br />
                        <div id="trykar" class="panel panel-default" style="height: 200px; width: 300px; float: left; margin-left: 40px">
                            <asp:Button class="filterbutton" runat="server" Text="Grayscale" OnClientClick="return bandw()" />
                            <asp:Button class="filterbutton" runat="server" Text="Brightness" OnClientClick="return brightness()" />
                            <asp:Button class="filterbutton" runat="server" Text="Contrast" OnClientClick="return contrast()" />
                            <asp:Button class="filterbutton" runat="server" Text="Saturate" OnClientClick="return saturate()" />
                            <asp:Button class="filterbutton" runat="server" Text="Opacity" OnClientClick="return opacity()" />

                        </div>


                    </div>
                    <div class="modal-body">
                        <div id="description" class="tagorCheckin" data-placeholder="Say something about this..." contenteditable="true" style="height: 80px"></div>


                    </div>
                    <div class="modal-body">

                        <div id="tagDiv" class="tagorCheckin" placeholder="Tag your friends..." contenteditable="true">
                            <div id="wrapper">
                                <div id="content">
                                    <form>
                                        <ul id="myULTags">
                                            <!-- Existing list items will be pre-added to the tags. -->
                                        </ul>
                                    </form>

                                </div>

                            </div>
                        </div>
                        <div id="locationField">
                            <input id="pac-input" class="form-control" placeholder="Provide Check-in Details" type="text" />
                        </div>
                        <hr />
                        <label class="file-upload">
                            <span><strong>Upload Image</strong></span>
                            <asp:FileUpload ID="FileUpload2" runat="server" onchange="ShowImagePreview(this)"></asp:FileUpload>
                        </label>
                        <asp:LinkButton ID="TagFriend" CssClass="btn btn-default btn-lg" runat="server" Text="Tag Friend" OnClientClick="return showthirdDiv()" Style="width: 32%"><span class="glyphicon glyphicon-user" > TagFriend</span></asp:LinkButton>
                        <asp:LinkButton ID="CheckInButton" CssClass="btn btn-default btn-lg" runat="server" Text="CheckIn" Style="width: 32%;"><span class="glyphicon glyphicon-map-marker" > CheckIn</span></asp:LinkButton>


                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal" onclick="HandleUpload()">Upload</button>

                    </div>
                </div>

            </div>
        </div>

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

    <hr />

    <div id="MyProfilePicture" style="overflow-x: auto;">
        <table>
            <tr>
                <td style="vertical-align: top; width: 280px;"></td>


                <td style="vertical-align: top; height: 100px; width: 660px; background-color: white">
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






                <td></td>
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
