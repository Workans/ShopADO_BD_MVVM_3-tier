using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Binding_DataContext.Infrastructures
{
    abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        protected void Notify([CallerMemberName] string propotyChanged = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propotyChanged));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
