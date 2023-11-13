<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="viewProductsUser.aspx.cs" Inherits="E_commProjectWithMasterPage.User.viewProductsUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<asp:Repeater runat="server" ID="Repeater1">
		<ItemTemplate>
			<div class="container mt-5 mb-5">
				<div class="row">
					<div class=" col-4 bg-light ">


						<img src='/Admin/ProdImg/<%#Eval("item_img") %>' class="card-img-top" alt="...">

						<%--<asp:Button ID="Button1" runat="server" CssClass="btn btn-warning" Height="50" Width="150" Text="ADD TO CART" />
						<asp:Button ID="Button2" runat="server" CssClass="btn btn-danger" Height="50" Width="200" Text="BUY NOW" />--%>
					</div>
					<div class="col">
						<h3 class="card-title pb-3"><%#Eval("item_Name") %></h2>
						<asp:Label ID="lb_id" Visible="false" runat="server" Text='<%#Eval("item_id")%>'></asp:Label>

							<h1 class="card-text pb-3">&#x20B9;<%#Eval("item_Price") %></h1>
							<h4 class="card-text pb-2"><%#Eval("item_Description") %></h4>
						Delivery Address :	<asp:TextBox ID="txtAdd" runat="server" CssClass=" bg-transparent  border-bottom border-0" Text="" />
							<asp:LinkButton ID="LinkButton1" runat="server">Change</asp:LinkButton>
							<br />
							<br />
							<asp:Button ID="Button3" runat="server" CssClass="btn btn-warning" Height="50" Width="150" Text="ADD TO CART" />
							<asp:Button ID="Button4" runat="server" CssClass="btn btn-danger" OnClick="Button4_Click" Height="50" Width="200" Text="BUY NOW" />
					</div>

				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</asp:Content>
