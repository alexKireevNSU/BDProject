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
    public partial class TradePointsPaymentsUC : UserControl, IUpdatable
    {
        ObservableCollection<TradePoint> TradePoints = new ObservableCollection<TradePoint>();
        TradePoint TradePoint = null;
        private ObservableCollection<TradePointPayment> tradePointPayments = new ObservableCollection<TradePointPayment>();

        public TradePointsPaymentsUC()
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
            List<TradePointPayment> tradePointPaymentsList = TradePointsController.GetInstance().GetTradePointPayments(TradePointComboBox.SelectedItem as TradePoint);
            tradePointPaymentsList.Sort((x, y) => x.Date.CompareTo(y.Date));
            tradePointPayments = new ObservableCollection<TradePointPayment>(tradePointPaymentsList);

            TradePointPaymentsList.ItemsSource = tradePointPayments;
            TradePointPaymentsList.Items.Refresh();
            TradePointPaymentsList.UpdateLayout();
        }

        private TradePointPayment GetTradePointPaymentByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as TradePointPayment;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TradePointsController.GetInstance().DeleteTradePointPayment(GetTradePointPaymentByButton(sender as Button));
            UpdateList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var tradePointPayment = GetTradePointPaymentByButton(sender as Button);
            if (tradePointPayment == null)
                return;

            Window window = new EditEntityWindow(this, tradePointPayment);
            window.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new TradePointPayment());
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
