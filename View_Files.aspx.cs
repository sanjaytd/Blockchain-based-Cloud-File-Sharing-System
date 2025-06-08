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

public partial class View_Files : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["stat"] == "ADD")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('File Added Successfully !')", true);

        }
        else if (Request.QueryString["stat"] == "ADD")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('File Updated Successfully !')", true);
        }
        else
        {

        }
        if (!IsPostBack)
        {

            gridview();

        }
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
    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
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
        Session["fid"] = Cid;

        Response.Redirect("~/add_file.aspx?pid=" + Cid.Trim() + "&status=edit");
    }

    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        Session["fid"] = Cid;

        Response.Redirect("~/add_file.aspx?pid=" + Cid.Trim() + "&status=view");
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from files where fid='" + Cid + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('File Deleted Successfully !')", true);
        gridview();
    }

    protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("add_file.aspx?uid="+Session["uid"]+"");
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;

        string Cid = b.CommandArgument;
        Response.Redirect("Allow_access.aspx?fid=" + Cid + "&uid=" + Session["uid"] + "");

    }


    protected void lnkrevoke_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;

        string Cid = b.CommandArgument;
        Response.Redirect("Revoke_access.aspx?fid=" + Cid + "&uid=" + Session["uid"] + "");
    }
    protected void gridview()
    {
        string q = ""; string mycontent = ""; long filelength = 0;
        if (TextBox1.Text == "")
        {
            q= "select fid,filename,type,size,content,prehash,path,description from files where owner_uid='" + Session["uid"] + "'";
        }
        else
        {
            q= "select fid,filename,type,size,content,prehash,path,description from files where owner_uid='" + Session["uid"] + "' and  (filename like '%" + TextBox1.Text + "%' or type like '%" + TextBox1.Text + "')order by fid desc ";
        }

       
        SqlDataAdapter da = new SqlDataAdapter(q, con);
        DataTable dt2 = new DataTable();
        da.Fill(dt2);

        if (dt2.Rows.Count > 0)
        {
            dt2.Columns.Add("isManupilated");
            string blockans = "";
            List<Blocklist> blocklist = getBlockList();
            for (int z = 0; z < blocklist.Count; z++)
            {
                Blocklist block1 = blocklist[z];
                DataRow row = dt2.Rows[z];
                WebClient request = new WebClient();
                string url = "ftp://Cloudstorage.hostoise.com/Webstorage/Files/" + block1.filename;
                request.Credentials = new NetworkCredential("Cloudstorage", "f@633dr4A");

                try
                {
                    byte[] newFileData = request.DownloadData(url);
                    string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                     filelength = newFileData.Length;
                     mycontent = Base64Encode(fileString);
                    
                }
                catch (WebException e)
                {
                    // Do something such as log error, but this is based on OP's original code
                    // so for now we do nothing.
                }
                Block blocks = new Block();
                if(block1.filename.EndsWith(".jpg")|| block1.filename.EndsWith(".png"))
                {
                    blocks.gethash1(block1.fid, block1.filename, Convert.ToString(filelength));
                }
                else
                {
                    blocks.gethash(block1.fid, block1.filename, Convert.ToString(filelength), mycontent, block1.previoushash);
                }
                
                string block1hash = blocks.getFinalBlock();

                if (block1hash == block1.block)
                {
                    blockans = "Match\n";
                    row["isManupilated"] = "No";


                }
                else
                {
                    blockans = "Not Match\n";
                    row["isManupilated"] = "Yes";
                }

            }
            string isManipulate = blockans;
            GridView2.DataSource = dt2;
            GridView2.DataBind();

            GridView2.Visible = true;

        }
        else
        {


            GridView2.Visible = false;
        }

    }

    public List<Blocklist> getBlockList()
    {
        string q = "";
        List<Blocklist> blocklist = new List<Blocklist>();
        DataTable dt = new DataTable("Blocklist");

        if (TextBox1.Text == "")
        {
            q = "select fid,filename,type,size,content,prehash,path,currhash from files where owner_uid='" + Session["uid"] + "'";
        }
        else
        {
            q = "select fid,filename,type,size,content,prehash,path,currhash from files where owner_uid='" + Session["uid"] + "' and  (filename like '%" + TextBox1.Text + "%' or type like '%" + TextBox1.Text + "')order by fid desc ";
        }
        SqlDataAdapter da = new SqlDataAdapter(q, con);
        da.Fill(dt);

        int count = dt.Rows.Count;
        for (int i = 0; i < count; i++)
        {
            Blocklist blst = new Blocklist();
            blst.fid = dt.Rows[i]["fid"].ToString();
            blst.filename = dt.Rows[i]["filename"].ToString();
            blst.type = dt.Rows[i]["type"].ToString();
            blst.size = dt.Rows[i]["size"].ToString();
            blst.contents = dt.Rows[i]["content"].ToString();
            blst.previoushash = dt.Rows[i]["prehash"].ToString();
            blst.block = dt.Rows[i]["currhash"].ToString();
            blocklist.Add(blst);
        }

        return blocklist;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        gridview();
    }
}