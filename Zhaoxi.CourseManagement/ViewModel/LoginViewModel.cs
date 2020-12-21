using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Zhaoxi.CourseManagement.Common;
using Zhaoxi.CourseManagement.Model;

namespace Zhaoxi.CourseManagement.ViewModel
{
    public class LoginViewModel:NotifyBase
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();
        public CommandBase CloseWindowCommand { get; set; }
        public CommandBase LoginCommand { get; set; }
        private string _errorMessage = "";

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value;
                this.DoNotify();
            }
        }

        public LoginViewModel()
        {
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
              {
                  (o as Window).Close();
              });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) =>
              {
                  return true;
              });
            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) =>
              {
                  return true;
              });
        }
        private void DoLogin(object o)
        {
            if (string.IsNullOrWhiteSpace(LoginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名！";
                return;
            }
            if (string.IsNullOrWhiteSpace(LoginModel.PassWord))
            {
                this.ErrorMessage = "请输入密码！";
                return;
            }
            if (string.IsNullOrWhiteSpace(LoginModel.ValidationCode))
            {
                this.ErrorMessage = "请输入验证码！";
                return;
            }
            if (!string.Equals(LoginModel.ValidationCode,"1234"))
            {
                this.ErrorMessage = "验证码错误，请重新输入！";
                return;
            }
        }
    }
}
