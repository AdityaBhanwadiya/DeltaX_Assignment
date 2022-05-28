<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddArtist.aspx.cs" Inherits="Spotify.AddArtist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function insert() {
            var name = document.getElementById("TextBox1").value;
            var dob = document.getElementById("TextBox2").value;
            var bio = document.getElementById("TextBox3").value;

            var xmlhttp = new XMLHttpRequest();
            xmlhttp.open("GET", "insert.aspx?nm=" + name + "&birth=" + dob + "&bio=" + bio, false);
            xmlhttp.send(null);

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Artist Name"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Date of Birth"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Bio"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />
        <input type="button" id="Button2" value="Add Artist" onclick="insert();"/>
    </form>
</body>
</html>
