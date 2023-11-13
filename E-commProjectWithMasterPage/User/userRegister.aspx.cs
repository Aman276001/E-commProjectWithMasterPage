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
    public partial class userRegister : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            query = " insert into userData (FirstName,LastName,Email,Phone,Gender,Passcode) values (@fname,@lname,@email,@Phone,@gen,@pass)\r\n";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@fname", txtfname.Text.Trim());
            cmd.Parameters.AddWithValue("@lname", txtlname.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtPass.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            cmd.Parameters.AddWithValue("@gen", DropDownList1.SelectedItem.Text.Trim());
            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            int res = (int)cmd.ExecuteNonQuery();
            if (res == 1)
            {

                Response.Redirect("userLogin.aspx");
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