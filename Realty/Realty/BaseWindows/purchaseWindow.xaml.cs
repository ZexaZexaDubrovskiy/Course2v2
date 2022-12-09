using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Realty.BaseWindows
{
    public partial class purchaseWindow : Window
    {
        private Base.Accounts User;
        public ObservableCollection<string> list = new ObservableCollection<string>();
        //конструктор
        public purchaseWindow(Base.Accounts User)
        {
            InitializeComponent();

            this.User = User;

            typeRealtyComboBox.ItemsSource = SourceCore.MyBase.TypeRealty.ToList();

            RealtyList.ItemsSource = SourceCore.MyBase.Realty.ToList().Where(U =>
                User.idAccount != U.IdOwnerAccount
                && U.Price >= 0
                && U.Price <= 1000000000
                && U.Square >= 0
                && U.Square <= 1000000000
                && U.idStatusRealty == 1
                );
            if (User.FIO != null)
            {
                nameUser.Text = User.FIO.Split()[0];
            }else
            {
                nameUser.Text = $"{User.idAccount}";
            }
        }
        //переход на окно аккаунт
        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            Account acc = new Account(User);
            acc.Show();
            Close();
        }
        //переход на домашнее окно
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(User);
            home.Show();
            Close();
        }
        //вывод недвижимости пользователей
        private void RealtyList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Base.Realty currentRealty = (Base.Realty)RealtyList.SelectedItem;

            RealtyItem rItem = new RealtyItem(User, currentRealty);
            rItem.Show();
            Close();
        }

        //фильтрация недвижимости
        private void update()
        {
            if (User != null)
            {
                if (_countRoom == 0 && _typeRealty == 6)
                {
                    RealtyList.ItemsSource = SourceCore.MyBase.Realty.ToList().Where(U =>
                    User.idAccount != U.IdOwnerAccount
                    && U.Price >= _startPrice
                    && U.Price <= _endPrice
                    && U.Square >= _startSquare
                    && U.Square <= _endSquare
                    && U.idStatusRealty == 1
                    && U.Address.Contains(typeRealtyFilterTextBox.Text)
                    );
                }else if (_countRoom == 0 && _typeRealty != 6)
                {
                    RealtyList.ItemsSource = SourceCore.MyBase.Realty.ToList().Where(U =>
                    User.idAccount != U.IdOwnerAccount
                    && U.Price >= _startPrice
                    && U.Price <= _endPrice
                    && U.Square >= _startSquare
                    && U.Square <= _endSquare
                    && U.IdTypeRealty == _typeRealty + 1
                    && U.idStatusRealty == 1
                    && U.Address.Contains(typeRealtyFilterTextBox.Text)
                    );
                }
                else
                {
                    if (_typeRealty == 6)
                    {
                        RealtyList.ItemsSource = SourceCore.MyBase.Realty.ToList().Where(U =>
                    User.idAccount != U.IdOwnerAccount
                    && U.Price >= _startPrice
                    && U.Price <= _endPrice
                    && U.Square >= _startSquare
                    && U.Square <= _endSquare
                    && U.idStatusRealty == 1
                    && U.Rooms == _countRoom
                    && U.Address.Contains(typeRealtyFilterTextBox.Text)
                    );
                    }
                    else
                    {
                        RealtyList.ItemsSource = SourceCore.MyBase.Realty.ToList().Where(U =>
                        User.idAccount != U.IdOwnerAccount
                        && U.Price >= _startPrice
                        && U.Price <= _endPrice
                        && U.Square >= _startSquare
                        && U.Square <= _endSquare
                        && U.IdTypeRealty == _typeRealty + 1
                        && U.idStatusRealty == 1
                        && U.Rooms == _countRoom
                        && U.Address.Contains(typeRealtyFilterTextBox.Text)
                        );
                    }
                }

            }

        }
        //переменные
        private int _startPrice = 0;
        private int _endPrice = 100000000;
        private int _startSquare = 0;
        private int _endSquare = 100000000;
        private int _countRoom = 0;
        private int _typeRealty = 6;
        //свойства
        private int StartPrice
        {
            get
            {
                return _startPrice;
            }
            set
            {
                if (_startPrice < 0) { value = 0; }
                if (_startPrice > _endPrice) { value = _endPrice - 1; }

                if (value != _startPrice)
                {
                    _startPrice = value;
                }
            }
        }
        private int EndPrice
        {
            get
            {
                return _endPrice;
            }
            set
            {
                if (_endPrice < _startPrice) { value = _startPrice + 1; }

                if (value != _endPrice)
                {
                    _endPrice = value;
                }
            }
        }
        private int StartSquare
        {
            get
            {
                return _startSquare;
            }
            set
            {
                if (_startSquare < 0) { value = 0; }
                if (_startSquare > _endSquare) { value = _endSquare - 1; }

                if (value != _startSquare)
                {
                    _startSquare = value;
                }
            }
        }
        private int EndSquare
        {
            get
            {
                return _endSquare;
            }
            set
            {
                if (_endSquare < _startSquare) { value = _startSquare + 1; }

                if (value != _endSquare)
                {
                    _endSquare = value;
                }
            }
        }
        private int CountRoom
        {
            get
            {
                return _countRoom;
            }
            set
            {
                if (value != _countRoom)
                {
                    _countRoom = value;
                }
            }
        }
        //фильтрация по начальной цене 
        private void inPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(inPriceTextBox.Text, out int result))
            {
                StartPrice = result;
                update();
            }
        }
        //фильтрация по конечной цене
        private void fiPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(fiPriceTextBox.Text, out int result))
            {
                EndPrice = result;
                update();
            }
        }
        //фильтрация по начальным кв. метрам
        private void inSquareTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(inSquareTextBox.Text, out int result))
            {
                StartSquare = result;
                update();
            }
        }
        //фильтрация по конечным кв. метрам
        private void fiSquareTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(fiSquareTextBox.Text, out int result))
            {
                EndSquare = result;
                update();
            }
        }
        //фильтрация по количеству комнат
        private void countRoomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(countRoomTextBox.Text, out int result))
            {
                CountRoom = result;
                update();
            }
            else
            {
                CountRoom = 0;
                update();
            }
        }
        //фильтрация по конечной цене
        private void typeRealtyTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _typeRealty = typeRealtyComboBox.SelectedIndex;
            update();
        }
        //фильтрация по адресу
        private void typeRealtyFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            update();
        }
    }
}
