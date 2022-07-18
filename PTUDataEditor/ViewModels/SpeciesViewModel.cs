using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public partial class SpeciesViewModel : ObservableObject
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

    
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SpeciesViewModel(Species model)
    {
        Model = model;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [ObservableProperty]
    private string _Name = "Unnamed";

    [ObservableProperty]
    private ObservableCollection<FormViewModel> _Forms;


    [ObservableProperty]
    private FormViewModel? _SelectedForm = null;

    [ObservableProperty]
    private int _NationalDexNumber = 0;

    [ObservableProperty]
    private Rarity _Rarity = Rarity.Common;

    [ObservableProperty]
    private int _MinimumLevel = 1;

}
