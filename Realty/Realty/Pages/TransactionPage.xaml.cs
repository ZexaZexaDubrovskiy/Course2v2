using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Realty.Pages
{
    public partial class TransactionPage : Page
    {
        //конструктор
        public TransactionPage()
        {
            InitializeComponent(); UpdateGrid(null);
            TransactionGridDlgLoad(false, "");
            DataContext = this;
            TransactionGrid.ItemsSource = SourceCore.MyBase.Transaction.ToList();
        }

        //new
        private int DlgMode = -1;
        public Base.Transaction SelectedTransaction;
        public ObservableCollection<Base.Transaction> Transaction;
        //вызов окна изменения записей
        public void TransactionGridDlgLoad(bool b, string DlgModeContent)
        {
            if (b == true)
            {
                TransactionColumnChange.Width = new GridLength(400);
                TransactionGrid.IsHitTestVisible = false;
                TransactionLabel.Content = DlgModeContent;
                TransactionAddCommitTextBox.Text = DlgModeContent;
                TransactionAdd.IsEnabled = false;
                TransactionCopy.IsEnabled = false;
                TransactionEdit.IsEnabled = false;
                TransactionDelete.IsEnabled = false;
            }
            else
            {
                TransactionColumnChange.Width = new GridLength(0);
                TransactionGrid.IsHitTestVisible = true;
                TransactionAdd.IsEnabled = true;
                TransactionCopy.IsEnabled = true;
                TransactionEdit.IsEnabled = true;
                TransactionDelete.IsEnabled = true;
                DlgMode = -1;
            }
        }
        //обновление таблицы
        public void UpdateGrid(Base.Transaction Transaction)
        {
            if ((Transaction == null) && (TransactionGrid.ItemsSource != null))
                Transaction = (Base.Transaction)TransactionGrid.SelectedItem;

            ObservableCollection<Base.Transaction> Transactions = new ObservableCollection<Base.Transaction>(SourceCore.MyBase.Transaction);
            TransactionGrid.ItemsSource = Transactions;
            TransactionGrid.SelectedItem = Transaction;
        }
        //загрузка списка для фильтрации
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();

            for (int i = 0; i < 6; i++)
                Columns.Add(TransactionGrid.Columns[i].Header.ToString());
            TransactionFilterComboBox.ItemsSource = Columns;
            TransactionFilterComboBox.SelectedIndex = 0;

            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in TransactionGrid.Columns)
                Column.CanUserSort = false;
        }

        //добавление записи
        private void TransactionAdd_Click(object sender, RoutedEventArgs e)
        {
            TransactionGridDlgLoad(true, "Добавить транзакцию");
            DataContext = null;
            DlgMode = 0;
        }
        //копирование записи
        private void TransactionCopy_Click(object sender, RoutedEventArgs e)
        {
            if (TransactionGrid.SelectedItem != null)
            {
                TransactionGridDlgLoad(true, "Копировать транзакцию");
                SelectedTransaction = (Base.Transaction)TransactionGrid.SelectedItem;

                //text
                TransactionTextIdTransactionRealty.Text = SelectedTransaction.IdTransactionRealty.ToString();
                TransactionTextTransactionAccountOwner.Text = SelectedTransaction.TransactionAccountOwner.ToString();
                //TransactionTextDate.Text = SelectedTransaction.Date.ToString();
                TransactionTextPriceTransaction.Text = SelectedTransaction.PriceTransaction.ToString();
                TransactionTextStatus.Text = SelectedTransaction.Status;
                TransactionTextIdTransactionTypeRealty.Text = SelectedTransaction.IdTransactionTypeRealty.ToString();
                TransactionTextTransactionAccountBuyer.Text = SelectedTransaction.TransactionAccountBuyer.ToString();
                
                DlgMode = 0;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }
        //изменение записи
        private void TransactionEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TransactionGrid.SelectedItem != null)
            {
                TransactionGridDlgLoad(true, "Изменить транзакцию");
                SelectedTransaction = (Base.Transaction)TransactionGrid.SelectedItem;
                //text
                TransactionTextIdTransactionRealty.Text = SelectedTransaction.IdTransactionRealty.ToString();
                TransactionTextTransactionAccountOwner.Text = SelectedTransaction.TransactionAccountOwner.ToString();
                
                
                TransactionTextDate.Text = SelectedTransaction.Date.ToString();
                
                TransactionTextPriceTransaction.Text = SelectedTransaction.PriceTransaction.ToString();
                TransactionTextStatus.Text = SelectedTransaction.Status;
                TransactionTextIdTransactionTypeRealty.Text = SelectedTransaction.IdTransactionTypeRealty.ToString();
                TransactionTextTransactionAccountBuyer.Text = SelectedTransaction.TransactionAccountBuyer.ToString();
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }
        //удаление записи
        private void TransactionDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую Transaction
                    Base.Transaction DeletingTransaction = (Base.Transaction)TransactionGrid.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (TransactionGrid.SelectedIndex < TransactionGrid.Items.Count - 1)
                        TransactionGrid.SelectedIndex++;
                    else
                    {
                        if (TransactionGrid.SelectedIndex > 0)
                            TransactionGrid.SelectedIndex--;
                    }
                    Base.Transaction SelectingTransaction = (Base.Transaction)TransactionGrid.SelectedItem;
                    SourceCore.MyBase.Transaction.Remove(DeletingTransaction);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(SelectingTransaction);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
        }
        //Добавление списка фильтрации
        private void TransactionFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (TransactionFilterComboBox.SelectedIndex)
            {
                case 0:
                    TransactionGrid.ItemsSource = SourceCore.MyBase.Transaction.Where(q => q.IdTransactionRealty.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    TransactionGrid.ItemsSource = SourceCore.MyBase.Transaction.Where(q => q.TransactionAccountOwner.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    TransactionGrid.ItemsSource = SourceCore.MyBase.Transaction.Where(q => q.PriceTransaction.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    TransactionGrid.ItemsSource = SourceCore.MyBase.Transaction.Where(q => q.Status.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 4:
                    TransactionGrid.ItemsSource = SourceCore.MyBase.Transaction.Where(q => q.IdTransactionTypeRealty.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 5:
                    TransactionGrid.ItemsSource = SourceCore.MyBase.Transaction.Where(q => q.TransactionAccountBuyer.ToString().Contains(textbox.Text)).ToList();
                    break;
                    //date
            }
        }
        //проверка введенных данных
        public Boolean Proverka()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(TransactionTextIdTransactionRealty.Text))
                errors.AppendLine("Введите id недвижимости");
            if (string.IsNullOrEmpty(TransactionTextTransactionAccountOwner.Text))
                errors.AppendLine("Введите владельца");
            if (string.IsNullOrEmpty(TransactionTextDate.Text))
                errors.AppendLine("Введите дату");
            if (string.IsNullOrEmpty(TransactionTextPriceTransaction.Text))
                errors.AppendLine("Введите цену");
            if (string.IsNullOrEmpty(TransactionTextStatus.Text))
                errors.AppendLine("Введите статус");
            if (string.IsNullOrEmpty(TransactionTextIdTransactionTypeRealty.Text))
                errors.AppendLine("Введите тип недвижимости");
            if (string.IsNullOrEmpty(TransactionTextTransactionAccountBuyer.Text))
                errors.AppendLine("Введите покупателя");



            if (int.TryParse(TransactionTextPriceTransaction.Text, out int result1) && result1 > 0 && result1 < 30000000)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение цены! От 0 до 30000000", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (int.TryParse(TransactionTextTransactionAccountOwner.Text, out int result2) && result2 > 0 )
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение id владельца! От 0 и более", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (int.TryParse(TransactionTextTransactionAccountBuyer.Text, out int result3) && result3 > 0)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный id покупателя! От 0 и более", "Внимание", MessageBoxButton.OK);
                return false;
            }
            
            if (int.TryParse(TransactionTextIdTransactionTypeRealty.Text, out int result4) && result4 > 0)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение id типа недвижимости! От 0 и более", "Внимание", MessageBoxButton.OK);
                return false;
            }
            if (int.TryParse(TransactionTextIdTransactionRealty.Text, out int result5) && result5 > 0)
            {
                //all good
            }
            else
            {
                MessageBox.Show("Неверный значение id недвижимости! От 0 и более", "Внимание", MessageBoxButton.OK);
                return false;
            }


            DateTime dDate;
            if (DateTime.TryParse(TransactionTextDate.Text, out dDate))
            {

            }
            else
            {
                MessageBox.Show("Неверный значение даты", "Внимание", MessageBoxButton.OK);
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
        private void TransactionAddCommit_Click(object sender, RoutedEventArgs e)
        {
            if (!Proverka())
                return;

            if (DlgMode == 0)
            {
                //text
                var NewTransaction = new Base.Transaction();
                NewTransaction.IdTransactionRealty = int.Parse(TransactionTextIdTransactionRealty.Text);

                DateTime dDate = DateTime.Parse(TransactionTextDate.Text);
                //string.Format("{0:d/MM/yyyy}", dDate);

                NewTransaction.Date = dDate;
                
                NewTransaction.PriceTransaction = int.Parse(TransactionTextPriceTransaction.Text);
                NewTransaction.Status = TransactionTextStatus.Text;
                NewTransaction.IdTransactionTypeRealty = int.Parse(TransactionTextIdTransactionTypeRealty.Text);
                NewTransaction.TransactionAccountBuyer = int.Parse(TransactionTextTransactionAccountBuyer.Text);

                SourceCore.MyBase.Transaction.Add(NewTransaction);
                SelectedTransaction = NewTransaction;
            }
            else
            {
                var EditTransaction = new Base.Transaction();
                EditTransaction = SourceCore.MyBase.Transaction.First(p => p.IdTransaction == SelectedTransaction.IdTransaction);
                EditTransaction.IdTransactionRealty = int.Parse(TransactionTextIdTransactionRealty.Text);

                DateTime dDate = DateTime.Parse(TransactionTextDate.Text);
                EditTransaction.Date = dDate;
                EditTransaction.PriceTransaction = int.Parse(TransactionTextPriceTransaction.Text);
                EditTransaction.Status = TransactionTextStatus.Text;
                EditTransaction.IdTransactionTypeRealty = int.Parse(TransactionTextIdTransactionTypeRealty.Text);
                EditTransaction.TransactionAccountBuyer = int.Parse(TransactionTextTransactionAccountBuyer.Text);

            }

            try
            {
                SourceCore.MyBase.SaveChanges();
                TransactionGridDlgLoad(false, "");
                UpdateGrid(SelectedTransaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //Отмена добавления/изменения записи
        private void TransactionAddRollback_Click(object sender, RoutedEventArgs e)
        {
            TransactionGridDlgLoad(false, "");
            UpdateGrid(SelectedTransaction);
        }
    }
}
