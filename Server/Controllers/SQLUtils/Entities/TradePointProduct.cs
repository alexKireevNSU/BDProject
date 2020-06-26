using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class TradePointProduct : INotifyPropertyChanged
    {
        public int id = -1;
        public TradePoint tradePoint;
        public Product product;
        public Supplier supplier;
        public int count = 0;
        public int price = 0;

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
        public TradePoint TradePoint
        {
            set
            {
                if (value != this.tradePoint)
                {
                    this.tradePoint = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.tradePoint;
            }
        }
        public Product Product
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
        public Supplier Supplier
        {
            set
            {
                if (value != this.supplier)
                {
                    this.supplier = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.supplier;
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
        public int Price
        {
            set
            {
                if (value != this.price)
                {
                    this.price = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.price;
            }
        }
        public string FullName
        {
            get
            {
                return (Supplier != null ? Supplier.Name : String.Empty) + " " + (Product != null ? Product.Name : String.Empty); 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}