using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class SupplierProduct : INotifyPropertyChanged
    {
        public Product product;
        public Supplier supplier;
        public int count = 0;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}