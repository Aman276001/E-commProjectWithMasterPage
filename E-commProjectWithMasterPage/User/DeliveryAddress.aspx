<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="DeliveryAddress.aspx.cs" Inherits="E_commProjectWithMasterPage.User.DeliveryAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class=" container mt-5">
		<div class="row">
			<div class="col-9 w-75 ">

				<asp:Repeater runat="server" ID="rep1">
					<ItemTemplate>
						<div class="card mb-2">
							<div class="card-header text-bg-gary">
								Delivary Address
							</div>
							<div class="card-body">
								<div class="pb-3">
									<asp:Label ID="Label1" runat="server" CssClass="h5" Text='<%#Eval("Name")%>'></asp:Label>

									<asp:Label ID="LinkButton1" runat="server" CssClass=" px-2 rounded text-white bg-secondary" Text='<%#Eval("AddressType") %>'></asp:Label>
									<asp:Label ID="lbshowPhone" runat="server" CssClass="fw-bolder" Text='<%#Eval("Mobile")%>'></asp:Label>
								</div>
								<div class=" text-uppercase pb-3">
									<asp:Label ID="lblocality" runat="server" CssClass=" " Text='<%#Eval("Locality") %>'></asp:Label> ,
									<asp:Label ID="lbaddress" runat="server" CssClass=" " Text='<%#Eval("Address") %>'></asp:Label> ,
									<asp:Label ID="lbstate" runat="server" CssClass=" " Text='<%#Eval("state") %>'></asp:Label>
									-<asp:Label ID="lbpin" runat="server" CssClass=" fw-bold " Text='<%#Eval("pincode") %>'></asp:Label>
					
								</div>					  
								<asp:Button ID="Button1" runat="server" CssClass="btn btn-danger rounded-1 pt-2 pb-2"  OnClick="Button1_Click" Text="DELIVER HERE" />
							</div>
						</div>
					</ItemTemplate>
				</asp:Repeater>


				<div class="card mt-2 mb-5" style="background-color: #eaf6f6;">
					<div class="card-header text-bg-gary">
						Add New Address
					</div>

					<div class="row card-body">
						<div class="form-group col-md-6">
							<label for="txtName" class="form-label">Name</label>
							<asp:TextBox ID="txtName" runat="server" CssClass="form-control pt-3 pb-3" placeholder="Name"></asp:TextBox>
						</div>
						<div class="form-group col-md-6 pt-0">
							<label for="txtMobile" class="form-label">Mobile</label>
							<asp:TextBox ID="txtMobile" runat="server" CssClass="form-control pt-3 pb-3	" placeholder="10-digit mobile number"></asp:TextBox>
						</div>
					</div>
					<div class="row card-body">

						<div class="form-group col-md-6 pt-0">
							<label for="txtPincode" class="form-label">Pincode</label>
							<asp:TextBox ID="txtPincode" runat="server" CssClass="form-control pt-3 pb-3" placeholder="Pincode"></asp:TextBox>
						</div>
						<div class="form-group col-md-6 pt-0">
							<label for="txtlandmark" class="form-label">Landmark</label>
							<asp:TextBox ID="txtlandmark" runat="server" CssClass="form-control pt-3 pb-3" placeholder="Landmark(Optionl)"></asp:TextBox>

						</div>
					</div>
					<div class="form-group card-body pt-0">
						<label for="txtAddress" class="form-label">Address</label>
						<asp:TextBox ID="txtAddress" runat="server" CssClass="form-control pt-3 pb-3" TextMode="MultiLine" Rows="5" placeholder="Address(Area and Street)"></asp:TextBox>
					</div>
					<div class="row card-body pt-0">
						<div class="form-group col-md-6 ">
							<label for="txtCity" class="form-label">Pincode</label>
							<asp:TextBox ID="txtCity" runat="server" CssClass="form-control pt-3 pb-3" placeholder="City"></asp:TextBox>

						</div>
						<div class="form-group col-md-6">
							<label for="DropDownList1">State</label>
							<asp:DropDownList ID="DropDownList1" CssClass="form-control pt-3 pb-3 mt-2" runat="server"></asp:DropDownList>

						</div>

					</div>
					<div class="row card-body pt-0">
						<div class="form-group col-md-6 ">
							<label for="DropDownList2" class="form-label">AddressType</label>
							<asp:DropDownList ID="DropDownList2" CssClass="form-control pt-3 pb-3" runat="server">
								<asp:ListItem>Choose Address Type</asp:ListItem>
								<asp:ListItem>HOME</asp:ListItem>
								<asp:ListItem>WORK</asp:ListItem>
							</asp:DropDownList>

						</div>
						<div class="form-group col-md-6 ">
							<label for="txtAlterPhone" class="form-label">Alternate Phone</label>
							<asp:TextBox ID="txtAlterPhone" runat="server" CssClass="form-control pt-3 pb-3" placeholder="Alternate Phone"></asp:TextBox>

						</div>


					</div>
					<asp:Button ID="Button2" class="btn btn-primary w-50 m-3" OnClick="Button2_Click" runat="server" Text="Sign in" />
				</div>
			</div>

			<div class="col-3">
				<div class="card px-3 pb-3" style="width: 20rem;">
					<div class="card-body">
						<h5 class="card-title">PRICE DETAILS</h5>
					</div>
					<div class="row">

						<div class="col-8">
							<h6>Price item</h6>
							<asp:Label ID="lbPrice" CssClass="pb-3" runat="server"></asp:Label><br />
							<br />
							<h6>Item Quntity</h6>

							<asp:TextBox ID="TextBox1" TextMode="Number" Width="45" CssClass="pb-3 border-0" runat="server"></asp:TextBox>
							<asp:LinkButton Text="Change" ID="lb_qty" OnClick="lb_qty_Click" runat="server" />

							<br />
							<h6>Delivery Charges</h6>

							<asp:Label ID="lb_deliveryCharges" runat="server" Text="Label"></asp:Label>
							<hr />
							<asp:Label ID="lbTotalPrice" CssClass="text-danger h2" runat="server" Text="Label"></asp:Label>
						</div>
					</div>

				</div>
			</div>
		</div>
	</div>


</asp:Content>
