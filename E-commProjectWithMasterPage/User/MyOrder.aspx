<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="MyOrder.aspx.cs" Inherits="E_commProjectWithMasterPage.User.MyOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<asp:GridView ID="GridView1" runat="server" CssClass="table table-dark w-75 mt-2 mx-auto table-bordered" AutoGenerateColumns="false" EmptyDataText="No Record Found">
		<Columns>
			<asp:TemplateField>
				<HeaderTemplate>
					Photo
				</HeaderTemplate>
				<ItemTemplate>
					<img src='/Admin/ProdImg/<%#Eval("item_img") %>' height="100">
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<HeaderTemplate>
					Product Name
				</HeaderTemplate>
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%#Eval("item_Name") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<HeaderTemplate>
					Price
				</HeaderTemplate>
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%#Eval("PayMoney") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

			<asp:TemplateField>
				<HeaderTemplate>
					Quntity
				</HeaderTemplate>
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%#Eval("buyQty") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<HeaderTemplate>
					Date Time
				</HeaderTemplate>
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%#Eval("DateTime") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

		</Columns>

	</asp:GridView>
</asp:Content>
