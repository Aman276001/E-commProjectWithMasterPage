<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EComm.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="E_commProjectWithMasterPage.Admin.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h2 class="text-center  text-bg-dark p-2">Welcome to Admin Page 	
		<asp:Label ID="Label1" runat="server"></asp:Label>
	</h2>
	<div class="container">
		<div class="form-group">
			<label for="exampleInputEmail1">Email address</label>
			<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
			<small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
		</div>
		<div class="form-group">
			<label for="exampleInputPassword1">Password</label>
			<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
		</div>
		<div class="form-check">
			<input type="checkbox" class="form-check-input" id="exampleCheck1">
			<label class="form-check-label" for="exampleCheck1">Check me out</label>
		</div>
		<button type="submit" class="btn btn-primary">Submit</button>
	</div>
</asp:Content>
