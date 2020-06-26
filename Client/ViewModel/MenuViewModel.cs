using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.View.Admin
{
    public class MenuViewModel
    {

        //ctor
        public MenuViewModel()
        {

        }

        public IMainWindowsCodeBehind CodeBehind { get; set; }
        

        private RelayCommand _LoadEmployeesCommand;
        public RelayCommand LoadEmployeesUCCommand
        {
            get
            {
                return _LoadEmployeesCommand = _LoadEmployeesCommand ??
                  new RelayCommand(OnLoadEmployeesUC, CanLoadEmployeesUC);
            }
        }
        private bool CanLoadEmployeesUC()
        {
            return true;
        }
        private void OnLoadEmployeesUC()
        {
            CodeBehind.LoadView(ViewType.Employees);
        }

        private RelayCommand _LoadTradePointsUCCommand;
        public RelayCommand LoadTradePointsUCCommand
        {
            get
            {
                return _LoadTradePointsUCCommand = _LoadTradePointsUCCommand ??
                  new RelayCommand(OnLoadTradePointsUC, CanLoadTradePointsUC);
            }
        }
        private bool CanLoadTradePointsUC()
        {
            return true;
        }
        private void OnLoadTradePointsUC()
        {
            CodeBehind.LoadView(ViewType.TradePoints);
        }

        private RelayCommand _LoadTradePointsPaymentsUCCommand;
        public RelayCommand LoadTradePointsPaymentsUCCommand
        {
            get
            {
                return _LoadTradePointsPaymentsUCCommand = _LoadTradePointsPaymentsUCCommand ??
                  new RelayCommand(OnLoadTradePointsPaymentsUC, CanLoadTradePointsPaymentsUC);
            }
        }
        private bool CanLoadTradePointsPaymentsUC()
        {
            return true;
        }
        private void OnLoadTradePointsPaymentsUC()
        {
            CodeBehind.LoadView(ViewType.TradePointsPayments);
        }

        private RelayCommand _LoadTradePointsSalesUCCommand;
        public RelayCommand LoadTradePointsSalesUCCommand
        {
            get
            {
                return _LoadTradePointsSalesUCCommand = _LoadTradePointsSalesUCCommand ??
                  new RelayCommand(OnLoadTradePointsSalesUC, CanLoadTradePointsSalesUC);
            }
        }
        private bool CanLoadTradePointsSalesUC()
        {
            return true;
        }
        private void OnLoadTradePointsSalesUC()
        {
            CodeBehind.LoadView(ViewType.TradePointsSales);
        }

        private RelayCommand _LoadTradePointsProductsUCCommand;
        public RelayCommand LoadTradePointsProductsUCCommand
        {
            get
            {
                return _LoadTradePointsProductsUCCommand = _LoadTradePointsProductsUCCommand ??
                  new RelayCommand(OnLoadTradePointsProductsUC, CanLoadTradePointsProductsUC);
            }
        }
        private bool CanLoadTradePointsProductsUC()
        {
            return true;
        }
        private void OnLoadTradePointsProductsUC()
        {
            CodeBehind.LoadView(ViewType.TradePointsProducts);
        }

        private RelayCommand _LoadTradePointsCustomersUCCommand;
        public RelayCommand LoadTradePointsCustomersUCCommand
        {
            get
            {
                return _LoadTradePointsCustomersUCCommand = _LoadTradePointsCustomersUCCommand ??
                  new RelayCommand(OnLoadTradePointsCustomersUC, CanLoadTradePointsCustomersUC);
            }
        }
        private bool CanLoadTradePointsCustomersUC()
        {
            return true;
        }
        private void OnLoadTradePointsCustomersUC()
        {
            CodeBehind.LoadView(ViewType.TradePointsCustomers);
        }

        private RelayCommand _LoadSuppliersUCCommand;
        public RelayCommand LoadSuppliersUCCommand
        {
            get
            {
                return _LoadSuppliersUCCommand = _LoadSuppliersUCCommand ??
                  new RelayCommand(OnLoadSuppliersUC, CanLoadSuppliersUC);
            }
        }
        private bool CanLoadSuppliersUC()
        {
            return true;
        }
        private void OnLoadSuppliersUC()
        {
            CodeBehind.LoadView(ViewType.Suppliers);
        }

        private RelayCommand _LoadProductsUCCommand;
        public RelayCommand LoadProductsUCCommand
        {
            get
            {
                return _LoadProductsUCCommand = _LoadProductsUCCommand ??
                  new RelayCommand(OnLoadProductsUC, CanLoadProductsUC);
            }
        }
        private bool CanLoadProductsUC()
        {
            return true;
        }
        private void OnLoadProductsUC()
        {
            CodeBehind.LoadView(ViewType.Products);
        }

        private RelayCommand _LoadTradePointsRequestsUCCommand;
        public RelayCommand LoadTradePointsRequestsUCCommand
        {
            get
            {
                return _LoadTradePointsRequestsUCCommand = _LoadTradePointsRequestsUCCommand ??
                  new RelayCommand(OnLoadTradePointsRequestsUC, CanLoadTradePointsRequestsUC);
            }
        }
        private bool CanLoadTradePointsRequestsUC()
        {
            return true;
        }
        private void OnLoadTradePointsRequestsUC()
        {
            CodeBehind.LoadView(ViewType.TradePointsRequests);
        }

        private RelayCommand _LoadOrdersUCCommand;
        public RelayCommand LoadOrdersUCCommand
        {
            get
            {
                return _LoadOrdersUCCommand = _LoadOrdersUCCommand ??
                  new RelayCommand(OnLoadOrdersUC, CanLoadOrdersUC);
            }
        }
        private bool CanLoadOrdersUC()
        {
            return true;
        }
        private void OnLoadOrdersUC()
        {
            CodeBehind.LoadView(ViewType.Orders);
        }

        private RelayCommand _LoadSuppliesUCCommand;
        public RelayCommand LoadSuppliesUCCommand
        {
            get
            {
                return _LoadSuppliesUCCommand = _LoadSuppliesUCCommand ??
                  new RelayCommand(OnLoadSuppliesUC, CanLoadSuppliesUC);
            }
        }
        private bool CanLoadSuppliesUC()
        {
            return true;
        }
        private void OnLoadSuppliesUC()
        {
            CodeBehind.LoadView(ViewType.Supplies);
        }

        private RelayCommand _LoadMainUCCommand;
        public RelayCommand LoadMainUCCommand
        {
            get
            {
                return _LoadMainUCCommand = _LoadMainUCCommand ??
                  new RelayCommand(OnLoadMainUC, CanLoadMainUC);
            }
        }
        private bool CanLoadMainUC()
        {
            return true;
        }
        private void OnLoadMainUC()
        {
            CodeBehind.LoadView(ViewType.Main);
        }

    }
}
