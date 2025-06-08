using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rejected : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0ES5ISQ\SQLEXPRESS;Initial Catalog=CrowdFunding;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                using (SqlCommand cmd1 = new SqlCommand("select pid,title,description,companyname,com_contact,category  from projects inner join  [user ] on [user].uid=projects.uid  where status='Rejected'"))

                {

                    cmd1.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                    {
                        DataTable dt1 = new DataTable();
                        da.Fill(dt1);
                        if (dt1.Rows.Count > 0 && dt1 != null)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();

                        }
                        else
                        {
                        }

                        con.Close();
                    }
                }


            }
        }
        catch
        {

        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from projects where pid='" + Cid + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Product Deleted Successfully !')", true);
        Response.Redirect("MyProjects.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;


        Response.Redirect("~/view_project.aspx?pid=" + Cid.Trim() + "&type=edit");
    }

    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddProject.aspx");
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;


        Response.Redirect("~/view_project.aspx?pid=" + Cid.Trim() + "&type=view");
    }



    protected void Button3_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        string str = "update [projects]  set status='Approved' where pid" + "='" + Cid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Project Approved !')", true);
    }
    protected void Button1_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("projectlist.aspx");
    }
}