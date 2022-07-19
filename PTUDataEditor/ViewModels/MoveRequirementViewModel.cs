using CommunityToolkit.Mvvm.ComponentModel;
using PTUDatabase;

namespace PTUDataEditor.ViewModels;

public partial class MoveRequirementViewModel : ObservableObject
{

    public MoveRequirement Model
    {
        get => new()
        {
             RequirementType = RequirementType,
             RequiredLevel = RequirementType == MoveRequirementType.Level ? RequiredLevel : null,
             MachineId = RequirementType == MoveRequirementType.Machine ? MachineId : null,
             Move = false ? Move.Model : throw new NotImplementedException("HELP"), // TODO: IMPORTANT! This needs to provide the correct INSTANCE! Not create a new one!
        };
        private set
        {
            RequirementType = value.RequirementType;
            RequiredLevel = value.RequiredLevel ?? 1;
            MachineId = value.MachineId ?? "TM00";
            Move = RootDB.Moves.FirstOrDefault(mvm => mvm.Name == value.Move.Name) ?? new MoveViewModel(value.Move, RootDB);
        }
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public MoveRequirementViewModel(MoveRequirement model, DatabaseViewModel db)
    {
        RootDB = db;
        Model = model;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public DatabaseViewModel RootDB { get; private set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShowLevelBox))]
    [NotifyPropertyChangedFor(nameof(ShowMachineBox))]
    [NotifyPropertyChangedFor(nameof(ShowEitherBox))]
    private MoveRequirementType _RequirementType;

    public bool ShowLevelBox => RequirementType == MoveRequirementType.Level;
    public bool ShowMachineBox => RequirementType == MoveRequirementType.Machine;
    public bool ShowEitherBox => ShowLevelBox || ShowMachineBox;

    [ObservableProperty]
    private int _RequiredLevel = 1;

    [ObservableProperty]
    private string _MachineId = "TM00";

    [ObservableProperty]
    private MoveViewModel _Move;
}
