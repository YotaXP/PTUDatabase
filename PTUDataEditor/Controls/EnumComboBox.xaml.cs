using System.ComponentModel;
using System.Windows.Controls;

namespace PTUDataEditor.Controls;

/// <summary>
/// Interaction logic for EnumComboBox.xaml
/// </summary>
public partial class EnumComboBox : ComboBox, INotifyPropertyChanged
{
    public EnumComboBox()
    {
        InitializeComponent();
    }

    private Type _enumType = typeof(Type);
    public Type EnumType
    {
        get => _enumType;
        set
        {
            if (value != _enumType)
            {
                _enumType = value;
                ItemsSource = Enum.GetValues(EnumType); // TODO: Show actual names.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EnumType)));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
