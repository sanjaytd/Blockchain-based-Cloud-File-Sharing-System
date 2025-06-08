using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_users : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlCommand cmd1 = new SqlCommand("select uid,name,address,contact,emailid from users "))

        {

            cmd1.Connection = con;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
            {
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                if (dt1.Rows.Count > 0 && dt1 != null)
                {

                    GridView2.DataSource = dt1;
                    GridView2.DataBind();
                }

                con.Close();
            }
        }
    }



    protected void btnregister_Click(object sender, EventArgs e)
    {

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            ImageButton b = (ImageButton)sender;

            string Cid = b.CommandArgument;
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from product where pid='" + Cid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Product Deleted Successfully !')", true);

        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from product where pid='" + Cid + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('User Deleted Successfully !')", true);
        using (SqlCommand cmd1 = new SqlCommand("select uid,name,address,contact,emailid from users "))

        {

            cmd1.Connection = con;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
            {
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                if (dt1.Rows.Count > 0 && dt1 != null)
                {

                    GridView2.DataSource = dt1;
                    GridView2.DataBind();
                }

                con.Close();
            }
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;


        Response.Redirect("~/register.aspx?pid=" + Cid.Trim() + "&status=edit");
    }

    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;


        Response.Redirect("~/register.aspx?pid=" + Cid.Trim() + "&status=view");
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from users where uid='" + Cid + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('User Deleted Successfully !')", true);
        Response.Redirect("Manage_users.aspx");
    }

    protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}