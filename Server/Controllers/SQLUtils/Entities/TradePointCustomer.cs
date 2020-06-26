using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class TradePointCustomer : INotifyPropertyChanged
    {
        public int id = -1;
        public string name = String.Empty;
        public string description = String.Empty;
        public List<TradePointSale> sales = new List<TradePointSale>();

        public int Id
        {
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.id;
            }
        }
        public string Name
        {
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.name;
            }
        }
        public string Description
        {
            set
            {
                if (value != this.description)
                {
                    this.description = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.description;
            }
        }
        public List<TradePointSale> Sales
        {
            set
            {
                if (value != this.sales)
                {
                    this.sales = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.sales;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}