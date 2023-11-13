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
    public partial class userLogin : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query;
        static string userID;
        static string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            query = "select * from userData where Email=@email and Passcode=@pass";
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
                userID = reader["userId"].ToString();
                username = reader["FirstName"].ToString();
                Session["userID"] = userID;
                Session["name"]= username;
                Response.Redirect("HomeUser.aspx?user=" + userID + "");
            }
            else
            {
                Response.Write("<script>alert('Something wrong')</script>");
            }

            if (conn.State == ConnectionState.Open) { conn.Close(); }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }
        }
    }
}