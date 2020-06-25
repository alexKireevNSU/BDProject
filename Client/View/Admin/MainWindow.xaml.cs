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
        TradePointsPayments
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
            switch (typeView)
            {
                case ViewType.Main:
                    MainUC view = new MainUC();
                    MainViewModel vm = new MainViewModel(this);
                    view.DataContext = vm;
                    this.OutputView.Content = view;
                    break;
                case ViewType.Employees:
                    EmployeesUC viewF = new EmployeesUC();
                    EmployeesViewModel vmF = new EmployeesViewModel(this);
                    viewF.DataContext = vmF;
                    this.OutputView.Content = viewF;
                    break;
                case ViewType.TradePoints:
                    TradePointsUC tradePointsUC = new TradePointsUC();
                    TradePointsViewModel tradePointsViewModel = new TradePointsViewModel(this);
                    tradePointsUC.DataContext = tradePointsViewModel;
                    this.OutputView.Content = tradePointsUC;
                    break;
                case ViewType.TradePointsPayments:
                    TradePointsPaymentsUC tradePointsPaymentsUC = new TradePointsPaymentsUC();
                    TradePointsPaymentsViewModel tradePointsPaymentsViewModel = new TradePointsPaymentsViewModel(this);
                    tradePointsPaymentsUC.DataContext = tradePointsPaymentsViewModel;
                    this.OutputView.Content = tradePointsPaymentsUC;
                    break;
            }
        }
    }
}
