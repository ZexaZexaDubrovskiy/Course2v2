using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Realty.Pages
{
    public partial class TypeRealtyStatusPage : Page
    {
        //конструктор
        public TypeRealtyStatusPage()
        {
            InitializeComponent();

            StatusRealtyGridDlgLoad(false, "");
            DataContext = this;
            StatusRealtyGrid.ItemsSource = SourceCore.MyBase.StatusRealty.ToList();
        }

        private int DlgMode = -1;
        public Base.StatusRealty SelectedStatusRealty;
        public ObservableCollection<Base.StatusRealty> StatusRealty;

        //вызов окна изменения записей
        public void StatusRealtyGridDlgLoad(bool b, string DlgModeContent)
        {
            if (b == true)
            {
                StatusRealtyColumnChange.Width = new GridLength(400);
                StatusRealtyGrid.IsHitTestVisible = false;
                StatusRealtyLabel.Content = DlgModeContent;
                StatusRealtyAddCommitTextBox.Text = DlgModeContent;
                StatusRealtyAdd.IsEnabled = false;
                StatusRealtyCopy.IsEnabled = false;
                StatusRealtyEdit.IsEnabled = false;
                StatusRealtyDelete.IsEnabled = false;
            }
            else
            {
                StatusRealtyColumnChange.Width = new GridLength(0);
                StatusRealtyGrid.IsHitTestVisible = true;
                StatusRealtyAdd.IsEnabled = true;
                StatusRealtyCopy.IsEnabled = true;
                StatusRealtyEdit.IsEnabled = true;
                StatusRealtyDelete.IsEnabled = true;
                DlgMode = -1;
            }
        }

        //обновление таблицы
        public void UpdateGrid(Base.StatusRealty StatusRealty)
        {
            if ((StatusRealty == null) && (StatusRealtyGrid.ItemsSource != null))
                StatusRealty = (Base.StatusRealty)StatusRealtyGrid.SelectedItem;

            ObservableCollection<Base.StatusRealty> StatusRealtys = new ObservableCollection<Base.StatusRealty>(SourceCore.MyBase.StatusRealty);
            StatusRealtyGrid.ItemsSource = StatusRealtys;
            StatusRealtyGrid.SelectedItem = StatusRealty;
        }

        //загрузка списка для фильтрации
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();

            for (int i = 0; i < 1; i++)
                Columns.Add(StatusRealtyGrid.Columns[i].Header.ToString());
            StatusRealtyFilterComboBox.ItemsSource = Columns;
            StatusRealtyFilterComboBox.SelectedIndex = 0;

            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in StatusRealtyGrid.Columns)
                Column.CanUserSort = false;
        }

        //добавление записи
        private void StatusRealtyAdd_Click(object sender, RoutedEventArgs e)
        {
            StatusRealtyGridDlgLoad(true, "Добавить тип");
            DataContext = null;
            DlgMode = 0;
        }

        //копирование записи
        private void StatusRealtyCopy_Click(object sender, RoutedEventArgs e)
        {
            if (StatusRealtyGrid.SelectedItem != null)
            {
                StatusRealtyGridDlgLoad(true, "Копировать тип");
                SelectedStatusRealty = (Base.StatusRealty)StatusRealtyGrid.SelectedItem;

                //text
                StatusRealtyTextStatus.Text = SelectedStatusRealty.Status;
                DlgMode = 0;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //изменение записи
        private void StatusRealtyEdit_Click(object sender, RoutedEventArgs e)
        {
            if (StatusRealtyGrid.SelectedItem != null)
            {
                StatusRealtyGridDlgLoad(true, "Изменить тип");
                SelectedStatusRealty = (Base.StatusRealty)StatusRealtyGrid.SelectedItem;
                //text
                StatusRealtyTextStatus.Text = SelectedStatusRealty.Status;
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }

        //удаление записи
        private void StatusRealtyDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую  StatusRealty
                    Base.StatusRealty DeletingStatusRealty = (Base.StatusRealty)StatusRealtyGrid.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (StatusRealtyGrid.SelectedIndex < StatusRealtyGrid.Items.Count - 1)
                        StatusRealtyGrid.SelectedIndex++;
                    else
                    {
                        if (StatusRealtyGrid.SelectedIndex > 0)
                            StatusRealtyGrid.SelectedIndex--;
                    }
                    Base.StatusRealty SelectingStatusRealty = (Base.StatusRealty)StatusRealtyGrid.SelectedItem;
                    SourceCore.MyBase.StatusRealty.Remove(DeletingStatusRealty);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(SelectingStatusRealty);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
        }

        //Добавление списка фильтрации
        private void StatusRealtyFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (StatusRealtyFilterComboBox.SelectedIndex)
            {
                case 0:
                    StatusRealtyGrid.ItemsSource = SourceCore.MyBase.StatusRealty.Where(q => q.Status.Contains(textbox.Text)).ToList();
                    break;
            }
        }
        //проверка введенных данных
        public Boolean Proverka()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(StatusRealtyTextStatus.Text))
                errors.AppendLine("Введите статус");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }
            return true;
        }
        //Добавление/изменение записей в таблице
        private void StatusRealtyAddCommit_Click(object sender, RoutedEventArgs e)
        {
            if (!Proverka())
                return;

            if (DlgMode == 0)
            {
                //text
                var NewStatusRealty = new Base.StatusRealty();
                NewStatusRealty.Status = StatusRealtyTextStatus.Text;

                SourceCore.MyBase.StatusRealty.Add(NewStatusRealty);
                SelectedStatusRealty = NewStatusRealty;
            }
            else
            {
                var EditStatusRealty = new Base.StatusRealty();
                EditStatusRealty = SourceCore.MyBase.StatusRealty.First(p => p.idStatusRealty == SelectedStatusRealty.idStatusRealty);
                EditStatusRealty.Status = StatusRealtyTextStatus.Text;

            }

            try
            {
                SourceCore.MyBase.SaveChanges();
                StatusRealtyGridDlgLoad(false, "");
                UpdateGrid(SelectedStatusRealty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Отмена добавления/изменения записи
        private void StatusRealtyAddRollback_Click(object sender, RoutedEventArgs e)
        {
            StatusRealtyGridDlgLoad(false, "");
            UpdateGrid(SelectedStatusRealty);
        }
    }
}
