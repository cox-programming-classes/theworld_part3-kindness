
using System.Security.AccessControl;
using CS_TheWorld_Part3.GameMath;
namespace CS_TheWorld_Part3.GameMechanics;
using static TextFormatter;

/// <summary>
/// Program is now a PARTIAL class, so it can be spread across
/// multiple files.  Different logical components of the Program
/// are distributed so that they're easier to understand, but
/// comprise the larger whole.
/// </summary>
public static partial class Program
{
    /// <summary>
    /// Upgraded Command Words!  Now this is a mapping from the command word to the Action that happens!
    /// </summary>
    private static Dictionary<UniqueName, Action<Command>> _commandWords = new()
    {
        {"look", ProcessLookCommand},
        {"get", command => throw new NotImplementedException("Gotta write this!")},
        {"fight", ProcessFightCommand},
        {"cheat", command => _player.Stats.GainExp(50)},
        {"go", ProcessGoCommand},
        {"drop", ProcessDropCommand},
        {"stats", ProcessStatsCommand},
        {"help", ProcessHelpCommand},
    };


    // TODO:  Add a `help` command that displays the list of allowed commands and describes how to use them [Easy]
    // TODO:  Expand the `help` command to take a second parameter like `help look` that describes 
    //        all the possible ways to use the `look` command. [Easy, Multipart]
    // TODO:  Add a `backpack` command that lists the contents of your players Inventory. [Easy]
    // TODO:  Implement the `get` command to pick up an item and place it in the player inventory [Easy]
    // TODO:  Implement a `drop` command that removes an item from the players inventory and places it in the current Area [Easy]
    // TODO:  Add a `use` command that allows you to use any IUseableItem that exists in the current Area [Moderate]
    // TODO:  extend the `use` command to allow you to use any IUseableItem in the players Inventory [Moderate]
    // TODO:  Make sure that the `use`, `get`, and `drop` commands do not conflict with other items with the same uniqueName [Moderate]
    // TODO:  Make it possible for the player to have more than one of the same item (same uniqueName) in their inventory [Difficult]
    // TODO:  Extend the `use` command to allow the player to target themself by accepting the word `self` as the secondary target of a command [Difficult]


    /// <summary>
    /// Process the Command string typed by the player.
    /// </summary>
    /// <param name="command"></param>
    private static void ProcessCommandString(Command command)
    {
        if (string.IsNullOrWhiteSpace(command.CommandWord))
            return;

        if (!_commandWords.ContainsKey(command.CommandWord))
        {
            WriteLineWarning("I don't know what that means.");
        }

        // TODO:  Reasearch!  Oh good god what the hell is this? [Moderate]
        _commandWords[command.CommandWord](command);
    }

    private static void ProcessGoCommand(Command command)
    {
        if (command.Target == "")
        {
            WriteLineWarning("Go Where?");
            return;
        }

        if (!_currentArea.HasNeighbor(command.Target))
        {
            WriteLineWarning($"I don't know where {command.Target} is.");
            return;
        }

        var place = _currentArea.GetNeighboringArea(command.Target)!;

        // Check the new Actions that Areas have.
        // Are there actions that happen when you leave an area or when you enter a new area?
        if (_currentArea.OnExitAction?.Invoke(_player) ?? false)
            return; // you were denied exit from the current area.

        if (place.OnEntryAction?.Invoke(_player) ?? false)
            return; // you were denied entry to this area.

        _currentArea = place;
    }

    private static void ProcessFightCommand(Command command)
    {
        if (command.Target == "")
        {
            WriteLineWarning("Stop hitting yourself.");
            return;
        }

        if (_currentArea.HasItem(command.Target))
        {
            WriteLineWarning($"You can't fight [{command.Target}].");
            return;
        }

        if (!_currentArea.HasCreature(command.Target))
        {
            WriteLineWarning($"You don't see [{command.Target}].");
            return;
        }

        WriteLineWarning("Gotta write that code yet....");
        var target = _currentArea.GetCreature(command.Target)!;
        DoBattle(target);
    }

    private static void ProcessLookCommand(Command cmd)
    {
        // if the command is literally just "look"
        // look around the current area.
        // the LookAround() method is an Extension!
        if (cmd.Target == "")
            _currentArea.LookAround();
        else
        {
            if (_currentArea.HasItem(cmd.Target))
                _currentArea.GetItem(cmd.Target)!.LookAt();
            // the ! in this line means I'm certain that this item isn't null.
            if (_currentArea.HasCreature(cmd.Target))
                _currentArea.GetCreature(cmd.Target)!.LookAt();
        }
    }

    private static void ProcessDropCommand(Command cmd)
    {
        //Implement a `drop` command that removes an item from the players inventory and places it in the current Area [Easy]
        // _player.Drop(cmd.Target)

    }

    private static void ProcessStatsCommand(Command cmd)
    {
        Console.WriteLine(_player.Stats);
    }

    private static void ProcessHelpCommand(Command cmd)
    {
        string look = "Look: look around the current area or specify an object to look at.";
        //string get = "";
        string fight = "Fight: fight a creature";
        string cheat = "Cheat: gain 50 HP";
        string go = "Go: go somewhere";
        //string drop = "";
        string stats = "Stats: get an update of the player's stats";
        string help = "Help: get a summary of the uses of all commands or specify a command to get a summary for.";
        /*

        if (cmd.Target == "")
        {
            Console.WriteLine(look);
            Console.WriteLine(fight);
            Console.WriteLine(cheat);
            Console.WriteLine(go);
            Console.WriteLine(stats);
            Console.WriteLine(help);
        }
        else
        {
            Console.WriteLine(cmd.Target);
        }
        */
        

        
        if(cmd.Target == "look")
            Console.WriteLine(look);
        else if(cmd.Target == "fight")
            Console.WriteLine(fight);
        else if(cmd.Target == "cheat")
            Console.WriteLine(cheat);
        else if(cmd.Target == "go")
            Console.WriteLine(go);
        else if(cmd.Target == "stats")
            Console.WriteLine(stats);
        else if(cmd.Target == "help")
            Console.WriteLine(help);
        else if (cmd.Target == "")
        {
            Console.WriteLine(look);
            Console.WriteLine(fight);
            Console.WriteLine(cheat);
            Console.WriteLine(go);
            Console.WriteLine(stats);
            Console.WriteLine(help);
        }
        else
        {
            Console.WriteLine("I dont know what that is. Type 'help' followed by one of the game commands: look, fight, cheat, go, stats, and help.");
        }
       
    }
}