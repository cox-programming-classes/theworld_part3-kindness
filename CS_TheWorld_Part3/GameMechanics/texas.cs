using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.GameMath;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.GameMechanics;
using static TextFormatter;

public static partial class Program
{
    private static Area InitializeTexas()
    {
        //make area
        Area Texas = new Area()
        {
            Name = "Texas",
            Description = "Its politically split. Keep Austin wierd"
        };

        //Creates Amber Monster
        Creature Amber = new()
        {
            Name = "Amber",
            Description = "its amber",
            Backpack = new(new Dictionary<UniqueName, ICarryable>()
            {
                {
                    "cowboyboots",
                    StandardItems.CowboyBoots
                }
            }),
            Stats = new StatChart(20, 5, new Dice(2, 5), new(2, 10))
        };

        Amber.Stats.Death += (sender, args) =>
        {
            OnCreatureDeath("amber", Amber, $"Amber Dies");
            _player.SocialStats.changeSP(+5);
            _player.SocialStats.changeMH(-5);
            WriteLineNegative("+5 Social points, -5 Mental Health points");
        };
        Texas.AddCreature("amber", Amber);
        return Texas;
    }
}

