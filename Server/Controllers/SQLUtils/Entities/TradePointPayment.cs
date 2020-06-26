using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class TradePointPayment : INotifyPropertyChanged
    {
        public int id = -1;
        public int tradePointId = -1;
        public string name = String.Empty;
        public double sum = 0;
        public DateTime date = DateTime.Today;

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
        public int TradePointId
        {
            set
            {
                if (value != this.tradePointId)
                {
                    this.tradePointId = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.tradePointId;
            }
        }
        public double Sum
        {
            set
            {
                if (value != this.sum)
                {
                    this.sum = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.sum;
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}