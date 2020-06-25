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
