using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commProjectWithMasterPage.User
{
    public partial class viewProductsUser : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query, userData;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        static string userID;
        string itemid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"] != null)
            {
                userID = Request.QueryString["user"];
                itemid = Request.QueryString["prod"];
                if (!IsPostBack)
                {

                    ViewProductes();
                }
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeliveryAddress.aspx?user="+userID+"&prod="+itemid+"");

        }

        void ViewProductes()
        {
            query = " select * from item where item_id="+itemid+"";
            adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}