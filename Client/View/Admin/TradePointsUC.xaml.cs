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
    /// Логика взаимодействия для TradePointsUC.xaml
    /// </summary>
    public partial class TradePointsUC : UserControl, IUpdatable
    {
        public ObservableCollection<TradePoint> tradePoints { get; set; }

        public TradePointsUC()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            List<TradePoint> tradePointsList = TradePointsController.GetInstance().GetTradePoints();
            tradePointsList.Sort((x, y) => x.FullName.CompareTo(y.FullName));
            tradePoints = new ObservableCollection<TradePoint>(tradePointsList);

            TradePointsList.ItemsSource = tradePoints;
            TradePointsList.Items.Refresh();
            TradePointsList.UpdateLayout();
        }

        private TradePoint GetTradePointByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as TradePoint;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TradePointsController.GetInstance().DeleteTradePoint(GetTradePointByButton(sender as Button));
            UpdateList();
        }

        public void Update()
        {
            UpdateList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var tradePoint = GetTradePointByButton(sender as Button);
            if (tradePoint == null)
                return;

            Window window = new EditEntityWindow(this, tradePoint);
            window.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new TradePoint());
            window.Show();
        }
    }
}
