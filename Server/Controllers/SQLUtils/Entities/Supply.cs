using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class Supply : INotifyPropertyChanged
    {
        public int id = -1;
        public DateTime date = DateTime.Today;
        public Order order;
        public TradePointProduct product;

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
        public Order Order
        {
            set
            {
                if (value != this.order)
                {
                    this.order = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.order;
            }
        }
        public TradePointProduct Product
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}