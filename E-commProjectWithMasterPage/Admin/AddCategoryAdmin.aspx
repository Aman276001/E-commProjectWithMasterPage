<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EComm.Master" AutoEventWireup="true" CodeBehind="AddCategoryAdmin.aspx.cs" Inherits="E_commProjectWithMasterPage.Admin.AddCategoryAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<h2 class="text-center  text-bg-dark p-2">Add Category</h2>

	<div class="form-inline col-md-4 mx-auto bg-dark text-white p-5 ">
		<div class="form-group mx-sm-3    mb-2">
			<asp:Label ID="Label1" runat="server" CssClass="" Text="Category :"></asp:Label>
			<asp:TextBox ID="TextBox1" CssClass="form-control mt-2" runat="server" placeholder="Category"></asp:TextBox>
		</div>
		<div class="text-center mt-4">
			<asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-primary mb-2" runat="server" Text="Add Category" />
		</div>
	</div>
	<div class=" container ">
		<div class="text-center ">
			<asp:GridView ID="GridView1" CssClass="table mt-2 table-dark w-50 mx-auto " DataKeyNames="cat_id" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
					<Columns>
					
						<asp:TemplateField HeaderText="Id" Visible="false">
							<ItemTemplate>
								<asp:Label ID="lb_itemID" runat="server" Text='<%# Eval("cat_id") %>'></asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:Label ID="lb_editID" runat="server" Text='<%# Eval("cat_id") %>'></asp:Label>
							</EditItemTemplate>
						</asp:TemplateField>
					
					<asp:TemplateField HeaderText="Category Name">
						<EditItemTemplate>
							<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("cat_Name") %>'></asp:TextBox>
						</EditItemTemplate>
						<ItemTemplate>
							<asp:Label ID="Label2" runat="server" Text='<%# Eval("cat_Name") %>'></asp:Label>
						</ItemTemplate>
					</asp:TemplateField>
							<asp:TemplateField HeaderText="action">
				<EditItemTemplate>
					<asp:Button ID="Button4" runat="server" CssClass=" btn btn-warning" CommandName="Update" Text="Update" />
					<asp:Button ID="Button5" runat="server" CommandName="Cancel" CssClass="btn btn-info" Text="Cancle" />
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Button ID="Button2" CssClass="btn btn-success" CommandName="Edit" runat="server" Text="Edit" />
					<asp:Button ID="Button3" CssClass="btn btn-danger" CommandName="Delete" runat="server" Text="Delete" />
				</ItemTemplate>
			</asp:TemplateField>
				</Columns>
			</asp:GridView>
		</div>
	</div>
</asp:Content>
