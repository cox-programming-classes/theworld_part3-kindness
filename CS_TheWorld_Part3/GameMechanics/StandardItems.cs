using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.GameMath;
using CS_TheWorld_Part3.Items;
namespace CS_TheWorld_Part3.GameMechanics;

using static TextFormatter;

/// <summary>
/// This is a specialized Item that doesn't have any extra characteristics yet....
/// TODO:  Research!  How is this used in the current example context?  What is it about this item that is useful [Moderate]
/// </summary>
public class KeyStone : Item, ICarryable, IUsable
{
    public string Element { get; init; }
    public int Weight { get; init; }

    /// <summary>
    /// Becareful what you use this on!
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public string UseOn(object target)
    {
        if (target is ICreature creature)
        {
            creature.Stats.ChangeHP(-3);
            return $"{creature.Name} is bathed in the light of {Element}";
        }

        return $"{this} has no effect on {target}";
    }

}

public class DrugStone : Item, ICarryable, IUsable
{
    public Area Place { get; init; }
    public (string, Creature) Monster { get; init; }
    public int Weight { get; init; }

    /// <summary>
    /// Becareful what you use this on!
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Use()
    {
        Place.AddCreature(Monster.Item1, Monster.Item2);
// needs to have a property that is the area that the monster goes into. So you can insert the monster into the area. 
        return "The Drug monster has appeared";
    }
}

public class Drug : Item, ICarryable, IUsable
{
    public string Type { get; init; }
    public int Weight { get; init; }
}
// TODO:  Create a specialized item that can be USED to Heal the player [Moderate]
public static class StandardItems
{
    public static KeyStone Sapphire => new()
    {
        Name = "Sapphire",
        Description = "A blue gem, but not like the diamond emoji.",
        Weight = 3
    };

    // TODO:  Create more cookie-cutter items that you can initialize at will


    /// <summary>
    /// A reusable instance of a KeyStone 
    /// </summary>
    public static KeyStone FireStone => new()
    {
        Name = "Fire Stone",
        Description = "A stone that glows bright orange and is warm to the touch.",
        Weight = 1
    };

    public static Drug Adderall => new()
    {
        Name = "Adderall",
        Description = "Focus in a pill",
        Weight = 1
    };

    // TODO:  Create more cookie-cutter items that you can initialize at will
}


