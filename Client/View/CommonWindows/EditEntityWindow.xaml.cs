using Client.Controllers;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.View.CommonWindows
{ 
    public partial class EditEntityWindow : Window
    {
        private object obj;

        private List<TextBox> textBoxes = new List<TextBox>();
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        private List<DatePicker> datePickers = new List<DatePicker>();

        private IUpdatable windowToUpdate;

        public EditEntityWindow(IUpdatable windowToUpdate, object obj)
        {
            this.windowToUpdate = windowToUpdate;
            textBoxes.Clear();
            comboBoxes.Clear();
            datePickers.Clear();
            this.obj = obj;
            InitializeComponent();
            AddFieldsBy(obj);
        }
        private ComboBox GetComboBoxOnData(List<object> objects, object curr, string memberNameToBind, bool addEmpty = false)
        {
            ComboBox comboBox = new ComboBox() { Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            var itemsSource = new ObservableCollection<object>(objects);
            Binding bind = new Binding();
            bind.Source = itemsSource;
            comboBox.DisplayMemberPath = memberNameToBind;
            comboBox.SetBinding(ComboBox.ItemsSourceProperty, bind);
            comboBox.SelectedItem = curr;
            return comboBox;
        }

        private void AddFieldsBy(Employee emp)
        {
            TextBox nameTB = new TextBox() { Text = emp.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

            List<EmployeePosition> positions = EmployeesController.GetInstance().GetEmployeePositions();
            EmployeePosition currPosition;
            try
            {
                currPosition = emp.Position == null ? positions.First() : positions.Find(x => x.Id == emp.Position.Id);
            }
            catch(Exception ex)
            {
                currPosition = null;
            }

            ComboBox positionCB = GetComboBoxOnData(positions.ToList<object>(), currPosition, "Name");

            List<TradePoint> tradePoints = TradePointsController.GetInstance().GetTradePoints();
            TradePoint currTradePoint;
            try
            {
                currTradePoint = emp.TradePoint == null ? tradePoints.First() : tradePoints.Find(x => x.Id == emp.TradePoint.Id);
            }
            catch(Exception ex)
            {
                currTradePoint = null;
            }
            ComboBox tradePointCB = GetComboBoxOnData(tradePoints.ToList<object>(), currTradePoint, "FullName");

            Elements.Children.Add(nameTB);
            Elements.Children.Add(positionCB);
            Elements.Children.Add(tradePointCB);

            textBoxes.Add(nameTB);
            comboBoxes.Add(positionCB);
            comboBoxes.Add(tradePointCB);
        }
        private void AddFieldsBy(TradePoint point)
        {
            TextBox nameTB = new TextBox() { Text = point.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

            List<TradePointType> tradePointsTypes = TradePointsController.GetInstance().GetTradePointTypes();
            TradePointType currTradePointType;
            try
            {
                currTradePointType = point.Type == null ? tradePointsTypes.First() : tradePointsTypes.Find(x => x.Id == point.Type.Id);
            }
            catch(Exception ex)
            {
                currTradePointType = null;
            }
            ComboBox typeCB = GetComboBoxOnData(tradePointsTypes.ToList<object>(), currTradePointType, "Name");

            TextBox sizeTB = new TextBox() { Text = point.Size.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            sizeTB.PreviewTextInput += NumberValidationTextBox;

            TextBox numOfCountersTB = new TextBox() { Text = point.NumberOfCounters.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            numOfCountersTB.PreviewTextInput += NumberValidationTextBox;

            List<TradePoint> tradePoints = TradePointsController.GetInstance().GetParents();
            TradePoint currParent = TradePointsController.GetInstance().GetParent(point);
            currParent = currParent == null ? null : tradePoints.Find(x => x.Id == currParent.Id);
            ComboBox parentCB = GetComboBoxOnData(tradePoints.ToList<object>(), currParent, "FullName");

            Elements.Children.Add(nameTB);
            Elements.Children.Add(typeCB);
            Elements.Children.Add(sizeTB);
            Elements.Children.Add(numOfCountersTB);
            Elements.Children.Add(parentCB);

            textBoxes.Add(nameTB);
            comboBoxes.Add(typeCB);
            textBoxes.Add(sizeTB);
            textBoxes.Add(numOfCountersTB);
            comboBoxes.Add(parentCB);
        }
        private void AddFieldsBy(TradePointPayment payment)
        {
            TextBox nameTB = new TextBox() { Text = payment.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            TextBox sumTB = new TextBox() { Text = payment.Sum.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            sumTB.PreviewTextInput += DoubleValidationTextBox;
            DatePicker datePicker = new DatePicker() { SelectedDate = payment.Date, IsDropDownOpen = false, Margin = new Thickness(5, 5, 5, 5), Width = 200 };


            Elements.Children.Add(nameTB);
            Elements.Children.Add(sumTB);
            Elements.Children.Add(datePicker);

            textBoxes.Add(nameTB);
            textBoxes.Add(sumTB);
            datePickers.Add(datePicker);
        }
        private void AddFieldsBy(Order order)
        {
            DatePicker datePicker = new DatePicker() { SelectedDate = order.Date, IsDropDownOpen = false, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

            List<Product> products = ProductsController.GetInstance().GetProducts();
            Product currProduct;
            try
            {
                currProduct = order.Product.Product == null ? products.First() : products.Find(x => x.Id == order.Product.Product.Id);
            }
            catch(Exception ex)
            {
                currProduct = null;
            }
            ComboBox productCB = GetComboBoxOnData(products.ToList<object>(), currProduct, "Name");

            List<Supplier> suppliers = SuppliersController.GetInstance().GetSuppliers();
            Supplier currSupplier;
            try
            {
                currSupplier = order.Product.Supplier == null ? suppliers.First() : suppliers.Find(x => x.Id == order.Product.Supplier.Id);
            }
            catch(Exception ex)
            {
                currSupplier = null;
            }
            ComboBox supplierCB = GetComboBoxOnData(suppliers.ToList<object>(), currSupplier, "Name");

            TextBox countTB = new TextBox() { Text = order.Product.Count.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            countTB.PreviewTextInput += NumberValidationTextBox;

            Elements.Children.Add(datePicker);
            Elements.Children.Add(productCB);
            Elements.Children.Add(supplierCB);
            Elements.Children.Add(countTB);

            datePickers.Add(datePicker);
            comboBoxes.Add(productCB);
            comboBoxes.Add(supplierCB);
            textBoxes.Add(countTB);
        }
        private void AddFieldsBy(Product product)
        {
            TextBox nameTB = new TextBox() { Text = product.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

            Elements.Children.Add(nameTB);

            textBoxes.Add(nameTB);
        }
        private void AddFieldsBy(Supplier supplier)
        {
            TextBox nameTB = new TextBox() { Text = supplier.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

            Elements.Children.Add(nameTB);

            textBoxes.Add(nameTB);
        }
        private void AddFieldsBy(TradePointCustomer customer)
        {
            TextBox nameTB = new TextBox() { Text = customer.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            TextBox descTB = new TextBox() { Text = customer.Description, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

            Elements.Children.Add(nameTB);
            Elements.Children.Add(descTB);

            textBoxes.Add(nameTB);
            textBoxes.Add(descTB);
        }
        private void AddFieldsBy(TradePointProduct product)
        {
            TextBox priceTB = new TextBox() { Text = product.Price.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            priceTB.PreviewTextInput += NumberValidationTextBox;

            List<TradePoint> tradePoints = TradePointsController.GetInstance().GetTradePoints();
            TradePoint currTradePoint;
            try
            {
                currTradePoint = product.TradePoint == null ? tradePoints.First() : tradePoints.Find(x => x.Id == product.TradePoint.Id);
            }
            catch(Exception ex)
            {
               currTradePoint = null;
            }
            ComboBox tradePointCB = GetComboBoxOnData(tradePoints.ToList<object>(), currTradePoint, "FullName");

            List<Product> products = ProductsController.GetInstance().GetProducts();
            Product currProduct;
            try
            {
                currProduct = product.Product == null ? products.First() : products.Find(x => x.Id == product.Product.Id);
            }
            catch (Exception ex)
            {
                currProduct = null;
            }
            ComboBox productCB = GetComboBoxOnData(products.ToList<object>(), currProduct, "Name");

            List<Supplier> suppliers = SuppliersController.GetInstance().GetSuppliers();
            Supplier currSupplier;
            try
            {
                currSupplier = product.Supplier == null ? suppliers.First() : suppliers.Find(x => x.Id == product.Supplier.Id);
            }
            catch (Exception ex)
            {
                currSupplier = null;
            }
            ComboBox supplierCB = GetComboBoxOnData(suppliers.ToList<object>(), currSupplier, "Name");

            TextBox countTB = new TextBox() { Text = product.Count.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            countTB.PreviewTextInput += NumberValidationTextBox;

            Elements.Children.Add(supplierCB);
            Elements.Children.Add(productCB);
            Elements.Children.Add(priceTB);
            Elements.Children.Add(countTB);
            Elements.Children.Add(tradePointCB);

            comboBoxes.Add(supplierCB);
            comboBoxes.Add(productCB);
            textBoxes.Add(priceTB);
            textBoxes.Add(countTB);
            comboBoxes.Add(tradePointCB);

        }
        private void AddFieldsBy(TradePointRequest request)
        {
            List<TradePoint> tradePoints = TradePointsController.GetInstance().GetTradePoints();
            TradePoint currTradePoint;
            try
            {
                currTradePoint = request.TradePoint == null ? tradePoints.First() : tradePoints.Find(x => x.Id == request.TradePoint.Id);
            }
            catch (Exception ex)
            {
                currTradePoint = null;
            }
            ComboBox tradePointCB = GetComboBoxOnData(tradePoints.ToList<object>(), currTradePoint, "FullName");

            List<Product> products = ProductsController.GetInstance().GetProducts();
            Product currProduct;
            try
            {
                currProduct = request.Product == null || request.Product.Product == null ? products.First() : products.Find(x => x.Id == request.Product.Product.Id);
            }
            catch (Exception ex)
            {
                currProduct = null;
            }
            ComboBox productCB = GetComboBoxOnData(products.ToList<object>(), currProduct, "Name");

            List<Supplier> suppliers = SuppliersController.GetInstance().GetSuppliers();
            Supplier currSupplier;
            try
            {
                currSupplier = request.Product == null || request.Product.Supplier == null ? suppliers.First() : suppliers.Find(x => x.Id == request.Product.Supplier.Id);
            }
            catch (Exception ex)
            {
                currSupplier = null;
            }
            ComboBox supplierCB = GetComboBoxOnData(suppliers.ToList<object>(), currSupplier, "Name");

            int count = request.Product == null ? 0 : request.Product.Count;
            TextBox countTB = new TextBox() { Text = count.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            countTB.PreviewTextInput += NumberValidationTextBox;

            Elements.Children.Add(supplierCB);
            Elements.Children.Add(productCB);
            Elements.Children.Add(countTB);
            Elements.Children.Add(tradePointCB);

            comboBoxes.Add(supplierCB);
            comboBoxes.Add(productCB);
            comboBoxes.Add(tradePointCB);
            textBoxes.Add(countTB);
        }
        private void AddFieldsBy(TradePointSale sale)
        {
            TextBox countTB = new TextBox() { Text = sale.Count.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
            countTB.PreviewTextInput += NumberValidationTextBox;
            DatePicker datePicker = new DatePicker() { SelectedDate = sale.Date, IsDropDownOpen = false, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

            List<TradePoint> tradePoints = TradePointsController.GetInstance().GetTradePoints();
            TradePoint currTradePoint;
            try
            {
                currTradePoint = sale.TradePointProduct == null || sale.TradePointProduct.TradePoint == null ? tradePoints.First() : tradePoints.Find(x => x.Id == sale.TradePointProduct.TradePoint.Id);
            }
            catch (Exception ex)
            {
                currTradePoint = null;
            }
            ComboBox tradePointCB = GetComboBoxOnData(tradePoints.ToList<object>(), currTradePoint, "FullName");
            tradePointCB.SelectionChanged += saleTradePoint_SelectionChanged;

            List<TradePointProduct> products = TradePointsController.GetInstance().GetTradePointProducts(currTradePoint);
            TradePointProduct currProduct;
            try
            {
                currProduct = sale.TradePointProduct == null ? products.First() : products.Find(x => x.Id == sale.TradePointProduct.Id);
            }
            catch (Exception ex)
            {
                currProduct = null;
            }
            ComboBox productCB = GetComboBoxOnData(products.ToList<object>(), currProduct, "FullName");

            Elements.Children.Add(datePicker);
            Elements.Children.Add(tradePointCB);
            Elements.Children.Add(productCB);
            Elements.Children.Add(countTB);

            textBoxes.Add(countTB);
            comboBoxes.Add(tradePointCB);
            comboBoxes.Add(productCB);
            datePickers.Add(datePicker);
        }
        
        private void saleTradePoint_SelectionChanged(object sender, EventArgs e)
        {
            if(sender as ComboBox != null)
            {
                var currTradePoint = ((sender as ComboBox).SelectedItem as TradePoint);
                if(currTradePoint != null)
                {
                    List<TradePointProduct> products = TradePointsController.GetInstance().GetTradePointProducts(currTradePoint);
                    TradePointProduct currProduct;
                    try
                    {
                        currProduct = products.First();
                    }
                    catch(Exception ex)
                    {
                        currProduct = null;
                    }

                    var itemsSource = new ObservableCollection<TradePointProduct>(products);
                    Binding bind = new Binding();
                    bind.Source = itemsSource;
                    comboBoxes[1].DisplayMemberPath = "FullName";
                    comboBoxes[1].SetBinding(ComboBox.ItemsSourceProperty, bind);
                    comboBoxes[1].SelectedItem = currProduct;
                    comboBoxes[1].UpdateLayout();
                    comboBoxes[1].Items.Refresh();
                }
            }
        }

        private void AddFieldsBy(object obj)
        {
            if (obj as Employee != null)
            {
                AddFieldsBy(obj as Employee);
                return;
            }
            else
            if(obj as TradePoint != null)
            {
                AddFieldsBy(obj as TradePoint);
                return;
            }
            else
            if(obj as TradePointPayment != null)
            {
                AddFieldsBy(obj as TradePointPayment);
                return;
            }
            else
            if(obj as Order != null)
            {
                AddFieldsBy(obj as Order);
                return;
            }
            else
            if (obj as Product != null)
            {
                AddFieldsBy(obj as Product);
                return;
            }
            else
            if (obj as Supplier != null)
            {
                AddFieldsBy(obj as Supplier);
                return;
            }
            else
            if (obj as TradePointCustomer != null)
            {
                AddFieldsBy(obj as TradePointCustomer);
                return;
            }
            else
            if (obj as TradePointProduct != null)
            {
                AddFieldsBy(obj as TradePointProduct);
                return;
            }
            else
            if (obj as TradePointRequest != null)
            {
                AddFieldsBy(obj as TradePointRequest);
                return;
            }
            else
            if (obj as TradePointSale != null)
            {
                AddFieldsBy(obj as TradePointSale);
                return;
            }
        }

        private void ApplyChangesBy(Employee emp)
        {
            emp.Name = textBoxes[0].Text;
            emp.Position = comboBoxes[0].SelectedItem as EmployeePosition;
            emp.TradePoint = comboBoxes[1].SelectedItem as TradePoint;
            if (emp.Id < 0)
            {
                EmployeesController.GetInstance().AddEmployee(emp);
            }
            else
            {
                EmployeesController.GetInstance().EditEmployee(emp);
            }
        }
        private void ApplyChangesBy(TradePoint tradePoint)
        {
            tradePoint.Name = textBoxes[0].Text;
            tradePoint.Type = comboBoxes[0].SelectedItem as TradePointType;
            try
            {
                tradePoint.Size = Int32.Parse(textBoxes[1].Text);
            }
            catch (Exception ex)
            {
                tradePoint.Size = 0;
            }
            try
            {
                tradePoint.NumberOfCounters = Int32.Parse(textBoxes[2].Text);
            }
            catch (Exception ex)
            {
                tradePoint.NumberOfCounters = 0;
            }

            if (tradePoint.Id < 0)
            {
                TradePointsController.GetInstance().AddTradePoint(tradePoint);
            }
            else
            {
                TradePointsController.GetInstance().EditTradePoint(tradePoint);
            }
        }
        private void ApplyChangesBy(TradePointPayment payment)
        {
            payment.Name = textBoxes[0].Text;
            try
            {
                payment.Sum = Double.Parse(textBoxes[1].Text);
            }
            catch (Exception ex)
            {
                payment.Sum = 0.0;
            }
            try
            {
                payment.Date = datePickers[0].DisplayDate;
            }
            catch (Exception ex)
            {
                payment.Date = DateTime.Today;
            }

            if (payment.Id < 0)
            {
                TradePointsController.GetInstance().AddTradePointPayment(payment);
            }
            else
            {
                TradePointsController.GetInstance().EditTradePointPayment(payment);
            }
        }
        private void ApplyChangesBy(TradePointSale tradePointSale)
        {
            tradePointSale.TradePointProduct = comboBoxes[1].SelectedItem as TradePointProduct;
            try
            {
                tradePointSale.Count = Int32.Parse(textBoxes[0].Text);
            }
            catch(Exception ex)
            {
                tradePointSale.Count = 0;
            }
            tradePointSale.Date = datePickers[0].DisplayDate;

            if(tradePointSale.Id < 0)
            {
                TradePointsController.GetInstance().AddTradePointSale(tradePointSale);
            }
            else
            {
                TradePointsController.GetInstance().EditTradePointSale(tradePointSale);
            }
        }
        private void ApplyChangesBy(TradePointRequest tradePointRequest)
        {
            SupplierProduct supplierProduct = tradePointRequest.Product ?? new SupplierProduct();

            supplierProduct.Supplier = comboBoxes[0].SelectedItem as Supplier;
            supplierProduct.Product = comboBoxes[1].SelectedItem as Product;
            
            try
            {
                supplierProduct.Count = Int32.Parse(textBoxes[0].Text);
            }
            catch(Exception ex)
            {
                supplierProduct.Count = 0;
            }
            tradePointRequest.Product = supplierProduct;
            tradePointRequest.TradePoint = comboBoxes[2].SelectedItem as TradePoint;

            if (tradePointRequest.Id < 0)
            {
                TradePointsController.GetInstance().AddTradePointRequest(tradePointRequest);
            }
            else
            {
                TradePointsController.GetInstance().EditTradePointRequest(tradePointRequest);
            }
        }
        private void ApplyChangesBy(TradePointProduct tradePointProduct)
        {
            tradePointProduct.Supplier = comboBoxes[0].SelectedItem as Supplier;
            tradePointProduct.Product = comboBoxes[1].SelectedItem as Product;
            try
            {
                tradePointProduct.Price = Int32.Parse(textBoxes[0].Text);
            }
            catch (Exception ex)
            {
                tradePointProduct.Price = 0;
            }
            try
            {
                tradePointProduct.Count = Int32.Parse(textBoxes[1].Text);
            }
            catch (Exception ex)
            {
                tradePointProduct.Count = 0;
            }
            tradePointProduct.TradePoint = comboBoxes[2].SelectedItem as TradePoint;

            if (tradePointProduct.Id < 0)
            {
                TradePointsController.GetInstance().AddTradePointProduct(tradePointProduct);
            }
            else
            {
                TradePointsController.GetInstance().EditTradePointProduct(tradePointProduct);
            }
        }
        private void ApplyChangesBy(TradePointCustomer tradePointCustomer)
        {
            tradePointCustomer.Name = textBoxes[0].Text;
            tradePointCustomer.Description = textBoxes[1].Text;

            if (tradePointCustomer.Id < 0)
            {
                TradePointCustomersController.GetInstance().AddTradePointCustomer(tradePointCustomer);
            }
            else
            {
                TradePointCustomersController.GetInstance().EditTradePointCustomer(tradePointCustomer);
            }
        }
        private void ApplyChangesBy(Supplier supplier)
        {
            supplier.Name = textBoxes[0].Text;

            if(supplier.Id < 0)
            {
                SuppliersController.GetInstance().AddSupplier(supplier);
            }
            else
            {
                SuppliersController.GetInstance().EditSupplier(supplier);
            }
        }
        private void ApplyChangesBy(Product product)
        {
            product.Name = textBoxes[0].Text;

            if (product.Id < 0)
            {
                ProductsController.GetInstance().AddProduct(product);
            }
            else
            {
                ProductsController.GetInstance().EditProduct(product);
            }
        }
        private void ApplyChangesBy(Order order)
        {
            order.Date = datePickers[0].DisplayDate;

            var supplierProduct = order.Product ?? new SupplierProduct();
            supplierProduct.Product = comboBoxes[0].SelectedItem as Product;
            supplierProduct.Supplier = comboBoxes[1].SelectedItem as Supplier;

            try
            {
                supplierProduct.Count = Int32.Parse(textBoxes[0].Text);
            }
            catch (Exception ex)
            {
                supplierProduct.Count = 0;
            }

            order.Product = supplierProduct;

            if (order.Id < 0)
            {
                OrdersController.GetInstance().AddOrder(order);
            }
            else
            {
                OrdersController.GetInstance().EditOrder(order);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (obj as Employee != null)
            {
                ApplyChangesBy(obj as Employee);
            }
            else
            if (obj as TradePoint != null)
            {
                ApplyChangesBy(obj as TradePoint);
            }
            else
            if(obj as TradePointPayment != null)
            {
                ApplyChangesBy(obj as TradePointPayment);
            }
            else
            if (obj as Order != null)
            {
                ApplyChangesBy(obj as Order);
            }
            else
            if (obj as Product != null)
            {
                ApplyChangesBy(obj as Product);
            }
            else
            if (obj as Supplier != null)
            {
                ApplyChangesBy(obj as Supplier);
            }
            else
            if (obj as TradePointCustomer != null)
            {
                ApplyChangesBy(obj as TradePointCustomer);
            }
            else
            if (obj as TradePointProduct != null)
            {
                ApplyChangesBy(obj as TradePointProduct);
            }
            else
            if (obj as TradePointRequest != null)
            {
                ApplyChangesBy(obj as TradePointRequest);
            }
            else
            if (obj as TradePointSale != null)
            {
                ApplyChangesBy(obj as TradePointSale);
            }

            windowToUpdate.Update();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
