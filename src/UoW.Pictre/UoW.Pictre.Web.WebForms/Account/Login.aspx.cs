using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using UoW.Pictre.Web.WebForms.Models;

namespace UoW.Pictre.Web.WebForms.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RememberMe.Visible = false;
            lbl_RememberMe.Visible = false;
            RegisterHyperLink.NavigateUrl = "Register";
            //Enable this once you have account confirmation enabled for password reset functionality
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }

            //Redirect if the user is already loggedin
            //string CurrentEmailID = (string)(Session["s_CurrentUserEmailID"]);
            string LoggedInUserEmailID = HttpContext.Current.User.Identity.Name;
            if (!string.IsNullOrEmpty(LoggedInUserEmailID))
            {
                Response.Redirect("/Home/Home");
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        HiddenField hdnf_CurrentUserEmailID = (HiddenField)Master.FindControl("pictre_hdnf_CurrentUserEmailID");
                        hdnf_CurrentUserEmailID.Value = Email.Text;
                        Session["s_CurrentUserEmailID"] = Email.Text;
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }

            //if(UName.Text == "user" && Password.Text == "user")
            //{
            //    Response.Redirect("/Home/Home");
            //}
            //else
            //{
            //    FailureText.Text = "Invalid login attempt";
            //    ErrorMessage.Visible = true;
            //}
        }
    }
}