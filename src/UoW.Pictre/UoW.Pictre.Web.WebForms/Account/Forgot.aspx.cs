using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using UoW.Pictre.Web.WebForms.Models;

namespace UoW.Pictre.Web.WebForms.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //securityquestionsHolder.Visible = false;
            SecQueGetSubmitHolder.Visible = true;
            securityquestionsHolder.Visible = false;
        }

        //protected void Forgot(object sender, EventArgs e)
        //{
        //    if (IsValid)
        //    {
        //        Validate the user's email address
        //        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //        ApplicationUser user = manager.FindByName(Email.Text);
        //        if (user == null || !manager.IsEmailConfirmed(user.Id))
        //        {
        //            FailureText.Text = "The user either does not exist or is not confirmed.";
        //            ErrorMessage.Visible = true;
        //            return;
        //        }
        //        For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
        //        Send email with the code and the redirect to reset password page
        //        string code = manager.GeneratePasswordResetToken(user.Id);
        //        string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
        //        manager.SendEmail(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>.");
        //        loginForm.Visible = false;
        //        DisplayEmail.Visible = true;
        //    }
        //}

        protected void SecQueGetSubmitBtn_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindByName(Email.Text);

            if (user != null)
            {
                SecQueGetSubmitHolder.Visible = false;
                securityquestionsHolder.Visible = true;

                //Retrieve Security Questions
                List<SecurityQuestionDto> questionsList = PictreBDelegate.Instance.GetSecurityQuestions();
                if (questionsList != null)
                {
                    SQuestion1.Text = questionsList[0].Question;
                    SQuestion2.Text = questionsList[1].Question;
                }
            }
            else
            {
                FailureText.Text = "The user does not exist in Pictre. Please Enter the registered email address ";
                ErrorMessage.Visible = true;
                //wrongEmailErrormsg.Text = "Please provide your correct email.";
                securityquestionsHolder.Visible = false;
            }
        }

        protected void SecQueAnsSubmitBtn_Click(object sender, EventArgs e)
        {
            //Retrieve Answers of Security Questions
            SecurityAnswersDto answersList = PictreBDelegate.Instance.GetSecurityQuestionsAnswers(Email.Text);
            String SQuestion1AnsString = (answersList != null && answersList.QuestionsAnswers[0] != null) ? answersList.QuestionsAnswers[0].Answer : String.Empty;
            String SQuestion2AnsString = (answersList != null && answersList.QuestionsAnswers[1] != null) ? answersList.QuestionsAnswers[1].Answer : String.Empty;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindByName(Email.Text);
            
            if (user == null || !SQuestion1Ans.Text.Equals(SQuestion1AnsString) || !SQuestion2Ans.Text.Equals(SQuestion2AnsString))
            {
                FailureText.Text = "The user either does not exist or is not confirmed.";
                ErrorMessage.Visible = true;
                return;
                //Response.Redirect("/Account/ResetPassword");
            }
            else
            {
                //wrongAnsErrormsg.Text = "Please provide Correct Answers to the Security questions.";
                //SecQueGetSubmitHolder.Visible = false;
                //securityquestionsHolder.Visible = true;
                string code = manager.GeneratePasswordResetToken(user.Id);
                Session["s_CurrentUserEmailID"] = Email.Text;
                Session["code"] = code;
                Response.Redirect("/Account/ResetPassword");
            }

        }
    }
}