<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EComm.Master" AutoEventWireup="true" CodeBehind="AddQuantityAdmin.aspx.cs" Inherits="E_commProjectWithMasterPage.Admin.AddQuantityAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<h2 class="text-center  text-bg-dark p-2">Add Quantity</h2>

	<div class="form-inline col-md-4 mx-auto bg-dark text-white p-5  ">
		<div class="form-group mx-sm-3   mb-2">
			<asp:Label ID="Label1" runat="server" CssClass=" form-inline" Text="Select Item :"></asp:Label>
			<asp:DropDownList ID="DropDownList1" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
		</div>
		<div class="form-group mx-sm-3   mb-2">
			<asp:Label ID="Label2" runat="server" CssClass=" form-inline" Text="Add Quantity"></asp:Label>
		<asp:TextBox ID="txtQun" CssClass="form-control form-inline mt-2" runat="server" placeholder="Category"></asp:TextBox>
		</div>
		<div class="text-center mt-4">
			<asp:Button ID="Button1" OnClick="Button1_Click"  CssClass="btn btn-primary mb-2" runat="server" Text="Add Quantity" />
		</div>
	</div>
	<div class="container mx-auto md-3">
		<div class="text-center">
			<asp:GridView ID="GridView1" runat="server"></asp:GridView>
		</div>
	</div>
</asp:Content>
