using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.Pictre.Web.WebForms.MyProfile
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyProfileName.Text = "Kevin";
            MyProfileDOB.Text = "29 February 2000";
            MyProfileGender.Text = "Male";
            MyProfileEmail.Text = "ECE651@uwaterloo.ca";
        }
    }
}