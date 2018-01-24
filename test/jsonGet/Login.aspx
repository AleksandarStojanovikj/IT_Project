<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <asp:HyperLink ID="hlYes" runat="server" NavigateUrl="~/TestForm.aspx" Visible="False">Yes</asp:HyperLink>
        <asp:HyperLink ID="hlNo" runat="server" NavigateUrl="~/Login.aspx" Visible="False">          No</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
