using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Realty.BaseWindows
{
    public partial class RealtyItem : Window
    {
        private Base.Accounts _user;
        private Base.Realty currentRealty;
        private Base.Accounts owner;
        //конструктор
        public RealtyItem(Base.Accounts User, Base.Realty currentRealty)
        {
            InitializeComponent();

            DataContext = this;
            _user = User;
            this.currentRealty = currentRealty;

            price.Text = $"Цена: {currentRealty.Price}";
            square.Text = $"Кв. метры: {currentRealty.Square}";
            Floor.Text = $"Этаж\\Этажей: {currentRealty.Floor}";
            rooms.Text = $"Комнат: {currentRealty.Rooms}";
            address.Text = $"Адрес: {currentRealty.Address}";

            string path = $"{currentRealty.img}";
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                img.Source = BitmapFrame.Create(new Uri(path));
            }
            else
            {
                path = @"D:\4is2\КУРСОВАЯ 2\Realty\Realty\Images\error2.png";
                img.Source = BitmapFrame.Create(new Uri(path));
            }

            var resultType = SourceCore.MyBase.TypeRealty.SingleOrDefault(T => T.idTypeRealty == currentRealty.IdTypeRealty);
            typeRealtys.Text = $"Тип: {resultType.Type}";
            owner = SourceCore.MyBase.Accounts.SingleOrDefault(T => T.idAccount == currentRealty.IdOwnerAccount);
            Owner.Text = $"Владелец: {owner.FIO}";

            var resultStatus = SourceCore.MyBase.StatusRealty.SingleOrDefault(T => T.idStatusRealty == currentRealty.idStatusRealty);
            Status.Text = $"Статус: {resultStatus.Status}";
        }
        //покупка недвижимости
        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            var user = SourceCore.MyBase.Accounts.First(u => u.idAccount == _user.idAccount);

            //transaction
            var NewTransaction = new Base.Transaction();
            NewTransaction.IdTransactionRealty = currentRealty.IdRealty;
            NewTransaction.IdTransactionTypeRealty = currentRealty.IdTypeRealty;
            NewTransaction.TransactionAccountOwner = (int)currentRealty.IdOwnerAccount;
            NewTransaction.TransactionAccountBuyer = user.idAccount;
            NewTransaction.PriceTransaction = (int)currentRealty.Price;
            NewTransaction.Date = DateTime.Now;

            if (user.money >= currentRealty.Price)
            {
                NewTransaction.Status = "Одобренно";

                //Sell and Buy realty
                owner.money += currentRealty.Price;
                user.money -= currentRealty.Price;
                currentRealty.IdOwnerAccount = user.idAccount;
                currentRealty.idStatusRealty = 2;

                MessageBox.Show("Поздравляем с покупкой!", "Поздравление", MessageBoxButton.OK);
            }
            else
            {
                NewTransaction.Status = "Отклоненно";
                MessageBox.Show("У вас не хватает денег!", "Внимание", MessageBoxButton.OK);
            }

            SourceCore.MyBase.Transaction.Add(NewTransaction);
            SourceCore.MyBase.SaveChanges();
            purchaseWindow pWindows = new purchaseWindow(user);
            pWindows.Show();
            Close();
        }
        //переход на окно с недвижимостью
        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {
            purchaseWindow pWindows = new purchaseWindow(_user);
            pWindows.Show();
            Close();
        }
    }
}
