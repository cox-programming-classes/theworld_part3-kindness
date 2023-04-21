using CS_TheWorld_Part3.GameMath;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.GameMechanics;

public class StandardEquipment : 
    Item, ICarryable, IEquipable
{
    public int Weight { get; init; }
    public EquipSlot Slot { get; init; }
    public StatChart EquipBonuses { get; init; }

    public static StandardEquipment Sword => new()
    {
        Name = "Bronze Sword",
        Description = "Basic Sword made from Cast Bronze",
        Weight = 2,
        EquipBonuses =
            new(0, 0, Dice.D20, Dice.D6),
        Slot = EquipSlot.MainHand
    };

    public static StandardEquipment Shield => new()
    {
        Name = "Wooden Shield",
        Description = "Small Wooden Buckler Suitable for self-defense",
        Weight = 1,
        EquipBonuses =
            new(0, 2, Dice.D20, Dice.D4),
        Slot = EquipSlot.OffHand
    };
    
    // TODO:  Create more standard equipment! [Easy]
    // TODO:  Create more advanced equipment by creating more classes that extend StandardEquipment and also implement IUseableItem [Difficult]
}