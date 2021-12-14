namespace PTUDatabase;

public record Skills
{
    // Body Skills
    public (int Rank, int Bonus) Intimidate { get; init; }
    public (int Rank, int Bonus) Survival { get; init; }
    public (int Rank, int Bonus) Athletics { get; init; }
    public (int Rank, int Bonus) Acrobatics { get; init; }
    public (int Rank, int Bonus) Combat { get; init; }
    public (int Rank, int Bonus) Stealth { get; init; }
    // Mind Skills
    public (int Rank, int Bonus) GeneralEducation { get; init; }
    public (int Rank, int Bonus) MedicineEducation { get; init; }
    public (int Rank, int Bonus) OccultEducation { get; init; }
    public (int Rank, int Bonus) PokemonEducation { get; init; }
    public (int Rank, int Bonus) TechnologyEducation { get; init; }
    public (int Rank, int Bonus) Guile { get; init; }
    public (int Rank, int Bonus) Perception { get; init; }
    // Spirit Skills
    public (int Rank, int Bonus) Charm { get; init; }
    public (int Rank, int Bonus) Command { get; init; }
    public (int Rank, int Bonus) Intuition { get; init; }
    public (int Rank, int Bonus) Focus { get; init; }

    public static readonly Skills Zero = new();
    public static readonly Skills Minimum = new()
    {
        Athletics = (1, 0),
        Acrobatics = (1, 0),
        Combat = (1, 0),
        Stealth = (1, 0),
        Intimidate = (1, 0),
        Survival = (1, 0),
        Perception = (1, 0),
        GeneralEducation = (1, 0),
        MedicineEducation = (1, 0),
        OccultEducation = (1, 0),
        PokemonEducation = (1, 0),
        TechnologyEducation = (1, 0),
        Focus = (1, 0),
        Guile = (1, 0),
        Charm = (1, 0),
        Command = (1, 0),
        Intuition = (1, 0),
    };
}

