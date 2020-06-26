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
    /// Логика взаимодействия для TradePointsRequestsUC.xaml
    /// </summary>
    public partial class TradePointsRequestsUC : UserControl, IUpdatable
    {
        ObservableCollection<TradePoint> TradePoints = new ObservableCollection<TradePoint>();
        TradePoint TradePoint = null;
        private ObservableCollection<TradePointRequest> collection = new ObservableCollection<TradePointRequest>();

        public TradePointsRequestsUC()
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
            List<TradePointRequest> tradePointRequestsList = TradePointsController.GetInstance().GetTradePointRequests(TradePointComboBox.SelectedItem as TradePoint);
            tradePointRequestsList.Sort((x, y) => x.Id.CompareTo(y.Id));
            collection = new ObservableCollection<TradePointRequest>(tradePointRequestsList);

            TradePointRequestsList.ItemsSource = collection;
            TradePointRequestsList.Items.Refresh();
            TradePointRequestsList.UpdateLayout();
        }

        private TradePointRequest GetTradePointRequestByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as TradePointRequest;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TradePointsController.GetInstance().DeleteTradePointRequest(GetTradePointRequestByButton(sender as Button));
            UpdateList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ent = GetTradePointRequestByButton(sender as Button);
            if (ent == null)
                return;

            Window window = new EditEntityWindow(this, ent);
            window.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new TradePointRequest());
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
