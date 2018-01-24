<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestForm.aspx.cs" Inherits="TestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
                    <asp:Button ID="btnAddUser" runat="server" OnClick="btnAddUser_Click" Text="Register" />
                    <br />
                    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                    <br />
                    <asp:GridView ID="gvData" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
