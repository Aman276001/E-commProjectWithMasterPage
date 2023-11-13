using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.CompilerServices;

namespace E_commProjectWithMasterPage.User
{
    public partial class HomeUser : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            Label id = (Label)item.FindControl("lb_id");

            string qr = "select itemCartID from cart where itemCartID=@itemcart and userCartID=@usercart";
            SqlDataAdapter adp = new SqlDataAdapter(qr, conn);
            adp.SelectCommand.Parameters.AddWithValue("@itemcart", id.Text);
            adp.SelectCommand.Parameters.AddWithValue("@usercart", userID.ToString());
            DataTable dt = new DataTable();
            int i = 0;
            i = adp.Fill(dt);
            if (i >= 1)
            {
                Response.Write("<script>alert('Data already in Cart')</script>");
                Response.AddHeader("refresh", "0");
            }
            else
            {
                query = "insert into cart (itemCartID,userCartID,cartQty,cartDatetime) values (@item,@user,@Qty,@datetime)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@item", id.Text);
                cmd.Parameters.AddWithValue("@user", userID.ToString());
                cmd.Parameters.AddWithValue("@Qty", 1);
                cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                cmd.ExecuteNonQuery();
                // Response.Write("<script>alert('Add to Cart')</script>");
                Response.AddHeader("refresh", "0");
                if (conn.State == ConnectionState.Open) { conn.Close(); }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            Label id = (Label)item.FindControl("lb_id");

            Response.Redirect("viewProductsUser.aspx?user="+userID.ToString()+"&prod="+id.Text.Trim()+"");

        }

        void ViewProductes()
        {
            query = " select * from item where item_Available_Quantity>0";
            adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

    }
}