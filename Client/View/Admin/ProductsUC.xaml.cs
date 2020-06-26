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
    /// Логика взаимодействия для ProductsUC.xaml
    /// </summary>
    public partial class ProductsUC : UserControl, IUpdatable
    {
        public ObservableCollection<Product> collection { get; set; }

        public ProductsUC()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            List<Product> entList = ProductsController.GetInstance().GetProducts();
            entList.Sort((x, y) => x.Name.CompareTo(y.Name));
            collection = new ObservableCollection<Product>(entList);

            ProductsList.ItemsSource = collection;
            ProductsList.Items.Refresh();
            ProductsList.UpdateLayout();
        }

        private Product GetProductByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as Product;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ent = GetProductByButton(sender as Button);
            if (ent == null)
                return;

            Window window = new EditEntityWindow(this, ent);
            window.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsController.GetInstance().DeleteProduct(GetProductByButton(sender as Button));
            UpdateList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new Product());
            window.Show();
        }

        public void Update()
        {
            UpdateList();
        }
    }
}
