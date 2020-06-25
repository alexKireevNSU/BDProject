using Client.Controllers;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

namespace Client.View.CommonWindows
{ 
    public partial class EditEntityWindow : Window
    {
        private object obj;

        private List<TextBox> textBoxes = new List<TextBox>();
        private List<ComboBox> comboBoxes = new List<ComboBox>();

        private IUpdatable windowToUpdate;

        public EditEntityWindow(IUpdatable windowToUpdate, object obj)
        {
            this.windowToUpdate = windowToUpdate;
            textBoxes.Clear();
            comboBoxes.Clear();
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

        private void AddFieldsBy(object obj)
        {
            if (obj as Employee != null)
            {
                Employee emp = obj as Employee;
                TextBox nameTB = new TextBox() { Text = emp.Name, Margin = new Thickness(5,5,5,5), Width = 200 };
                
                List<EmployeePosition> positions = EmployeesController.GetInstance().GetEmployeePositions();
                EmployeePosition currPosition = emp.Position == null ? positions.First() : positions.Find(x => x.Id == emp.Position.Id);
                ComboBox positionCB = GetComboBoxOnData(positions.ToList<object>(), currPosition, "Name");

                List<TradePoint> tradePoints = TradePointsController.GetInstance().GetTradePoints();
                TradePoint currTradePoint = emp.TradePoint == null ? tradePoints.First() : tradePoints.Find(x => x.Id == emp.TradePoint.Id);
                ComboBox tradePointCB = GetComboBoxOnData(tradePoints.ToList<object>(), currTradePoint, "FullName");

                Elements.Children.Add(nameTB);
                Elements.Children.Add(positionCB);
                Elements.Children.Add(tradePointCB);

                textBoxes.Add(nameTB);
                comboBoxes.Add(positionCB);
                comboBoxes.Add(tradePointCB);

                return;
            }

            if(obj as TradePoint != null)
            {
                TradePoint point = obj as TradePoint;
                TextBox nameTB = new TextBox() { Text = point.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

                List<TradePointType> tradePointsTypes = TradePointsController.GetInstance().GetTradePointTypes();
                TradePointType currTradePointType = point.Type == null ? tradePointsTypes.First() : tradePointsTypes.Find(x => x.Id == point.Type.Id);
                ComboBox typeCB = GetComboBoxOnData(tradePointsTypes.ToList<object>(), currTradePointType, "Name");

                TextBox sizeTB = new TextBox() { Text = point.Size.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
                TextBox numOfCountersTB = new TextBox() { Text = point.NumberOfCounters.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };

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

                return;
            }

            if(obj as TradePointPayment != null)
            {
                TradePointPayment payment = obj as TradePointPayment;

                TextBox nameTB = new TextBox() { Text = payment.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };
                TextBox sumTB = new TextBox() { Text = payment.Sum.ToString(), Margin = new Thickness(5, 5, 5, 5), Width = 200 };
                TextBox dateTB = new TextBox() { Text = payment.Date.ToString("YYYY/MM/DD"), Margin = new Thickness(5, 5, 5, 5), Width = 200 };

                textBoxes.Add(nameTB);
                textBoxes.Add(sumTB);
                textBoxes.Add(dateTB);

                return;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (obj as Employee != null)
            {
                Employee emp = obj as Employee;
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
                windowToUpdate.Update();
                this.Close();

                return;
            }

            if (obj as TradePoint != null)
            {
                TradePoint tradePoint = obj as TradePoint;
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
               
                if(tradePoint.Id < 0)
                {
                    TradePointsController.GetInstance().AddTradePoint(tradePoint);
                }
                else
                {
                    TradePointsController.GetInstance().EditTradePoint(tradePoint);
                }
                windowToUpdate.Update();
                this.Close();

                return;
            }

            if(obj as TradePointPayment != null)
            {
                TradePointPayment payment = obj as TradePointPayment;
                payment.Name = textBoxes[0].Text;
                try
                {
                    payment.Sum = Double.Parse(textBoxes[1].Text);
                }
                catch(Exception ex)
                {
                    payment.Sum = 0.0;
                }
                try
                {
                    payment.Date = DateTime.ParseExact(textBoxes[2].Text.Trim(), "YYYY/MM/DD", CultureInfo.InvariantCulture);
                }
                catch(Exception ex)
                {
                    payment.Date = DateTime.Today;
                }

                if(payment.Id < 0)
                {
                    TradePointsController.GetInstance().AddTradePointPayment(payment);
                }
                else
                {
                    TradePointsController.GetInstance().EditTradePointPayment(payment);
                }

                return;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
