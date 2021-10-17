using System.ComponentModel;

namespace PTUDatabase
{
    [System.Flags]
    public enum MoveRangeKeywords : ulong
    {
        None = 0,
        AllAdjacentFoes = 1UL << 0,
        AllCardinallyAdjacentTargets = 1UL << 1,
        Aura = 1UL << 2,
        Berry = 1UL << 3,
        Coat = 1UL << 4,
        Dash = 1UL << 5,
        DoubleStrike = 1UL << 6,
        Environ = 1UL << 7,
        Execute = 1UL << 8,
        Exhaust = 1UL << 9,
        ExtendedAction = 1UL << 10,
        Fling = 1UL << 11,
        FreeAction = 1UL << 12,
        Friendly = 1UL << 13,
        FiveStrike = 1UL << 14,
        FullAction = 1UL << 15,
        Groundsource = 1UL << 16,
        Hazard = 1UL << 17,
        Healing = 1UL << 18,
        [Description("HP Loss")]
        HPLoss = 1UL << 19,
        Illusion = 1UL << 20,
        Interrupt = 1UL << 21,
        Pass = 1UL << 22,
        Pledge = 1UL << 23,
        Powder = 1UL << 24,
        Priority = 1UL << 25,
        [Description("Priority (Limited)")]
        PriorityLimited = 1UL << 26,
        Push = 1UL << 27,
        Reaction = 1UL << 28,
        [Description("Recoil 1/4")]
        RecoilFourth = 1UL << 29,
        [Description("Recoil 1/3")]
        RecoilThird = 1UL << 30,
        [Description("Recoil 1/2")]
        RecoilHalf = 1UL << 31,
        [Description("Set-Up")]
        SetUp = 1UL << 32,
        Shield = 1UL << 33,
        ShiftAction = 1UL << 34,
        Smite = 1UL << 35,
        Social = 1UL << 36,
        Sonic = 1UL << 37,
        SpiritSurge = 1UL << 38,
        StandardAction = 1UL << 39,
        SwiftAction = 1UL << 40,
        Trigger = 1UL << 41,
        Vortex = 1UL << 42,
        Weather = 1UL << 43,
        Hail = 1UL << 44,
        Rainy = 1UL << 45,
        Sandstorm = 1UL << 46,
        Sunny = 1UL << 47,
        WeightClass = 1UL << 48,

        SeeEffect = 1UL << 49,
    }
}
