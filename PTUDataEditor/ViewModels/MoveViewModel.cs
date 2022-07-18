using CommunityToolkit.Mvvm.ComponentModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public partial class MoveViewModel : ObservableObject
{
    public Move Model
    {
        get => new()
        {
            Name = Name,
            Type = Type,
            Class = Class,
            DamageBase = HasDamageBase ? DamageBase : null,
            Frequency = FrequencyType switch
            {
                FrequencyType.Daily or FrequencyType.Scene => new() { Type = FrequencyType, Count = FrequencyCount },
                _ => new() { Type = FrequencyType, Count = null },
            },
            AccuracyCheck = HasAccuracyCheck ? AccuracyCheck : null,
            Range = Range,
            ContestType = ContestType,
            ContestEffect = (HasContestEffect ? MoveContestEffect?.Model : null) ?? ContestEffect.None,
            Effects = Effects,
            UnofficialAlternative = UnofficialAlternative,
        };
        private set
        {
            Name = value.Name;
            Type = value.Type;
            Class = value.Class;
            DamageBase = value.DamageBase ?? 1;
            HasDamageBase = value.DamageBase is not null;
            FrequencyType = value.Frequency.Type;
            FrequencyCount = value.Frequency.Count ?? 1;
            AccuracyCheck = value.AccuracyCheck ?? 0;
            HasAccuracyCheck = value.AccuracyCheck is not null;
            Range = value.Range;
            ContestType = value.ContestType;
            HasContestEffect = value.ContestEffect != ContestEffect.None;
            MoveContestEffect = RootDB.ContestEffects.FirstOrDefault(cevm => cevm.Model == value.ContestEffect);
            Effects = value.Effects;
            UnofficialAlternative = value.UnofficialAlternative;
        }
    }


    public MoveViewModel(Move model, DatabaseViewModel db)
    {
        RootDB = db;
        Model = model;
    }

    public DatabaseViewModel RootDB { get; set; }

    [ObservableProperty]
    private string _Name = "Unnamed";

    [ObservableProperty]
    private PokemonType _Type = PokemonType.Unknown;

    [ObservableProperty]
    private MoveClass _Class = MoveClass.Status;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DamageRoll))]
    private int _DamageBase = 1;

    public string DamageRoll => Move.DamageBaseData[DamageBase].Dice;

    [ObservableProperty]
    private bool _HasDamageBase = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FrequencyCountVisible))]
    private FrequencyType _FrequencyType = FrequencyType.AtWill;

    [ObservableProperty]
    private int _FrequencyCount = 1;

    public bool FrequencyCountVisible => FrequencyType switch
    {
        FrequencyType.Scene or FrequencyType.Daily => true,
        _ => false,
    };

    [ObservableProperty]
    private int _AccuracyCheck = 0;

    [ObservableProperty]
    private bool _HasAccuracyCheck = false;

    [ObservableProperty]
    private string _Range = "";

    [ObservableProperty]
    private ContestType _ContestType = ContestType.None;

    [ObservableProperty]
    private bool _HasContestEffect = false;

    [ObservableProperty]
    private ContestEffectViewModel? _MoveContestEffect = null;

    [ObservableProperty]
    private string _Effects = "";

    [ObservableProperty]
    private bool _UnofficialAlternative = false;
}
