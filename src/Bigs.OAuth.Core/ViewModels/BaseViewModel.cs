﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Bigs.OAuth.ViewModels
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Protected Methods
        protected void RaiseEvent(EventHandler handler)
        {
            if (null != handler)
                handler(this, EventArgs.Empty);
        }

        protected void RaiseEvent<T>(EventHandler<T> handler, Func<T> argsFunc) where T : EventArgs
        {
            handler?.Invoke(this, argsFunc());
        }

        protected void SetAndRaise<T>(ref T field, T newValue, [CallerMemberName]string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName)) return;

            if (Equals(field, newValue))
                return;

            field = newValue;
            RaisePropertyChangedInternal(propertyName);
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            RaisePropertyChangedInternal(propertyName);
        }

        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedInternal(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class ActionCommand : ICommand
    {
        private readonly Action _execute;

        public ActionCommand(Action action)
        {
            _execute = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }
    }
}
