<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSong.aspx.cs" Inherits="Spotify.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
 </head>
<body>
    <form id="form1" runat="server">
        <div>
            
        </div>
        <h2><asp:Label ID="Label3" runat="server" Text="Add a new Song"></asp:Label></h2>

        <p>
            <asp:Label ID="Label4" runat="server" Text="Song Name"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label5" runat="server" Text="Date Released"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Artwork"></asp:Label>
            <asp:FileUpload  ID="FileUpload1" runat="server" />
        </p>
        <asp:Label ID="Label7" runat="server" Text="Artists"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add Artist" />
        <asp:Button ID="Button1" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;"/>
        <asp:Button ID="Button2" runat="server" Text="Add Song" OnClick="Button2_Click" /> 

        
    
        
    </form>
    
        
    </body>
</html>