<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Spotify.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
        <h1><asp:Label ID="Label1" runat="server" Text="Top 10 Songs"></asp:Label></h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5">
            <Columns>
                <asp:BoundField HeaderText="Song Name" DataField="song_name" />
                <asp:BoundField HeaderText="Cover Image" DataField="song_cover_image" />
                <asp:BoundField HeaderText="Released on" DataField="song_date_of_release" />
                <asp:BoundField HeaderText="Average Rating" DataField="song_avg_rating" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" Text="Rate" runat="server" CommandArgument='<%#Eval("song_id") %>' OnClick="lnkSelect_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="Button1" runat="server" Text="Add Song" OnClick="Button1_Click"/>
        <br />
        <br />
        <br />
        <h1><asp:Label ID="Label2" runat="server" Text="Top 10 Artists"></asp:Label></h1>

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CellPadding="5">
            <Columns>
                <asp:BoundField HeaderText="Artist Name" DataField="artist_name" />
                <asp:BoundField HeaderText="Artist DOB" DataField="artist_dob" />
                <asp:BoundField HeaderText="Artist Bio" DataField="artist_bio" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>