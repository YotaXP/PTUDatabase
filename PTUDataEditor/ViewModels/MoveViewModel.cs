using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public class MoveViewModel : ViewModelBase
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
            ContestEffect = ContestEffect ?? ContestEffect.None,
            Effects = Effects,
            UnofficialAlternative = UnofficialAlternative,
        };
        private set
        {
            Name = value.Name;
            Type = value.Type;
            Class = value.Class;
            DamageBase = value.DamageBase ?? 1;
            HasDamageBase = value.DamageBase is { };
            FrequencyType = value.Frequency.Type;
            FrequencyCount = value.Frequency.Count ?? 1;
            AccuracyCheck = value.AccuracyCheck ?? 0;
            HasAccuracyCheck = value.AccuracyCheck is { };
            Range = value.Range;
            ContestType = value.ContestType;
            ContestEffect = value.ContestEffect;
            Effects = value.Effects;
            UnofficialAlternative = value.UnofficialAlternative;
        }
    }


    public MoveViewModel(Move model)
    {
        Model = model;
    }


    private string _Name = "Unnamed";
    public string Name
    {
        get => _Name;
        set => SetProperty(ref _Name, value, nameof(Name));
    }

    private PokemonType _Type = PokemonType.Unknown;
    public PokemonType Type
    {
        get => _Type;
        set => SetProperty(ref _Type, value, nameof(Type));
    }

    private MoveClass _Class = MoveClass.Status;
    public MoveClass Class
    {
        get => _Class;
        set => SetProperty(ref _Class, value, nameof(Class));
    }

    private int _DamageBase = 1;
    public int DamageBase
    {
        get => _DamageBase;
        set => SetProperty(ref _DamageBase, value, nameof(DamageBase), nameof(DamageRoll));
    }

    private bool _HasDamageBase = false;
    public bool HasDamageBase
    {
        get => _HasDamageBase;
        set => SetProperty(ref _HasDamageBase, value, nameof(HasDamageBase));
    }

    public string DamageRoll => Move.DamageBaseData[DamageBase].Dice;

    private FrequencyType _FrequencyType = FrequencyType.AtWill;
    public FrequencyType FrequencyType
    {
        get => _FrequencyType;
        set => SetProperty(ref _FrequencyType, value, nameof(FrequencyType), nameof(FrequencyCountVisible));
    }

    private int _FrequencyCount = 1;
    public int FrequencyCount
    {
        get => _FrequencyCount;
        set => SetProperty(ref _FrequencyCount, value, nameof(FrequencyCount));
    }

    public bool FrequencyCountVisible => FrequencyType switch
    {
        FrequencyType.Scene or FrequencyType.Daily => true,
        _ => false,
    };

    private int _AccuracyCheck = 0;
    public int AccuracyCheck
    {
        get => _AccuracyCheck;
        set => SetProperty(ref _AccuracyCheck, value, nameof(AccuracyCheck));
    }

    private bool _HasAccuracyCheck = false;
    public bool HasAccuracyCheck
    {
        get => _HasAccuracyCheck;
        set => SetProperty(ref _HasAccuracyCheck, value, nameof(HasAccuracyCheck));
    }

    private string _Range = "";
    public string Range
    {
        get => _Range;
        set => SetProperty(ref _Range, value, nameof(Range));
    }

    private ContestType _ContestType = ContestType.None;
    public ContestType ContestType
    {
        get => _ContestType;
        set => SetProperty(ref _ContestType, value, nameof(ContestType));
    }

    private ContestEffect? _ContestEffect = null;
    public ContestEffect? ContestEffect
    {
        get => _ContestEffect;
        set => SetProperty(ref _ContestEffect, value, nameof(ContestEffect));
    }

    private string _Effects = "";
    public string Effects
    {
        get => _Effects;
        set => SetProperty(ref _Effects, value, nameof(Effects));
    }

    private bool _UnofficialAlternative = false;
    public bool UnofficialAlternative
    {
        get => _UnofficialAlternative;
        set => SetProperty(ref _UnofficialAlternative, value, nameof(UnofficialAlternative));
    }
}
