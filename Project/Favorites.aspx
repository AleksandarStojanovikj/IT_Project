<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.master" AutoEventWireup="true" CodeFile="Favorites.aspx.cs" Inherits="Favorites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    
    <div class="container">  
        <asp:Table ID="Table1" runat="server" CssClass="table">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Scope="Column">Name</asp:TableHeaderCell>
                <asp:TableHeaderCell Scope="Column">Button</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>1</asp:TableCell>
                <asp:TableCell>button 1</asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                <asp:TableCell>2</asp:TableCell>
                <asp:TableCell>button 2</asp:TableCell>
            </asp:TableRow>
                <asp:TableRow>
                <asp:TableCell><a></a></asp:TableCell>
                
            </asp:TableRow>
            
        </asp:Table>
</div>  

    
</asp:Content>




