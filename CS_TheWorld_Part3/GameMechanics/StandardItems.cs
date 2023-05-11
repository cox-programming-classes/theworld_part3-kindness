using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.Items;
using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.GameMath;

namespace CS_TheWorld_Part3.GameMechanics;


using static TextFormatter;

/// <summary>
/// This is a specialized Item that doesn't have any extra characteristics yet....
/// TODO:  Research!  How is this used in the current example context?  What is it about this item that is useful [Moderate]
/// </summary>
public class KeyStone : Item, ICarryable, IUsable //colon is the inheritance relationship, it inherits from Item, I carryable, I usuable 
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

public class MagicWand : Item, IUsable, ICarryable
{
    public string Spell { get; init; }
    public int Weight { get; init; }
    public (string, Creature) Monster { get; init; }
    public string UseOn(object target)
    {
        if (target is Area area)
        {
            area.AddCreature(Monster.Item1, Monster.Item2);
            return $"You spawned a {Monster.Item1} in {target}";
        }

        return $"You cannot summon a monster in a {target}, try casting the spell on a Area";

    }

}

public class LSD : Item, IUsable, ICarryable
{
    public int Weight { get; init; }
    public string Use()
    {
        return "transport to some area";

    }
}



// TODO:  Create a specialized item that can be USED to Heal the player [Moderate]

public static class StandardItems
{
    /// <summary>
    /// A reusable instance of a KeyStone 
    /// </summary>
    public static KeyStone FireStone => new()
    {
        Name = "Fire Stone",
        Description = "A stone that glows bright orange and is warm to the touch.",
        Weight = 1
    };
    
    // TODO:  Create more cookie-cutter items that you can initialize at will
}