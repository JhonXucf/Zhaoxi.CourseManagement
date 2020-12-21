using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhaoxi.CourseManagement.Common;
 

namespace Zhaoxi.CourseManagement.Model
{
    public class LoginModel:NotifyBase
    {
        private string _username;
        public string UserName
        {
            get { return _username; }
            set {
                _username = value;
                this.DoNotify();
            }
        }
        private string _password;

        public string PassWord
        {
            get { return _password; }
            set {
                _password = value;
                this.DoNotify(); 
            }
        }
        private string _validationCode;

        public string ValidationCode
        {
            get { return _validationCode; }
            set {
                _validationCode = value;
                this.DoNotify();
            }
        }


    }
}
