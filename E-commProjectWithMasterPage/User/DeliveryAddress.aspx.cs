using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace E_commProjectWithMasterPage.User
{
    public partial class DeliveryAddress : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query, userData;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        static string userID,tprice;
        string itemid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"] != null)
            {
                userID = Request.QueryString["user"];
                itemid = Request.QueryString["prod"];
                if (!IsPostBack)
                {

                    state();
                    showAddress();
                    showProd();
                    showTotalPrice();
                    showQty();

                }
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }

        }
        void showAddress()
        {
            query = "select * from userDeliveryAddress where DeliveryUserId="+userID.Trim()+"";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            rep1.DataSource = dt;
            rep1.DataBind();
        }
        void state()
        {
            query = " select * from IndiaState";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataValueField = "stateId";
            DropDownList1.DataTextField = "StateName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select State", "0"));
        }
        void showProd()
        {
            query = "select * from item where item_id="+itemid+"";
            SqlCommand cmd = new SqlCommand (query, conn);
            conn.Open ();
            SqlDataReader dr = cmd.ExecuteReader ();
            if(dr.Read ())
            {
                lbPrice.Text = dr["item_Price"].ToString();
                lb_deliveryCharges.Text = dr["item_DeliveryCharges"].ToString();
            }
            conn.Close ();
            showQty();

        }
        void showTotalPrice()
        {
            //query = "select * from item where item_id="+itemid+"";
            query = " select (item_Price*item_ChooseProdQty)+item_DeliveryCharges as totalPrice from item where item_id=" + itemid+"";
            SqlCommand cmd = new SqlCommand (query, conn);
            conn.Open ();
            SqlDataReader dr = cmd.ExecuteReader ();
            if(dr.Read ())
            {
                lbTotalPrice.Text = "&#x20B9;" + dr["totalPrice"].ToString();
                tprice = dr["totalPrice"].ToString();
            }
            conn.Close ();

        }

        protected void lb_qty_Click(object sender, EventArgs e)
        {
            query = "update item set item_ChooseProdQty=@itemQty where item_id=@item_id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@itemQty", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@item_id", itemid.Trim());
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            int res = (int)cmd.ExecuteNonQuery();
            if (res == 1)
            {
                Response.Write("<script>alert('Data has been update')</script>");
                Response.AddHeader("refresh", "0");

            }
            else
            {
                Response.Write("<script>alert('somethig wrong')</script>");

            }
            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            query = "insert into userDeliveryAddress (Name,Mobile,Pincode,Locality,Address,Landmark,AlternatePhone,AddressType,DeliveryUserId,State) values\r\n(@name,@mobile,@pin,@locality,@address,@landmark,@alternetePhone,@addType,@deliveryuserID,@state)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name",txtName.Text.Trim());   
            cmd.Parameters.AddWithValue("@mobile",txtMobile.Text.Trim());   
            cmd.Parameters.AddWithValue("@pin",txtPincode.Text.Trim());   
            cmd.Parameters.AddWithValue("@locality",txtlandmark.Text.Trim());   
            cmd.Parameters.AddWithValue("@address",txtAddress.Text.Trim());   
            cmd.Parameters.AddWithValue("@landmark",txtlandmark.Text.Trim());   
            cmd.Parameters.AddWithValue("@alternetePhone", txtAlterPhone.Text.Trim());   
            cmd.Parameters.AddWithValue("@addType",DropDownList2.SelectedItem.Text.Trim());   
            cmd.Parameters.AddWithValue("@deliveryuserID", userID.Trim());      
            cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Text.Trim());
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            int res = (int)cmd.ExecuteNonQuery();
            if (res == 1)
            {
                Response.Write("<script>alert('Data has been update')</script>");
                Response.AddHeader("refresh", "0");

            }
            else
            {
                Response.Write("<script>alert('somethig wrong')</script>");

            }
            if (conn.State == ConnectionState.Open) { conn.Close(); }
        

    }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx?user="+userID.ToString()+"&Qty=" + TextBox1.Text.ToString()+"&itemid="+itemid.ToString()+"&totalP="+ tprice.ToString()+ "");

        }

        void showQty()
        {
            query = "select * from item where item_id=" + itemid + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr["item_ChooseProdQty"].ToString();
            }
            conn.Close();
        }
    }
}