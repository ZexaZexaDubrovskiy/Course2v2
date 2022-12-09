using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Realty.Pages
{
    public partial class RealtyPage : Page
    {
        //конструктор
        public RealtyPage()
        {
            InitializeComponent();

            UpdateGrid(null);
            RealtyGridDlgLoad(false, "");
            DataContext = this;
            RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.ToList();
            RealtyTextIdTypeRealty.ItemsSource = SourceCore.MyBase.TypeRealty.ToList();
            RealtyTextidStatusRealty.ItemsSource = SourceCore.MyBase.StatusRealty.ToList();
        }

        //new
        private int DlgMode = -1;
        public Base.Realty SelectedRealty;
        public ObservableCollection<Base.Realty> Realty;
        //вызов окна изменения записей
        public void RealtyGridDlgLoad(bool b, string DlgModeContent)
        {
            if (b == true)
            {
                RealtyColumnChange.Width = new GridLength(400);
                RealtyGrid.IsHitTestVisible = false;
                RealtyLabel.Content = DlgModeContent;
                RealtyAddCommitTextBox.Text = DlgModeContent;
                RealtyAdd.IsEnabled = false;
                RealtyCopy.IsEnabled = false;
                RealtyEdit.IsEnabled = false;
                RealtyDelete.IsEnabled = false;
            }
            else
            {
                RealtyColumnChange.Width = new GridLength(0);
                RealtyGrid.IsHitTestVisible = true;
                RealtyAdd.IsEnabled = true;
                RealtyCopy.IsEnabled = true;
                RealtyEdit.IsEnabled = true;
                RealtyDelete.IsEnabled = true;
                DlgMode = -1;
            }
        }
        //обновление таблицы
        public void UpdateGrid(Base.Realty Realty)
        {
            if ((Realty == null) && (RealtyGrid.ItemsSource != null))
                Realty = (Base.Realty)RealtyGrid.SelectedItem;

            ObservableCollection<Base.Realty> Realtys = new ObservableCollection<Base.Realty>(SourceCore.MyBase.Realty);
            RealtyGrid.ItemsSource = Realtys;
            RealtyGrid.SelectedItem = Realty;
        }
        //загрузка списка для фильтрации
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();

            for (int i = 0; i < 8; i++)
                Columns.Add(RealtyGrid.Columns[i].Header.ToString());
            RealtyFilterComboBox.ItemsSource = Columns;
            RealtyFilterComboBox.SelectedIndex = 0;

            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in RealtyGrid.Columns)
                Column.CanUserSort = false;
        }
        //добавление записи
        private void RealtyAdd_Click(object sender, RoutedEventArgs e)
        {
            RealtyGridDlgLoad(true, "Добавить недвижимость");
            DataContext = null;
            DlgMode = 0;
        }
        //копирование записи
        private void RealtyCopy_Click(object sender, RoutedEventArgs e)
        {
            if (RealtyGrid.SelectedItem != null)
            {
                RealtyGridDlgLoad(true, "Копировать недвижимость");
                SelectedRealty = (Base.Realty)RealtyGrid.SelectedItem;

                //text
                RealtyTextPrice.Text = SelectedRealty.Price.ToString();
                RealtyTextSquare.Text = SelectedRealty.Square.ToString();
                RealtyTextFloor.Text = SelectedRealty.Floor.ToString();
                RealtyTextRooms.Text = SelectedRealty.Rooms.ToString();
                RealtyTextAddress.Text = SelectedRealty.Address;
                RealtyTextIdOwnerAccount.Text = SelectedRealty.IdOwnerAccount.ToString();
                RealtyTextimg.Text = SelectedRealty.img;
                //combo
                RealtyTextIdTypeRealty.Text = SelectedRealty.TypeRealty.Type;
                RealtyTextidStatusRealty.Text = SelectedRealty.StatusRealty.Status;

                DlgMode = 0;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }
        //изменение записи
        private void RealtyEdit_Click(object sender, RoutedEventArgs e)
        {
            if (RealtyGrid.SelectedItem != null)
            {
                RealtyGridDlgLoad(true, "Изменить недвижимость");
                SelectedRealty = (Base.Realty)RealtyGrid.SelectedItem;
                //text
                RealtyTextPrice.Text = SelectedRealty.Price.ToString();
                RealtyTextSquare.Text = SelectedRealty.Square.ToString();
                RealtyTextFloor.Text = SelectedRealty.Floor.ToString();
                RealtyTextRooms.Text = SelectedRealty.Rooms.ToString();
                RealtyTextAddress.Text = SelectedRealty.Address;
                RealtyTextIdOwnerAccount.Text = SelectedRealty.IdOwnerAccount.ToString();
                RealtyTextimg.Text = SelectedRealty.img;
                //combo
                RealtyTextIdTypeRealty.Text = SelectedRealty.TypeRealty.Type;
                RealtyTextidStatusRealty.Text = SelectedRealty.StatusRealty.Status;
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }
        //удаление записи
        private void RealtyDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую Realty
                    Base.Realty DeletingRealty = (Base.Realty)RealtyGrid.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (RealtyGrid.SelectedIndex < RealtyGrid.Items.Count - 1)
                        RealtyGrid.SelectedIndex++;
                    else
                    {
                        if (RealtyGrid.SelectedIndex > 0)
                            RealtyGrid.SelectedIndex--;
                    }
                    Base.Realty SelectingRealty = (Base.Realty)RealtyGrid.SelectedItem;
                    SourceCore.MyBase.Realty.Remove(DeletingRealty);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(SelectingRealty);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
        }
        //Добавление списка фильтрации
        private void RealtyFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (RealtyFilterComboBox.SelectedIndex)
            {
                case 0:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.Price.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.Square.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.Floor.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.Rooms.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 4:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.Address.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 5:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.IdOwnerAccount.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 6:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.IdTypeRealty.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 7:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.img.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 8:
                    RealtyGrid.ItemsSource = SourceCore.MyBase.Realty.Where(q => q.idStatusRealty.ToString().Contains(textbox.Text)).ToList();
                    break;
            }
        }
        //проверка введенных данных
        public Boolean Proverka()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(RealtyTextPrice.Text))
                errors.AppendLine("Введите цену");
            if (string.IsNullOrEmpty(RealtyTextSquare.Text))
                errors.AppendLine("Введите кв. метры");
            if (string.IsNullOrEmpty(RealtyTextFloor.Text))
                errors.AppendLine("Введите этаж//этажи");
            if (string.IsNullOrEmpty(RealtyTextRooms.Text))
                errors.AppendLine("Введите комнаты");
            if (string.IsNullOrEmpty(RealtyTextAddress.Text))
                errors.AppendLine("Введите адрес");
            if (string.IsNullOrEmpty(RealtyTextIdOwnerAccount.Text))
                errors.AppendLine("Введите владельца");
            if (string.IsNullOrEmpty(RealtyTextimg.Text))
                errors.AppendLine("Введите src картинки");

            if ((Base.TypeRealty)RealtyTextIdTypeRealty.SelectedItem == null)
                errors.AppendLine("Укажите тип");
            if ((Base.StatusRealty)RealtyTextidStatusRealty.SelectedItem == null)
                errors.AppendLine("Укажите статус");



            if (int.TryParse(RealtyTextPrice.Text, out int result1) && result1 > 0 && result1 < 30000000)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение цены! От 0 до 30000000", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (double.TryParse(RealtyTextSquare.Text, out double result2) && result2 > 0 && result2 < 30000000)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение кв. метров! От 0 до 30000000", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (int.TryParse(RealtyTextFloor.Text, out int result3) && result3 > 0 && result3 < 30000000)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение кол-во этажа\\этажей! От 0 до 30000000", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (int.TryParse(RealtyTextRooms.Text, out int result4) && result4 > 0 && result4 < 30000000)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение комнат! От 0 до 30000000", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (int.TryParse(RealtyTextIdOwnerAccount.Text, out int result5) && result5 > 0)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение id владельца! От 1 и более!", "Внимание", MessageBoxButton.OK);
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
        private void RealtyAddCommit_Click(object sender, RoutedEventArgs e)
        {
            if (!Proverka())
                return;

            if (DlgMode == 0)
            {
                //text
                var NewRealty = new Base.Realty();
                NewRealty.Price = int.Parse(RealtyTextPrice.Text);
                NewRealty.Square = decimal.Parse(RealtyTextSquare.Text);
                NewRealty.Floor = int.Parse(RealtyTextFloor.Text);
                NewRealty.Rooms = int.Parse(RealtyTextRooms.Text);
                NewRealty.Address = RealtyTextAddress.Text;                 
                NewRealty.img = RealtyTextimg.Text;
                NewRealty.IdOwnerAccount = int.Parse(RealtyTextIdOwnerAccount.Text);

                NewRealty.TypeRealty = RealtyTextIdTypeRealty.SelectedItem as Base.TypeRealty;
                NewRealty.StatusRealty = RealtyTextidStatusRealty.SelectedItem as Base.StatusRealty;


                SourceCore.MyBase.Realty.Add(NewRealty);
                SelectedRealty = NewRealty;
            }
            else
            {
                var EditRealty = new Base.Realty();
                EditRealty = SourceCore.MyBase.Realty.First(p => p.IdRealty == SelectedRealty.IdRealty);
                EditRealty.Price = int.Parse(RealtyTextPrice.Text);
                EditRealty.Square = decimal.Parse(RealtyTextSquare.Text);
                EditRealty.Floor = int.Parse(RealtyTextFloor.Text);
                EditRealty.Rooms = int.Parse(RealtyTextRooms.Text);
                EditRealty.Address = RealtyTextAddress.Text;
                EditRealty.img = RealtyTextimg.Text;
                EditRealty.IdOwnerAccount = int.Parse(RealtyTextIdOwnerAccount.Text);

                EditRealty.TypeRealty = RealtyTextIdTypeRealty.SelectedItem as Base.TypeRealty;
                EditRealty.StatusRealty = RealtyTextidStatusRealty.SelectedItem as Base.StatusRealty;
            }

            try
            {
                SourceCore.MyBase.SaveChanges();
                RealtyGridDlgLoad(false, "");
                UpdateGrid(SelectedRealty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //Отмена добавления/изменения записи
        private void RealtyAddRollback_Click(object sender, RoutedEventArgs e)
        {
            RealtyGridDlgLoad(false, "");
            UpdateGrid(SelectedRealty);
        }
    }
}
