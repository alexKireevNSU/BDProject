using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class TradePointRequest : INotifyPropertyChanged
    {
        public int id = -1;
        public TradePoint tradePoint;
        public SupplierProduct product;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}