using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public partial class SpeciesViewModel : ObservableObject
{
    public Species BuildModel(IReadOnlyList<Move> allMoves, IReadOnlyList<Ability> allAbilities) => new()
    {
        Name = Name,
        Forms = Forms.Select(vm => vm.BuildModel(allMoves, allAbilities)).ToList(),
        NationalDexNumber = NationalDexNumber == 0 ? null : NationalDexNumber,
        Rarity = Rarity,
        MinimumLevel = MinimumLevel,
    };

    
    public SpeciesViewModel(Species model, DatabaseViewModel db)
    {
        _Name = model.Name;
        _Forms = new ObservableCollection<FormViewModel>(model.Forms.Select(m => new FormViewModel(m, db)));
        _SelectedForm = Forms.FirstOrDefault();
        _NationalDexNumber = model.NationalDexNumber ?? 0;
        _Rarity = model.Rarity;
        _MinimumLevel = model.MinimumLevel;
        RootDB = db;
    }

    public static readonly IEnumerable<MoveRequirementType> MoveRequirementTypes = Enum.GetValues(typeof(MoveRequirementType)).Cast<MoveRequirementType>();

    public DatabaseViewModel RootDB { get; }

    [ObservableProperty]
    private string _Name;

    [ObservableProperty]
    private ObservableCollection<FormViewModel> _Forms;


    [ObservableProperty]
    private FormViewModel? _SelectedForm = null;

    [ObservableProperty]
    private int _NationalDexNumber;

    [ObservableProperty]
    private Rarity _Rarity;

    [ObservableProperty]
    private int _MinimumLevel;

}
