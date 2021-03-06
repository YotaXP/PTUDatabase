using System.Windows.Controls;
using PTUDataEditor.ViewModels;

namespace PTUDataEditor.Views;
/// <summary>
/// Interaction logic for SpeciesView.xaml
/// </summary>
public partial class SpeciesView : UserControl
{
    public SpeciesView()
    {
        InitializeComponent();
    }

    private bool suppressChanged = false;

    private void TypesChanged(object sender, SelectionChangedEventArgs e)
    {
        var types = TypesList.SelectedItems.Cast<PTUDatabase.PokemonType>();
        var content = string.Join(", ", types);
        TypesBtn.Content = content == "" ? "None" : content;

        var form = FormsListBox.SelectedItem as FormViewModel;
        if (!suppressChanged && form is not null)
        {
            form.Types.Clear();
            foreach (var type in types)
                form.Types.Add(type);
        }
    }

    private void EggGroupsChanged(object sender, SelectionChangedEventArgs e)
    {
        var groups = EggGroupsList.SelectedItems.Cast<PTUDatabase.EggGroup>();
        var content = string.Join(", ", groups);
        EggGroupsBtn.Content = content == "" ? "None" : content;

        var form = FormsListBox.SelectedItem as FormViewModel;
        if (!suppressChanged && form is not null)
        {
            form.EggGroups.Clear();
            foreach (var group in groups)
                form.EggGroups.Add(group);
        }
    }

    private void FormsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var form = FormsListBox.SelectedItem as FormViewModel;
        suppressChanged = true;
        try
        {
            TypesList.SelectedItems.Clear();
            EggGroupsList.SelectedItems.Clear();
            if (form is not null)
            {
                foreach (var type in form.Types)
                    TypesList.SelectedItems.Add(type);
                foreach (var group in form.EggGroups)
                    EggGroupsList.SelectedItems.Add(group);
            }
        }
        finally
        {
            suppressChanged = false;
        }
    }
}
