using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Channels;

namespace E_commProjectWithMasterPage.User
{
    public partial class userCart : System.Web.UI.Page
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

                    showData();
                }
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn=(Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            Label id = (Label)item.FindControl("Label1");
            query = "delete cart where cart_id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id",id.Text.Trim());
            if(conn.State==ConnectionState.Closed) { conn.Open(); }
            cmd.ExecuteNonQuery();
            Response.AddHeader("refresh", "0");
            if(conn.State==ConnectionState.Open) { conn.Close(); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            Label id = (Label)item.FindControl("LbitemCartId");

            Response.Redirect("viewProductsUser.aspx?user=" + userID.ToString() + "&prod=" + id.Text.Trim() + "");
        }

        protected void lb_qty_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            TextBox qty = (TextBox)item.FindControl("TextBox1");
            Label id = (Label)item.FindControl("Label1");
            query = "update cart set cartQty=@cartQty where cart_id=@cart_id";
            SqlCommand cmd =new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cartQty",qty.Text.Trim());
            cmd.Parameters.AddWithValue("@cart_id",id.Text.Trim());
            if(conn.State==ConnectionState.Closed) { conn.Open();}
            int res=(int)cmd.ExecuteNonQuery();
            if (res == 1)
            {
                Response.Write("<script>alert('Data has been update')</script>");
                Response.AddHeader("refresh", "0");

            }
            else
            {
                Response.Write("<script>alert('somethig wrong')</script>");

            }
            if(conn.State==ConnectionState.Open) { conn.Close();}
        }
        
        void showData()
        {
            query = "select a.cart_id,a.itemCartID,a.userCartID,a.cartQty, b.item_Name,b.item_Price,b.item_img,b.item_Description  from cart as a inner join item as b on a.itemCartID=b.item_id where userCartID="+userID.ToString()+"";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        //void updateNumber()
        //{
        //    TextBox number = (TextBox)
        //}
    }
}