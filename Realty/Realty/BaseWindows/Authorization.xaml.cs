using Realty.AdminWindows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Realty.BaseWindows
{
    public partial class Authorization : Window
    {
        private Base.RealtyEntities DataBase;
        //конструктор
        public Authorization()
        {
            InitializeComponent();
            userLogin.Opacity = 0.5;
            userLogin.Text = "Login";

            try
            {
                DataBase = new Base.RealtyEntities();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения приложения.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }

        }
        //подсказка для логина
        private void userLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userLogin.Text == "Login")
            {
                userLogin.Opacity = 1;
                userLogin.Text = "";
            }
        }
        //подсказка для логина
        private void userLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (userLogin.Text == "")
            {
                userLogin.Opacity = 0.5;
                userLogin.Text = "Login";
            }
        }
        //изменение цвета для label
        private void ButtonSignUp_MouseLeave(object sender, MouseEventArgs e) => ButtonSignUp.Foreground = Brushes.White;
        //изменение цвета для label
        private void ButtonSignUp_MouseEnter(object sender, MouseEventArgs e) => ButtonSignUp.Foreground = Brushes.Black;
        //переход на окно с регистрацией
        private void ButtonSignUp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Registration RegistrationWindow = new Registration();
            Close();
            RegistrationWindow.Show();
        }
        //авторизация
        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            var password = userConfirmPassword.Password != "" ? userConfirmPassword.Password : userPassword.Text;
            Base.Accounts User = DataBase.Accounts.SingleOrDefault(U => U.Login == userLogin.Text && U.Password == password);

            if (User != null)
            {
                if (User.Admin == 1)
                {
                    AdminWindow window = new AdminWindow();
                    window.Show();
                    Close();
                }
                else
                {
                    Home window = new Home(User);
                    window.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Неверно указан логин и/или пароль!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            };
        }
        //скрыть/показать пароль
        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            String Password = userConfirmPassword.Password;
            Visibility Visibility = userConfirmPassword.Visibility;
            double Width = userConfirmPassword.ActualWidth;

            textButton.Text = Visibility == Visibility.Visible ? "Скрыть" : "Показать";

            userConfirmPassword.Password = userPassword.Text;
            userConfirmPassword.Visibility = userPassword.Visibility;
            userConfirmPassword.Width = userPassword.Width;

            userPassword.Text = Password;
            userPassword.Visibility = Visibility;
            userPassword.Width = Width;
        }
    }
}
