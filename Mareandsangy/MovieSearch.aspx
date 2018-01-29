<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.master" AutoEventWireup="true" CodeFile="MovieSearch.aspx.cs" Inherits="MovieSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .row {
            padding-top: 50px;
            align-content: center;
        }

        body {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row  align-content-center">
            <div class="col-3">
                <asp:TextBox ID="tbTitle" runat="server" class="form-control" placeholder="Enter a movie name" aria-label="Recipient's username" aria-describedby="basic-addon2"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:TextBox ID="tbYear" runat="server" class="form-control" placeholder="Enter a year (optional)" aria-label="Recipient's username" aria-describedby="basic-addon2"></asp:TextBox>

            </div>
            <div>
                <asp:Button ID="btnSearch" runat="server" Text="Search" type="button" CssClass="btn btn-primary btnSignout ml-3" aria-pressed="false" OnClick="btnSearch_Click" />
            </div>
        </div>
        <div class="row">
            <asp:Panel ID="pnlMovie" runat="server" Visible="False">
                
                    <asp:Image ID="imgPoster" runat="server" style="float:left;"/>
                
                <div style="width:40%;float:left; padding-left:50px">

                    <h3>
                        <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h3>

                    <asp:Label ID="Label13" runat="server" Text="Genre: " Font-Bold="True"></asp:Label><asp:Label ID="lblGenre" runat="server" Text=""></asp:Label><br />

                    <asp:Label ID="Lable10" runat="server" Text="Duration: " Font-Bold="True"></asp:Label><asp:Label ID="lblRuntime" runat="server" Text=""></asp:Label><br />

                    <asp:Label ID="Label3" runat="server" Text="Rating: " Font-Bold="True"></asp:Label><asp:Label ID="lblRating" runat="server" Text=""></asp:Label><br />

                    <asp:Label ID="Label5" runat="server" Text="Director: " Font-Bold="True"></asp:Label><asp:Label ID="lblDirector" runat="server" Text=""></asp:Label><br />

                    <asp:Label ID="Label7" runat="server" Text="Writer: " Font-Bold="True"></asp:Label><asp:Label ID="lblWriter" runat="server" Text=""></asp:Label><br />

                    <asp:Label ID="Label9" runat="server" Text="Actors: " Font-Bold="True"></asp:Label><asp:Label ID="lblActors" runat="server" Text=""></asp:Label><br />

                    <asp:Label ID="Label11" runat="server" Text="Plot: " Font-Bold="True"></asp:Label><asp:Label ID="lblPlot" runat="server" Text=""></asp:Label><br />

                    <div><asp:Button ID="btnFav" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout my-3" aria-pressed="false" OnClick="btnFav_Click"/><asp:Button ID="btnWatch" runat="server" Text="To Watch" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnWatch_Click"/></div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

