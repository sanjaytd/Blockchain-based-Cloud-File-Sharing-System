using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    string val = "",id="";
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!IsPostBack)
        {
            if(  Request.QueryString["status"]=="edit")
            {
                Button2.Visible = true;
                Label6.Text = " Edit User Details";
                Button1.Visible = true;
                Button1.Text = "Update";
                TextBoxpass.Visible = false;
                Label7.Visible = false;
                try
                {
                    string val = Request.QueryString["pid"];
                    SqlDataAdapter da = new SqlDataAdapter("SELECT name,address,emailid,contact,uid  from users where uid='" +val.Trim()+ "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       
                            TextBoxname.Text = ds.Tables[0].Rows[0][0].ToString();
                            TextBoxemail.Text = ds.Tables[0].Rows[0][2].ToString();
                            TextBoxadd.Text = ds.Tables[0].Rows[0][1].ToString();
                            TextBoxcno.Text = ds.Tables[0].Rows[0][3].ToString();
                        TextBoxid.Text= ds.Tables[0].Rows[0][4].ToString();
                        TextBoxid.Enabled = false;

                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("Logout.aspx");
                }

            }
            else if ( Request.QueryString["status"] == "view")
            {
                Button2.Visible = true;
                Label6.Text = " User Details";
                Button1.Visible = false;
                TextBoxpass.Visible = false;
                Label7.Visible = false;
                try
                {
                    string val = Request.QueryString["pid"];
                    SqlDataAdapter da = new SqlDataAdapter("SELECT name,address,emailid,contact,uid  from users where uid='" + val.Trim() + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (!IsPostBack)
                        {
                            TextBoxname.Text = ds.Tables[0].Rows[0][0].ToString();
                            TextBoxemail.Text = ds.Tables[0].Rows[0][2].ToString();
                            TextBoxadd.Text = ds.Tables[0].Rows[0][1].ToString();
                            TextBoxcno.Text = ds.Tables[0].Rows[0][3].ToString();
                            TextBoxid.Text = ds.Tables[0].Rows[0][4].ToString();
                            TextBoxid.Enabled = false;
                            TextBoxemail.Enabled = false;
                            TextBoxcno.Enabled = false;
                            TextBoxadd.Enabled = false;
                            TextBoxname.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("Logout.aspx");
                }
            }
            else
            {
                Button2.Visible = false;
                string com = "select top 1 uid From users ORDER BY uid Desc;";
                con.Open();
                cmd = new SqlCommand(com, con);
                object count = cmd.ExecuteScalar();
                if (count != null)
                {
                    int i = Convert.ToInt32(count);
                    i++;
                    TextBoxid.Text = i.ToString();
                    TextBoxid.Enabled = false;

                }
                else
                {
                    TextBoxid.Text = "1";
                    TextBoxid.Enabled = false;
                }

            }
        }
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Button1.Text== "Add User")
        {
            if (TextBoxid.Text != "" && TextBoxname.Text != "" && TextBoxemail.Text != "" && TextBoxcno.Text != "" && TextBoxadd.Text != "")
            {

                //SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=d846nnA^");
                SqlCommand cmd;
                string pass = TextBoxpass.Text;
                string s = "insert into users(uid,name,emailid,contact,address,pass) values('" + TextBoxid.Text + "','" + TextBoxname.Text + "','" + TextBoxemail.Text + "','" + TextBoxcno.Text + "','" + TextBoxadd.Text + "','" + TextBoxpass.Text + "')";
                con.Open();
                cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
                con.Close();
                TextBoxid.Text = "";
                TextBoxname.Text = "";
                TextBoxemail.Text = "";
                TextBoxcno.Text = "";
                TextBoxadd.Text = "";
                TextBoxpass.Text = "";

                Response.Redirect("user_login.aspx?status=success");
                //}
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Kindly Fill in Details')", true);
            }
        }
        else if (Button1.Text == "Update")
        {
            if (TextBoxid.Text != "" && TextBoxname.Text != "" && TextBoxemail.Text != "" && TextBoxcno.Text != "" && TextBoxadd.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update users set name='" + TextBoxname.Text + "',address='" + TextBoxadd.Text + "',emailid='" + TextBoxemail.Text + "',contact='" + TextBoxcno.Text + "' where uid='" + Request.QueryString["pid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Profile Changed Successfully')", true);
                Response.Redirect("manage_users.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Kindly Fill in Details')", true);
            }
        }
       
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage_users.aspx");
    }
}