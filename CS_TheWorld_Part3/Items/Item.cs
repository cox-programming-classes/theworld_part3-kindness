namespace CS_TheWorld_Part3.Items;

public class Item
{
    public string Name { get; init; }
    public string Description { get; init; }
    
    //GUID
    public string guid { get; }

    public Item()
    {
        guid = Guid.NewGuid().ToString();
    }

    public override string ToString() => Name;
}