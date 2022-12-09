using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Realty.Pages
{
    public partial class TypeRealtyPage : Page
    {
        //конструктор
        public TypeRealtyPage()
        {
            InitializeComponent();
            TypeRealtyGridDlgLoad(false, "");
            DataContext = this;
            TypeRealtyGrid.ItemsSource = SourceCore.MyBase.TypeRealty.ToList();
        }

        //new
        private int DlgMode = -1;
        public Base.TypeRealty SelectedTypeRealty;
        public ObservableCollection<Base.TypeRealty> TypeRealty;
        //вызов окна изменения записей
        public void TypeRealtyGridDlgLoad(bool b, string DlgModeContent)
        {
            if (b == true)
            {
                TypeRealtyColumnChange.Width = new GridLength(400);
                TypeRealtyGrid.IsHitTestVisible = false;
                TypeRealtyLabel.Content = DlgModeContent;
                TypeRealtyAddCommitTextBox.Text = DlgModeContent;
                TypeRealtyAdd.IsEnabled = false;
                TypeRealtyCopy.IsEnabled = false;
                TypeRealtyEdit.IsEnabled = false;
                TypeRealtyDelete.IsEnabled = false;
            }
            else
            {
                TypeRealtyColumnChange.Width = new GridLength(0);
                TypeRealtyGrid.IsHitTestVisible = true;
                TypeRealtyAdd.IsEnabled = true;
                TypeRealtyCopy.IsEnabled = true;
                TypeRealtyEdit.IsEnabled = true;
                TypeRealtyDelete.IsEnabled = true;
                DlgMode = -1;
            }
        }
        //обновление таблицы
        public void UpdateGrid(Base.TypeRealty TypeRealty)
        {
            if ((TypeRealty == null) && (TypeRealtyGrid.ItemsSource != null))
                TypeRealty = (Base.TypeRealty)TypeRealtyGrid.SelectedItem;

            ObservableCollection<Base.TypeRealty> TypeRealtys = new ObservableCollection<Base.TypeRealty>(SourceCore.MyBase.TypeRealty);
            TypeRealtyGrid.ItemsSource = TypeRealtys;
            TypeRealtyGrid.SelectedItem = TypeRealty;
        }
        //загрузка списка для фильтрации
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();

            for (int i = 0; i < 1; i++)
                Columns.Add(TypeRealtyGrid.Columns[i].Header.ToString());
            TypeRealtyFilterComboBox.ItemsSource = Columns;
            TypeRealtyFilterComboBox.SelectedIndex = 0;

            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in TypeRealtyGrid.Columns)
                Column.CanUserSort = false;
        }
        //добавление записи
        private void TypeRealtyAdd_Click(object sender, RoutedEventArgs e)
        {
            TypeRealtyGridDlgLoad(true, "Добавить тип");
            DataContext = null;
            DlgMode = 0;
        }
        //копирование записи
        private void TypeRealtyCopy_Click(object sender, RoutedEventArgs e)
        {
            if (TypeRealtyGrid.SelectedItem != null)
            {
                TypeRealtyGridDlgLoad(true, "Копировать тип");
                SelectedTypeRealty = (Base.TypeRealty)TypeRealtyGrid.SelectedItem;

                //text
                TypeRealtyTextType.Text = SelectedTypeRealty.Type;
                DlgMode = 0;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }
        //изменение записи
        private void TypeRealtyEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TypeRealtyGrid.SelectedItem != null)
            {
                TypeRealtyGridDlgLoad(true, "Изменить тип");
                SelectedTypeRealty = (Base.TypeRealty)TypeRealtyGrid.SelectedItem;
                //text
                TypeRealtyTextType.Text = SelectedTypeRealty.Type;
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }
        //удаление записи
        private void TypeRealtyDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую  TypeRealty
                    Base.TypeRealty DeletingTypeRealty = (Base.TypeRealty)TypeRealtyGrid.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (TypeRealtyGrid.SelectedIndex < TypeRealtyGrid.Items.Count - 1)
                        TypeRealtyGrid.SelectedIndex++;
                    else
                    {
                        if (TypeRealtyGrid.SelectedIndex > 0)
                            TypeRealtyGrid.SelectedIndex--;
                    }
                    Base.TypeRealty SelectingTypeRealty = (Base.TypeRealty)TypeRealtyGrid.SelectedItem;
                    SourceCore.MyBase.TypeRealty.Remove(DeletingTypeRealty);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(SelectingTypeRealty);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
        }
        //Добавление списка фильтрации
        private void TypeRealtyFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (TypeRealtyFilterComboBox.SelectedIndex)
            {
                case 0:
                    TypeRealtyGrid.ItemsSource = SourceCore.MyBase.TypeRealty.Where(q => q.Type.ToString().Contains(textbox.Text)).ToList();
                    break;
            }
        }
        //проверка введенных данных
        public Boolean Proverka()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(TypeRealtyTextType.Text))
                errors.AppendLine("Введите тип");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }
            return true;
        }
        //Добавление/изменение записей в таблице
        private void TypeRealtyAddCommit_Click(object sender, RoutedEventArgs e)
        {
            if (!Proverka())
                return;

            if (DlgMode == 0)
            {
                //text
                var NewTypeRealty = new Base.TypeRealty();
                NewTypeRealty.Type = TypeRealtyTextType.Text;

                SourceCore.MyBase.TypeRealty.Add(NewTypeRealty);
                SelectedTypeRealty = NewTypeRealty;
            }
            else
            {
                var EditTypeRealty = new Base.TypeRealty();
                EditTypeRealty = SourceCore.MyBase.TypeRealty.First(p => p.idTypeRealty == SelectedTypeRealty.idTypeRealty);
                EditTypeRealty.Type = TypeRealtyTextType.Text;

            }

            try
            {
                SourceCore.MyBase.SaveChanges();
                TypeRealtyGridDlgLoad(false, "");
                UpdateGrid(SelectedTypeRealty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //Отмена добавления/изменения записи
        private void TypeRealtyAddRollback_Click(object sender, RoutedEventArgs e)
        {
            TypeRealtyGridDlgLoad(false, "");
            UpdateGrid(SelectedTypeRealty);
        }
    }
}
