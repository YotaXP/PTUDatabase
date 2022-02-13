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

#pragma warning disable CA1822, IDE0051 // Mark members as static, Remove unused private members
    private object NewForm() => new FormViewModel(new PTUDatabase.Form() { Name = "*New Form" });
#pragma warning restore CA1822, IDE0051 // Mark members as static, Remove unused private members


    private void TypesChanged(object sender, System.Windows.RoutedEventArgs e)
    {
        var content = string.Join(", ", TypesList.SelectedItems);
        TypesBtn.Content = content == "" ? "None" : content;
    }

    private void EggGroupsChanged(object sender, System.Windows.RoutedEventArgs e)
    {
        var content = string.Join(", ", EggGroupsList.SelectedItems);
        EggGroupsBtn.Content = content == "" ? "None" : content;
    }

}
