using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class Employee : INotifyPropertyChanged
    {
        public int id = -1;
        public string name = String.Empty;
        public EmployeePosition position;
        public TradePoint tradePoint;

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
        public EmployeePosition Position
        {
            set
            {
                if (value != this.position)
                {
                    this.position = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.position;
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}