using CommunityToolkit.Mvvm.ComponentModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public partial class ContestEffectViewModel : ObservableObject
{
    public ContestEffect Model
    {
        get => new()
        {
            Name = Name,
            Dice = Dice == 0 ? null : Dice,
            Effect = Effect,
        };
        private set
        {
            Name = value.Name;
            Dice = value.Dice ?? 0;
            Effect = value.Effect;
        }
    }

    public ContestEffectViewModel(ContestEffect model)
    {
        Model = model;
    }

    [ObservableProperty]
    private string _Name = "Unnamed";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DiceString))]
    [NotifyPropertyChangedFor(nameof(UsesVariableDice))]
    private int _Dice = 0;

    public string DiceString => _Dice == 0 ? "Xd6" : $"{_Dice}d6";

    public bool UsesVariableDice
    {
        get => _Dice == 0;
        set
        {
            if (value && _Dice != 0)
                Dice = 0;
            else if (!value && _Dice == 0)
                Dice = 1;
        }
    }

    [ObservableProperty]
    private string _Effect = "No effect.";
}
