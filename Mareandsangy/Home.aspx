<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .card{
            border: none;
            background:none;
            color:white;
        }
        .card-img-top{
            padding-left:20px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    <div class="row justify-content-around pb-3 pt-5">
        <div class="col-4">
            <h1 style="color: white">Recommended:</h1>
        </div>
        <div class="col-4"></div>

        <div class="row align-items-center py-3 ">

            <div class="card-deck" style="justify-content: center;">
                <div class="card col-3">
                    <asp:Image ID="img1" runat="server" class="card-img-top" Style="width: 50%; height: 50%;" />
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblCT1" runat="server" Text=""></asp:Label><asp:Label ID="lblYear1" runat="server" Text=""></asp:Label></h5>
                        <asp:Label ID="lblCD1" runat="server" Text="" class="card-text"></asp:Label></br>
                        
                    </div>
                    <div class="card-footer bg-transparent">
                            <asp:Button ID="btnFav1" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnFav1_Click"/><asp:Button ID="btnWatch1" runat="server" Text="To Watch" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnWatch1_Click"/></div>
                    
                </div>
                <div class="card col-3">
                    <asp:Image ID="img2" runat="server" class="card-img-top" Style="width: 50%; height: 50%" />
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblCT2" runat="server" Text=""></asp:Label><asp:Label ID="lblYear2" runat="server" Text=""></asp:Label></h5>
                        <asp:Label ID="lblCD2" runat="server" Text="" class="card-text"></asp:Label>
                    </div>
                     <div class="card-footer bg-transparent">
                            <asp:Button ID="btnFav2" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnFav2_Click"/><asp:Button ID="btnWatch2" runat="server" Text="To Watch" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnWatch2_Click"/></div>
                </div>
                <div class="card col-3">
                    <asp:Image ID="img3" runat="server" class="card-img-top" Style="width: 50%; height: 50%;" />
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblCT3" runat="server" Text=""></asp:Label><asp:Label ID="lblYear3" runat="server" Text=""></asp:Label></h5>
                        <asp:Label ID="lblCD3" runat="server" Text="" class="card-text"></asp:Label>
                    </div>
                     <div class="card-footer bg-transparent">
                            <asp:Button ID="btnFav3" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnFav3_Click"/><asp:Button ID="btnWatch3" runat="server" Text="To Watch" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnWatch3_Click"/></div>
                </div>

            </div>
        </div>

    </div>

    <div class="row justify-content-around py-5">
        <div class="col-4">
            <h1 style="color: white">Other users watching:</h1>
        </div>
        <div class="col-4"></div>

        <div class="row align-items-center py-3 ">

            <div class="card-deck" style="justify-content: center">
                <div class="card col-3">
                    <asp:Image ID="img11" runat="server" class="card-img-top" Style="width: 50%; height: 50%" />
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblCT11" runat="server" Text=""></asp:Label><asp:Label ID="lblYear11" runat="server" Text=""></asp:Label></h5>
                        <asp:Label ID="lblCD11" runat="server" Text="" class="card-text"></asp:Label>
                    </div>
                     <div class="card-footer bg-transparent">
                            <asp:Button ID="btnFav4" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnFav4_Click"/><asp:Button ID="btnWatch4" runat="server" Text="To Watch" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnWatch4_Click"/></div>
                </div>
                <div class="card col-3">
                    <asp:Image ID="img22" runat="server" class="card-img-top" Style="width: 50%; height: 50%" />
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblCT22" runat="server" Text=""></asp:Label><asp:Label ID="lblYear22" runat="server" Text=""></asp:Label></h5>
                        <asp:Label ID="lblCD22" runat="server" Text="" class="card-text"></asp:Label>
                    </div>
                     <div class="card-footer bg-transparent">
                            <asp:Button ID="btnFav5" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnFav5_Click"/><asp:Button ID="btnWatch5" runat="server" Text="To Watch" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnWatch5_Click"/></div>
                </div>
                <div class="card col-3">
                    <asp:Image ID="img33" runat="server" class="card-img-top" Style="width: 50%; height: 50%;" />
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblCT33" runat="server" Text=""></asp:Label><asp:Label ID="lblYear33" runat="server" Text=""></asp:Label></h5>
                        <asp:Label ID="lblCD33" runat="server" Text="" class="card-text"></asp:Label>
                    </div>
                     <div class="card-footer bg-transparent">
                            <asp:Button ID="btnFav6" runat="server" Text="Favorite" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnFav6_Click"/><asp:Button ID="btnWatch6" runat="server" Text="To Watch" type="button" CssClass="btn btn-info btnSignout ml-3" aria-pressed="false" OnClick="btnWatch6_Click"/></div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>

