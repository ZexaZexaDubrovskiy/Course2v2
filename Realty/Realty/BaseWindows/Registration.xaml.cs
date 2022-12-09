using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Realty.BaseWindows
{
    public partial class Registration : Window
    {
        private Base.RealtyEntities Database;
        //конструктор
        public Registration()
        {
            InitializeComponent();
            userNewLogin.Opacity = 0.5;
            userNewLogin.Text = "Login";
            Database = SourceCore.MyBase;
        }
        //подсказка для логина
        private void userNewLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userNewLogin.Text == "Login")
            {
                userNewLogin.Opacity = 1;
                userNewLogin.Text = "";
            }
        }
        //подсказка для логина
        private void userNewLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (userNewLogin.Text == "")
            {
                userNewLogin.Opacity = 0.5;
                userNewLogin.Text = "Login";
            }
        }
        //переход на окно авторизации
        private void userHaveAccount_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Authorization AuthorizationWindow = new Authorization();
            Close();
            AuthorizationWindow.Show();
        }

        //изменение цвета label
        private void userHaveAccount_MouseEnter(object sender, MouseEventArgs e) => userHaveAccount.Foreground = Brushes.Black;

        //изменение цвета label
        private void userHaveAccount_MouseLeave(object sender, MouseEventArgs e) => userHaveAccount.Foreground = Brushes.White;
        //регистрация пользователя
        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum5Chars = new Regex(@".{4,}");
           
            var password = userNewConfirmPassword.Password != "" ? userNewConfirmPassword.Password : userNewPassword.Text;
            password.Replace(" ", "");
            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum5Chars.IsMatch(password);

            var login = userNewLogin.Text;
            login.Replace(" ", "");

            var uniq = SourceCore.MyBase.Accounts.FirstOrDefault(p => p.Login == login);

            if (isValidated && login != null && login != "" && uniq == null)
            {
                Capcha capcha = new Capcha(login, password);
                capcha.Show();
                Close();
            }
            else
            {
                if (uniq != null)
                {
                    System.Windows.MessageBox.Show("Данный логин занят!","Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    System.Windows.MessageBox.Show("Пароль должен содержать заглавную букву, цифру и быть не менее 4 символов!",
                        "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        //скрыть/показать пароль
        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            
            String Password = userNewConfirmPassword.Password;
            Visibility Visibility = userNewConfirmPassword.Visibility;
            double Width = userNewConfirmPassword.ActualWidth;

            buttonText.Text = Visibility == Visibility.Visible ? "Скрыть" : "Показать";
            
            userNewConfirmPassword.Password = userNewPassword.Text;
            userNewConfirmPassword.Visibility = userNewPassword.Visibility;
            userNewConfirmPassword.Width = userNewPassword.Width;
            
            userNewPassword.Text = Password;
            userNewPassword.Visibility = Visibility;
            userNewPassword.Width = Width;
        }
    }
}
