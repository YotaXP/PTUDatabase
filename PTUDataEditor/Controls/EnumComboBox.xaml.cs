using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PTUDataEditor.Controls
{
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
}
