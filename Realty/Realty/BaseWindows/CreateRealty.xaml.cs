using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace Realty.BaseWindows
{
    public partial class CreateRealty : Window
    {
        private Base.Accounts User;
        private Base.Realty currentRealty;
        //конструктор
        public CreateRealty(Base.Accounts User, Base.Realty currentRealty)
        {
            InitializeComponent();

            typeRealty.ItemsSource = SourceCore.MyBase.TypeRealty.ToList().Where(T => T.idTypeRealty != 7);
            typeRealtyStatus.ItemsSource = SourceCore.MyBase.StatusRealty.ToList();


            DataContext = this;
            this.User = User;
            this.currentRealty = currentRealty;

            if (currentRealty != null)
            {
                Price.Text = $"{ currentRealty.Price}";
                SquareMeters.Text = $"{ currentRealty.Square}";
                Floor.Text = $"{ currentRealty.Floor}";
                Address.Text = $"{ currentRealty.Address}";
                Rooms.Text = $"{ currentRealty.Rooms}";
                img.Text = $"{ currentRealty.img}";
                typeRealty.SelectedIndex = (int)currentRealty.IdTypeRealty - 1;
                typeRealtyStatus.SelectedIndex = (int)currentRealty.idStatusRealty - 1;
                TextBoxEvent.Text = "Обновить";
            }
            else
            {
                Price.Opacity = 0.5;
                Floor.Opacity = 0.5;
                Rooms.Opacity = 0.5;
                img.Opacity = 0.5;
                SquareMeters.Opacity = 0.5;
                Address.Opacity = 0.5;
                Price.Text = "Цена";
                Floor.Text = "Этаж\\Этажи";
                Rooms.Text = "Комнат";
                img.Text = "Изображение";
                Address.Text = "Адрес";
                SquareMeters.Text = "кв. метры";
                typeRealty.SelectedIndex = 0;
                typeRealtyStatus.SelectedIndex = 0;
            }
        }
        //переход на домашнее окно
        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account(User);
            account.Show();
            Close();
        }
        //добавление/изменение записи в таблице
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Proverka())
                return;

            if (currentRealty != null)
            {
                string path = $"{currentRealty.img}";
                bool fileExist = File.Exists(path);
                if (!fileExist)
                {
                    path = @"D:\4is2\КУРСОВАЯ 2\Realty\Realty\Images\error2.png";
                    img.Text = path;
                }
            }
            else
            {
                string path = img.Text;
                bool fileExist = File.Exists(path);
                if (!fileExist)
                {
                    path = @"D:\4is2\КУРСОВАЯ 2\Realty\Realty\Images\error2.png";
                    img.Text = path;
                }
            }
            

            if (currentRealty != null)
            {
                var EditRealty = new Base.Realty();
                EditRealty = SourceCore.MyBase.Realty.First(p => p.IdRealty == currentRealty.IdRealty);
                EditRealty.Price = int.Parse(Price.Text);
                EditRealty.Square = (decimal?)double.Parse(SquareMeters.Text);
                EditRealty.Floor = (byte?)int.Parse(Floor.Text);
                EditRealty.Address = Address.Text;
                EditRealty.Rooms = (byte?)int.Parse(Rooms.Text);
                EditRealty.img = img.Text;
                EditRealty.IdOwnerAccount = User.idAccount;
                EditRealty.IdTypeRealty = typeRealty.SelectedIndex + 1;
                EditRealty.idStatusRealty = typeRealtyStatus.SelectedIndex + 1;
            }
            else
            {
                var newRealty = new Base.Realty();
                newRealty.Price = (byte?)int.Parse(Price.Text);
                newRealty.Square = (decimal?)double.Parse(SquareMeters.Text);
                newRealty.Floor = (byte?)int.Parse(Floor.Text);
                newRealty.Address = Address.Text;
                newRealty.Rooms = (byte?)int.Parse(Rooms.Text);
                newRealty.img = img.Text;
                newRealty.IdOwnerAccount = User.idAccount;
                newRealty.IdTypeRealty = typeRealty.SelectedIndex + 1;
                newRealty.idStatusRealty = typeRealtyStatus.SelectedIndex + 1;

                SourceCore.MyBase.Realty.Add(newRealty);
            }

            try
            {
                SourceCore.MyBase.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Account acc = new Account(User);
            acc.Show();
            Close();
        }
        //подсказка для адреса
        private void Address_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Address.Text == "Адрес")
            {
                Address.Opacity = 1;
                Address.Text = "";
            }
        }
        //подсказка для адреса
        private void Address_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Address.Text == "")
            {
                Address.Opacity = 0.5;
                Address.Text = "Адрес";
            }
        }
        //подсказка для изображения
        private void img_LostFocus(object sender, RoutedEventArgs e)
        {
            if (img.Text == "")
            {
                img.Opacity = 0.5;
                img.Text = "Изображение";
            }
        }
        //подсказка для изображения
        private void img_GotFocus(object sender, RoutedEventArgs e)
        {
            if (img.Text == "Изображение")
            {
                img.Opacity = 1;
                img.Text = "";
            }
        }
        //подсказка для этажа//этажей
        private void Floor_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Floor.Text == "Этаж\\Этажи")
            {
                Floor.Opacity = 1;
                Floor.Text = "";
            }
        }
        //подсказка для этажа//этажей
        private void Floor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Floor.Text == "")
            {
                Floor.Opacity = 0.5;
                Floor.Text = "Этаж\\Этажи";
            }
        }
        //подсказка для комнат
        private void Rooms_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Rooms.Text == "Комнат")
            {
                Rooms.Opacity = 1;
                Rooms.Text = "";
            }
        }
        //подсказка для комнат
        private void Rooms_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Rooms.Text == "")
            {
                Rooms.Opacity = 0.5;
                Rooms.Text = "Комнат";
            }
        }
        //подсказка для цены
        private void Price_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Price.Text == "Цена")
            {
                Price.Opacity = 1;
                Price.Text = "";
            }
        }
        //подсказка для цены
        private void Price_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Price.Text == "")
            {
                Price.Opacity = 0.5;
                Price.Text = "Цена";
            }
        }
        //подсказка для кв. метров
        private void SquareMeters_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SquareMeters.Text == "кв. метры")
            {
                SquareMeters.Opacity = 1;
                SquareMeters.Text = "";
            }
        }
        //подсказка для кв. метров
        private void SquareMeters_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SquareMeters.Text == "")
            {
                SquareMeters.Opacity = 0.5;
                SquareMeters.Text = "кв. метры";
            }
        }
        //проверка введенных значений
        public Boolean Proverka()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(Address.Text))
                errors.AppendLine("Введите адрес");
            if (string.IsNullOrEmpty(SquareMeters.Text))
                errors.AppendLine("Введите кв. метры");
            if (string.IsNullOrEmpty(Floor.Text))
                errors.AppendLine("Введите этаж или их количество");
            if (string.IsNullOrEmpty(Rooms.Text))
                errors.AppendLine("Введите количество комнат");
            if (string.IsNullOrEmpty(Price.Text))
                errors.AppendLine("Введите цену");
            if (string.IsNullOrEmpty(img.Text))
                errors.AppendLine("Введите путь до изображения");


            if (!(int.TryParse(Floor.Text, out int result1)))
            {
                MessageBox.Show("Некорректное значение этажа//этажей", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (!(int.TryParse(Rooms.Text, out int result2)))
            {
                MessageBox.Show("Некорректное значение комнат", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (!(int.TryParse(Price.Text, out int result3)) || result3 < 0 || result3 > 100000000)
            {
                MessageBox.Show("Некорректное значение цены", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (!(double.TryParse(SquareMeters.Text, out double result4)))
            {
                MessageBox.Show("Некорректное значение кв. метров", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (Address.Text == "Адрес")
            {
                MessageBox.Show("Некорректное значение адреса", "Внимание", MessageBoxButton.OK);
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
