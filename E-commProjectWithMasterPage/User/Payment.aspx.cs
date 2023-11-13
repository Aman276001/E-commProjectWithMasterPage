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
    public partial class Payment : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query, userData;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        static string userID;
        string qty;
        string itemid,tprice;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"] != null)
            {
                userID = Request.QueryString["user"];
                itemid = Request.QueryString["itemid"];
                tprice = Request.QueryString["totalP"];
                qty = Request.QueryString["Qty"];
                if (!IsPostBack)
                {
                    bankName();
                    LabelP.Text= "&#x20B9;"+tprice.ToString();
                }
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            query = "insert into userBankDetails (BankName,Branch,cardName,cardNumber,cvvNumber,userbankID,itemId,buyQty,payMoney) values (@bName,@branch,@cardName,@cardNo,@cvv,@userid,@itemID,@buyQty,@payMoney)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@bName",DropDownList3.SelectedItem.Text.Trim());
            cmd.Parameters.AddWithValue("@branch", txtbranch.Text.Trim());
            cmd.Parameters.AddWithValue("@cardName", DropDownList2.SelectedItem.Text.Trim());
            cmd.Parameters.AddWithValue("@cardNo", txtcard.Text.Trim());
            cmd.Parameters.AddWithValue("@cvv", txtcvv.Text.Trim());
            cmd.Parameters.AddWithValue("@userid", userID.ToString());
            cmd.Parameters.AddWithValue("@itemID", itemid.ToString());
            cmd.Parameters.AddWithValue("@buyQty", qty.ToString());
            cmd.Parameters.AddWithValue("@payMoney", tprice.ToString());
            if(conn.State==ConnectionState.Closed) { conn.Open(); }
            int res = (int)cmd.ExecuteNonQuery();
            if (res == 1)
            {
                query = " update item set item_Sell_Quantity="+qty.ToString()+" , item_Available_Quantity-="+qty.ToString()+" where item_id="+itemid.ToString()+"";
               SqlCommand cmd1 = new SqlCommand(query,conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();
                Response.Redirect("Thanks.aspx");

            }
            else
            {
                Response.Write("<script>alert('Something wrong')</script>");

            }
            if (conn.State==ConnectionState.Open) { conn.Close(); }
        }

        void bankName()
        {
            query = "select * from BankName";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataValueField = "id";
            DropDownList3.DataTextField = "BankName";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Bank Name", "0"));
        }
    }
}