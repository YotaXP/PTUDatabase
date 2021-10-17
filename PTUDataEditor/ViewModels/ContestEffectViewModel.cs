using PTUDatabase;

namespace PTUDataEditor.ViewModels
{
    public class ContestEffectViewModel : ViewModelBase
    {
        public ContestEffect Model
        {
            get => new()
            {
                Name = Name,
                Dice = Dice,
                Effect = Effect,
            };
            private set
            {
                Name = value.Name;
                SetProperty(ref _Dice, value.Dice, nameof(Dice), nameof(DiceString), nameof(UsesVariableDice));
                Effect = value.Effect;
            }
        }

        public ContestEffectViewModel(ContestEffect model)
        {
            Model = model;
        }

        private string _Name = "Unnamed";
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value, nameof(Name));
        }

        private int? _Dice = null;
        public int Dice
        {
            get => _Dice ?? 0;
            set => SetProperty(ref _Dice, value, nameof(Dice), nameof(DiceString), nameof(UsesVariableDice));
        }

        public string DiceString => $"{_Dice?.ToString() ?? "X"}d6";

        public bool UsesVariableDice
        {
            get => !_Dice.HasValue;
            set
            {
                if (value && _Dice.HasValue)
                    SetProperty(ref _Dice, null, nameof(Dice), nameof(DiceString), nameof(UsesVariableDice));
                else if (!value && !_Dice.HasValue)
                    SetProperty(ref _Dice, 1, nameof(Dice), nameof(DiceString), nameof(UsesVariableDice));
            }
        }

        private string _Effect = "No effect.";
        public string Effect
        {
            get => _Effect;
            set => SetProperty(ref _Effect, value, nameof(Effect));
        }
    }
}
