  <%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EComm.Master" AutoEventWireup="true" CodeBehind="AddItemAdmin.aspx.cs" Inherits="E_commProjectWithMasterPage.Admin.AddItemAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h2 class="text-center  text-bg-dark p-2">Add Item</h2>
	<div class="container col-md-6 bg-dark text-white p-5">
		<div class="row">
			<div class="form-group col-md-6">
				<label for="txtItemame" class="form-label">Item Name</label>
				<asp:TextBox ID="txtItemname" runat="server" CssClass="form-control" placeholder="Item Name"></asp:TextBox>
			</div>
			<div class="form-group col-md-6">
				<label for="txtPrice" class="form-label">Price</label>
				<asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Price"></asp:TextBox>
			</div>
		</div>
		<div class="form-group mt-3">
			<label for="txtDesc" class="form-label">Description</label>
			<asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" placeholder="Description" TextMode="MultiLine"></asp:TextBox>
		</div>

		<div class="row mt-3">
			<div class="form-group col-md-4">
				<label for="inputCity">Image</label>
				<asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
			</div>
			<div class="form-group col-md-5">
				<label for="ddCategory1">Category</label>
				<asp:DropDownList ID="ddCategory" CssClass="form-control" runat="server"></asp:DropDownList>
			</div>
			<div class="form-group col-md-3">
				<label for="txtQuantity">Quantity</label>
				<asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" placeholder="Quantity"></asp:TextBox>
			</div>
		</div>

		<div class="text-center mt-4">
			<asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Add Item" />

		</div>

	</div>
	<asp:GridView ID="GridView1" runat="server" CssClass="table table-dark w-75 mt-2 mx-auto" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" AutoGenerateColumns="False">
		<Columns>
			<asp:TemplateField Visible="false" HeaderText="id">
				<EditItemTemplate>
					<asp:Label ID="Label2" runat="server" Text='<%# Eval("item_id") %>'></asp:Label>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%# Eval("item_id") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Image">
				<EditItemTemplate>
					<asp:FileUpload ID="FileUpload2"  CssClass="w-200" runat="server" />
				</EditItemTemplate>
				<ItemTemplate>
					<img src='/Admin/ProdImg/<%# Eval("item_img") %>' height="50px" alt="Alternate Text" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Name">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("item_Name") %>'></asp:TextBox>

				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label3" runat="server" Text='<%# Eval("item_Name") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Price">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox2" runat="server" CssClass="w-100" Text='<%# Eval("item_Price") %>'></asp:TextBox>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label4" runat="server" Text='<%# Eval("item_Price") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

			<asp:TemplateField HeaderText="Description">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox3" runat="server"  Text='<%# Eval("item_Description") %>'></asp:TextBox>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label5" runat="server" Text='<%# Eval("item_Description") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


			<asp:TemplateField HeaderText="Quantity">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox4" runat="server" CssClass="w-100" Text='<%# Eval("item_Totol_Quantity") %>'></asp:TextBox>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label6" runat="server" Text='<%# Eval("item_Totol_Quantity") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="action">
				<EditItemTemplate>
					<asp:Button ID="Button4" runat="server" CssClass="mb-2 btn btn-warning" CommandName="Update" Text="Update" />
					<asp:Button ID="Button5" runat="server" CommandName="Cancel" CssClass="btn btn-info mb-2" Text="Cancle" />
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Button ID="Button2" CssClass="btn btn-success mb-2" CommandName="Edit" runat="server" Text="Edit" />
					<asp:Button ID="Button3" CssClass="btn btn-danger mb-2" CommandName="Delete" runat="server" Text="Delete" />
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>

	</asp:GridView>

</asp:Content>
