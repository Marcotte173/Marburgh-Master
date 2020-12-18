using System;
using System.Collections.Generic;

public class ExploreTown
{
    public static void Menu()
    {
        GameState.location = Location.ExploreTown;
        Console.Clear();
        UI.Choice(new List<int> { }, new List<string>
        {

        },
        new List<string> {"alk around town" }, new List<string> {Color.XP+"W"+Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "W" && Button.challengeOpponentButton.active) Explore();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") Town.Menu();
        Menu();
    }

    private static void Explore()
    {
        
    }
}