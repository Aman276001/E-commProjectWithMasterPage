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
    public partial class ChangePassAdmin : System.Web.UI.Page
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
            query = "update saller set Passcode=@pass where Saller_id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@pass",TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@id",userID);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            int res = (int)cmd.ExecuteNonQuery();
            if (res == 1)
            {

                Response.Write("<script>alert('Password Change Successfully...')</script>");
            }
            else
            {

                Response.Write("<script>alert('Something wrong')</script>");
            }
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal(Good job!, You clicked the button!,success)",true);


            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }
    }
}
