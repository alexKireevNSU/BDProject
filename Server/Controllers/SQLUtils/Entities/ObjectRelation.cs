using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    [Serializable]
    public class ObjectRelation : INotifyPropertyChanged
    {
        public int id = -1;
        public int objRelId = -1;
        public int parent = -1;

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
        public int ObjRelId
        {
            set
            {
                if (value != this.objRelId)
                {
                    this.objRelId = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.objRelId;
            }
        }
        public int Parent
        {
            set
            {
                if (value != this.parent)
                {
                    this.parent = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return this.parent;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}