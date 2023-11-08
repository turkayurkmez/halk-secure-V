﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="_Default" ValidateRequest="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
            <p>
                Kullanıcı Giriş</p>
            <p>
                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Giriş" />
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                Yorumunuz:</p>
            <p>
                <asp:TextBox ID="TextBoxComment" runat="server" Height="89px" TextMode="MultiLine" Width="363px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="ButtonComment" runat="server" OnClick="ButtonComment_Click" Text="Yorum Ekle" />
            </p>
            <p>
                <asp:Label ID="Labelcomment" runat="server" Text="Label"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>