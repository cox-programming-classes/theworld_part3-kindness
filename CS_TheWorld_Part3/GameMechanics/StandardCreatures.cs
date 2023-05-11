using CS_TheWorld_Part3.GameMath;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.GameMechanics;

public static class StandardCreatures
{
    /// <summary>
    /// Generic Giant Rat
    /// </summary>
    public static Creature GiantRat => new()
    {
        Name="Giant Rat",
        Description = "Oh geez, look at those beady little eyes.",
        Stats = new StatChart(10, 10, Dice.D20, new(2, 4, -2))
    };

    public static Creature FireBird => new()
    {
        Name="Fire Bird",
        Description = "It's a bird, and it's made of fire",
        Stats = new(24, 12, Dice.D20, Dice.D12)
    };

   
    
    
    
    public static Creature Marsupial 
    {
        get
        {
            var marsupial =  new Creature()
            {
                Name = "POSSUM",
                Description = "It's a possum",
                Stats = new(24, 12, Dice.D20, new Dice (2,6)),
                Items = new (new Dictionary<UniqueName,ICarryable>()
                {
                
                {"firestone", new KeyStone()}
                 })
                    
            };

            return marsupial;


        }
    }
    
    
    



    // TODO:  Create Some more CREATURES! [Easy]
    // TODO:  Create more KINDS of creatures. [Varying Difficulty]
    // TODO:  Creatures with special abilities [Moderate]
    // TODO:  NPCs that can engage in Dialog [Difficult]
    // TODO:  NPCs that you can engage in commerce with [Very Difficult]
}