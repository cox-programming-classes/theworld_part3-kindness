
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using CS_TheWorld_Part3.GameMath;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.Creatures;


/// <summary>
/// Player in a game
/// </summary>
public class Player : ICreature
{
    /* ------------------------------------------------------- *
     * Properties (or Attributes)
     * Nouns that describe the "State" of the object.
     * ------------------------------------------------------- */
    
    /// <summary>
    /// The Player's Name.  This can only be set upon initialization.
    /// </summary>
    public string Name { get; init; }
    
    public StatChart Stats { get; init; }

    public uint EffectiveAC
    {
        get
        {
            var result = Stats.AC;
            foreach (var equpiment in Equipment.Values)
            {
                result += equpiment.EquipBonuses.AC;
            }

            return result;
        }
    }

    public Player(string name)
    {
        Name = name;
        Stats = new(10, 10, Dice.D20, new(2, 4));
        
    }


    private Dictionary<EquipSlot, IEquipable> _equipment = new();
    public ReadOnlyDictionary<EquipSlot, IEquipable> Equipment => _equipment.AsReadOnly();
    
    /* TODO:  Write Behaviors that allow the player to equip and unequip things things
              i.e. move something from your inventory to equipment [Moderate]
                   make sure items aren't lost when equiping a new item [Easy]
                   when an item is unequiped, it should return to the players inventory [Easy]
     */
    
    private Dictionary<UniqueName, ICarryable> _items = new();
    public ReadOnlyDictionary<UniqueName, ICarryable> Backpack => _items.AsReadOnly();

    
    /* TODO:  Write Behaviors that allow the player to access their Items.
              i.e PickUp an item and add it to the inventory, [Easy]
                  Get an item from your inventory, [Moderate]
                  Drop an item from your inventory, [Moderate]
                  Use an item in your inventory. [Difficult]
    */

    public Action<ICreature, Command> CombatLogic =>
        (creature, command) =>
    {
        // TODO:  Write Better Combat Logic here for the Player!
        bool hit = Stats.HitDice.Roll() > creature.EffectiveAC;
        if (hit)
        {
            var value = Stats.AttackDice.Roll();
            creature.Stats.ChangeHP(-value);
        }
    };

    public void AddItem(UniqueName uniqueName, ICarryable item)
    {
        if (Backpack.ContainsKey(uniqueName))
            throw new WorldException<Player>(this, $"{uniqueName} already exists in this area's _Items");
        
        _items.Add(uniqueName, item);
    }

    public bool HasItem(UniqueName uniqueName) => Backpack.ContainsKey(uniqueName);
    
    public ICarryable? GetItem(UniqueName uniqueName)
    {
        if (!this.HasItem(uniqueName))
            return null;

        return Backpack[uniqueName];
    }

    // TODO:  Create a way for players to have special abilities that can be used in or out of combat. [Extremely Difficult]
    // TODO:  Part 1:  Define what a "special ability" is. [Moderate]
    // TODO:  Part 2:  Define a way for the player to acquire abilities [Moderate~Difficult]
    // TODO:  Part 3:  Define the command structure for a player to use abilities [Difficult]
    // TODO:  Part 4:  Implement a bunch of different abilities [Difficult]
}
