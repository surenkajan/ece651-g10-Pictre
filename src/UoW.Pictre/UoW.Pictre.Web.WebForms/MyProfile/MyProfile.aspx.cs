using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace UoW.Pictre.Web.WebForms.MyProfile
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://localhost:32785/Service.svc/userrest/GetUserByEmailID?Email=brindha@gmail.com");

            IRestResponse response = client.Execute(new RestRequest());

            JObject json = JObject.Parse(response.Content);

            String FirstName = Convert.ToString(json["FirstName"]);
            String DateOfBirth = Convert.ToString(json["DateOfBirth"]);
            String EmailAddress = Convert.ToString(json["EmailAddress"]);

            MyProfileName.Text = FirstName;
            MyProfileHeading.Text = FirstName;
            MyProfileDOB.Text = DateOfBirth;
            //MyProfileGender.Text = "Male";
            MyProfileEmail.Text = EmailAddress;
            if (!IsPostBack)
                LoadGridData();
        }
        protected GridView GridView1;
        //private object ds;

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    //if (!this.IsPostBack)
        //    //{
        //    //    this.loadTable();
        //    //}
        //    if (!IsPostBack)
        //        LoadGridData();

        //}

        private void LoadGridData()
        {
            //I am adding dummy data here. You should bring data from your repository.
            DataTable dt = new DataTable();
            dt.Columns.Add("ImageUrl");
            dt.Columns.Add("Profile_Name");
            for (int i = 0; i < 20; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ImageUrl"] = "../Content/Images/friends.png";
                dr["Profile_Name"] = "User " + (i + 1);
                dt.Rows.Add(dr);
            }
            grdData.DataSource = dt;
            grdData.DataBind();
        }
        //protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdData.PageIndex = e.NewPageIndex;
        //    LoadGridData();
        //}

        private void loadTable()
        {

            DataSet ds = new DataSet();
            DataTable dt;
            DataRow dr;
            DataColumn pName;
            DataColumn pImage;


            dt = new DataTable();
            pName = new DataColumn("Profile_Name", Type.GetType("System.String"));
            pImage = new DataColumn("ImageURL", Type.GetType("System.String"));

            dt.Columns.Add(pName);
            dt.Columns.Add(pImage);

            dr = dt.NewRow();
            dr["Profile_Name"] = "John Cena";
            dr["ImageUrl"] = "Content/Images/friends.png";

            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Profile_Name"] = "Hannah Ray";
            dr["ImageUrl"] = "Content/Images/friends.png";

            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Profile_Name"] = "Karl Marx";
            dr["ImageUrl"] = "Content/Images/friends.png";

            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Profile_Name"] = "Hey you";
            dr["ImageUrl"] = "Content/Images/friends.png";

            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdData.PageIndex = e.NewPageIndex;

            LoadGridData();
        }

        protected void grdData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}