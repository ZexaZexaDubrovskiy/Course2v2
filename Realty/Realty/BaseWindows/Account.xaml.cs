using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Realty.BaseWindows
{
    public partial class Account : Window
    {
        private Base.Accounts User;
        //конструктор
        public Account(Base.Accounts User)
        {
            InitializeComponent();
            this.User = User;
            DataContext = this;
            RealtyList.ItemsSource = SourceCore.MyBase.Realty.ToList().Where(U => User.idAccount == U.IdOwnerAccount);

            if (User.money != null)
                userMoney.Content = $"Money: {(int)User.money}";
            if (User.FIO != null)
                userLogin.Content = $"{User.FIO.Split()[0]}";
            if (User.FIO != null)
                userFIO.Text = $"{User.FIO}";
            if (User.FIO == null)
                userLogin.Content = $"{User.idAccount}";
            if (User.Phone != null)
                userMobilePhone.Text = User.Phone.ToString();
            if (User.email != null)
                userMail.Text = User.email;
            if (User.PassportNumbers != null)
                userPasport.Text = User.PassportNumbers.ToString();
        }
        //обновление личной недвижимости
        private void update()
        {
            RealtyList.ItemsSource = SourceCore.MyBase.Realty.ToList().Where(U => User.idAccount == U.IdOwnerAccount);
        }
        //сохранение информации о себе
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Proverka())
                return;

            var EditAccount = new Base.Accounts();
            EditAccount = SourceCore.MyBase.Accounts.First(p => p.idAccount == User.idAccount);

            EditAccount.Phone = userMobilePhone.Text;
            EditAccount.PassportNumbers = int.Parse(userPasport.Text);
            EditAccount.email = userMail.Text;
            EditAccount.FIO = userFIO.Text;


            SourceCore.MyBase.SaveChanges();
            userLogin.Content = $"{EditAccount.FIO.Split()[0]}";
            MessageBox.Show("Сохранено", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //переход на окно авторизации
        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            auth.Show();
            Close();
        }
        //переход на домашнее окно
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(User);
            home.Show();
            Close();
        }
        //переход на окно добавление недвижимости
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            CreateRealty cRealty = new CreateRealty(User, null);
            cRealty.Show();
            Close();
        }
        //переход на окно изменение записи
        private void RealtyList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Base.Realty currentRealty = (Base.Realty)RealtyList.SelectedItem; //DataBase.Accounts.Where(U => U.idAccount);

            CreateRealty UpdateRealty = new CreateRealty(User, currentRealty);
            UpdateRealty.Show();
            Close();
        }
        //удаление записи
        private void RealtyList_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Удалить объявление?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    Base.Realty DeletingRealty = (Base.Realty)RealtyList.SelectedItem;
                    SourceCore.MyBase.Realty.Remove(DeletingRealty);
                    SourceCore.MyBase.SaveChanges();
                    update();
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
        }
        //переход на окно с добавление денег
        private void addMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            addMoneyWindow addMoney = new addMoneyWindow(User);
            addMoney.Show();
            Close();
        }
        //проверка введенных значений
        public Boolean Proverka()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(userMail.Text))
                errors.AppendLine("Введите почту");
            if (string.IsNullOrEmpty(userMobilePhone.Text))
                errors.AppendLine("Введите номер телефон");
            if (string.IsNullOrEmpty(userFIO.Text))
                errors.AppendLine("Введите ФИО");
            if (string.IsNullOrEmpty(userPasport.Text))
                errors.AppendLine("Введите серию и номер паспорта");

            if (!(userMobilePhone.Text.Length == 11))
            {
                MessageBox.Show("Неверный номер телефона! Формат 89450001122", "Внимание", MessageBoxButton.OK);
                return false;
            }

            for (int i = 0; i < userMobilePhone.Text.Length; i++)
            {
                if (!(userMobilePhone.Text[i] >= '0' && userMobilePhone.Text[i] <= '9'))
                {
                    MessageBox.Show("Неверный номер телефона! Формат 89450001122", "Внимание", MessageBoxButton.OK);
                    return false;
                }
            }


            if (int.TryParse(userPasport.Text, out int result2))
            {
                if (!(userPasport.Text.Length == 10))
                {
                    MessageBox.Show("Неверный номер паспорта! Формат 1020320160", "Внимание", MessageBoxButton.OK);
                    return false;
                }
            }

            byte charSpace = 0;
            for (int i = 0; i < userFIO.Text.Length; i++)
            {
                if ((userFIO.Text[i] >= 'а' && userFIO.Text[i] <= 'я') || (userFIO.Text[i] >= 'А' && userFIO.Text[i] <= 'Я') || (charSpace < 3))
                {
                    if (userFIO.Text[i].ToString() == " ")
                    {
                        charSpace++;
                    }
                }
                else
                {
                    MessageBox.Show("ФИО некорректно", "Внимание", MessageBoxButton.OK);
                    return false;
                }
            }


            if (!(userPasport.Text.Length == 10))
            {
                MessageBox.Show("Неверный номер паспорта! Формат 1020320160", "Внимание", MessageBoxButton.OK);
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(userMail.Text);
            }
            catch
            {
                MessageBox.Show("Неверный email");
                return false;
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }
            return true;
        }

    }
}
