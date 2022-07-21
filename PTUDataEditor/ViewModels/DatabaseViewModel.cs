using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public partial class DatabaseViewModel : ObservableObject
{
    public Database BuildModel()
    {
        var contestEffects = ContestEffects.Select(vm => vm.BuildModel()).ToList();
        var moves = Moves.Select(vm => vm.BuildModel(contestEffects)).ToList();
        var abilities = Abilities.Select(vm => vm.BuildModel()).ToList();
        var species = Species.Select(vm => vm.BuildModel(moves, abilities)).ToList();
        return new()
        {
            ContestEffects = contestEffects,
            Abilities = abilities,
            Moves = moves,
            Species = species,
        };
    }

    public DatabaseViewModel(Database model)
    {
        _ContestEffects = new(model.ContestEffects.Select(ce => new ContestEffectViewModel(ce)));
        _Abilities = new(model.Abilities.Select(a => new AbilityViewModel(a)));
        _Moves = new(model.Moves.Select(m => new MoveViewModel(m, this)));
        _Species = new(model.Species.Select(s => new SpeciesViewModel(s, this)));
    }

    [ObservableProperty]
    private ObservableCollection<SpeciesViewModel> _Species;

    [ObservableProperty]
    private SpeciesViewModel? _SelectedSpecies = null;


    [ObservableProperty]
    private ObservableCollection<MoveViewModel> _Moves;

    [ObservableProperty]
    private MoveViewModel? _SelectedMove = null;


    [ObservableProperty]
    private ObservableCollection<AbilityViewModel> _Abilities;

    [ObservableProperty]
    private AbilityViewModel? _SelectedAbility = null;


    [ObservableProperty]
    private ObservableCollection<ContestEffectViewModel> _ContestEffects;

    [ObservableProperty]
    private ContestEffectViewModel? _SelectedContestEffect = null;

#if DEBUG
    public static DatabaseViewModel DesignData { get; } = new DatabaseViewModel(Database.Load(GetDesignDataPath()));
    private static string GetDesignDataPath([System.Runtime.CompilerServices.CallerFilePath] string path = "")
        => System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"../../../Data/ptu.1.05.yaml"));
#endif
}
