<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.master" AutoEventWireup="true" CodeFile="MyPage.aspx.cs" Inherits="MyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mpbtn {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row py-4 justify-content-start" style="margin-left: -50px;">
        <div class="col-2"></div>

        <div class="col-2">
            <asp:button id="btnFavorites" runat="server" text="My favorites" type="button" cssclass="btn btn-info btn-lg mpbtn" aria-pressed="false" onclick="btnFavorites_Click" />
        </div>

        <div class="col-2">
            <asp:button id="btntoWatch" runat="server" text="To watch" type="button" cssclass="btn btn-info btn-lg mpbtn" aria-pressed="false" onclick="btntoWatch_Click" />
        </div>


        <div class="col-2">
            <asp:button id="btnWatched" runat="server" text="Already watched" type="button" cssclass="btn btn-info btn-lg mpbtn" aria-pressed="false" onclick="btnWatched_Click" />
        </div>
    </div>

    <div class="row py-4 justify-content-start" style="margin-left: 73px;">
        <div class="col-1"></div>

        <div class="col-6">
            <asp:gridview id="gvMyFavs" runat="server" allowpaging="True" autogeneratecolumns="False" cellpadding="4" pagesize="7" visible="False" datakeynames="Title" width="500px" onselectedindexchanged="gvMyFavs_SelectedIndexChanged" onpageindexchanging="gvMyFavs_PageIndexChanging" forecolor="#333333" gridlines="None">
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
            </asp:gridview>

            <asp:gridview id="gvToWatch" runat="server" allowpaging="True" autogeneratecolumns="False" cellpadding="4" datakeynames="Title" onrowdeleting="gvToWatch_RowDeleting" onselectedindexchanged="gvToWatch_SelectedIndexChanged" pagesize="7" width="500px" onpageindexchanging="gvToWatch_PageIndexChanging" forecolor="#333333" gridlines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonField CommandName="select" DataTextField="Title" HeaderText="Title" />
                    <asp:CommandField DeleteText="Mark as watched" ShowDeleteButton="True" />
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
            </asp:gridview>

            <asp:label id="Label1" runat="server"></asp:label>

        </div>


        <div class="col-4">
            <asp:panel id="pnlDetails" runat="server" visible="False">
                <div class="row">
                    <asp:Image ID="imgPoster" runat="server" />
                </div>
                <div class="row">
                    <asp:Label ID="Label2" runat="server" Text="Tile:" ForeColor="White" Font-Bold="True"></asp:Label><asp:Label ID="lblTitle" runat="server" Text="" ForeColor="White"></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="Label4" runat="server" Text="Duration: " ForeColor="White" Font-Bold="True"></asp:Label><asp:Label ID="lblDuration" runat="server" Text="" ForeColor="White"></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="Label6" runat="server" Text="Director: " ForeColor="White" Font-Bold="True"></asp:Label><asp:Label ID="lblDirector" runat="server" Text="" ForeColor="White"></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="Label8" runat="server" Text="Plot: " ForeColor="White" Font-Bold="True"></asp:Label><asp:Label ID="lblPlot" runat="server" Text="" ForeColor="White"></asp:Label>
                </div>
                <div class="card-footer bg-transparent">
                        <asp:Button ID="btnFav1" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnFav1_Click" />
                    </div>
            </asp:panel>
        </div>


    </div>

</asp:Content>

