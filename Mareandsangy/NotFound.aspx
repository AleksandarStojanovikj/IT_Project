﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.master" AutoEventWireup="true" CodeFile="NotFound.aspx.cs" Inherits="NotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        h1, h3 {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container py-4" style="margin-left: 150px;">

        <h1>Oops!</h1>
        <h3>Seems like the user you've been looking for doesn't exist.</h3>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx"><em>Go back to home page.</em></asp:HyperLink>
    </div>
</asp:Content>

