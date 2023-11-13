<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="E_commProjectWithMasterPage.User.userLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<section class=" container min-vh-100 d-flex justify-content-center align-items-center">
		<div class="container col-md-3 text-white w-50 p-5 bg-secondary p-4 rounded  ">
			 
				<div class="mb-2">
					<label for="txtemail" class="form-label">Email</label>
					<asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Email" required=""></asp:TextBox>
				</div>
				<div class="mb-2">
					<label for="txtPass" class="form-label">Password</label>
					<asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" required=""></asp:TextBox>
				</div>

				<div class="text-center mt-3">
					<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-dark" Text="Submit" />
				</div>

			</div>
	</section>
</asp:Content>
