using E_commProjectWithMasterPage.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace E_commProjectWithMasterPage.Admin
{
    public partial class ViewOrder : System.Web.UI.Page
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

                        showData();
                    }
                }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }

        }
        void showData()
        {
            query = "select b.item_img,b.item_Name,a.payMoney,a.buyQty,a.DateTime from userBankDetails as a inner join item as b on a.itemId=b.item_id where item_SallerId=" + userID.ToString().Trim() + "";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}