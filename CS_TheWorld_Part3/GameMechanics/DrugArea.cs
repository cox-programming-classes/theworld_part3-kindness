using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.Items;
using CS_TheWorld_Part3.GameMath;

namespace CS_TheWorld_Part3.GameMechanics;
using static TextFormatter;
public static partial class Program
{
    public static Area InitializeDrugArea()
    {
        //make area
        Area DrugArea = new Area()
        {
            Name = "Drug Area",
            Description = "this is a drug area"
        };
        
        //lsd
        var LSDMonster = new Creature ()
        {
            Name = "lsdmonster",
            Description = "It is a LSD Monster",
            Backpack= new(new Dictionary<UniqueName, ICarryable>()
            {
                {
                    "monsterlsd",  Drugs.LSD
                }
                
            }), 
                
            Stats = new StatChart (30,10, new Dice(2,6), new Dice (2,6))

        };
        
        LSDMonster.Stats.Death += (sender, args) =>
        {
            OnCreatureDeath("lsdmonster", LSDMonster, $"{LSDMonster.Name} bursts into flames");
            //add LSD to backpack 
        };
        
        DrugArea.AddCreature("lsdmonster", LSDMonster);
        
        //other drugs

        return DrugArea;

    }
}