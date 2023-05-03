using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.GameMath;
using CS_TheWorld_Part3.Items;

namespace CS_TheWorld_Part3.GameMechanics;

public static partial class Program
{
    private static Area InitializeMaze()
    {
        var startMaze = new Area()
        {
            Name = "This Place",
            Description = "A barren plane with an ambient temperature around 22C and moderate humidity."
        };
        startMaze.AddItem(
                "sign",
                new Item()
                {
                    Name = "Sign",
                    Description = "A busted sign that reads 'enter if you dare'"
                }
            );
        var snowmanLiar = new Area()
        {
            Name = "The Snowman's Liar",
            Description = "Here awaits a devious snowman"
        };
        snowmanLiar.AddCreature(
            "snowman",
            new Creature()
            {
                Name = "A devious snowman",
                Description = "A snowman that throws snowballs",
                Stats = new StatChart(12, 3, Dice.D100, new Dice(3, 3, 2))
            });
        
        startMaze.AddNeighboringArea(new Direction("east", "the south of the maze"), snowmanLiar);
        snowmanLiar.AddNeighboringArea(new Direction("west", "the east of the maze, to the left of the start"), snowmanLiar);
        
        return startMaze;
    }
}