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
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            query = "select * from saller where Email=@email and Passcode=@pass";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtPass.Text.Trim());
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["user"] = txtemail.Text.ToString(); 
                Response.Redirect("AdminHome.aspx?user=" + txtemail.Text.Trim() + "");
            }
            else
            {
                Response.Write("<script>alert('Something wrong')</script>");
            }

            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }
    }
}