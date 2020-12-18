using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LocalGossip
{
    public static void Menu()
    {
        Console.Clear();
        Utilities.Buttons(Button.listOfLocalsOptions);
        UI.Choice(new List<int> {  }, new List<string>
        {
            
        },
        Button.list1, Button.button1);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "s" && Button.startFightButton.active) Fight();
        else if (choice == "t" && Button.gossipButton.active) Gossip();
        else if (choice == "g" && Button.giveSpeechButton.active) Speech();
        else if (choice == "l" && Button.bardButton.active) Bard();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") Tavern.Menu();
        Menu();
    }

    private static void Bard()
    {
        
    }

    private static void Speech()
    {
        
    }

    private static void Gossip()
    {
        
    }

    private static void Fight()
    {
        
    }
}