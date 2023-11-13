using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commProjectWithMasterPage.Admin
{
    public partial class ViewReportAdmin : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query, userData;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        static string userID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["userID"] != null)
            {
                if (!IsPostBack)
                {
                    if (Session["userId"] != null)
                    {
                        userID = Session["userId"].ToString();
                        ddShow();
                    }
                }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            query = " select * from item where item_CategoryId="+DropDownList1.SelectedValue.ToString().Trim()+"";
            adp = new SqlDataAdapter(query,conn);
            DataSet ds = new DataSet(); 
            adp.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        void ddShow()
        {
            query = " select * from Category";
            adp = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataValueField = "cat_id";
            DropDownList1.DataTextField = "cat_Name";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Item", "0"));
        }
    }
}