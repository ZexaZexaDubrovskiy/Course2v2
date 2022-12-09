using System.Windows;

namespace Realty.BaseWindows
{
    public partial class learnWindow : Window
    {
        private Base.Accounts User;
        //конструктор
        public learnWindow(Base.Accounts User, int valueText)
        {
            InitializeComponent();
            this.User = User;

            if (valueText == 1)
            {
                Text.Content = "Пока нет новостей.";
            } else if (valueText == 2)
            {
                Text.Content = "Пока нет отзывов.";
            } else
            {
                Text.Content = "Здесь вы можете продать или купить недвижимость!";
            }


        }
        //переход на домашнее окно
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(User);
            home.Show();
            Close();
        }
    }
}
