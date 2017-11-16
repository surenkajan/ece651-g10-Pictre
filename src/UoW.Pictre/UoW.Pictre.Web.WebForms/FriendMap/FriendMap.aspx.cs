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
            var client = new RestClient("http://localhost:32785/Service.svc/userrest/GetUserByEmailID?Email=brindha@gmail.com");

            IRestResponse response = client.Execute(new RestRequest());

            if (response.ErrorException == null)
            {
                JObject json = JObject.Parse(response.Content);

                String FirstName = Convert.ToString(json["FirstName"]);

                // Add pictures to db using the below query.
                // UPDATE [pictre].[User] SET ProfilePhoto = (SELECT MyImage.* from Openrowset(Bulk 'C:\Users\SHITIJ\Desktop\map_marker.png', Single_Blob) MyImage) where ID in (1,2,3,4,5)
                logoImg.Src = Convert.ToString(json["ProfilePhoto"]);

                System.Diagnostics.Debug.WriteLine(FirstName);
            }
        }
    }
}