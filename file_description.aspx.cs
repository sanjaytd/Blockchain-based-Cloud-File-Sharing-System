using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class file_description : System.Web.UI.Page
{
    string val = "", id = "";
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (Request.QueryString["status"] == "view")
            {
                
                 try
                {
                    string val = Request.QueryString["pid"];
                    SqlDataAdapter da = new SqlDataAdapter("SELECT fid,filename,path,type,upload_date,description  from files where fid='" + val.Trim() + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextBoxname.Text = ds.Tables[0].Rows[0][1].ToString();
                       TextBox2.Text = ds.Tables[0].Rows[0][2].ToString();
                        TextBox1.Text = ds.Tables[0].Rows[0][3].ToString();
                        TextBox3.Text= ds.Tables[0].Rows[0][4].ToString();

                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("Logout.aspx");
                }

            }
          
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sharedfiles.aspx");
    }
}