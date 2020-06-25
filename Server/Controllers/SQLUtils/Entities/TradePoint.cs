using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class TradePoint : INotifyPropertyChanged
    {
        public int id = -1;
        public string name = String.Empty;
        public string fullName = String.Empty;
        public TradePointType type;
        public int size = 0;
        public int numberOfCounters = 0;

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
        public string FullName
        {
            set
            {
                if (value != this.fullName)
                {
                    this.fullName = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.fullName;
            }
        }
        public TradePointType Type
        {
            set
            {
                if (value != this.type)
                {
                    this.type = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.type;
            }
        }
        public int Size
        {
            set
            {
                if (value != this.size)
                {
                    this.size = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.size;
            }
        }
        public int NumberOfCounters
        {
            set
            {
                if (value != this.numberOfCounters)
                {
                    this.numberOfCounters = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.numberOfCounters;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}