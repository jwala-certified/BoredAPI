<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ActivityBoredAPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Please select your prefrence :
            <asp:DropDownList ID="ddlPreference" runat="server" ClientIDMode="AutoID" DataMember="Education"></asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="btnGetActivity" runat="server" Text="Get Activity" CssClass="btn btn-primary btn-lg" OnClick="btnGetActivity_Click" />
        </p>
    </div>
    
    <div id ="dvContent" runat="server">
        <button type="button" id="btn" runat="server" class="collapsible"></button>
        <div class="content">
            <label id="lblType" runat="server"></label><br />
            <label id="lblNP" runat="server"></label><br />
            <label id="lblRelPrice" runat="server"></label><br />
            <label id="lblLink" runat="server"></label><br />
            <label id="lblAccRating" runat="server"></label><br />
        </div>
    </div>

    <script>
        var coll = document.getElementsByClassName("collapsible");
        var i;

        for (i = 0; i < coll.length; i++) {
            coll[i].addEventListener("click", function () {
                this.classList.toggle("active");
                var content = this.nextElementSibling;
                if (content.style.display === "block") {
                    content.style.display = "none";
                } else {
                    content.style.display = "block";
                }
            });
        }
    </script>
</asp:Content>


