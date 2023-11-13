<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ShowCategoryUser.aspx.cs" Inherits="E_commProjectWithMasterPage.User.ShowCategoryUser" %>
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

								<p class="card-text"><small class="text-body-secondary"><%#Eval("item_Description") %></small></p>
								<asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Details" />
							</div>
						</div>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</asp:Content>
