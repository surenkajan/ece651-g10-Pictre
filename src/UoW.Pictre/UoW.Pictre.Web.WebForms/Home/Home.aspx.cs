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
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUser = HttpContext.Current.User.Identity.Name;
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