<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="Spotify.RegistrationPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Register User<br />
            <hr />
            <br />
            <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
            :&nbsp
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                BorderStyle="Dotted" ControlToValidate="TextBox1" ErrorMessage="User Name Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            :&nbsp
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                BorderStyle="Dotted" ControlToValidate="TextBox3" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Age"></asp:Label>
            :&nbsp
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                BorderStyle="Dotted" ControlToValidate="TextBox4" ErrorMessage="Age Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            :&nbsp
            <asp:TextBox ID="TextBox2" runat="server"
                TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                BorderStyle="Dotted" ControlToValidate="TextBox2" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Reg_Click"
                Text="Register" Width="112px" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
