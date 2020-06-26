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
    /// Логика взаимодействия для OrdersUC.xaml
    /// </summary>
    public partial class OrdersUC : UserControl, IUpdatable
    {
        public ObservableCollection<Order> collection { get; set; }

        public OrdersUC()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            List<Order> entList = OrdersController.GetInstance().GetOrders();
            entList.Sort((x, y) => x.Id.CompareTo(y.Id));
            collection = new ObservableCollection<Order>(entList);

            OrdersList.ItemsSource = collection;
            OrdersList.Items.Refresh();
            OrdersList.UpdateLayout();
        }

        private Order GetOrderByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as Order;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ent = GetOrderByButton(sender as Button);
            if (ent == null)
                return;

            Window window = new EditEntityWindow(this, ent);
            window.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersController.GetInstance().DeleteOrder(GetOrderByButton(sender as Button));
            UpdateList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new Order());
            window.Show();
        }

        public void Update()
        {
            UpdateList();
        }
    }
}
