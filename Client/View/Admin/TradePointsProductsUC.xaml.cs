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
    /// Логика взаимодействия для TradePointsProductsUC.xaml
    /// </summary>
    public partial class TradePointsProductsUC : UserControl, IUpdatable
    {
        ObservableCollection<TradePoint> TradePoints = new ObservableCollection<TradePoint>();
        TradePoint TradePoint = null;
        private ObservableCollection<TradePointProduct> collection = new ObservableCollection<TradePointProduct>();

        public TradePointsProductsUC()
        {
            InitializeComponent();

            List<TradePoint> tradePointsList = TradePointsController.GetInstance().GetTradePoints();
            tradePointsList.Sort((x, y) => x.FullName.CompareTo(y.FullName));
            TradePoints = new ObservableCollection<TradePoint>(tradePointsList);

            Binding bind = new Binding();
            bind.Source = TradePoints;
            TradePointComboBox.DisplayMemberPath = "FullName";
            TradePointComboBox.SetBinding(ComboBox.ItemsSourceProperty, bind);
            TradePoint = TradePoints.FirstOrDefault();
            TradePointComboBox.SelectedItem = TradePoint;
        }

        public void UpdateList()
        {
            List<TradePointProduct> tradePointProductsList = TradePointsController.GetInstance().GetTradePointProducts(TradePointComboBox.SelectedItem as TradePoint);
            tradePointProductsList.Sort((x, y) => x.Product.Name.CompareTo(y.Product.Name));
            collection = new ObservableCollection<TradePointProduct>(tradePointProductsList);

            TradePointProductsList.ItemsSource = collection;
            TradePointProductsList.Items.Refresh();
            TradePointProductsList.UpdateLayout();
        }

        private TradePointProduct GetTradePointProductByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as TradePointProduct;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TradePointsController.GetInstance().DeleteTradePointProduct(GetTradePointProductByButton(sender as Button));
            UpdateList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ent = GetTradePointProductByButton(sender as Button);
            if (ent == null)
                return;

            Window window = new EditEntityWindow(this, ent);
            window.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new TradePointProduct());
            window.Show();
        }

        public void Update()
        {
            UpdateList();
        }

        private void TradePointComboBox_DropDownClosed(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
