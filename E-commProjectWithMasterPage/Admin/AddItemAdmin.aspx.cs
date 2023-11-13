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
    public partial class AddItemAdmin : System.Web.UI.Page
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

                        showCategory();
                        showlist();
                    }
                }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        void showlist()
        {
            query = " select * from item where item_SallerId=" + userID + "";
            adp = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            query = " insert into item (item_Name,item_Price,item_Totol_Quantity,item_Available_Quantity,item_Description,item_img,item_CategoryId,item_SallerId,item_Sell_Quantity,item_ChooseProdQty) values (@item_Name,@item_Price,@item_Totol_Quantity,@item_Available_Quantity,@item_Description,@item_img,@item_CategoryId,@item_SallerId,@itemSell,@item_ChooseProdQty)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@item_Name", txtItemname.Text.Trim());
            cmd.Parameters.AddWithValue("@item_Price", txtPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@item_Totol_Quantity", txtQuantity.Text.Trim());
            cmd.Parameters.AddWithValue("@item_Available_Quantity", txtQuantity.Text.Trim());
            cmd.Parameters.AddWithValue("@item_Description", txtDesc.Text.Trim());
            cmd.Parameters.AddWithValue("@item_CategoryId", Convert.ToInt16(ddCategory.Text.Trim()));
            cmd.Parameters.AddWithValue("@item_SallerId", userID.ToString());
            cmd.Parameters.AddWithValue("@itemSell",0);
            cmd.Parameters.AddWithValue("@item_ChooseProdQty", 1);
            string imgPath = Guid.NewGuid().ToString() + FileUpload1.FileName;
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "//Admin//ProdImg//" + imgPath.ToString());
            cmd.Parameters.AddWithValue("@item_img", imgPath.Trim());
            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            int res = (int)cmd.ExecuteNonQuery();
            if (res == 1)
            {

                Response.Write("<script>alert('Data has been Saved...')</script>");
                Response.AddHeader("refresh", "1");
            }
            else
            {

                Response.Write("<script>alert('Something wrong')</script>");
            }
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal(Good job!, You clicked the button!,success)",true);


            if (conn.State == ConnectionState.Open) { conn.Close(); }


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            showlist();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label id = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
      
            query = "Delete item where item_id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id.Text.ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Data has been Deleted...')</script>");
            conn.Close();
            GridView1.EditIndex = -1;
            showlist();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = (Label)GridView1.Rows[e.RowIndex].FindControl("Label2");
            TextBox name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
            TextBox price = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox Description = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");
            TextBox Quantity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4");
            FileUpload img = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload2");
            query = "update item set item_Name=@name,item_Price=@price,item_Description=@dis,item_Totol_Quantity=@qun,item_Available_Quantity=@qun,item_Sell_Quantity=0,item_img=@img where item_id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name.Text.ToString());
            cmd.Parameters.AddWithValue("@price", price.Text.ToString());
            cmd.Parameters.AddWithValue("@dis", Description.Text.ToString());
            cmd.Parameters.AddWithValue("@qun", Quantity.Text.ToString());
            cmd.Parameters.AddWithValue("@id", id.Text.ToString());

            string imgPath = Guid.NewGuid().ToString() + img.FileName;
            img.SaveAs(Request.PhysicalApplicationPath + "//Admin//ProdImg//" + imgPath.ToString());
            cmd.Parameters.AddWithValue("@img", imgPath);



            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            GridView1.EditIndex = -1;
            showlist();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            showlist();
        }

        void showCategory()
        {
            query = " select * from Category";
            adp = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ddCategory.DataSource = ds;
            ddCategory.DataValueField = "cat_id";
            ddCategory.DataTextField = "cat_Name";
            ddCategory.DataBind();
            ddCategory.Items.Insert(0, new ListItem("Select Category", "0"));

        }

    }
}