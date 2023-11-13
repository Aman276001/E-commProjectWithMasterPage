<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="userCart.aspx.cs" Inherits="E_commProjectWithMasterPage.User.userCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="row m-4 justify-content-center ">
		<asp:Repeater ID="Repeater1" runat="server">
			<ItemTemplate>
				<div class="card mb-3" style="max-width: 80%;">
					<div class="row g-0">
						<div class="col-md-4">
							<img src='/Admin/ProdImg/<%#Eval("item_img") %>' class="card-img-top pt-2 pb-2 ">
						</div>
						<div class="col-md-8">
							<div class="card-body">
								<h5 class="card-title"><%#Eval("item_Name") %></h5>
								<h4 class="card-text">Price :  <%#Eval("item_Price") %></h4>
								<div>
								Qty: 	<asp:TextBox ID="TextBox1" TextMode="Number" Text='<%#Eval("cartQty")%>' Width="45" runat="server"></asp:TextBox>
									<asp:LinkButton Text="Change" ID="lb_qty" OnClick="lb_qty_Click" runat="server" />
									<%--<asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-warning" Text="Update" />--%>
								</div>
								<asp:Label ID="Label1" runat="server" Text='<%#Eval("cart_id") %>'></asp:Label>
								<asp:Label ID="LbitemCartId" Visible="false" runat="server" Text='<%#Eval("itemCartID") %>'></asp:Label>
								<p class="card-text"><small class="text-body-secondary"><%#Eval("item_Description") %></small></p>
								<asp:Button ID="Button1" runat="server" CssClass="btn btn-success" OnClick="Button1_Click" Text="Details" />
								<asp:Button ID="Button2" runat="server" CssClass="btn btn-danger" OnClick="Button2_Click" Text="Remove" />
							</div>
						</div>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</asp:Content>
