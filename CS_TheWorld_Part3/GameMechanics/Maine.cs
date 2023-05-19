using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.Items;
using CS_TheWorld_Part3.GameMath;

namespace CS_TheWorld_Part3.GameMechanics;
using static TextFormatter;
public static partial class Program
{
    private static Area InitializeMaine()
    {
        //make area
        Area Maine = new Area()
        {
            Name = "Maine",
            Description = "A wonderful land with many trees"
        };

        //Creates Adderall Monster
        Creature AdderallMonster = new()
        {
            Name = "Adderall Monster",
            Description = "Allows you to fight the Adderall monster",
            Backpack = new(new Dictionary<UniqueName, ICarryable>()
            {
                {
                    "adderallstone",
                    StandardItems.Adderall
                }
            }),
            Stats = new StatChart(20, 5, new Dice(2,5), new (2, 10))
        };

        AdderallMonster.Stats.Death += (sender, args) =>
        {
            OnCreatureDeath("Adderall Monster", AdderallMonster, $"Adderall Monster Dies");
            _player.SocialStats.changeMH(-5);
            WriteLineNegative("-5 Mental Health");
        };

        //Creates the Adderall Stone and then puts the Adderall Monster as what it makes
        DrugStone AdderallStone = new()
        {
            Name = "Adderall Stone",
            Description = "Allows you to fight the Adderall monster",
            Weight = 2,
            Place = _currentArea,
            Monster = ("adderallmonster", AdderallMonster)
        };

        //Creates Kenna as a creature-- once you defeat Kenna you get the Adderall Stone
        Creature Kenna = new()
        {
            Name = "Kenna",
            Description = "Its Kenna",
            Stats = new StatChart(27, 3, Dice.D20, new(1, 6, -1)),
            Backpack = new(new Dictionary<UniqueName, ICarryable>()
            {
                {
                    "adderallstone",
                    AdderallStone
                }
            }),
        };

        Kenna.Stats.Death += (sender, args) =>
        {
            OnCreatureDeath("Kenna", Kenna,
                $"{Kenna.Name} dies");
            _player.SocialStats.changeSP(5);
        };
        Maine.AddCreature("Kenna", Kenna);

        return Maine;
    }

}