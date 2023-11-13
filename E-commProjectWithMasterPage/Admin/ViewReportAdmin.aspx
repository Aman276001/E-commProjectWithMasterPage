<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EComm.Master" AutoEventWireup="true" CodeBehind="ViewReportAdmin.aspx.cs" Inherits="E_commProjectWithMasterPage.Admin.ViewReportAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h2 class="text-center  text-bg-dark p-2">View Report</h2>

	<div class="form-inline col-md-4 mx-auto bg-dark text-white p-5  ">
		<div class="form-group mx-sm-3   mb-2">
			<asp:Label ID="Label1" runat="server" CssClass=" form-inline" Text="Select Category"></asp:Label>
			<asp:DropDownList ID="DropDownList1" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
		</div>

		<div class="text-center mt-4">
			<asp:Button ID="Button1" CssClass="btn btn-primary mb-2" OnClick="Button1_Click" runat="server" Text="View Report" />
		</div>
	</div>
	<asp:GridView ID="GridView1" EmptyDataText="No Record Found" CssClass=" table table-dark mt-2 w-75 mx-auto text-center" runat="server" AutoGenerateColumns="False">
		<Columns>
			<asp:TemplateField Visible="false" HeaderText="id">
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%# Eval("item_id") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Image">

				<ItemTemplate>
					<asp:Image ID="Image1" runat="server" ImageUrl= />
					<img src='/Admin/ProdImg/<%# Eval("item_img") %>' height= "50px" />
				</ItemTemplate>

			</asp:TemplateField>
			<asp:TemplateField HeaderText="Item Name">
				<ItemTemplate>
					<asp:Label ID="Label2" runat="server" Text='<%# Eval("item_Name") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Price">
					<ItemTemplate>
					<asp:Label ID="Label3" runat="server" Text='<%# Eval("item_Price") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Qnt">
					<ItemTemplate>
					<asp:Label ID="Label4" runat="server" Text='<%# Eval("item_Totol_Quantity") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Available">
					<ItemTemplate>
					<asp:Label ID="Label5" runat="server" Text='<%# Eval("item_Available_Quantity") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Sell Qnt">
					<ItemTemplate>
					<asp:Label ID="Label6" runat="server" Text='<%# Eval("item_Sell_Quantity") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>
