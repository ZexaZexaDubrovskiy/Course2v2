using System.Linq;
using System.Windows;

namespace Realty.BaseWindows
{
    public partial class addMoneyWindow : Window
    {
        private Base.Accounts User;
        //конструктор
        public addMoneyWindow(Base.Accounts User)
        {
            InitializeComponent();
            this.User = User;
        }
        //переход на домашнее окно
        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(User);
            home.Show();
            Close();
        }
        //добавление денег
        private void addMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Money.Text, out int result) && result > 0 && result < 100000000) {


                var EditAccount = new Base.Accounts();
                EditAccount = SourceCore.MyBase.Accounts.First(p => p.idAccount == User.idAccount);
                EditAccount.money += result;
                SourceCore.MyBase.SaveChanges();
                Account acc = new Account(EditAccount);
                acc.Show();
                Close();
            } else
            {
                MessageBox.Show("Введено некорректное значение! Максимум: 100000000", "Внимание", MessageBoxButton.OK);
            }
        }
    }
}
