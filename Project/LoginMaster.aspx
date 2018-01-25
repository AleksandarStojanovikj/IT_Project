<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginMaster.aspx.cs" Inherits="LoginMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.1.0.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <style>
        .form-group {
            width:30%; 
        }
        
         
    </style>
</head>
<body style="background-image:url(collage1.jpg);background-size:cover">
    <form id="form1" runat="server">

       
        
        <div class="container" style="margin-top:13%">
           
           <div class="row justify-content-between">
               <div class="col-4">
                   <h1 style="color:white">Login</h1>
               </div>
               <div class="col-4">
                   <h1 style="color:white">Sign Up</h1>
               </div>
           </div> 

        <div class="row justify-content-between">
            <div class="col-4 form-group">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>  
            </div>
            <div class="col-4 form-group">
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Enter name"></asp:TextBox>
            </div>
        </div>

        <div class="row justify-content-between">
            <div class="col-4 form-group">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Enter password"></asp:TextBox></div>
            <div class="col-4 form-group">
                <asp:TextBox ID="TextBox5" runat="server"  CssClass="form-control" placeholder="Enter username"></asp:TextBox></div>
         </div>  
             <div class="row justify-content-between">
                 <div class="col-2 form-group">
                    <asp:Button ID="Button1" runat="server" Text="Login" type="button" class="btn btn-danger" data-toggle="button" aria-pressed="false"/>
                 </div>
                 <div class="col-4 form-group">
                     <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
                 </div>
                 
             </div>

            <div class="row justify-content-between">
                <div class="col-2 form-group">
                    
                 </div>
                 <div class="col-4 form-group">
                     <asp:Button ID="Button2" runat="server" Text="Register" type="button" class="btn btn-danger" data-toggle="button" aria-pressed="false"/>
                 </div>
                
            </div>
         </div>
        
        </form>
                
        </div> 

    </div>

    </form>
</body>
</html>
