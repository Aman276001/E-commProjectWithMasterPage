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
    public partial class AddQuantityAdmin : System.Web.UI.Page
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
            query = " update item set item_Totol_Quantity=item_Totol_Quantity+@qun, item_Available_Quantity=item_Available_Quantity+@qun where item_id=" + DropDownList1.SelectedValue.ToString().Trim() + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@qun", txtQun.Text.ToString().Trim());

            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            int res = (int)cmd.ExecuteNonQuery();
            if (res == 1)
            {

                Response.Write("<script>alert('Data has been Saved...')</script>");
            }
            else
            {

                Response.Write("<script>alert('Something wrong')</script>");
            }
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal(Good job!, You clicked the button!,success)",true);


            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }

        void ddShow()
        {
            query = " select * from item";
            adp = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataValueField = "item_id";
            DropDownList1.DataTextField = "item_Name";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Item", "0"));
        }
    }
}