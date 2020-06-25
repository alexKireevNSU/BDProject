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
    public partial class EmployeesUC : UserControl, IUpdatable
    {
        public ObservableCollection<Employee> employees { get; set; }

        public EmployeesUC()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            List<Employee> employeesList = EmployeesController.GetInstance().GetEmployees();
            employeesList.Sort((x, y) => x.TradePoint.Name.CompareTo(y.TradePoint.Name));
            employees = new ObservableCollection<Employee>(employeesList);

            EmployeesList.ItemsSource = employees;
            EmployeesList.Items.Refresh();
            EmployeesList.UpdateLayout();
        }

        private Employee GetEmployeeByButton(Button button)
        {
            if (button == null)
                return null;

            return button.DataContext as Employee;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var emp = GetEmployeeByButton(sender as Button);
            if (emp == null)
                return;

            Window window = new EditEntityWindow(this, emp);
            window.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesController.GetInstance().DeleteEmployee(GetEmployeeByButton(sender as Button));
            UpdateList();
        }

        public void Update()
        {
            UpdateList();   
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditEntityWindow(this, new Employee());
            window.Show();
        }
    }
}
