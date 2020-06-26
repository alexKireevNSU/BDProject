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
    /// Логика взаимодействия для SuppliesUC.xaml
    /// </summary>
    public partial class SuppliesUC : UserControl
    {
        ObservableCollection<TradePoint> TradePoints = new ObservableCollection<TradePoint>();
        TradePoint TradePoint = null;
        ObservableCollection<Product> Products = new ObservableCollection<Product>();
        Product Product = null;
        ObservableCollection<Supplier> Suppliers = new ObservableCollection<Supplier>();
        Supplier Supplier = null;
        ObservableCollection<Order> Orders = new ObservableCollection<Order>();
        Order Order = null;

        public SuppliesUC()
        {
            InitializeComponent();

            List<TradePoint> tradePointsList = TradePointsController.GetInstance().GetTradePoints();
            tradePointsList.Sort((x, y) => x.FullName.CompareTo(y.FullName));
            TradePoints = new ObservableCollection<TradePoint>(tradePointsList);

            Binding bind1 = new Binding();
            bind1.Source = TradePoints;
            TradePointComboBox.DisplayMemberPath = "FullName";
            TradePointComboBox.SetBinding(ComboBox.ItemsSourceProperty, bind1);
            TradePoint = TradePoints.FirstOrDefault();
            TradePointComboBox.SelectedItem = TradePoint;
            
            List<Product> productsList = ProductsController.GetInstance().GetProducts();
            Products = new ObservableCollection<Product>(productsList);

            Binding bind2 = new Binding();
            bind2.Source = Products;
            ProductComboBox.DisplayMemberPath = "Name";
            ProductComboBox.SetBinding(ComboBox.ItemsSourceProperty, bind2);
            Product = Products.FirstOrDefault();
            ProductComboBox.SelectedItem = Product;

            List<Supplier> suppliersList = SuppliersController.GetInstance().GetSuppliers();
            Suppliers = new ObservableCollection<Supplier>(suppliersList);

            Binding bind3 = new Binding();
            bind3.Source = Suppliers;
            SupplierComboBox.DisplayMemberPath = "Name";
            SupplierComboBox.SetBinding(ComboBox.ItemsSourceProperty, bind3);
            Supplier = Suppliers.FirstOrDefault();
            SupplierComboBox.SelectedItem = Supplier;

            List<Order> ordersList = OrdersController.GetInstance().GetOrders();
            Orders = new ObservableCollection<Order>(ordersList);

            Binding bind4 = new Binding();
            bind4.Source = Orders;
            OrderComboBox.DisplayMemberPath = "Id";
            OrderComboBox.SetBinding(ComboBox.ItemsSourceProperty, bind4);
            Order = Orders.FirstOrDefault();
            OrderComboBox.SelectedItem = Order;
        }

        private Supply GetSupplyByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as Supply;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int price = 0;
            try
            {
                price = Int32.Parse(Price.Text);
            }
            catch(Exception ex)
            {
                price = 0;
            }
            int count = 0;
            try
            {
                count = Int32.Parse(Count.Text);
            }
            catch (Exception ex)
            {
                count = 0;
            }

            Supply supply = new Supply()
            {
                Product = new TradePointProduct()
                {
                    Product = ProductComboBox.SelectedItem as Product,
                    Supplier = SupplierComboBox.SelectedItem as Supplier,
                    TradePoint = TradePointComboBox.SelectedItem as TradePoint,
                    Price = price,
                    Count = count
                },
                Order = OrderComboBox.SelectedItem as Order,
                Date = DateTime.Today
            };
            SuppliesController.GetInstance().AddSupply(supply);
        }
    }
}
