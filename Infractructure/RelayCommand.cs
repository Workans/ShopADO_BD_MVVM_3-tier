using System;
using System.Windows.Input;

namespace HT_5_Comlex_MVVM_DB
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<object> predicate;
        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            this.action = action;
            this.predicate = predicate;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public bool CanExecute(object parameter)
        {
            return predicate != null ? predicate(parameter) : true;
        }
        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
