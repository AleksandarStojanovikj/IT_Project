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
        .btn-danger{
            width:100px;
        }
        .form-control{
            width:76%;
        }
         
    </style>
</head>
<body style="background-image:url(collage1.jpg);background-size:cover">
    <form id="form1" runat="server">

       
        
        <div class="container" style="margin-top:10%">
           
           <div class="row justify-content-center">
               <div class="col-4">
                   <h1 style="color:white">Login</h1>
               </div>
               
           </div> 

        <div class="row justify-content-center">
            <div class="col-4 form-group">
            <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>  
                
            </div>
            
        </div>

        <div class="row justify-content-center">
            <div class="col-4 form-group">
            <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox></div>
            
         </div>  
             <div class="row justify-content-center">
                 <div class="col-4 form-group">
                    <asp:Button ID="Button1" runat="server" Text="Login" type="button" class="btn btn-danger" data-toggle="button" aria-pressed="false"/>
                 </div>
                
             </div>

            <div class="row justify-content-center">
                 <div class="col-4 form-group">
                    <p style="color:white">Don't have an account? <a href="Register.aspx" style="color:white"><u><em>Sign up here!</em></u></a></p>
                 </div>
                
             </div>

            <div class="row justify-content-center">
                <div class="col-4 form-group">
                <asp:Label ID="lblError" runat="server" Text="Oops! Wrong credidentials.." class="alert alert-danger" role="alert" Visible="False"></asp:Label></div>
             </div>
           
         </div>
        
        </form>
                
        </div> 

    </div>

    </form>
</body>
</html>
