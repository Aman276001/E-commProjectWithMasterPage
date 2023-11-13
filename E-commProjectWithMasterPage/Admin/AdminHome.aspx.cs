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
    public partial class AdminHome : System.Web.UI.Page
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
                userData = Request.QueryString["user"].ToString();
                if (!IsPostBack)
                {
                    userinfo();
                   
                    
                }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }

            void userinfo()
            {
                query = "select * from saller where Email=@email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@email", userData);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Label1.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                    userID = reader["Saller_id"].ToString();
                    Session["userId"]=userID;
                }


                if (conn.State == ConnectionState.Open) { conn.Close(); }
            }
        }
    }
}