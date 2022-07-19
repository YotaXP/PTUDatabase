using CommunityToolkit.Mvvm.ComponentModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public partial class AbilityRequirementViewModel : ObservableObject
{
    public AbilityRequirement Model
    {
        get => new()
        {
            RequirementType = RequirementType,
            Ability = false ? Ability.Model : throw new NotImplementedException("HELP"), // TODO: IMPORTANT! This needs to provide the correct INSTANCE! Not create a new one!
        };
        init
        {
            RequirementType = value.RequirementType;
            Ability = new AbilityViewModel(value.Ability);
        }
    }


    public AbilityRequirementViewModel(AbilityRequirement model)
    {
        Model = model;
    }

    [ObservableProperty]
    private AbilityRequirementType _RequirementType = AbilityRequirementType.Basic;

    [ObservableProperty]
    private AbilityViewModel? _Ability = null;

}
