using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.Pictre.Web.WebForms.FriendMap
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUserEmailID = HttpContext.Current.User.Identity.Name;
            //Approach 2 - lost its value since the page moves from one to another
            HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("pictre_hdnf_CurrentUserEmailID");
            //currentUserEmailID = hdnf_CurrentUserEmailID.Value;
            //Approach 3
            //currentUserEmailID = (string)(Session["s_CurrentUserEmailID"]);
            // Set Asp hidden field back, so that Javascript can use this value
            hdnf_CurrentUserEmailID.Value = currentUserEmailID;
            //currentUserEmailID = hdnf_CurrentUserEmailID.Value;

            //var client = new RestClient("http://localhost:32785/Service.svc/userrest/GetUserByEmailID?Email=brindha@gmail.com");

            //IRestResponse response = client.Execute(new RestRequest());

            //if (response.ErrorException == null)
            //{
            //    JObject json = JObject.Parse(response.Content);

            //    String FirstName = Convert.ToString(json["FirstName"]);

            //    // Add pictures to db using the below query.
            //    // UPDATE [pictre].[User] SET ProfilePhoto = (SELECT MyImage.* from Openrowset(Bulk 'C:\Users\SHITIJ\Desktop\map_marker.png', Single_Blob) MyImage) where ID in (1,2,3,4,5)
            //    logoImg.Src = Convert.ToString(json["ProfilePhoto"]);

            //    System.Diagnostics.Debug.WriteLine(FirstName);
            //}
        }
    }
}