<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Spotify.LoginPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Login<br />
            <hr />
            <br />
            <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
            :&nbsp
 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                BorderStyle="Dotted" ControlToValidate="TextBox1" ErrorMessage="User Name Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            :&nbsp
 <asp:TextBox ID="TextBox2" runat="server"
     TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                BorderStyle="Dotted" ControlToValidate="TextBox1" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="LoginClick" Text="Login"
                Width="112px" />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server"
                NavigateUrl="~/RegistrationPage.aspx">New User Click Here!!</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>
