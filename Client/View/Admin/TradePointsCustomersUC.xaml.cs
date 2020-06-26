using Client.Controllers;
using Client.View.CommonWindows;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для TradePointsCustomersUC.xaml
    /// </summary>
    public partial class TradePointsCustomersUC : UserControl, IUpdatable
    {
        public ObservableCollection<TradePointCustomer> collection { get; set; }

        public TradePointsCustomersUC()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            List<TradePointCustomer> entList = TradePointCustomersController.GetInstance().GetTradesPointCustomers();
            entList.Sort((x, y) => x.Name.CompareTo(y.Name));
            collection = new ObservableCollection<TradePointCustomer>(entList);

            CustomersList.ItemsSource = collection;
            CustomersList.Items.Refresh();
            CustomersList.UpdateLayout();
        }

        private TradePointCustomer GetTradePointCustomerByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as TradePointCustomer;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ent = GetTradePointCustomerByButton(sender as Button);
            if (ent == null)
                return;

            Window window = new EditEntityWindow(this, ent);
            window.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TradePointCustomersController.GetInstance().DeleteTradePointCustomer(GetTradePointCustomerByButton(sender as Button));
            UpdateList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new TradePointCustomer());
            window.Show();
        }

        private void ShowPurchasesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Update()
        {
            UpdateList();
        }
    }
}