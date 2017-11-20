<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientForm.aspx.cs" Inherits="SignalRDemo.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Client Form Receiving Notifications</title>
    <script src="/Scripts/jquery-1.8.2.min.js" ></script>
    <script src="/Scripts/jquery.signalR-1.0.0.js"></script>
    <script src="/signalr/hubs"></script>
    <script type="text/javascript">
        $(function () {
            var proxy = $.connection.notificationHub;

            proxy.client.receiveNotification = function (message) {
                $("#container").html(message);
                $("#container").slideDown(20);
                //setTimeout('$("#container").slideUp(2000);', 6000);
            };

            $.connection.hub.start();
        });
    </script>

    <style>
        .notificationPopUp
        {
            
            padding:6px;
            text-align:center;
            width:300px;
            position:absolute;
            display:none;
        }
    </style>
</head>
<body>
    <div class="notificationPopUp" id="container">
    </div>
</body>
</html>
