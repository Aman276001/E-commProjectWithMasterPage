<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="HomeUser.aspx.cs" Inherits="E_commProjectWithMasterPage.User.HomeUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class=" row m-4 justify-content-center ">

		<asp:Repeater ID="Repeater1"  runat="server">
			<ItemTemplate>
				<div class="card m-1 bg-dark text-white pt-2" style="width: 17rem;">
					<img src='/Admin/ProdImg/<%#Eval("item_img") %>' class="card-img-top" alt="...">
					<div class="card-body">
						<h6 class="card-title"><%#Eval("item_Name") %></h6>
						<asp:Label ID="lb_id" Visible="false" runat="server" Text='<%#Eval("item_id")%>'></asp:Label>

						<p class="card-text"><%#Eval("item_Price") %></p>
						<div class="">
							<asp:Button ID="Button1" runat="server" CssClass="btn btn-warning " OnClick="Button1_Click" Text="Add to cart" />
							<asp:Button ID="Button2" runat="server" CssClass="btn btn-success" OnClick="Button2_Click" Text="View" />
						</div>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>

	</div>
	<%--				<div class=" container-fluid row justify-content-center  ">
				<div class="card m-1 " style="width: 18rem;">
					<img src="..." class="card-img-top" alt="...">
					<div class="card-body">
						<h5 class="card-title">Card title</h5>
						<p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
						<a href="#" class="btn btn-primary">Go somewhere</a>
					</div>
				</div>
				<div class="card m-1 " style="width: 18rem;">
					<img src="..." class="card-img-top" alt="...">
					<div class="card-body">
						<h5 class="card-title">Card title</h5>
						<p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
						<a href="#" class="btn btn-primary">Go somewhere</a>
					</div>
				</div>
			</div>--%>
</asp:Content>
