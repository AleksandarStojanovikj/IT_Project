<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.master" AutoEventWireup="true" CodeFile="OtherUserPage.aspx.cs" Inherits="OtherUserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mpbtn {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
        <div class="row py-4 justify-content-start" style="margin-left:-50px;">
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

        <div class="row py-4 justify-content-start" style="margin-left:73px;">
            <div class="col-1"></div>

            <div class="col-6">
                <asp:GridView ID="gvMyFavs" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="7" Visible="False" DataKeyNames="Title" Width="500px" OnSelectedIndexChanged="gvMyFavs_SelectedIndexChanged" OnPageIndexChanging="gvMyFavs_PageIndexChanging">
                    <Columns>
                        <asp:ButtonField CommandName="select" DataTextField="Title" Text="Button" HeaderText="Title" />
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>

                <asp:Label ID="Label1" runat="server"></asp:Label>

            </div>


            <div class="col-4">
                <asp:Panel ID="pnlDetails" runat="server" Visible="False">
                    <div class="row">
                        <asp:Image ID="imgPoster" runat="server" />
                    </div>
                    <div class="row">
                        <asp:Label ID="Label2" runat="server" Text="Tile:"></asp:Label><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="row">
                        <asp:Label ID="Label4" runat="server" Text="Duration: "></asp:Label><asp:Label ID="lblDuration" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="row">
                        <asp:Label ID="Label6" runat="server" Text="Director: "></asp:Label><asp:Label ID="lblDirector" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="row">
                        <asp:Label ID="Label8" runat="server" Text="Plot: "></asp:Label><asp:Label ID="lblPlot" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
            </div>


        </div>
    
</asp:Content>

