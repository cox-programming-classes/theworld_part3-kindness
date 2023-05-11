using CS_TheWorld_Part3.Areas;
using CS_TheWorld_Part3.GameMechanics;
using CS_TheWorld_Part3.Creatures;
using CS_TheWorld_Part3.GameMath;

namespace CS_TheWorld_Part3;

public static partial class Program
{
    private static Area InitializeMaze()
    {
        var PrinceArea = new Area()
        {
            Name = "The Prince",
            Description = "It is a dead end, but there is a large golden throne room with a prince sitting on the throne",
            /*OnEntryAction = (player) =>
            {
                string marriage = GetPlayerInput("Would you like to marry the prince?");
                if (marriage = "Yes")
                {
                    
                }
                
            }
            */
        };

        Creature Prince = new Creature()
        {
            Name = "Prince Charming",
            Description = "Holy shit that things huge!",
            Stats = new StatChart(12, 8, Dice.D20, new(1, 6, -1))

            start.AddCreature("Prince Charming", Prince);

        };
    
        

              