using System.Windows.Controls;
using PTUDataEditor.ViewModels;

namespace PTUDataEditor.Views;

/// <summary>
/// Interaction logic for DatabaseView.xaml
/// </summary>
public partial class DatabaseView : UserControl
{
    public DatabaseView()
    {
        InitializeComponent();

#if DEBUG
        // Quickly load ptu.1.05.yaml to speed up debugging.
        DataContext = DatabaseViewModel.DesignData;
        // TODO: Ensure things work correctly when nothing is loaded here. As of writing this, things don't.
#endif
    }

#pragma warning disable CA1822, IDE0051 // Mark members as static, Remove unused private members
    private object NewSpecies() => new SpeciesViewModel(new PTUDatabase.Species() { Name = "*New Species", Forms = new PTUDatabase.Form[] { new() { Name = "Normal" } } }, (DatabaseViewModel)DataContext);
    private object NewMove() => new MoveViewModel(new PTUDatabase.Move() { Name = "*New Move" }, (DatabaseViewModel)DataContext);
    private object NewAbility() => new AbilityViewModel(new PTUDatabase.Ability() { Name = "*New Ability" });
    private object NewContestEffect() => new ContestEffectViewModel(new PTUDatabase.ContestEffect() { Name = "*New Contest Effect" });
#pragma warning restore CA1822, IDE0051 // Mark members as static, Remove unused private members
}
