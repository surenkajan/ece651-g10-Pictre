﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using UoW.Pictre.Core;
using UoW.Pictre.CoreService.DataTransferObjectMapper;
using UoW.Pictre.CoreService.DataTransferObjects;


namespace UoW.Pictre.CoreService
{
    public partial class Service : ISecurityService
    {
        public int AddSecurityAnswersEmailID(SecurityAnswersDto answers)
        {
            SecurityDao secDao = new SecurityDao();
            return secDao.AddSecurityAnswersEmailID(CoreObjectMapper.SecurityAnswersDtoToDao(answers));
        }

        //public List<SecurityAnswersDto> GetSecurityAnswersByEmailID(string EmailID)
        public SecurityAnswersDto GetSecurityAnswersByEmailID(string EmailID)
        {
            SecurityDao secDao = new SecurityDao();
            return CoreObjectMapper.SecurityAnswersDaoToDto(secDao.GetSecurityAnswersByEmailID(EmailID));
        }

        //public List<SecurityQuestionDto> GetSecurityQuestions()
        public List<SecurityQuestionDto> GetSecurityQuestions()
        {
            SecurityDao secDao = new SecurityDao();
            return CoreObjectMapper.SecurityQuestionsDaoToDto(secDao.GetSecurityQuestions());
        }

        public int UpdateSecurityAnswersEmailID(SecurityAnswersDto answers)
        {
            SecurityDao secDao = new SecurityDao();
            return secDao.UpdateSecurityAnswersByEmailID(CoreObjectMapper.SecurityAnswersDtoToDao(answers));
        }
    }
}
