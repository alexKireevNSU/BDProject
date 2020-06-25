using Client.Controllers;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
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

namespace Client.View.CommonWindows
{
    
    public partial class AddEntityWindow : Window
    {
        private object obj;

        private List<TextBox> textBoxes = new List<TextBox>();

        private IUpdatable windowToUpdate;

        public AddEntityWindow(IUpdatable windowToUpdate, object obj)
        {
            this.windowToUpdate = windowToUpdate;
            textBoxes.Clear();
            this.obj = obj;
            InitializeComponent();
            AddFieldsBy(obj);
        }

        private void AddFieldsBy(object obj)
        {
            if (obj as Employee != null)
            {
                Employee emp = obj as Employee;
                TextBox nameTB = new TextBox() { Text = emp.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };
                TextBox positionTB = new TextBox() { Text = emp.Position.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };
                TextBox tradePointTB = new TextBox() { Text = emp.TradePoint.Name, Margin = new Thickness(5, 5, 5, 5), Width = 200 };

                Elements.Children.Add(nameTB);
                Elements.Children.Add(positionTB);
                Elements.Children.Add(tradePointTB);

                textBoxes.Add(nameTB);
                textBoxes.Add(positionTB);
                textBoxes.Add(tradePointTB);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (obj as Employee != null)
            {
                Employee emp = obj as Employee;
                emp.Name = textBoxes[0].Text;
                EmployeesController.GetInstance().AddEmployee(emp);
                windowToUpdate.Update();
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
