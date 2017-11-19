using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.Pictre.Web.WebForms.MyProfile
{
    public partial class Settings : System.Web.UI.Page
    {
        string currentUserEmailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUserEmailID = HttpContext.Current.User.Identity.Name;
            //Retrieve the Security questions:
            List<SecurityQuestionDto> questionsList = PictreBDelegate.Instance.GetSecurityQuestions();
            if (questionsList != null)
            {
                SQuestion1.Text = questionsList[0].Question;
                SQuestion2.Text = questionsList[1].Question;
            }

            //Retrieve User Personal Details
            UserDto Currentuser = PictreBDelegate.Instance.GetUserByEmailID(currentUserEmailID);
            FName.Text = Currentuser.FirstName;
            LName.Text = Currentuser.LastName;
            FullName.Text = Currentuser.FullName;
            Gender.Text = Currentuser.Sex;
            DOB.Text = String.Format("MMMM d, yyyy", Currentuser.DateOfBirth);

            //Retrieve Answers of Security Questions
            SecurityAnswersDto answersList = PictreBDelegate.Instance.GetSecurityQuestionsAnswers(currentUserEmailID);
            SQuestion1Ans.Text = answersList.QuestionAnswer[SQuestion1.Text];
            SQuestion1Ans.Text = answersList.QuestionAnswer[SQuestion2.Text];

        }
    }
}