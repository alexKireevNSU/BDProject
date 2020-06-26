using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class Order : INotifyPropertyChanged
    {
        public int id = -1;
        public DateTime date = DateTime.Today;
        public SupplierProduct product;
        public TradePointRequest request;

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

        public DateTime Date
        {
            set
            {
                if (value != this.date)
                {
                    this.date = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.date;
            }
        }
        public SupplierProduct Product
        {
            set
            {
                if (value != this.product)
                {
                    this.product = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.product;
            }
        }
        public TradePointRequest Request
        {
            set
            {
                if (value != this.request)
                {
                    this.request = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.request;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}