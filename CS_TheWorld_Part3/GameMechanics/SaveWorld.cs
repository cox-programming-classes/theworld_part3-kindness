using System.Diagnostics;
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
            ItemsData.Append() //my issue is that now i've lost the instance
                               //but if i keep the instance then its an Item and i get get stuff from interfaces
                               //or it stays as an interface class type in the list and now i cant get stuff from Item
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

/// <summary>
/// Here's a starting point for a serializable way to approach the game data
/// Here, it is important that this be a "struct" and not a "record" because records are `immutable` (we can talk about that).
/// (also, for reasons we can talk about, it might be better to use "record struct" for the records... because ... we should talk about that too.)
/// (it has to do with the difference between a "reference type" and a "value type")
/// </summary>
public struct GameData
{
    /// <summary>
    /// The Serialized Player....
    /// </summary>
    public PlayerRecord player;

    /// <summary>
    /// All the Areas in a single dictionary.  Keys are GUIDs.
    /// </summary>
    public Dictionary<string, AreaRecord> AllAreas;

    /// <summary>
    ///  Same idea, All the Unique Item References indexed by their GUID.
    /// </summary>
    public Dictionary<string, ItemRecord> AllItems;

    public Dictionary<string, CreatureRecord> AllCreatures;

    // TODO: Do the same for any other types that are separate.

    /// <summary>
    /// Try Adding the serialized area....
    /// if the record already exists in the Dictionary--do nothing!
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="record"></param>
    public void AddArea(Area theRealArea)
    {
        var guid = theRealArea.guid;
        if (!AllAreas.ContainsKey(guid))
        {
            AreaRecord record = null; // TODO:  convert theRealArea into a record here.
            AllAreas.Add(guid, record);

            // Here comes the recursive step which is why it is important that this method do *nothing* if the guid
            // is already present in the Dictionary. 
            foreach (var neighboringArea in theRealArea.Neighbors.Values)
            {
                this.AddArea(neighboringArea);
            }

            foreach (var item in theRealArea.Items.Values)
            {
                // TODO: you get the idea.
            }
            
            // TODO:  yeah all the collection properties have to be deliberately serialized.
        }
    }

    /// <summary>
    /// Here's the tough one.
    /// </summary>
    /// <param name="creature"></param>
    public void AddCreature(Creature creature)
    {
        var guid = creature.guid;
        if (!AllCreatures.ContainsKey(guid))
        {
            CreatureRecord record = null; //TODO: Yeah all that stuff.
            foreach (var thing in creature.Items.Values)
            {
                // the type on `thing` is ICarryable...
                if (thing is Item item) // this turns it into an item!
                                        // If it isn't an Item, then something is wrong and we'll ignore it for now...
                {
                    Debug.WriteLine($"{creature.Name} has a {item.Name}"); // just a little debug message~
                    //this.AddItem(item); TODO: once you write that you can uncomment this line.
                }
            }
        }
    }
    
    // TODO: yadayada do the other types too.
}
