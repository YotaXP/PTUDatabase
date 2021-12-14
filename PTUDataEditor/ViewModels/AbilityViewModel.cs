using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public class AbilityViewModel : ViewModelBase
{
    public Ability Model
    {
        get => new()
        {
            Name = Name,
            Trigger = Trigger,
            Target = Target,
            Effect = Effect,
            Frequency = new Frequency
            {
                Type = FrequencyType,
                Count = FrequencyType switch
                {
                    FrequencyType.Scene or FrequencyType.Daily => FrequencyCount,
                    _ => null,
                },
            },
            Keywords = Keywords,
            UnofficialAlternative = UnofficialAlternative,
        };
        private set
        {
            Name = value.Name;
            Trigger = value.Trigger;
            Target = value.Target;
            Effect = value.Effect;
            FrequencyType = value.Frequency.Type;
            FrequencyCount = value.Frequency.Count ?? 1;
            Keywords = value.Keywords;
            UnofficialAlternative = value.UnofficialAlternative;
        }
    }

    public AbilityViewModel(Ability model)
    {
        Model = model;
    }

    private string _Name = "Unnamed";
    public string Name
    {
        get => _Name;
        set => SetProperty(ref _Name, value, nameof(Name));
    }

    private string _Trigger = "";
    public string Trigger
    {
        get => _Trigger;
        set => SetProperty(ref _Trigger, value, nameof(Trigger));
    }

    private string _Target = "";
    public string Target
    {
        get => _Target;
        set => SetProperty(ref _Target, value, nameof(Target));
    }

    private string _Effect = "";
    public string Effect
    {
        get => _Effect;
        set => SetProperty(ref _Effect, value, nameof(Effect));
    }

    private FrequencyType _FrequencyType = FrequencyType.Static;
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

    private MoveRangeKeywords _Keywords = MoveRangeKeywords.None;
    public MoveRangeKeywords Keywords
    {
        get => _Keywords;
        set => SetProperty(ref _Keywords, value, nameof(Keywords));
    }

    private bool _UnofficialAlternative = false;
    public bool UnofficialAlternative
    {
        get => _UnofficialAlternative;
        set => SetProperty(ref _UnofficialAlternative, value, nameof(UnofficialAlternative));
    }
}
