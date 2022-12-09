using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Realty.Pages
{
    public partial class AccountPage : Page
    {
        //конструктор
        public AccountPage()
        {
            InitializeComponent();

            UpdateGrid(null);
            AccountGridDlgLoad(false, "");
            DataContext = this;
            AccountGrid.ItemsSource = SourceCore.MyBase.Accounts.ToList();
        }

        private int DlgMode = -1;
        public Base.Accounts SelectedAccount;
        public ObservableCollection<Base.Accounts> Account;

        //вызов окна изменения записей
        public void AccountGridDlgLoad(bool b, string DlgModeContent)
        {
            if (b == true)
            {
                AccountColumnChange.Width = new GridLength(400);
                AccountGrid.IsHitTestVisible = false;
                AccountLabel.Content = DlgModeContent;
                AccountAddCommitTextBox.Text = DlgModeContent;
                AccountAdd.IsEnabled = false;
                AccountCopy.IsEnabled = false;
                AccountEdit.IsEnabled = false;
                AccountDelete.IsEnabled = false;
            }
            else
            {
                AccountColumnChange.Width = new GridLength(0);
                AccountGrid.IsHitTestVisible = true;
                AccountAdd.IsEnabled = true;
                AccountCopy.IsEnabled = true;
                AccountEdit.IsEnabled = true;
                AccountDelete.IsEnabled = true;
                DlgMode = -1;
            }
        }
        //обновление таблицы
        public void UpdateGrid(Base.Accounts Account)
        {
            if ((Account == null) && (AccountGrid.ItemsSource != null))
                Account = (Base.Accounts)AccountGrid.SelectedItem;

            ObservableCollection<Base.Accounts> Accounts = new ObservableCollection<Base.Accounts>(SourceCore.MyBase.Accounts);
            AccountGrid.ItemsSource = Accounts;
            AccountGrid.SelectedItem = Account;
        }
        //загрузка списка для фильтрации
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();

            for (int i = 0; i < 8; i++)
                Columns.Add(AccountGrid.Columns[i].Header.ToString());
            AccountFilterComboBox.ItemsSource = Columns;
            AccountFilterComboBox.SelectedIndex = 0;

            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in AccountGrid.Columns)
                Column.CanUserSort = false;
        }
        //добавление записи
        private void AccountAdd_Click(object sender, RoutedEventArgs e)
        {
            AccountGridDlgLoad(true, "Добавить аккаунт");
            DataContext = null;
            DlgMode = 0;
        }
        //копирование записи
        private void AccountCopy_Click(object sender, RoutedEventArgs e)
        {
            if (AccountGrid.SelectedItem != null)
            {
                AccountGridDlgLoad(true, "Копировать аккаунт");
                SelectedAccount = (Base.Accounts)AccountGrid.SelectedItem;
                //text
                AccountTextLogin.Text = SelectedAccount.Login;
                AccountTextPassword.Text = SelectedAccount.Password;
                if (SelectedAccount.Admin != null)
                    AccountTextAdmin.Text = SelectedAccount.Admin.ToString();
                else
                    AccountTextAdmin.Text = " ";

                if (SelectedAccount.Phone != null)
                    AccountTextPhone.Text = SelectedAccount.Phone.ToString();
                else
                    AccountTextPhone.Text = " ";


                if (SelectedAccount.PassportNumbers != null)
                    AccountTextPassportNumbers.Text = SelectedAccount.PassportNumbers.ToString();
                else
                    AccountTextPassportNumbers.Text = " ";


                if (SelectedAccount.FIO != null)
                    AccountTextFIO.Text = SelectedAccount.FIO.ToString();
                else
                    AccountTextFIO.Text = " ";


                if (SelectedAccount.email != null)
                    AccountTextEmail.Text = SelectedAccount.email.ToString();
                else
                    AccountTextEmail.Text = " ";
                AccountTextMoney.Text = SelectedAccount.money.ToString();



                DlgMode = 0;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }
        //изменение записи
        private void AccountEdit_Click(object sender, RoutedEventArgs e)
        {
            if (AccountGrid.SelectedItem != null)
            {
                AccountGridDlgLoad(true, "Изменить аккаунт");
                SelectedAccount = (Base.Accounts)AccountGrid.SelectedItem;
                //text
                AccountTextLogin.Text = SelectedAccount.Login;
                AccountTextPassword.Text = SelectedAccount.Password;

                if (SelectedAccount.Admin != null)
                    AccountTextAdmin.Text = SelectedAccount.Admin.ToString();
                else
                    AccountTextAdmin.Text = " ";

                if (SelectedAccount.Phone != null)
                    AccountTextPhone.Text = SelectedAccount.Phone.ToString();
                else
                    AccountTextPhone.Text = " ";


                if (SelectedAccount.PassportNumbers != null)
                    AccountTextPassportNumbers.Text = SelectedAccount.PassportNumbers.ToString();
                else
                    AccountTextPassportNumbers.Text = " ";


                if (SelectedAccount.FIO != null)
                    AccountTextFIO.Text = SelectedAccount.FIO.ToString();
                else
                    AccountTextFIO.Text = " ";


                if (SelectedAccount.email != null)
                    AccountTextEmail.Text = SelectedAccount.email.ToString();
                else
                    AccountTextEmail.Text = " ";

                AccountTextMoney.Text = SelectedAccount.money.ToString();

            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }
        //удаление записи
        private void AccountDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую Account
                    Base.Accounts DeletingAccount = (Base.Accounts)AccountGrid.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (AccountGrid.SelectedIndex < AccountGrid.Items.Count - 1)
                        AccountGrid.SelectedIndex++;
                    else
                    {
                        if (AccountGrid.SelectedIndex > 0)
                            AccountGrid.SelectedIndex--;
                    }
                    Base.Accounts SelectingAccount = (Base.Accounts)AccountGrid.SelectedItem;
                    SourceCore.MyBase.Accounts.Remove(DeletingAccount);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(SelectingAccount);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
        }
        //Добавление списка фильтрации
        private void AccountFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (AccountFilterComboBox.SelectedIndex)
            {
                case 0:
                    AccountGrid.ItemsSource = SourceCore.MyBase.Accounts.Where(q => q.Login.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    AccountGrid.ItemsSource = SourceCore.MyBase.Accounts.Where(q => q.Password.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    AccountGrid.ItemsSource = SourceCore.MyBase.Accounts.Where(q => q.Phone.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    AccountGrid.ItemsSource = SourceCore.MyBase.Accounts.Where(q => q.PassportNumbers.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 4:
                    AccountGrid.ItemsSource = SourceCore.MyBase.Accounts.Where(q => q.FIO.Contains(textbox.Text)).ToList();
                    break;
                case 5:
                    AccountGrid.ItemsSource = SourceCore.MyBase.Accounts.Where(q => q.email.ToString().Contains(textbox.Text)).ToList();
                    break;
            }
        }
        //проверка введенных данных
        public Boolean Proverka()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(AccountTextEmail.Text))
                errors.AppendLine("Введите почту");
            if (string.IsNullOrEmpty(AccountTextPhone.Text))
                errors.AppendLine("Введите номер телефон");
            if (string.IsNullOrEmpty(AccountTextFIO.Text))
                errors.AppendLine("Введите ФИО");
            if (string.IsNullOrEmpty(AccountTextPassportNumbers.Text))
                errors.AppendLine("Введите серию и номер паспорта");

            if (string.IsNullOrEmpty(AccountTextMoney.Text))
                errors.AppendLine("Введите кол-во денег");
            if (string.IsNullOrEmpty(AccountTextLogin.Text))
                errors.AppendLine("Введите логин");
            if (string.IsNullOrEmpty(AccountTextPassword.Text))
                errors.AppendLine("Введите пароль");
            if (string.IsNullOrEmpty(AccountTextAdmin.Text))
                errors.AppendLine("Введите админа/пользователя");

            if (int.TryParse(AccountTextAdmin.Text, out int result) && result >= 0 && result <= 1)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение! От 0 до 1", "Внимание", MessageBoxButton.OK);
                return false;
            }

            if (int.TryParse(AccountTextMoney.Text, out int result1) && result1 > 0 && result1 < 30000000)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение! От 0 до 30000000", "Внимание", MessageBoxButton.OK);
                return false;
            }




            if (!(AccountTextPhone.Text.Length == 11))
            {
                MessageBox.Show("Неверный номер телефона! Формат 89450001122", "Внимание", MessageBoxButton.OK);
                return false;
            }

            for (int i = 0; i < AccountTextPhone.Text.Length; i++)
            {
                if (!(AccountTextPhone.Text[i] >= '0' && AccountTextPhone.Text[i] <= '9'))
                {
                    MessageBox.Show("Неверный номер телефона! Формат 89450001122", "Внимание", MessageBoxButton.OK);
                    return false;
                }
            }


            if (int.TryParse(AccountTextPassportNumbers.Text, out int result2))
            {
                if (!(AccountTextPassportNumbers.Text.Length == 10))
                {
                    MessageBox.Show("Неверный номер паспорта! Формат 1020320160", "Внимание", MessageBoxButton.OK);
                    return false;
                }
            }

            byte charSpace = 0;
            for (int i = 0; i < AccountTextFIO.Text.Length; i++)
            {
                if ((AccountTextFIO.Text[i] >= 'а' && AccountTextFIO.Text[i] <= 'я') || (AccountTextFIO.Text[i] >= 'А' && AccountTextFIO.Text[i] <= 'Я') || (charSpace < 3))
                {
                    if (AccountTextFIO.Text[i].ToString() == " ")
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


            if (!(AccountTextPassportNumbers.Text.Length == 10))
            {
                MessageBox.Show("Неверный номер паспорта! Формат 1020320160", "Внимание", MessageBoxButton.OK);
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(AccountTextEmail.Text);
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
        //Добавление/изменение записей в таблице
        private void AccountAddCommit_Click(object sender, RoutedEventArgs e)
        {
            if (!Proverka())
                return;

            if (DlgMode == 0)
            {
                //text
                var NewAccount = new Base.Accounts();
                NewAccount.Login = AccountTextLogin.Text;
                NewAccount.Password = AccountTextPassword.Text;
                NewAccount.Admin = (byte?)int.Parse(AccountTextAdmin.Text);
                NewAccount.Phone = AccountTextPhone.Text;
                NewAccount.PassportNumbers = int.Parse(AccountTextPassportNumbers.Text);
                NewAccount.FIO = AccountTextFIO.Text;
                NewAccount.email = AccountTextEmail.Text;
                NewAccount.money = (byte?)int.Parse(AccountTextMoney.Text);

                SourceCore.MyBase.Accounts.Add(NewAccount);
                SelectedAccount = NewAccount;
            }
            else
            {
                var EditAccount = new Base.Accounts();
                EditAccount = SourceCore.MyBase.Accounts.First(p => p.idAccount == SelectedAccount.idAccount);
                EditAccount.Login = AccountTextLogin.Text;
                EditAccount.Password = AccountTextPassword.Text;
                EditAccount.Admin = (byte?)int.Parse(AccountTextAdmin.Text);
                EditAccount.Phone = AccountTextPhone.Text;
                EditAccount.PassportNumbers = int.Parse(AccountTextPassportNumbers.Text);
                EditAccount.FIO = AccountTextFIO.Text;
                EditAccount.email = AccountTextEmail.Text;
                EditAccount.money = (byte?)int.Parse(AccountTextMoney.Text);
            }

            try
            {
                SourceCore.MyBase.SaveChanges();
                AccountGridDlgLoad(false, "");
                UpdateGrid(SelectedAccount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //Отмена добавления/изменения записи
        private void AccountAddRollback_Click(object sender, RoutedEventArgs e)
        {
            AccountGridDlgLoad(false, "");
            UpdateGrid(SelectedAccount);
        }
    }
}
