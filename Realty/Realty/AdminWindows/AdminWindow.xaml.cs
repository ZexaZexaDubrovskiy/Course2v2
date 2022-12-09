using System.Windows;
namespace Realty.AdminWindows
{
    public partial class AdminWindow : Window
    {
        //конструктор
        public AdminWindow()
        {
            InitializeComponent();
        }

        //открытие страницы с аккаунтами
        private void AccountPage_Click(object sender, RoutedEventArgs e) => RootFrame.Navigate(new Pages.AccountPage());
        //открытие страницы с недвижимостью
        private void RealtyPage_Click(object sender, RoutedEventArgs e) => RootFrame.Navigate(new Pages.RealtyPage());
        //открытие страницы с транзакциями
        private void TransactionPage_Click(object sender, RoutedEventArgs e) => RootFrame.Navigate(new Pages.TransactionPage());
        //открытие страницы с типом недвижимости
        private void TypeRealtyPage_Click(object sender, RoutedEventArgs e) => RootFrame.Navigate(new Pages.TypeRealtyPage());
        //переход на окно авторизации
        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            BaseWindows.Authorization aut = new BaseWindows.Authorization();
            aut.Show();
            Close();
        }
        //открытие страницы с типом статуса недвижимости
        private void TypeRealtyStatusPage_Click(object sender, RoutedEventArgs e) => RootFrame.Navigate(new Pages.TypeRealtyStatusPage());
    }
}
