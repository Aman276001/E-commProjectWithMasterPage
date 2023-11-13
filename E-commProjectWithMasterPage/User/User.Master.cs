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
    public partial class User : System.Web.UI.MasterPage
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query, userData;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        static string userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"] != null)
            {
                userID = Request.QueryString["user"];
                if (!IsPostBack)
                {
                    if (Session["userID"] != null)
                    {

                        lbFeedback.Visible = true;
                        lbChangePass.Visible = true;
                        lbLogOut.Visible = true;
                        navbarDarkDropdownMenuLink.Visible = false;
                        navbarDarkDropdownMenuLink1.Visible = true;
                        Panel1.Visible = true;
                        LinkButton1.Visible = true;
                        navbarDarkDropdownMenuLink1.Text = Session["name"].ToString();
                        showList();
                        showCartNumber();
                    }
                }
            }


        }

        protected void lb_newAcc_Click(object sender, EventArgs e)
        {
            Response.Redirect("userRegister.aspx");
        }

        protected void lb_logIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userCart.aspx?user="+userID.ToString().Trim()+"");

        }

        void showList()
        {
            query = "select * from Category";
            adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            Label id = (Label)item.FindControl("Label1");
            Response.Redirect("ShowCategoryUser.aspx?user="+userID.ToString().Trim()+"&cat=" + id.Text.Trim() + "");

        }

        protected void lbFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeUser.aspx?user=" + userID + "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            query = " select * from item where item_name like '"+TextBox1.Text+"%'";
        }

        protected void lbChangePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyOrder.aspx?user=" + userID.ToString().Trim() + "");

        }

        void showCartNumber()
        {
          //  query = "select * from cart where userCartID="+userID.ToString()+"";
            query = "select COUNT(userCartID) as total from cart where userCartID="+userID.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lb_cartNumber.Text = reader["total"].ToString();
            }
            conn.Close();

        }

    }
}