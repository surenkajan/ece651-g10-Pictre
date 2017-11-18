using System;
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

        public List<SecurityQuestionDto> GetSecurityQuestions()
        {
            SecurityDao secDao = new SecurityDao();
            return CoreObjectMapper.SecurityQuestionsDaoToDto(secDao.GetSecurityQuestions());
        }
    }
}
