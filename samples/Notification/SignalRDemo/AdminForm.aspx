<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="SignalRDemo.AdminForm" %>

<!DOCTYPE html>
<html>
<head>
    <title>Admin Form Sending Notifications</title>

    <script src="/Scripts/jquery-1.8.2.min.js" ></script>
    <script src="/Scripts/jquery.signalR-1.0.0.js"></script>
    <script src="/signalr/hubs"></script>

    <script type="text/javascript">
        $(function () {
            var proxy = $.connection.notificationHub;

            $("#Notification").click(function () {
               // proxy.server.sendNotifications($("#text1").val());
                proxy.server.sendNotifications($.connection.hub.id, ("You got a Friend request!!!"));
            });

            $.connection.hub.start();
        });
    </script>

</head>
<body>
   <%-- <input id="text1" type="text" />
   <input id="button1" type="button" value="Send" />--%>
    <%--<asp:Button ID="Button1" OnClick="Button_Click"  runat="server" Text="+Add Friend" />--%>
   <%-- <script type="text/javascript">
        var i = 0;

        function increase() {
            i++;
            return false;
        }
    </script>--%>
    <input type="button" id="Notification" value="+AddFriend"/>
</body>
</html>
