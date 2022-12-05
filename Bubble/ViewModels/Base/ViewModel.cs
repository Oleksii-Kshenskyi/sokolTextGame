﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bubble.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
        

        //Передаём имя свойства и генерируем внутри событие. Атрибут для компилятора. 
       protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        //Задача метода обновлять значение свойства, для которого определено поле в котором это свойство хранит свои данные.
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if(Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
