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
        var snowmanLair = new Area()
        {
            Name = "The Snowman's Liar",
            Description = "Here awaits a devious snowman"
        };
        var snowman = new Creature()
        {
            Name = "Devious snowman",
            Description = "A snowman that throws snowballs",
            Stats = new StatChart(12, 3, Dice.D100, new Dice(3, 3, 2))
        };
        snowman.Stats.Death += (sender, args) =>
        {
            OnCreatureDeath("moth", snowman, 
                $"{snowman.Name} has been defeated. You can now exit its lair");
        };
        // Add the Moth to the area.
        snowmanLair.AddCreature("moth", snowman);
        
        startMaze.AddNeighboringArea(new Direction("east", "a door to the left"), snowmanLair);
        snowmanLair.AddNeighboringArea(new Direction("west", "the south of the maze - maze start"), snowmanLair);

        var hallway1 = new Area()
        {
            Name = "An ominous hallway",
            Description = "A very long hallway"
        };
        
        startMaze.AddNeighboringArea(new Direction("north", "a hallway ahead"), hallway1);
        hallway1.AddNeighboringArea(new Direction("south", "the start behind you"), startMaze);
        
        var princePalace = new Area()
        {
            Name = "A prince's palace",
            Description = "A golden room full of golden things. A handsome figure awaits you."
        };
        
        princePalace.AddCreature(
            "prince",
            new Creature()
            {
                Name = "A handsome prince",
                Description = "A handsome prince that you can marry",
                Stats = new StatChart(30, 0, Dice.D20, new Dice(3, 2, 0))
            });
        
        hallway1.AddNeighboringArea(new Direction("east", "a door the to left"), princePalace);
        princePalace.AddNeighboringArea(new Direction ("west", "a door to the right - the hallway"), hallway1);

        return startMaze;
        }
}