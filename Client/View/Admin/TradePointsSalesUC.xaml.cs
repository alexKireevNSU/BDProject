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
    public partial class TradePointsSalesUC : UserControl, IUpdatable
    {
        ObservableCollection<TradePoint> TradePoints = new ObservableCollection<TradePoint>();
        TradePoint TradePoint = null;
        private ObservableCollection<TradePointSale> collection = new ObservableCollection<TradePointSale>();

        public TradePointsSalesUC()
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
            List<TradePointSale> tradePointSalesList = TradePointsController.GetInstance().GetTradePointSales(TradePointComboBox.SelectedItem as TradePoint);
            List<TradePointProduct> tradePointProducts = TradePointsController.GetInstance().GetTradePointProducts(TradePointComboBox.SelectedItem as TradePoint);
            for(int i = 0; i < tradePointSalesList.Count; ++i)
            {
                for (int j = 0; j < tradePointSalesList.Count; ++j)
                {
                    if (tradePointSalesList[i].TradePointProduct.Id == tradePointProducts[j].Id)
                    {
                        tradePointSalesList[i].TradePointProduct = tradePointProducts[j];
                    }
                }
            }
            tradePointSalesList.Sort((x, y) => x.Date.CompareTo(y.Date));
            collection = new ObservableCollection<TradePointSale>(tradePointSalesList);

            TradePointSalesList.ItemsSource = collection;
            TradePointSalesList.Items.Refresh();
            TradePointSalesList.UpdateLayout();
        }

        private TradePointSale GetTradePointSaleByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as TradePointSale;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TradePointsController.GetInstance().DeleteTradePointSale(GetTradePointSaleByButton(sender as Button));
            UpdateList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ent = GetTradePointSaleByButton(sender as Button);
            if (ent == null)
                return;

            Window window = new EditEntityWindow(this, ent);
            window.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new TradePointSale());
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
