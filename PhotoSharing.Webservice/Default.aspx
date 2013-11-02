<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoSharing.Webservice.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>


    <script type="text/javascript" src="Scripts/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="Scripts/jquery.signalR-2.0.0-rc1.js"></script>
    <script src="signalr/hubs"></script>

    <script type="text/javascript">
        $(function () {
            var photoHub = $.connection.photoHub;

            photoHub.client.onImageUploaded = function (url) {
                $("#qrCode").html("<img src='" + url + "' />");
            }

            $.connection.hub.start().done(function () {
                // ok
            });
        });
    </script>

    <style>
        body
        {
            font-family:"Segoe UI Light";
            margin:0;
            padding:0;
            background-color:#D6DBE9;
        }
        header
        {
            text-align:center;
            background-color:#007ACC;
            color:white;
            padding:5px 0;
            border-bottom:6px solid #68217A;
        }
        #qrCode
        {
            width:50%;
            margin:0 auto;
            text-align:center;
        }
        section
        {
            margin-top:50px;
        }
    </style>
</head>
<body>

    <header>
        <hgroup>
            <h1>Photo Sharing in Real-time</h1>
            <h3>Balusoft Labs</h3>
        </hgroup>
    </header>

    <section>
        <form id="form1" runat="server">
        <div id="qrCode">
            <asp:Image id="qrImage" runat="server"/>
        </div>        
        </form>
    </section>
</body>
</html>
