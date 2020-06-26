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
    

    public partial class SuppliersUC : UserControl, IUpdatable
    {
        public ObservableCollection<Supplier> suppliers { get; set; }

        public SuppliersUC()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            List<Supplier> suppliersList = SuppliersController.GetInstance().GetSuppliers();
            suppliersList.Sort((x, y) => x.Name.CompareTo(y.Name));
            suppliers = new ObservableCollection<Supplier>(suppliersList);

            SuppliersList.ItemsSource = suppliers;
            SuppliersList.Items.Refresh();
            SuppliersList.UpdateLayout();
        }

        private Supplier GetSupplierByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as Supplier;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var sup = GetSupplierByButton(sender as Button);
            if (sup == null)
                return;

            Window window = new EditEntityWindow(this, sup);
            window.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SuppliersController.GetInstance().DeleteSupplier(GetSupplierByButton(sender as Button));
            UpdateList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new Supplier());
            window.Show();
        }

        public void Update()
        {
            UpdateList();
        }
    }
}
