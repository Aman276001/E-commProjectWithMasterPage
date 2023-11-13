using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commProjectWithMasterPage
{
    public partial class EComm : System.Web.UI.MasterPage
    {
        static string userID;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null || Session["userId"] != null)
            {
                lbCat.Visible = true;
                lbItem.Visible = true;
                lbQuntity.Visible = true;
                lbOrder.Visible = true;
                lbPayment.Visible = true;
                lbReport.Visible = true;
                lbFeedback.Visible = true;
                lbChangePass.Visible = true;
                lbLogOut.Visible = true;
                navbarDarkDropdownMenuLink.Visible = false;
                userID = Session["userId"].ToString();
            }
        }

        protected void lbCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategoryAdmin.aspx?userid="+userID+"");
        }

        protected void lbItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItemAdmin.aspx?userid="+userID+"");

        }

        protected void lbQuntity_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddQuantityAdmin.aspx?userid=" + userID + "");

        }

        protected void lbReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewReportAdmin.aspx?userid=" + userID + "");

        }

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");

        }

        protected void lbChangePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassAdmin.aspx?userid=" + userID + "");

        }

        protected void lbOrder_Click(object sender, EventArgs e)
        {

            Response.Redirect("ViewOrder.aspx?userid=" + userID + "");

        }
    }
}