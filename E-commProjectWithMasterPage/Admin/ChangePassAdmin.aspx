<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EComm.Master" AutoEventWireup="true" CodeBehind="ChangePassAdmin.aspx.cs" Inherits="E_commProjectWithMasterPage.Admin.ChangePassAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h2 class="text-center  text-bg-dark p-2">Change Password</h2>

	<div class="form-inline col-md-4 mx-auto bg-dark text-white p-5  ">
<%--		<div class="form-group mx-sm-3 mb-2">
			<asp:Label ID="Label2" runat="server" CssClass=" form-inline" Text="Old Password"></asp:Label>
			<asp:TextBox ID="TextBox2" CssClass="form-control mt-2"  runat="server"></asp:TextBox>
		</div>--%>
		<div class="form-group mx-sm-3 mb-2">
			<asp:Label ID="Label1" runat="server" CssClass=" form-inline" Text="New Password"></asp:Label>
			<asp:TextBox ID="TextBox1" CssClass="form-control mt-2" placeholder="New Password"  runat="server"></asp:TextBox>
		</div>

		<div class="text-center mt-4">
			<asp:Button ID="Button1" CssClass="btn btn-primary mb-2" OnClick="Button1_Click" runat="server" Text="Change Password" />
		</div>
	</div>
</asp:Content>
