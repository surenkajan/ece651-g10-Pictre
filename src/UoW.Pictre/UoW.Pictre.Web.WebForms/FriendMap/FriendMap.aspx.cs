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

            JObject json = JObject.Parse(response.Content);

            String FirstName = Convert.ToString(json["GetUserByEmailIDResult"]["FirstName"]);

            System.Diagnostics.Debug.WriteLine(FirstName);
        }
    }
}