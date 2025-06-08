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

public partial class Sharedfiles : System.Web.UI.Page
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
        string com = "select top 1 lid From logs ORDER BY lid Desc;";
        con.Open();
        cmd = new SqlCommand(com, con);
        object count = cmd.ExecuteScalar();
        if (count != null)
        {
            int i = Convert.ToInt32(count);
            i++;
            HiddenField1.Value = i.ToString();

        }
        else
        {
            HiddenField1.Value = "1";

        }
        gridview();
        con.Close();
        if (!IsPostBack)
        {
            string q = "select *,filename from access_control a inner join files f on f.fid=a.fid where viewstatus='unseen' and uid='"+ Session["uid"].ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
          if (ds.Tables[0].Rows.Count > 0)
        {
               string fname= ds.Tables[0].Rows[0][6].ToString();
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('New File Shared : "+fname +"')", true);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update access_control set viewstatus='seen' where uid='" + Session["uid"].ToString() + "' ", con);
                cmd1.ExecuteNonQuery();
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
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Product Deleted Successfully !')", true);
        Response.Redirect("Manage_Products.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;


        Response.Redirect("~/register.aspx?pid=" + Cid.Trim() + "&status=edit");
    }

    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {

    }


    protected void DownloadFile(object sender, EventArgs e)
    {
        con.Close();
        string fileName = (sender as Button).CommandArgument;
        string s = "insert into logs(lid,title,date,time,uid,fileacess) values('" + HiddenField1.Value + "','  Downloaded the File','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + Session["uid"].ToString() + "','" + fileName + "')";
        con.Open();
        cmd = new SqlCommand(s, con);
        cmd.ExecuteNonQuery();
        con.Close();
        //FTP Server URL.
        string ftp = "ftp://Cloudstorage.hostoise.com/Webstorage/";

        //FTP Folder name. Leave blank if you want to Download file from root folder.
        string ftpFolder = "Files/";

        try
        {
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            request.Credentials = new NetworkCredential("Cloudstorage", "f@633dr4A");
            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (MemoryStream stream = new MemoryStream())
            {
                //Download the File.
                response.GetResponseStream().CopyTo(stream);
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }

        }
        catch (WebException ex)
        {
            string s1 = "insert into logs(lid,title,date,time,uid,fileacess) values('" + HiddenField1.Value + "',' Files  Deleted or Download Error','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + Session["uid"].ToString() + "','" + fileName + "')";
            con.Open();
            cmd = new SqlCommand(s1, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("View_Files.aspx?filestat=error");
            //throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
        }
    }
    protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("add_file.aspx");
    }

   
    protected void lnkDownload1_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;

        string[] Cid = b.CommandArgument.Split(',');
        string s = "insert into logs(lid,title,date,time,uid,fileacess) values('" + HiddenField1.Value + "','  Viewed the File','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + Session["uid"].ToString() + "','" + Cid[1] + "')";
        con.Open();
        cmd = new SqlCommand(s, con);
        cmd.ExecuteNonQuery();
        con.Close();

        Response.Redirect("~/file_description.aspx?pid=" + Cid[0].Trim() + "&status=view");
    }
    protected void gridview()
    {

        string q = "select files.fid,filename,type,size,content,prehash,path from files inner join access_control a on a.fid=files.fid  inner join users on a.uid=users.uid  where  a.uid !='" + Session["uid"] + "' and  fileaccess='Yes' and a.owner='No'";
        SqlDataAdapter da = new SqlDataAdapter(q, con);
        DataTable dt2 = new DataTable();
        da.Fill(dt2);

        if (dt2.Rows.Count > 0)
        {
            
            GridView2.DataSource = dt2;
            GridView2.DataBind();

            GridView2.Visible = true;

        }
        else
        {


            GridView2.Visible = false;
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            string q = "select files.fid,filename,type,size,content,prehash,path from files inner join access_control a on a.fid=files.fid  inner join users on a.uid=users.uid  where  files.owner_uid !='" + Session["uid"] + "' and  fileaccess='Yes' and a.owner='No'";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {

                GridView2.DataSource = dt2;
                GridView2.DataBind();

                GridView2.Visible = true;

            }
            else
            {


                GridView2.Visible = false;
            }
        }
        else
        {
                string q = "select files.fid,filename,type,size,content,prehash,path from files inner join access_control a on a.fid=files.fid  inner join users on a.uid=users.uid  where  files.owner_uid !='" + Session["uid"] + "' and  fileaccess='Yes' and a.owner='No'  and (path='" + TextBox1.Text + "' or type='" + TextBox1.Text + "' )";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {

                GridView2.DataSource = dt2;
                GridView2.DataBind();

                GridView2.Visible = true;

            }
            else
            {


                GridView2.Visible = false;
            }

        }
    }
}