<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MovieList.aspx.cs" Inherits="MovieList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
        <asp:Button ID="btnAddToFav" runat="server" OnClick="btnAddToFav_Click" Text="Add to favorites" />
    
    </div>
    </form>
</body>
</html>
