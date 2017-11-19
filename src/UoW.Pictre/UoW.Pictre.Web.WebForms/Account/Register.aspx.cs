using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using UoW.Pictre.Web.WebForms.Models;

namespace UoW.Pictre.Web.WebForms.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ErrorMessage.Visible = false;

            //Retrieve the Security questions:
            List<SecurityQuestionDto> questionsList = PictreBDelegate.Instance.GetSecurityQuestions();
            if(questionsList != null)
            {
                SQuestion1.Text = questionsList[0].Question;
                SQuestion2.Text = questionsList[1].Question;
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //Add user details to Pictre DB
                //Add user
                UserDto newUser = new UserDto() { EmailAddress = Email.Text, DateOfBirth = Convert.ToDateTime(DOB.Text), FirstName = FName.Text, FullName = FullName.Text, LastName = LName.Text, Sex = Gender.Text };
                int AddStatus = PictreBDelegate.Instance.InsertUser(newUser);
                //Add Answers to the security questions
                SecurityAnswersDto answers = new SecurityAnswersDto() {
                    UserEmailID = Email.Text,
                    QuestionAnswer = new Dictionary<string, string>
                    {
                        {SQuestion1.Text,SQuestion1Ans.Text},
                        {SQuestion2.Text,SQuestion2Ans.Text}
                    }
                };
                int AddAnsStatus = PictreBDelegate.Instance.InsertSecurityAnswers(answers);

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
            //RegisterStatusPH.Visible = true;
            //PictreRegisterUserPH.Visible = false;
            //registerStatus.Text = "You have successfully registered with Pictre. Please login to the system using your credentials";
        }

        protected void CreateUserCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Login");
        }
    }
}