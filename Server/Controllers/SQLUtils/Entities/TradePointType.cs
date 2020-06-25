using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class TradePointType : INotifyPropertyChanged
    {
        public int id = -1;
        public string name = String.Empty;
        public bool isBarren = true;

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
        public bool IsBarren
        {
            set
            {
                if (value != this.isBarren)
                {
                    this.isBarren = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.isBarren;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}