<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EComm.Master" AutoEventWireup="true" CodeBehind="AdminRegister.aspx.cs" Inherits="E_commProjectWithMasterPage.Admin.AdminRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<section class=" container min-vh-100 d-flex justify-content-center align-items-center">

		<div class="container col-md-4 w-50 text-white mt-5 bg-secondary p-4 rounded">
			<div class="row">
				<div class="mb-2 col-md-6">
					<label for="txtfname" class="form-label">First Name</label>
					<asp:TextBox ID="txtfname" runat="server" CssClass="form-control" placeholder="First Name" required=""></asp:TextBox>
				</div>
				<div class="mb-2 col-md-6">
					<label for="txtlname" class="form-label">Last Name</label>
					<asp:TextBox ID="txtlname" runat="server" CssClass="form-control" placeholder="Last Name" required=""></asp:TextBox>
				</div>
			</div>
			<div class="mb-2">
				<label for="txtPhone" class="form-label">Phone No.</label>
				<asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Phone no." required=""></asp:TextBox>
			</div>
			<div class="mb-2">
				<label for="txtemail" class="form-label">Email</label>
				<asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Email" required=""></asp:TextBox>
			</div>
			<div class="mb-2">
				<label for="txtPass" class="form-label">Password</label>
				<asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" required=""></asp:TextBox>
			</div>
			<label for="txtPass" class="form-label">Gender</label>

			<asp:DropDownList ID="DropDownList1" CssClass="mb-2 form-control" AutoPostBack="true" runat="server">
				<asp:ListItem Selected="True">Select</asp:ListItem>
				<asp:ListItem>Male</asp:ListItem>
				<asp:ListItem>Female</asp:ListItem>

			</asp:DropDownList>




			<div class="text-center mt-3">
				<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-dark" Text="Submit" />
			</div>

		</div>
	</section>
</asp:Content>
