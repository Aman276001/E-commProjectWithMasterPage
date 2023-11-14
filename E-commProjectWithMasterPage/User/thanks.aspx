<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="thanks.aspx.cs" Inherits="E_commProjectWithMasterPage.User.thanks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="text-center ">
	<h1 class="mb-5 mt-5">Payment Successfully.... </h1>
	<asp:Button ID="Button1" CssClass="btn btn-success w-50" runat="server" OnClick="Button1_Click" Text="Countinue Shoppinng >>" />
	</div>
	</asp:Content>
