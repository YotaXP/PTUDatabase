using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public class AbilityRequirementViewModel : ViewModelBase
{
    public AbilityRequirement Model
    {
        get => new()
        {
            RequirementType = RequirementType,
            Ability = Ability!.Model,
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

    private AbilityRequirementType _RequirementType = AbilityRequirementType.Basic;
    public AbilityRequirementType RequirementType
    {
        get => _RequirementType;
        set => SetProperty(ref _RequirementType, value, nameof(RequirementType));
    }

    private AbilityViewModel? _Ability = null;
    public AbilityViewModel? Ability
    {
        get => _Ability;
        set => SetProperty(ref _Ability, value, nameof(Ability));
    }

}
