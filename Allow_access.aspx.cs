using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Allow_access : System.Web.UI.Page
{
    string val = "", id = "";
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            string qs1 = "Select name from users where uid !='"+Request.QueryString["uid"]+"'";
            SqlDataAdapter sda = new SqlDataAdapter(qs1, con);
            DataSet dset1 = new DataSet();
            sda.Fill(dset1);
            int cn1 = dset1.Tables[0].Rows.Count;
            if (cn1 > 0)
            {
                for (int i = 0; i < cn1; i++)
                {
                    string departs = dset1.Tables[0].Rows[i][0].ToString();
                    DropDownList1.Items.Add(departs);
                }
            }


            try
            {
                string val = Request.QueryString["fid"];
                SqlDataAdapter da = new SqlDataAdapter("SELECT fid,path  from files where fid='" + val.Trim() + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //TextBoxname.Text = ds.Tables[0].Rows[0][1].ToString();
                    TextBox2.Text = ds.Tables[0].Rows[0][1].ToString();

                }
            }
            catch (Exception ex)
                {
                    Response.Redirect("Logout.aspx");
                }

            

        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("View_Files.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string uid = "";
        string qs1 = "Select uid from users where name='" + DropDownList1.SelectedValue + "'";
        SqlDataAdapter sda = new SqlDataAdapter(qs1, con);
        DataSet dset1 = new DataSet();
        sda.Fill(dset1);
        int cn1 = dset1.Tables[0].Rows.Count;
        if (cn1 > 0)
        {
            uid = dset1.Tables[0].Rows[0][0].ToString();

        }
        string qs2 = "Select uid,fid from access_control  where cast(uid as int) in (select uid from users where name='" + DropDownList1.SelectedValue + "' ) and fid='" + Request.QueryString["fid"] + "'";
        SqlDataAdapter sda2 = new SqlDataAdapter(qs2, con);
        DataSet dset2 = new DataSet();
        sda2.Fill(dset2);
        if (dset2.Tables[0].Rows.Count > 0)
        {

            string s = "update   access_control set fileaccess='Yes' where uid='" + uid + "' and fid='" + Request.QueryString["fid"] + "'";
            con.Open();
            cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Access Granted')", true);
        }
        else
        {
            string s = "insert into access_control(fid,uid,fileaccess,owner,viewstatus) values('" + Request.QueryString["fid"] + "','" + uid + "','Yes','No','unseen')";
            con.Open();
            cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Access Granted')", true);
        }

    }
}