using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commProjectWithMasterPage.User
{
    public partial class ShowCategoryUser : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query, userData;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        static string userID;
        string itemid;
        static string prod;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["user"] != null)
            {
                userID = Request.QueryString["user"];
                prod = Request.QueryString["cat"];
                if (!IsPostBack)
                {

                    showData();
                }
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }


        }
        void showData()
        {
            query = "select * from item where item_CategoryId=" + prod.ToString() + "";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }


    }
}