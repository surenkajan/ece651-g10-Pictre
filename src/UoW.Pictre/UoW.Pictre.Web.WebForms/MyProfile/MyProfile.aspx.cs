using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Identity;

namespace UoW.Pictre.Web.WebForms.MyProfile
{
    public partial class MyProfile : System.Web.UI.Page
    {
        string currentUserEmailID;
        string VisitedUserEmailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            currentUserEmailID = HttpContext.Current.User.Identity.Name;
            HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("pictre_hdnf_CurrentUserEmailID");
            //hdnf_CurrentUserEmailID.Value = currentUserEmailID;

            UserDto user = null;
            Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            //myUri = new Uri("http://localhost:32231/MyProfile/MyProfile?uid=4");
            string uid = HttpUtility.ParseQueryString(myUri.Query).Get("uid");


            if (string.IsNullOrEmpty(uid))
            {
                // My Profile
                user = PictreBDelegate.Instance.GetUserByEmailID(currentUserEmailID);
                Btn_addFriend.Visible = false;
                hdnf_CurrentUserEmailID.Value = currentUserEmailID;
                uid = user.Uid.ToString();
            }
            else
            {
                //Friends Profile
                user = GetFriendProfile(uid);
                VisitedUserEmailID = user.EmailAddress;
                List<FriendDto> Friends = PictreBDelegate.Instance.GetFriendByEmailID(currentUserEmailID);
                hdnf_CurrentUserEmailID.Value = user.EmailAddress;
                if (Friends != null)
                {
                    foreach (FriendDto frnd in Friends)
                    {
                        if (VisitedUserEmailID == frnd.EmailAddress)
                            Btn_addFriend.Visible = false;

                        else if (VisitedUserEmailID == currentUserEmailID)
                            Btn_addFriend.Visible = false;
                    }
                }

            }



            if (user != null)
            {

                string FirstName = user.FirstName;
                string FullName = user.FullName;
                DateTime BirthDate = user.DateOfBirth ?? DateTime.Now;
                string DateOfBirth = BirthDate.ToString("d");
                string EmailAddress = user.EmailAddress;

                MyProfileName.Text = FullName;
                MyProfileHeading.Text = FirstName;
                MyProfileDOB.Text = DateOfBirth;
                //MyProfileGender.Text = "Male";
                MyProfileEmail.Text = EmailAddress;
                //string id = user.Uid.ToString();
                //Profile Image
                if (user.ProfilePhoto != null)
                {
                    var pieces = user.ProfilePhoto.Split(new[] { ',' }, 2);
                    byte[] imageBytes = Convert.FromBase64String(pieces[1]);
                    //byte[] imageBytes = Convert.FromBase64String(Currentuser.ProfilePhoto);
                    Session["ImageBytes" + uid] = imageBytes;
                    ImagePreview.ImageUrl = "~/ImageHandler.ashx?uid=" + uid;
                }

            }


            if (!IsPostBack)
                LoadGridData();
        }

        private UserDto GetFriendProfile(string uid)
        {
            UserDto friend = null;
            if (!String.IsNullOrEmpty(uid))
            {
                int UserID = Int32.Parse(uid);
                friend = PictreBDelegate.Instance.GetUserByUid(UserID);

                //FriendDto friend = new FriendDto() { };

            }
            return friend;
        }


        protected GridView GridView1;


        //        var client = new RestClient("http://localhost:32785/Service.svc/userrest/GetUserByEmailID?Email=brindha@gmail.com");

        //    IRestResponse response = client.Execute(new RestRequest());

        //    if (response.ErrorException == null)
        //    {
        //        JObject json = JObject.Parse(response.Content);

        //        String FirstName = Convert.ToString(json["FirstName"]);
        //        String DateOfBirth = Convert.ToString(json["DateOfBirth"]);
        //        String EmailAddress = Convert.ToString(json["EmailAddress"]);

        //        MyProfileName.Text = FirstName;
        //        MyProfileHeading.Text = FirstName;
        //        MyProfileDOB.Text = DateOfBirth;
        //        //MyProfileGender.Text = "Male";
        //        MyProfileEmail.Text = EmailAddress;
        //    }
        //    if (!IsPostBack)
        //        LoadGridData();
        //}
        //protected GridView GridView1;
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
            string EmailId = null;
            currentUserEmailID = HttpContext.Current.User.Identity.Name;

            Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            //myUri = new Uri("http://localhost:32231/MyProfile/MyProfile?uid=4");
            string uid = HttpUtility.ParseQueryString(myUri.Query).Get("uid");


            if (string.IsNullOrEmpty(uid))
            {
                // My Profile
                EmailId = currentUserEmailID;
            }
            else
            {
                //Friends Profile
                EmailId = VisitedUserEmailID;
            }
            //currentUserEmailID = HttpContext.Current.User.Identity.Name;
            List<FriendDto> Friends = PictreBDelegate.Instance.GetFriendByEmailID(EmailId);
            //I am adding dummy data here. You should bring data from your repository.
            if (Friends != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ImageUrl");
                dt.Columns.Add("Profile_Name");
                dt.Columns.Add("EmailAddress");
                dt.Columns.Add("Uid");

                foreach (FriendDto frnd in Friends)
                {
                    //Btn_addFriend.Visible = false;
                    DataRow dr = dt.NewRow();
                    string fid = frnd.Uid.ToString();
                    //Profile Image
                    if (frnd.ProfilePhoto != null)
                    {

                        var pieces = frnd.ProfilePhoto.Split(new[] { ',' }, 2);
                        byte[] imageBytes = Convert.FromBase64String(pieces[1]);
                        //byte[] imageBytes = Convert.FromBase64String(Currentuser.ProfilePhoto);
                        //Session["ImageBytes"] = imageBytes;
                        //dr["ImageUrl"] = "~/ImageHandler.ashx";
                        Session["ImageBytes" + fid] = imageBytes;
                        //ImagePreview.ImageUrl = "~/ImageHandler.ashx?uid=" + fid;
                        dr["ImageUrl"] = "~/ImageHandler.ashx?uid=" + fid;
                    }

                    //dr["ImageUrl"] = frnd.ProfilePhoto;
                    dr["Profile_Name"] = frnd.FullName;
                    dr["EmailAddress"] = frnd.EmailAddress;
                    dr["Uid"] = frnd.Uid;
                    dt.Rows.Add(dr);
                }
                grdData.DataSource = dt;
                grdData.DataBind();
            }
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

        protected void Btn_addFriend_Click(object sender, EventArgs e)
        {
            Btn_addFriend.Visible = false;
            Label1.Visible = true;
            Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            // Uri myUri = new Uri("http://localhost:32231/MyProfile/MyProfile?uid=3");
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("uid");

            if (!String.IsNullOrEmpty(param1))
            {
                string currentUserEmailID = HttpContext.Current.User.Identity.Name;
                int UserID = Int32.Parse(param1);
                FriendRequestDto addfriend = new FriendRequestDto() { CurrentUserEmailID = currentUserEmailID, Uid = UserID };
                int AddStatus = PictreBDelegate.Instance.InsertFriend(addfriend);
                LoadGridData();

                //FriendDto friend = new FriendDto() { };

            }
        }
    }
}
