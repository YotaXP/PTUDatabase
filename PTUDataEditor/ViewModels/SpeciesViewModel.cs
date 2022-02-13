using System.Collections.ObjectModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public class SpeciesViewModel : ViewModelBase
{
    public Species Model
    {
        get => new()
        {
            Name = Name,
            Forms = Forms.Select(vm => vm.Model).ToList(),
            NationalDexNumber = NationalDexNumber == 0 ? null : NationalDexNumber,
            Rarity = Rarity,
            MinimumLevel = MinimumLevel,
        };
        private set
        {
            Name = value.Name;
            Forms = new ObservableCollection<FormViewModel>(value.Forms.Select(m => new FormViewModel(m)));
            SelectedForm = Forms.FirstOrDefault();
            NationalDexNumber = value.NationalDexNumber ?? 0;
            Rarity = value.Rarity;
            MinimumLevel = value.MinimumLevel;
        }
    }

    public SpeciesViewModel(Species model)
    {
        Model = model;
    }

    private string _Name = "Unnamed";
    public string Name
    {
        get => _Name;
        set => SetProperty(ref _Name, value, nameof(Name));
    }

    private ObservableCollection<FormViewModel> _Forms = null;
    public ObservableCollection<FormViewModel> Forms
    {
        get => _Forms;
        set => SetProperty(ref _Forms, value, nameof(Forms));
    }


    private FormViewModel _SelectedForm = null;
    public FormViewModel SelectedForm
    {
        get => _SelectedForm;
        set => SetProperty(ref _SelectedForm, value, nameof(SelectedForm));
    }

    private int _NationalDexNumber = 0;
    public int NationalDexNumber
    {
        get => _NationalDexNumber;
        set => SetProperty(ref _NationalDexNumber, value, nameof(NationalDexNumber));
    }

    private Rarity _Rarity = Rarity.Common;
    public Rarity Rarity
    {
        get => _Rarity;
        set => SetProperty(ref _Rarity, value, nameof(Rarity));
    }

    private int _MinimumLevel = 1;
    public int MinimumLevel
    {
        get => _MinimumLevel;
        set => SetProperty(ref _MinimumLevel, value, nameof(MinimumLevel));
    }

}
