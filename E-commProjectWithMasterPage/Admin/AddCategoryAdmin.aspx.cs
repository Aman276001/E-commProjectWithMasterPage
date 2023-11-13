using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace E_commProjectWithMasterPage.Admin
{
    public partial class AddCategoryAdmin : System.Web.UI.Page
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

                        showList();

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
            query = " insert into Category(cat_Name,salllerCatId) values (@name,@sid)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@sid", userID.ToString().Trim());

            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            int res = (int)cmd.ExecuteNonQuery();
            if (res == 1)
            {

                Response.Write("<script>alert('Data has been saved...')</script>");
                Response.AddHeader("refresh", "1");
            }
            else
            {

                Response.Write("<script>alert('Something wrong')</script>");
            }
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal(Good job!, You clicked the button!,success)",true);


            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label id = GridView1.Rows[e.RowIndex].FindControl("lb_itemID") as Label;

            conn.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("Delete Category  where cat_id=" + id.Text.Trim() + "", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            showList();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = GridView1.Rows[e.RowIndex].FindControl("lb_editID") as Label;

            TextBox name = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            conn.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("Update Category set cat_Name='" + name.Text + "' where cat_id="+id.Text.Trim()+"", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            showList();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            showList();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            showList();
        }

        void showList()
        {
            query = "select * from Category";
            adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }
}