using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class myprofile : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    
    protected void Page_Load(object sender, EventArgs e)
    {       
        try
        {
            string val = Session["uid"].ToString();
            SqlDataAdapter da = new SqlDataAdapter("SELECT name,address,emailid,contact  from users where uid='" + val.Trim() + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!IsPostBack)
                {
                    TextBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                    TextBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                    TextBox4.Text = ds.Tables[0].Rows[0][2].ToString();
                    TextBox2.Text = ds.Tables[0].Rows[0][3].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Logout.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("update users set name='"+TextBox1.Text+"',address='"+TextBox3.Text+"',emailid='"+TextBox4.Text+"',contact='"+TextBox2.Text+"' where uid='"+Session["uid"]+"'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Profile Changed Successfully')", true);
        Response.Redirect("~/myprofile.aspx");
    }
}