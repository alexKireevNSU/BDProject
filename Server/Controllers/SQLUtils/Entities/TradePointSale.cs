using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class TradePointSale : INotifyPropertyChanged
    {
        public int id = -1;
        public int count = 0;
        public DateTime date = DateTime.Today;
        public TradePointProduct tradePointProduct;

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
        public int Count
        {
            set
            {
                if (value != this.count)
                {
                    this.count = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.count;
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
        public TradePointProduct TradePointProduct
        {
            set
            {
                if (value != this.tradePointProduct)
                {
                    this.tradePointProduct = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.tradePointProduct;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}