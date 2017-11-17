using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace UoW.Pictre.Web.WebForms.Home
{
    public partial class Upload : System.Web.UI.Page
    {
        string currentUserEmailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Approach 1
            currentUserEmailID = HttpContext.Current.User.Identity.Name;
            ////Approach 2 - lost its value since the page moves from one to another
            ////HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("pictre_hdnf_CurrentUserEmailID");
            ////currentUserEmailID = hdnf_CurrentUserEmailID.Value;
            ////Approach 3
            ////currentUserEmailID = (string)(Session["s_CurrentUserEmailID"]);
            //// Set Asp hidden field back, so that Javascript can use this value
            ////hdnf_CurrentUserEmailID.Value = (string)(Session["s_CurrentUserEmailID"]);
            ////currentUserEmailID = hdnf_CurrentUserEmailID.Value;


            ////Get all Users 
            //List<UserDto> users = PictreBDelegate.Instance.GetAllUsers();

            ////Get User by Email ID
            //UserDto user = PictreBDelegate.Instance.GetUserByEmailID(currentUserEmailID);

            ////Delete User
            ////int DeleteStatus = PictreBDelegate.Instance.DeleteUserByEmailID(currentUserEmailID);

            ////Add user
            //int AddStatus = PictreBDelegate.Instance.InsertUser(user);

            //if (user != null)
            //{
            //    //Insert user
            //    user.FirstName = "New First Name";
            //    int UpdateStatus = PictreBDelegate.Instance.UpdateUser(user);
            //}            

            if (!IsPostBack)
            {
                //string[] filePaths = Directory.GetFiles(Server.MapPath("~/Home/Images/"));
                //List<ListItem> files = new List<ListItem>();
                //foreach (string filePath in filePaths)
                //{
                //    string fileName = Path.GetFileName(filePath);
                //    files.Add(new ListItem(fileName, "~/Home/Images/" + fileName));
                //}
                ////DataList1.DataSource = files;
                //DataList1.DataBind();
            }
        }

        //private void show_data()
        //{
        //    DirectoryInfo dir = new DirectoryInfo(@"C:\GitHub\Project_Data\");
        //    FileInfo[] fil = dir.GetFiles();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("path");
        //    for (int i = 0; i < fil.Length; i++)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["path"] = fil[i].Name;
        //        dt.Rows.Add();
        //    }

        //   // DataList1.DataSource = dt;
        //   // DataList1.DataBind();
        //}

        protected void Pictre_btnUpload_Click(object sender, EventArgs e)
        {
            /*if (Pictre_FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(Pictre_FileUpload1.PostedFile.FileName);
                Pictre_FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Home/Images/") + filename);
                Response.Redirect(Request.Url.AbsoluteUri);
                //Pictre_FileUpload1.SaveAs(filename);
                //show_data();


            }*/
        }
    }
}