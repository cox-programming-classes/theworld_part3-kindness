using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.GameMechanics;
using CS_TheWorld_Part3.GameMath;
using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;

using System.Text.Json;
using System.Text.Json.Serialization;

public static partial class Program
{
    
    //area
    private static string SerializeArea(Area area)
    {
        //items
        List<string> ItemGuids = new List<string>();
        foreach (var kvp in area.Items)
            ItemGuids.Append(kvp.Value.guid);
        
        //serialzie the items
        List<string> ItemsData = new List<string>();
        foreach (var itemGuid in ItemGuids)
        {
            var item = 
            ItemsData.Append()
        }

            //creatures
        List<string> CreatureGuids = new List<string>();
        foreach (var kvp in area.Creatures)
            CreatureGuids.Append(kvp.Value.guid);
        
        //combine
        var wholeArea = new AreaRecord(area.guid, ItemGuids, CreatureGuids);
        return JsonSerializer.Serialize(wholeArea);
    }
    
    //do one item
    private static string SerializeItem(UniqueName uniqueName, Item item)
    {
        var itemRecord = new ItemRecord(uniqueName, item.Name, item.Description);
        return JsonSerializer.Serialize(itemRecord);
    }
    
    //creature

    private static string SerializeCreature(UniqueName uniqueName, Creature creature)
    {
        var Equipment = new List<string>();
        foreach (var kvp in creature.Equipment)
            Equipment.Append(SerializeItem(kvp.Key, kvp.Value));

        var Items = new List<string>();
        foreach (var kvp in creature.Items)
            Items.Append(SerializeItem(kvp.Key, kvp.Value));

        var creatureRecord = new CreatureRecord(uniqueName, creature.Name, 
            creature.Description, creature.Stats, null, null);
        return JsonSerializer.Serialize(creatureRecord);
    }
    
    
    
    //Player
    
    private static string SerializePlayer()
    {
        PlayerRecord playerRecord = new PlayerRecord(_player.Name, _player.Stats);
        return JsonSerializer.Serialize(playerRecord);
    }
    
    //final function

    public static void SaveWorld(Command cmd)
    { 
        var area = SerializeArea(_currentArea);
        AddDataToFile(area);
        Console.WriteLine(area);
    }

    public static void AddDataToFile(string data)
    {
        File.WriteAllText("player.txt", data);
    }
    
}
