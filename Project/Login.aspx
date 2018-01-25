<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.1.0.min.js"></script>
    <script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
</head>
<body>
    
    
    
    <form id="form1" runat="server">

        <form style="background-color:white">
            <div class="form-group">
                <label for="exampleInputEmail1">Email address</label>
                <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Password</label>
                <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
            </div>
            <div class="form-check">
                <input type="checkbox" class="form-check-input" id="exampleCheck1">
                <label class="form-check-label" for="exampleCheck1">Check me out</label>
            </div>
         <button type="submit" class="btn btn-primary">Submit</button>
        </form>
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
