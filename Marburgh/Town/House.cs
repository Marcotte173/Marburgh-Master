using System;
using System.Collections.Generic;

public class House
{

    public static Bartender mate = new Bartender("Mate");
    public static void Menu()
    {
        Utilities.Buttons(Button.listOfHouseOptions);
        GameState.location = Location.House;
        Console.Clear();
        if (Button.enhancementMachine.active && Button.hangoutButton.active)
            UI.Choice(new List<int> { 1,0, 1,0,0,0,1 }, new List<string>
            {
                Color.SPEAK, "","You are in your house. It's not big, but it's clean and cozy. In the corner you see your bed.","",
                "",
                Color.ENHANCEMENT, "In the center of the room you see your ", "crafting machine","",
                "",
                "Now you just have to figure out how it works",
                "",
                Color.NAME, "Your see ",mate.name, " cleaning your kitchen, looking for a mug to polish",
            },
            Button.list1, Button.button1);
        else if (Button.enhancementMachine.active)
            UI.Choice(new List<int> { 1, 0, 1, 0, 0, }, new List<string>
            {
                Color.SPEAK, "","You are in your house. It's not big, but it's clean and cozy. In the corner you see your bed.","",
                "",
                Color.ENHANCEMENT, "In the center of the room you see your ", "crafting machine","",
                "",
                "Now you just have to figure out how it works"
            },
            Button.list1, Button.button1);
        else 
            UI.Choice(new List<int> { 1 }, new List<string>
            {
                Color.SPEAK, "", "You are in your house. It's not big, but it's clean and cozy. In the corner you see your bed.", "",
            },
            Button.list1, Button.button1);        
        Write.Line(104, 27, "[" + Color.BLOOD + "?" + Color.RESET + "] " + Color.BLOOD + "MORE INFO" + Color.RESET);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();        
        if (choice == "0") Utilities.ToTown();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "?") Info();
        else if (choice == "s")
        {
            Console.Clear();
            if (UI.Confirm(
            new List<int> { 0,0, 2,0, 1 }, new List<string>
            {
                "Would you like to sleep until morning?",
                "",
                Color.HEALTH,Color.ENERGY,"Your ", "Health " ,"and " ,"Energy " , "will be restored to maximum",
                "",
                Color.TIME, "Time will advance by ","one ","day",
            })) Sleep();
            else Menu();
        }
        //If you hit c and it's available, you get to choose how to craft
        if (choice == "e" && Button.enhancementMachine.active) Craft.Menu();
        if (choice == "h" && Button.hangoutButton.active) mate.Mate();
        Menu();
    }

    internal static void Sleep()
    {
        Console.Clear();
        Time.DayChange(1);
        UI.Keypress(new List<int> { 0, 0, 1, 1, 1, 0, 1 }, new List<string>
        {
            "You sleep until morning",
            "",
            Color.HEALTH, "", "Health " , "at Maximum ",
            Color.ENERGY , "", "Energy " ,  "at maximum",
            Color.HEALTH, "Your potion returns to " , "full " , "size",
            "",
            Color.MONSTER, "You can ","explore"," again"
        });
        if (Time.Events[0].active && Time.week == 2 && Time.day == 5)
        {
            UI.Keypress(new List<int> { 2 }, new List<string>
            {
                Color.MONSTER,Color.TIME,"The ","Savage Orc"," will destroy your town ","tomorrow"," if you don't kill him"

            });
        }
        else if(Time.Events[0].active && Time.week == 2)
        {
            UI.Keypress(new List<int> { 2 }, new List<string>
            {
                Color.TIME,Color.MONSTER,"You have ",(5 - Time.day).ToString()," days until the ","Savage Orc"," destroys your town"
            }) ;
        }          
    }

    static void Info()
    {
        Console.Clear();
        Write.Line(Color.BLOOD, "", "MORE INFO", "\n\n");
        Console.WriteLine(Color.XP + "YOUR HOUSE" + Color.RESET + "\n\nYour" + Color.XP + " house" + Color.RESET + " is where you return at the end of each day to heal up, pass time and craft poweful items ");
        Console.WriteLine("\n\n" + Color.TIME + "SLEEPING" + Color.RESET + "\n\nWhen you sleep, several things happen. \n\n- Your potion refills itself\n- You can go adventuring. You can go adventuring once per day\n- The day passes. This is important as many events will happen on specific days");
        Console.WriteLine("\n\n" + Color.ENHANCEMENT + "CRAFTING" + Color.RESET + "\n\nDefeated " + Color.MONSTER + "monsters" + Color.RESET + " can " + Color.DROP + "drop" + Color.RESET + " special loot that can be used to craft " + Color.ITEM + "items" + Color.RESET + ".\nTo begin, you must find the " + Color.ENHANCEMENT + "crafting machine" + Color.RESET + "\n\n");
        Utilities.Keypress();
    }
}