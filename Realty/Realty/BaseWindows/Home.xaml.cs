using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Realty.BaseWindows
{
    public partial class Home : Window
    {
        private Base.RealtyEntities DataBase;
        private Base.Accounts User;
        //конструктор
        public Home(Base.Accounts User)
        {
            InitializeComponent();

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
            this.User = User;

            centerItem = SourceCore.MyBase.Realty.OrderByDescending(d => d.Price).FirstOrDefault(r => r.idStatusRealty == 1 && r.IdOwnerAccount != User.idAccount);
            rightItem = SourceCore.MyBase.Realty.Where(u => u.Price >= 10000).FirstOrDefault(r => r.idStatusRealty == 1 && r.IdOwnerAccount != User.idAccount);
            leftItem = SourceCore.MyBase.Realty.Where(u => u.Price >= 0 && u.Price < 100000).FirstOrDefault(r => r.idStatusRealty == 1 && r.IdOwnerAccount != User.idAccount);
            LeftItem.Source = BitmapFrame.Create(new Uri(leftItem.img));
            RightItem.Source = BitmapFrame.Create(new Uri(rightItem.img));
            CenterItem.Source = BitmapFrame.Create(new Uri(centerItem.img));
        }

        private Base.Realty leftItem; 
        private Base.Realty rightItem;
        private Base.Realty centerItem;
        //вывод центрального изображения
        private void CenterItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RealtyItem rItem = new RealtyItem(User, centerItem);
            rItem.Show();
            Close();
        }
        //вывод изображения слева
        private void LeftItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RealtyItem rItem = new RealtyItem(User, leftItem);
            rItem.Show();
            Close();
        }
        //вывод изображения справа
        private void RightItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RealtyItem rItem = new RealtyItem(User, rightItem);
            rItem.Show();
            Close();
        }
        //переход на окно аккаунт
        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            Account userAccount = new Account(User);
            userAccount.Show();
            Close();
        }
        //переход на окно с недвижимосьтю других пользователей
        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            var user = SourceCore.MyBase.Accounts.First(u => u.idAccount == User.idAccount);
            purchaseWindow buyRealty = new purchaseWindow(user);
            buyRealty.Show();
            Close();
        }
        //переход на домашнее окно
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(User);
            home.Show();
            Close();
        }
        //переход на окно с новостями
        private void NewsLabel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            learnWindow learnWindows = new learnWindow(User, 1);
            learnWindows.Show();
            Close();
        }
        //изменение цвета для label
        private void NewsLabel_MouseEnter(object sender, MouseEventArgs e) => NewsLabel.Foreground = Brushes.Black;
        //изменение цвета для label
        private void NewsLabel_MouseLeave(object sender, MouseEventArgs e) => NewsLabel.Foreground = Brushes.White;
        //переход на окно с комментариями
        private void commentsLabel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            learnWindow learnWindows = new learnWindow(User, 2);
            learnWindows.Show();
            Close();
        }
        //изменение цвета для label
        private void commentsLabel_MouseEnter(object sender, MouseEventArgs e) => commentsLabel.Foreground = Brushes.Black;
        //изменение цвета для label
        private void commentsLabel_MouseLeave(object sender, MouseEventArgs e) => commentsLabel.Foreground = Brushes.White;
        //переход на окно с информацией о проекте
        private void aboutLabel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            learnWindow learnWindows = new learnWindow(User, 3);
            learnWindows.Show();
            Close();
        }
        //изменение цвета для label
        private void aboutLabel_MouseEnter(object sender, MouseEventArgs e) => aboutLabel.Foreground = Brushes.Black;
        //изменение цвета для label
        private void aboutLabel_MouseLeave(object sender, MouseEventArgs e) => aboutLabel.Foreground = Brushes.White;

    }
}
