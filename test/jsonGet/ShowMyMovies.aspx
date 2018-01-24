<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowMyMovies.aspx.cs" Inherits="ShowMyMovies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="This are my lists."></asp:Label>
    
        <br />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <br />
        <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
    
    </div>
    </form>
</body>
</html>
