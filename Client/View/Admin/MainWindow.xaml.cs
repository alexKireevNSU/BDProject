using Client.ViewModel;
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

namespace Client.View.Admin
{
    public interface IMainWindowsCodeBehind
    {
        void LoadView(ViewType typeView);
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewType
    {
        Main,
        Employees,
        TradePoints,
        TradePointsPayments,
        TradePointsProducts,
        TradePointsSales,
        TradePointsCustomers,
        Suppliers,
        Products,
        TradePointsRequests,
        Orders,
        Supplies
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
            MenuViewModel vm = new MenuViewModel();
            //даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;

            //загрузка стартовой View
            LoadView(ViewType.Main);
        }

        public void LoadView(ViewType typeView)
        {
            UserControl uc = null;
            MainViewModel vm = new MainViewModel(this);
     
            switch (typeView)
            {
                case ViewType.Main:
                    uc = new MainUC();
                    break;
                case ViewType.Employees:
                    uc = new EmployeesUC();
                    break;
                case ViewType.TradePoints:
                    uc = new TradePointsUC();
                    break;
                case ViewType.TradePointsPayments:
                    uc = new TradePointsPaymentsUC();
                    break;
                case ViewType.TradePointsSales:
                    uc = new TradePointsSalesUC();
                    break;
                case ViewType.TradePointsProducts:
                    uc = new TradePointsProductsUC();
                    break;
                case ViewType.TradePointsCustomers:
                    uc = new TradePointsCustomersUC();
                    break;
                case ViewType.Suppliers:
                    uc = new SuppliersUC();
                    break;
                case ViewType.Products:
                    uc = new ProductsUC();
                    break;
                case ViewType.TradePointsRequests:
                    uc = new TradePointsRequestsUC();
                    break;
                case ViewType.Orders:
                    uc = new OrdersUC();
                    break;
                case ViewType.Supplies:
                    uc = new SuppliesUC();
                    break;

            }
            if (uc != null)
            {
                uc.DataContext = vm;
                this.OutputView.Content = uc;
            }
        }
    }
}
