﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.Pictre.Web.WebForms.MyProfile
{
    public partial class Settings : System.Web.UI.Page
    {
        string currentUserEmailID;
        UserDto Currentuser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUserEmailID = HttpContext.Current.User.Identity.Name;
            Session["ImageBytes"] = null;
            Currentuser = PictreBDelegate.Instance.GetUserByEmailID(currentUserEmailID);
            if (!IsPostBack)
            {
                //Retrieve the Security questions:
                List<SecurityQuestionDto> questionsList = PictreBDelegate.Instance.GetSecurityQuestions();
                if (questionsList != null)
                {
                    SQuestion1.Text = questionsList[0].Question;
                    SQuestion2.Text = questionsList[1].Question;
                }

                //Retrieve User Personal Details
                
                if (Currentuser != null)
                {
                    FName.Text = Currentuser.FirstName;
                    LName.Text = Currentuser.LastName;
                    FullName.Text = Currentuser.FullName;
                    Gender.Text = Currentuser.Sex;
                    //DOB.Text = String.Format("MMMM d, yyyy", Currentuser.DateOfBirth);
                    //ImagePreview = Base64ToImage(Currentuser.ProfilePhoto);
                    //ImagePreview.Attributes["src"] = Currentuser.ProfilePhoto;
                    if(Currentuser.ProfilePhoto != null)
                    {
                        var pieces = Currentuser.ProfilePhoto.Split(new[] { ',' }, 2);
                        byte[] imageBytes = Convert.FromBase64String(pieces[1]);
                        //byte[] imageBytes = Convert.FromBase64String(Currentuser.ProfilePhoto);
                        Session["ImageBytes"] = imageBytes;
                        ImagePreview.ImageUrl = "~/ImageHandler.ashx";
                    }
                    //Retrieve Answers of Security Questions
                    SecurityAnswersDto answersList = PictreBDelegate.Instance.GetSecurityQuestionsAnswers(currentUserEmailID);
                    //SQuestion1Ans.Text = (answersList != null && answersList.QuestionAnswer != null) ? answersList.QuestionAnswer[SQuestion1.Text] : String.Empty;
                    //SQuestion1Ans.Text = (answersList != null && answersList.QuestionAnswer != null) ? answersList.QuestionAnswer[SQuestion2.Text] : String.Empty;

                    SQuestion1Ans.Text = (answersList != null && answersList.QuestionsAnswers[0] != null) ? answersList.QuestionsAnswers[0].Answer : String.Empty;
                    SQuestion1Ans.Text = (answersList != null && answersList.QuestionsAnswers[1] != null) ? answersList.QuestionsAnswers[1].Answer : String.Empty;

                }
            }
            else
            {
                if (IsPostBack && ProfilePhotoUpload.PostedFile != null)
                {
                    if (ProfilePhotoUpload.PostedFile.FileName.Length > 0)
                    {
                        Session["ImageBytes"] = ProfilePhotoUpload.FileBytes;
                        ImagePreview.ImageUrl = "~/ImageHandler.ashx";

                        UserDto user_Updated = new UserDto()
                        {
                            EmailAddress = Currentuser.EmailAddress,
                            DateOfBirth = Currentuser.DateOfBirth,
                            FirstName = Currentuser.FirstName,
                            FullName = Currentuser.FullName,
                            LastName = Currentuser.LastName,
                            Sex = Currentuser.Sex,
                            UserName = Currentuser.UserName,
                            ProfilePhoto = Convert.ToBase64String(ProfilePhotoUpload.FileBytes)
                        };
                        int updateuserStatus = PictreBDelegate.Instance.UpdateUser(user_Updated);

                    }
                }
            }
        }

        //protected void btnPreview_Click(object sender, EventArgs e)
        //{
        //    Session["ImageBytes"] = ProfilePhotoUpload.FileBytes;
        //    ImagePreview.ImageUrl = "~/ImageHandler.ashx";
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Update the User Details
            UserDto user_Updated = new UserDto() {
                EmailAddress = Currentuser.EmailAddress,
                DateOfBirth = Currentuser.DateOfBirth,
                FirstName = FName.Text,
                FullName = FullName.Text,
                LastName = LName.Text,
                Sex = Gender.Text,
                UserName = Currentuser.UserName,
                ProfilePhoto = Currentuser.ProfilePhoto.Split(new[] { ',' }, 2)[1]
            };
            int updateuserStatus = PictreBDelegate.Instance.UpdateUser(user_Updated);

            //Update Security Questions
            SecurityAnswersDto Ans_Updated = new SecurityAnswersDto()
            {
                UserEmailID = Currentuser.EmailAddress,
                //QuestionAnswer = new Dictionary<string, string>
                //    {
                //        {SQuestion1.Text,SQuestion1Ans.Text},
                //        {SQuestion2.Text,SQuestion2Ans.Text}
                //    }
                QuestionsAnswers = new List<SecurityAnswerPair>()
                {
                    new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = SQuestion1.Text},
                            Answer =  SQuestion1Ans.Text
                        },
                        new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = SQuestion2.Text},
                            Answer =  SQuestion2Ans.Text
                        }
                }

            };
            //int updateAnsStatus = PictreBDelegate.Instance.up(user_Updated);
            int updateAnsStatus = 0;
            lblSaveStatus.Visible = true;
            if (updateuserStatus == 0 && updateAnsStatus == 0)
            {
                lblSaveStatus.Text = "Your Profile is uccessfully saved.";
            }
            else
            {
                lblSaveStatus.Text = "Something went wrong. Please try again.";
            }

            //Render the image again
            var pieces = Currentuser.ProfilePhoto.Split(new[] { ',' }, 2);
            byte[] imageBytes = Convert.FromBase64String(pieces[1]);
            Session["ImageBytes"] = imageBytes;
            ImagePreview.ImageUrl = "~/ImageHandler.ashx";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home/Home");
        }

        public static string ImageToBase64(System.Drawing.Image image)
        {
            string base64String = null;
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
                base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        public static System.Drawing.Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
    }
}