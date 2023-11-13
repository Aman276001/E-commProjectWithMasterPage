<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="E_commProjectWithMasterPage.User.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h1 class="text-center mt-2 text-bg-dark p-1">Payment Method</h1>
	<div class=" container">
		<div class=" mt-2 mb-5 w-50 mx-auto" style="background-color: #eaf6f6;">


			<div class="text-center mt-2 text-bg-warning">

			<asp:Label ID="LabelP" runat="server" CssClass="text-center mt-2 text-bg-warning" Text="Label"></asp:Label>
			</div>

			<div class="">
				<div class="form-group">
					<label for="DropDownList2" class="form-label">Select Paymet Type</label>
					<asp:DropDownList ID="DropDownList2" CssClass="form-control " required="" runat="server">
						<asp:ListItem>Choose Paymet Type</asp:ListItem>
						<asp:ListItem>CREDIT CARD</asp:ListItem>
						<asp:ListItem>DEBIT CARD</asp:ListItem>
					</asp:DropDownList>

				</div>
				<div class="form-group">
					<label for="DropDownList3" class="form-label">Bank Name</label>
					<asp:DropDownList ID="DropDownList3" CssClass="form-control " required="" runat="server">
					</asp:DropDownList>

				</div>

				<div class="form-group">
					<label for="txtbranch" class="form-label">Branch</label>
					<asp:TextBox ID="txtbranch" runat="server" CssClass="form-control " required="" placeholder="Branch"></asp:TextBox>



				</div>

				<div class="form-group ">
					<label for="txtcard" class="form-label">Card No.</label>
					<asp:TextBox ID="txtcard" runat="server" CssClass="form-control 	" required="" placeholder="16-digit card number"></asp:TextBox>
				</div>

				<div class="form-group  ">
					<label for="txtcvv" class="form-label">CVV</label>
					<asp:TextBox ID="txtcvv" runat="server" CssClass="form-control " required="" placeholder="3-digit CVV number"></asp:TextBox>
				</div>
			</div>


			<div class="text-center">

				<asp:Button ID="Button2" class="btn btn-primary mt-4 w-100" OnClick="Button2_Click" runat="server" Text="PAY NOW" />
			</div>
		</div>
	</div>

</asp:Content>
