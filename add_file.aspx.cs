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

public partial class add_file : System.Web.UI.Page
{
    string val = "", id = "";
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["status"] == "edit")
            {
                Label6.Text = " Edit File Details";
                Button1.Visible = true;
                Button1.Text = "Update";
                try
                {
                    string val = Session["fid"].ToString();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT fid,filename,path,type,description  from files where fid='" + val.Trim() + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        TextBoxname.Text = ds.Tables[0].Rows[0][4].ToString();
                        TextBox1.Visible = true;
                        TextBox1.Enabled = false;
                        FileUpload1.Visible = false;
                        Label4.Text = "File Name ";
                        TextBox1.Text= ds.Tables[0].Rows[0][2].ToString();
                        TextBoxid.Text = ds.Tables[0].Rows[0][0].ToString();
                        TextBoxid.Enabled = false;

                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("Logout.aspx");
                }

            }
            else if (Request.QueryString["status"] == "view")
            {
                Label6.Text = " File Details";
                Button1.Visible = false;
                try
                {
                    string val = Request.QueryString["pid"];
                    SqlDataAdapter da = new SqlDataAdapter("SELECT fid,filename,path,type,description  from files where fid='" + val.Trim() + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (!IsPostBack)
                        {
                            TextBoxname.Text = ds.Tables[0].Rows[0][4].ToString();
                           TextBoxid.Text = ds.Tables[0].Rows[0][0].ToString();
                            TextBoxid.Enabled = false;
                            TextBox1.Visible = true;
                            FileUpload1.Visible = false;
                            TextBox1.Text = ds.Tables[0].Rows[0][2].ToString();
                            TextBox1.Enabled = false;
                            Label4.Text = "File Name ";
                            //DropDownList1.SelectedValue= ds.Tables[0].Rows[0][3].ToString();
                            //DropDownList1.Enabled = false;

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
             
                string com = "select top 1 fid From files ORDER BY fid Desc;";
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
    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string text = "";
        if (Button1.Text == "Add File")
        {
            try
            {
                string folderPath = Server.MapPath("~/Project_Docs/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                string file1 = Path.GetFileName(folderPath + FileUpload1.FileName);
              
                string fname1 = Server.MapPath(FileUpload1.FileName);
             if(FileUpload1.FileName.EndsWith(".jpg") ||  FileUpload1.FileName.EndsWith(".png"))
                {
                    text = FileUpload1.FileName + FileUpload1.FileBytes;
                }
                else
                {
                    text = File.ReadAllText(folderPath + file1);
                }
               

                if (TextBoxid.Text != "" && TextBoxname.Text != "" && FileUpload1.HasFile)
                {

                    string content = Base64Encode(text);
                    long length = new System.IO.FileInfo(folderPath + file1).Length;
                    string strpath = System.IO.Path.GetExtension(FileUpload1.FileName);
                    // long length = new System.IO.FileInfo(strpath).Length;
                    Blocklist bl = new Blocklist();
                    bl.fid = TextBoxid.Text;
                    bl.filename = FileUpload1.FileName;
                    bl.type = strpath;
                    bl.size = length.ToString();
                    bl.contents = content;
                    SqlDataAdapter da = new SqlDataAdapter("select Top 1 * from files order by fid Desc ", con);
                    da.SelectCommand.CommandTimeout = 60;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        bl.previoushash = "Genesis";
                    }
                    else
                    {
                        bl.previoushash = ds.Tables[0].Rows[0][7].ToString();
                    }
                    Block block = new Block();
                    if (FileUpload1.FileName.EndsWith(".jpg") || FileUpload1.FileName.EndsWith(".png"))
                    {
                        block.gethash1(bl.fid, bl.filename, length.ToString());
                    }
                    else
                    {
                        block.gethash(bl.fid, bl.filename, bl.size, bl.contents, bl.previoushash);
                    }
              
                    string Currentblock = block.getFinalBlock();

                    string s = "insert into files(fid,filename,path,type,upload_date,size,content,prehash,currhash,description,owner_uid) values('" + TextBoxid.Text + "','" + bl.filename + "','" + FileUpload1.FileName + "','" + strpath + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + length + "','" + content + "','" + bl.previoushash + "','" + Currentblock + "','" + TextBoxname.Text + "','" + Request.QueryString["uid"] + "')";
                    con.Open();
                    cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    string s1 = "insert into access_control(fid,uid,fileaccess,owner) values('" + TextBoxid.Text + "','" + Request.QueryString["uid"] + "','Yes','Yes')";
                    con.Open();
                    cmd = new SqlCommand(s1, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    TextBoxid.Text = "";
                    TextBoxname.Text = "";

                  
                    if (FileUpload1.HasFile)
                    {
                        string file = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        string fname = Server.MapPath(FileUpload1.FileName);

                        string ftp = "ftp://Cloudstorage.hostoise.com/Webstorage/";
                        string ftpFolder = "Files/" + FileUpload1.FileName;
                        byte[] fileBytes = null;

                        FileUpload1.PostedFile.InputStream.Seek(0, SeekOrigin.Begin);
                        using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                        {
                            fileBytes = binaryReader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                        }

                        try
                        {
                            //Create FTP Request.
                            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder);
                            request.Method = WebRequestMethods.Ftp.UploadFile;

                            //Enter FTP Server credentials.
                            request.Credentials = new NetworkCredential("Cloudstorage", "f@633dr4A");
                            request.ContentLength = fileBytes.Length;
                            request.UsePassive = true;
                            request.UseBinary = true;
                            request.ServicePoint.ConnectionLimit = fileBytes.Length;
                            request.EnableSsl = false;

                            using (Stream requestStream = request.GetRequestStream())
                            {
                                requestStream.Write(fileBytes, 0, fileBytes.Length);
                                requestStream.Close();
                            }

                            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('File Uploaded successfully;')", true);
                            //  lblMessage.Text += fileName + " uploaded.<br />";
                            response.Close();
                        }
                        catch (WebException ex)
                        {
                            con.Close();
                            throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
                        }

                        Response.Redirect("view_files.aspx?stat=ADD");
                        //}
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Kindly Fill in Details')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Kindly Upload File Again')", true);
            }
        }
        else if (Button1.Text == "Update")
        {
            if (TextBoxid.Text != "" && TextBoxname.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update files set filename='" + TextBox1.Text + "' ,description='"+TextBoxname.Text+"' where fid='" + Request.QueryString["pid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('File Updated Successfully')", true);
                Response.Redirect("View_Files.aspx?stat=UPDATE");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Kindly Fill in Details')", true);
            }
        }

        
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("View_Files.aspx");
    }
}