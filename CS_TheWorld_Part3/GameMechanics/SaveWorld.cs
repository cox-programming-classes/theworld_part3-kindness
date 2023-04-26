using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.GameMechanics;
using CS_TheWorld_Part3.GameMath;
using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;

using System.Text.Json;
using System.Text.Json.Serialization;

public static partial class Program
{
    private static string SerializeArea(Area area)
    {
        //items
        List<string> Items = new List<string>();
        foreach (var kvp in area.Items)
            Items.Append(SerializeItem(kvp.Key, kvp.Value));

        //creatures
        List<string> Creatures = new List<string>();
        foreach (var kvp in area.Creatures)
            Creatures.Append(SerializeCreature(kvp.Key, kvp.Value));
        
        //combine
        var wholeArea = new AreaRecord(Items, Creatures);
    }

    private static string SerializeItem(UniqueName uniqueName, Item item)
    {
        var itemRecord = new ItemRecord(uniqueName, item.Name, item.Description);
        Console.WriteLine(itemRecord);
        return JsonSerializer.Serialize(itemRecord);
    }

    /*private static string SerializeICarryable(UniqueName uniqueName, ICarryable item)
    {
        var itemRecord = new ICarryableRecord(uniqueName, item.Name, I)
    }*/

    private static string SerializeCreature(UniqueName uniqueName, Creature creature)
    {
        /*var Equipment = new List<string>();
        foreach (var kvp in creature.Equipment)
            Equipment.Append(SerializeItem(kvp.Key, kvp.Value));

        var Items = new List<string>();
        foreach (var kvp in creature.Items)
            Items.Append(SerializeItem(kvp.Key, kvp.Value));*/

        var creatureRecord = new CreatureRecord(uniqueName, creature.Name, 
            creature.Description, creature.Stats, null, null);
        return JsonSerializer.Serialize(creatureRecord);
    }
    
    private static string SerializePlayer()
    {
        PlayerRecord playerRecord = new PlayerRecord(_player.Name, _player.Stats);
        return JsonSerializer.Serialize(playerRecord);
    }

    public static void SaveWorld(Command cmd)
    {
        SerializeArea(_currentArea);
    }

    public static void AddDataToFile()
    {
        
    }
    
}
