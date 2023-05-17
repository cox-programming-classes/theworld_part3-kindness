namespace CS_TheWorld_Part3.GameMechanics;
using CS_TheWorld_Part3.GameMath;
using static TextFormatter;
using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.Items;

public static partial class Program
{
    public static Area InitializeBandBattle()
    {
        var BandArea = new Area()
        {
            Name = "Band Battle",
            Description = "Battle with the Band"
        };

        var BandMember = new Creature()
        {
            Name = "Gerard Way",
            Description = "He is gerard way",
            Stats = new StatChart(50, 25, new(4, 3), new(2, 4))
        };

        BandMember.Stats.Death += (sender, args) =>
        {
            WriteLinePositive("You have defeated Gerard Way! Now you are in the band");
            //add drug area and band areas as neighboring areas so you can go to them
        };
        
        BandArea.AddCreature("gerard", BandMember);

        return BandArea;
    }

}