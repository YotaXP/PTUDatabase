using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PTUDataEditor.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T property, T value, params string[] propertyNames)
        {
            if (!Equals(property, value))
            {
                property = value;
                foreach (var name in propertyNames)
                    OnPropertyChange(name);
            }
        }
    }
}
