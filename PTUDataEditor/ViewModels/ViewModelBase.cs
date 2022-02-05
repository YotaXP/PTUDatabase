using System.ComponentModel;

namespace PTUDataEditor.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChange(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void SetProperty<T>(ref T property, T value, string propertyName)
    {
        if (!Equals(property, value))
        {
            property = value;
            OnPropertyChange(propertyName);
        }
    }
    protected void SetProperty<T>(ref T property, T value, string propertyName1, string propertyName2)
    {
        if (!Equals(property, value))
        {
            property = value;
            OnPropertyChange(propertyName1);
            OnPropertyChange(propertyName2);
        }
    }
    protected void SetProperty<T>(ref T property, T value, string propertyName1, string propertyName2, string propertyName3)
    {
        if (!Equals(property, value))
        {
            property = value;
            OnPropertyChange(propertyName1);
            OnPropertyChange(propertyName2);
            OnPropertyChange(propertyName3);
        }
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
