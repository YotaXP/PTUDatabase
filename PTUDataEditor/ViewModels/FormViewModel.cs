using System.Collections.ObjectModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public class FormViewModel : ViewModelBase
{
    public Form Model
    {
        get => new()
        {
            Name = Name,
            ImageUrl = ImageUrl == "" ? null : ImageUrl,
            BaseStats = BaseStats,
            Types = Types,
            Abilities = Abilities,
            Moves = Moves,
            BaseSkills = BaseSkills,
            Capabilities = Capabilities,
            AverageSize = (AverageSizeMeters, AverageSizeInches, SizeClass),
            AverageWeight = (AverageWeightKilograms, 0f, 0),
            MaleFemaleRatio = HasGender ? MaleFemaleRatio : null,
            EggGroups = EggGroups,
            SelectionWeight = SelectionWeight,
        };
        private set
        {
            Name = value.Name;
            ImageUrl = value.ImageUrl ?? "";
            BaseStats = value.BaseStats;
            Types = new ObservableCollection<PokemonType>(value.Types);
            Abilities = new ObservableCollection<AbilityRequirement>(value.Abilities);
            Moves = new ObservableCollection<MoveRequirement>(value.Moves);
            BaseSkills = value.BaseSkills;
            Capabilities = value.Capabilities;
            AverageSizeMeters = value.AverageSize.Meters;
            SizeClass = value.AverageSize.Class;
            AverageWeightKilograms = value.AverageWeight.Kilograms;
            MaleFemaleRatio = value.MaleFemaleRatio ?? 0.5f;
            HasGender = value.MaleFemaleRatio.HasValue;
            EggGroups = new ObservableCollection<EggGroup>(value.EggGroups);
            SelectionWeight = value.SelectionWeight;
        }
    }

    public FormViewModel(Form model)
    {
        Model = model;
    }

    private string _Name = "Unnamed";
    public string Name
    {
        get => _Name;
        set => SetProperty(ref _Name, value, nameof(Name));
    }

    private string _ImageUrl = "";
    public string ImageUrl
    {
        get => _ImageUrl;
        set => SetProperty(ref _ImageUrl, value, nameof(ImageUrl));
    }

    private Stats _BaseStats = Stats.Zero;
    public Stats BaseStats
    {
        get => _BaseStats;
        set => SetProperty(ref _BaseStats, value, nameof(BaseStats));
    }

    private ObservableCollection<PokemonType> _Types = null;
    public ObservableCollection<PokemonType> Types
    {
        get => _Types;
        set => SetProperty(ref _Types, value, nameof(Types));
    }

    private ObservableCollection<AbilityRequirement> _Abilities = null;
    public ObservableCollection<AbilityRequirement> Abilities
    {
        get => _Abilities;
        set => SetProperty(ref _Abilities, value, nameof(Abilities));
    }

    private ObservableCollection<MoveRequirement> _Moves = null;
    public ObservableCollection<MoveRequirement> Moves
    {
        get => _Moves;
        set => SetProperty(ref _Moves, value, nameof(Moves));
    }

    private Skills _BaseSkills = Skills.Minimum;
    public Skills BaseSkills
    {
        get => _BaseSkills;
        set => SetProperty(ref _BaseSkills, value, nameof(BaseSkills));
    }

    private Capabilities _Capabilities = Capabilities.None;
    public Capabilities Capabilities
    {
        get => _Capabilities;
        set => SetProperty(ref _Capabilities, value, nameof(Capabilities));
    }

    private float _AverageSizeMeters = 0f;
    public float AverageSizeMeters
    {
        get => _AverageSizeMeters;
        set => SetProperty(ref _AverageSizeMeters, value, nameof(AverageSizeMeters), nameof(AverageSizeInches), nameof(AverageSizeFeetInches));
    }
    public float AverageSizeInches => AverageSizeMeters * 39.37f;
    public string AverageSizeFeetInches => $"{(int)Math.Round(AverageSizeInches) / 12}' {(int)Math.Round(AverageSizeInches) % 12}\"";

    private SizeClass _SizeClass = SizeClass.Small;
    public SizeClass SizeClass
    {
        get => _SizeClass;
        set => SetProperty(ref _SizeClass, value, nameof(SizeClass));
    }

    private float _AverageWeightKilograms = 0f;
    public float AverageWeightKilograms
    {
        get => _AverageWeightKilograms;
        set => SetProperty(ref _AverageWeightKilograms, value, nameof(AverageWeightKilograms), nameof(AverageWeightPounds), nameof(WeightClass));
    }
    public float AverageWeightPounds => AverageWeightKilograms * 2.2f;
    public int WeightClass => AverageWeightKilograms switch
    {
        < 11.001f => 1,
        < 25.001f => 2,
        < 50.001f => 3,
        < 100.001f => 4,
        < 200.001f => 5,
        _ => 6,
    };

    private float _MaleFemaleRatio = 0.5f;
    public float MaleFemaleRatio
    {
        get => _MaleFemaleRatio;
        set => SetProperty(ref _MaleFemaleRatio, value, nameof(MaleFemaleRatio));
    }

    private bool _HasGender = true;
    public bool HasGender
    {
        get => _HasGender;
        set => SetProperty(ref _HasGender, value, nameof(HasGender));
    }

    private ObservableCollection<EggGroup> _EggGroups = null;
    public ObservableCollection<EggGroup> EggGroups
    {
        get => _EggGroups;
        set => SetProperty(ref _EggGroups, value, nameof(EggGroups));
    }

    private float _SelectionWeight = 1f;
    public float SelectionWeight
    {
        get => _SelectionWeight;
        set => SetProperty(ref _SelectionWeight, value, nameof(SelectionWeight));
    }
}
