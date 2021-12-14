using System.Collections.ObjectModel;
using System.Linq;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public class DatabaseViewModel : ViewModelBase
{
    public Database Model
    {
        get => new()
        {
            Moves = Moves.Select(vm => vm.Model).ToList(),
            Abilities = Abilities.Select(vm => vm.Model).ToList(),
            ContestEffects = ContestEffects.Select(vm => vm.Model).ToList(),
        };
        private set
        {
            Moves = new ObservableCollection<MoveViewModel>(value.Moves.Select(m => new MoveViewModel(m)));
            Abilities = new ObservableCollection<AbilityViewModel>(value.Abilities.Select(a => new AbilityViewModel(a)));
            ContestEffects = new ObservableCollection<ContestEffectViewModel>(value.ContestEffects.Select(ce => new ContestEffectViewModel(ce)));
        }
    }

    public DatabaseViewModel(Database model)
    {
        //Model = model;
        // Code inlined below to avoid nagging about null values
        Moves = new ObservableCollection<MoveViewModel>(model.Moves.Select(m => new MoveViewModel(m)));
        Abilities = new ObservableCollection<AbilityViewModel>(model.Abilities.Select(a => new AbilityViewModel(a)));
        ContestEffects = new ObservableCollection<ContestEffectViewModel>(model.ContestEffects.Select(ce => new ContestEffectViewModel(ce)));
    }


    public ObservableCollection<MoveViewModel> Moves { get; private set; }

    private MoveViewModel? _SelectedMove = null;
    public MoveViewModel? SelectedMove
    {
        get => _SelectedMove;
        set => SetProperty(ref _SelectedMove, value, nameof(SelectedMove));
    }


    public ObservableCollection<AbilityViewModel> Abilities { get; private set; }

    private AbilityViewModel? _SelectedAbility = null;
    public AbilityViewModel? SelectedAbility
    {
        get => _SelectedAbility;
        set => SetProperty(ref _SelectedAbility, value, nameof(SelectedAbility));
    }


    public ObservableCollection<ContestEffectViewModel> ContestEffects { get; private set; }

    private ContestEffectViewModel? _SelectedContestEffect = null;
    public ContestEffectViewModel? SelectedContestEffect
    {
        get => _SelectedContestEffect;
        set => SetProperty(ref _SelectedContestEffect, value, nameof(SelectedContestEffect));
    }

#if DEBUG
    public static DatabaseViewModel DesignData { get; } = new DatabaseViewModel(Database.Load(GetDesignDataPath()));
    private static string GetDesignDataPath([System.Runtime.CompilerServices.CallerFilePath] string path = "")
        => System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"../../../Data/ptu.1.05.yaml"));
#endif
}
