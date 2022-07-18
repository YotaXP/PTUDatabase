using CommunityToolkit.Mvvm.ComponentModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public partial class AbilityViewModel : ObservableObject
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

    [ObservableProperty]
    private string _Name = "Unnamed";

    [ObservableProperty]
    private string _Trigger = "";

    [ObservableProperty]
    private string _Target = "";

    [ObservableProperty]
    private string _Effect = "";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FrequencyCountVisible))]
    private FrequencyType _FrequencyType = FrequencyType.Static;

    [ObservableProperty]
    private int _FrequencyCount = 1;

    public bool FrequencyCountVisible => FrequencyType switch
    {
        FrequencyType.Scene or FrequencyType.Daily => true,
        _ => false,
    };

    [ObservableProperty]
    private MoveRangeKeywords _Keywords = MoveRangeKeywords.None;

    [ObservableProperty]
    private bool _UnofficialAlternative = false;
}
