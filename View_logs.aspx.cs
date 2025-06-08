using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_logs : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    string s = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["filestat"] == "error")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Files are Either Deleted or Not Available on Server !')", true);

        }
        if (!IsPostBack)
        {
            TextBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            using (SqlCommand cmd1 = new SqlCommand("select top 10 lid,title,date,time,name,fileacess from logs inner join users on logs.uid=users.uid order by lid desc "))

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
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            using (SqlCommand cmd1 = new SqlCommand("select  lid,title,date,time,name,fileacess from logs inner join users on logs.uid=users.uid inner join files on files.path=logs.fileacess where (date between '" + TextBox2.Text + "' and '" + TextBox3.Text + "') order by lid desc "))

            {

                cmd1.Connection = con;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    DataTable dt1 = new DataTable();
                    da.Fill(dt1);
                    if (dt1.Rows.Count > 0 && dt1 != null)
                    {
                        GridView2.Visible = true;
                        GridView2.DataSource = dt1;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.Visible = false;
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('No Files Found Change Filters and try again!')", true);

                    }

                    con.Close();
                }
            }

        }
        else
        {
            using (SqlCommand cmd1 = new SqlCommand("select top 20  lid,title,date,time,name,fileacess from logs inner join users on logs.uid=users.uid inner join files on files.path=logs.fileacess where date between '" + TextBox2.Text + "' and '" + TextBox3.Text + "' and (filename='" + TextBox1.Text + "' or type='" + TextBox1.Text + "')order by lid desc "))

            {

                cmd1.Connection = con;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    DataTable dt1 = new DataTable();
                    da.Fill(dt1);
                    if (dt1.Rows.Count > 0 && dt1 != null)
                    {

                        GridView2.Visible = true;
                        GridView2.DataSource = dt1;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.Visible = false;
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('No Files Found Change Filters and try again!')", true);


                        con.Close();
                    }
                }
            }
        }

    }
}