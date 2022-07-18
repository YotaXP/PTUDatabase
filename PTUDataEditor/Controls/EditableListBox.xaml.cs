using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PTUDataEditor.Controls;

/// <summary>
/// Interaction logic for EditableListBox.xaml
/// </summary>
public partial class EditableListBox : ListBox
{
    public EditableListBox()
    {
        InitializeComponent();
    }

    private void RemoveBtn_Click(object sender, RoutedEventArgs e)
    {
        var collection = ItemsSource as dynamic;
        if (collection is not null)
            collection.RemoveAt(SelectedIndex);
    }

    private void AddBtn_Click(object sender, RoutedEventArgs e)
    {
        var collection = ItemsSource as dynamic;
        if (collection is null)
            collection = ItemsSource = new ObservableCollection<object>();
        var newItem = (dynamic)NewItem!.Invoke();
        collection.Add(newItem);
        SelectedItem = newItem;
    }

    public event Func<object>? NewItem;
}
