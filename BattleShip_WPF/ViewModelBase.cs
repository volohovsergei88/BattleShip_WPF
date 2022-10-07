using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_WPF
{
   internal class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T field, T value,[CallerMemberName] string propName= "") where T: IEquatable<T> {
            if (field !=null && !field.Equals(value)) { // определяет неравен ли объект field объекту value
                    field = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                } }
        protected void Fire(params string [] names)
        {
            foreach (var name in names)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
