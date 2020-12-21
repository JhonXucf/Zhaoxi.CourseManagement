using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Zhaoxi.CourseManagement.Common
{
    public static class PassWordHelper
    {
        public static readonly DependencyProperty PassWordProperty = DependencyProperty.RegisterAttached
            ("PassWord", typeof(string), typeof(PassWordHelper), new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPropertyChanged)));
        public static string GetPassWord(DependencyObject d)
        {
            return d.GetValue(PassWordProperty).ToString();
        }
        public static void SetPassWord(DependencyObject d, string value)
        {
            d.SetValue(PassWordProperty, value);
        }
        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged -= Password_PasswordChanged;
            if (!_IsUpdated)
            {
                password.Password = e.NewValue?.ToString();
            }
            password.PasswordChanged += Password_PasswordChanged;
        }
        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached
           ("Attach", typeof(bool), typeof(PassWordHelper), new FrameworkPropertyMetadata(default(bool), new PropertyChangedCallback(OnAttached)));
        public static bool GetAttach(DependencyObject d)
        {
            return (bool)d.GetValue(AttachProperty);
        }
        public static void SetAttach(DependencyObject d, bool value)
        {
            d.SetValue(AttachProperty, value);
        }
        public static void OnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged += Password_PasswordChanged;
        }
        static bool _IsUpdated = false;
        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            _IsUpdated = true;
            SetPassWord(passwordBox, passwordBox.Password);
            _IsUpdated = false;
        }
    }
}
