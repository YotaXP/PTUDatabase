using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using PTUDatabase;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PTUDataEditor.ViewModels;

public partial class FormViewModel : ObservableValidator
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
            Moves = Moves.Select(mvm => mvm.Model).ToList(),
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
            Moves = new ObservableCollection<MoveRequirementViewModel>(value.Moves.Select(move => new MoveRequirementViewModel(move, RootDB)));
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public FormViewModel(Form model, DatabaseViewModel db)
    {
        RootDB = db;
        Model = model;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public DatabaseViewModel RootDB { get; private set; }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.PropertyName is not nameof(ValidationIssues) and not nameof(HasValidationIssues))
            ValidationIssues = Validate();
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasValidationIssues))]
    private IReadOnlyList<string> _ValidationIssues = Array.Empty<string>();
    public bool HasValidationIssues => ValidationIssues.Count > 0;

    private List<string> Validate()
    {
        var issues = new List<string>();
        if (string.IsNullOrEmpty(Name)) issues.Add("Missing form name.");
        if (SelectionWeight < 0) issues.Add("Selection weight must be >= 0.");
        if (Types?.Count is null or 0) issues.Add("Missing types.");
        if (EggGroups?.Count is null or 0) issues.Add("Missing egg groups.");
        if (AverageWeightKilograms == 0) issues.Add("Missing weight.");
        if (AverageSizeMeters == 0) issues.Add("Missing size.");
        if (string.IsNullOrEmpty(ImageUrl)) issues.Add("Missing image.");
        if (BaseStats == Stats.Zero) issues.Add("Missing base stats.");
        if (BaseSkills == Skills.Zero) issues.Add("Missing base skills.");
        if (BaseSkills.Any(s => s.Rank < 1)) issues.Add("Some base skills are below the minimum of 1.");
        // TODO: Validate capabilities
        if (Moves?.Count is null or 0) issues.Add("Missing moves.");
        if (Abilities?.Count is null or 0) issues.Add("Missing abilities.");
        return issues;
    }

    [ObservableProperty]
    private string _Name = "Unnamed";

    [ObservableProperty]
    private string _ImageUrl = "";

    [ObservableProperty]
    private Stats _BaseStats = Stats.Zero;

    [ObservableProperty]
    private ObservableCollection<PokemonType> _Types;

    [ObservableProperty]
    private ObservableCollection<AbilityRequirement> _Abilities;

    [ObservableProperty]
    private ObservableCollection<MoveRequirementViewModel> _Moves;

    [ObservableProperty]
    private Skills _BaseSkills = Skills.Minimum;

    [ObservableProperty]
    private Capabilities _Capabilities = Capabilities.None;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AverageSizeInches))]
    [NotifyPropertyChangedFor(nameof(AverageSizeFeetInches))]
    private float _AverageSizeMeters = 0f;
    public float AverageSizeInches
    {
        get => AverageSizeMeters * 39.37f;
        set => AverageSizeMeters = value / 39.37f;
    }
    public string AverageSizeFeetInches => $"{(int)Math.Round(AverageSizeInches) / 12}' {(int)Math.Round(AverageSizeInches) % 12}\"";

    [ObservableProperty]
    private SizeClass _SizeClass = SizeClass.Small;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AverageWeightPounds))]
    [NotifyPropertyChangedFor(nameof(WeightClass))]
    private float _AverageWeightKilograms = 0f;
    public float AverageWeightPounds
    {
        get => AverageWeightKilograms * 2.2f;
        set => AverageWeightKilograms = value / 2.2f;
    }
    public int WeightClass => AverageWeightKilograms switch
    {
        < 11.001f => 1,
        < 25.001f => 2,
        < 50.001f => 3,
        < 100.001f => 4,
        < 200.001f => 5,
        _ => 6,
    };

    [ObservableProperty]
    private float _MaleFemaleRatio = 0.5f;

    [ObservableProperty]
    private bool _HasGender = true;

    [ObservableProperty]
    private ObservableCollection<EggGroup> _EggGroups;

    [ObservableProperty]
    private float _SelectionWeight = 1f;
}
