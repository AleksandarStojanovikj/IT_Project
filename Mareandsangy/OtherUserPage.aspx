<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.master" AutoEventWireup="true" CodeFile="OtherUserPage.aspx.cs" Inherits="OtherUserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mpbtn {
            width: 200px;
        }
        
        body{
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row py-4 justify-content-start" style="margin-left: -50px;">
        <div class="col-2"></div>

        <div class="col-2">
            <asp:Button ID="btnFavorites" runat="server" Text="My favorites" type="button" CssClass="btn btn-info btn-lg mpbtn" aria-pressed="false" OnClick="btnFavorites_Click" />
        </div>

        <div class="col-2">
            <asp:Button ID="btntoWatch" runat="server" Text="To watch" type="button" CssClass="btn btn-info btn-lg mpbtn" aria-pressed="false" OnClick="btntoWatch_Click" />
        </div>


        <div class="col-2">
            <asp:Button ID="btnWatched" runat="server" Text="Already watched" type="button" CssClass="btn btn-info btn-lg mpbtn" aria-pressed="false" OnClick="btnWatched_Click" />
        </div>
    </div>

    <div class="row py-4 justify-content-start" style="margin-left: 73px;">
        <div class="col-1"></div>

        <div class="col-6">
            <asp:GridView ID="gvMyFavs" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" PageSize="7" Visible="False" DataKeyNames="Title" Width="500px" OnSelectedIndexChanged="gvMyFavs_SelectedIndexChanged" OnPageIndexChanging="gvMyFavs_PageIndexChanging" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonField CommandName="select" DataTextField="Title" Text="Button" HeaderText="Title" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

            <asp:Label ID="Label1" runat="server"></asp:Label>

        </div>


        <div class="col-4">
            <asp:Panel ID="pnlDetails" runat="server" Visible="False">
                <div class="row">
                    <asp:Image ID="imgPoster" runat="server" />
                </div>
                <div class="row">
                    <asp:Label ID="Label2" runat="server" Text="Title: " Font-Bold="True"></asp:Label> <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="Label4" runat="server" Text="Duration: " Font-Bold="True"></asp:Label> <asp:Label ID="lblDuration" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="Label6" runat="server" Text="Director: " Font-Bold="True"></asp:Label> <asp:Label ID="lblDirector" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="Label8" runat="server" Text="Plot: " Font-Bold="True"></asp:Label> <asp:Label ID="lblPlot" runat="server" Text=""></asp:Label>
                </div>
                <div class="card-footer bg-transparent">
                        <asp:Button ID="btnFav1" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnFav1_Click" /><asp:Button ID="btnWatch1" runat="server" Text="To Watch" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnWatch1_Click" />
                    </div>
            </asp:Panel>
        </div>


    </div>

</asp:Content>

