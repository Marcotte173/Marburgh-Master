using System;
using System.Collections.Generic;

public class House:Location
{
    public static List<string> houseOptionButton = new List<string>
    {
        Colour.NAME + "S" + Colour.RESET
    };
    public static List<string> houseOptionList = new List<string>
    {
        "leep"
    };
    public House()
    : base() { }
    //When you go to your house
    public override void Menu()
    {
        Console.Clear();
        if (houseOptionList.Count < 3)
            UI.Choice(new List<int> { 1 }, new List<string>
            {
                Colour.SPEAK, "", "You are in your house. It's not big, but it's clean and cozy. In the corner you see your bed.", "",
            },
            houseOptionList, houseOptionButton);
        else
            UI.Choice(new List<int> { 1, 1 }, new List<string>
            {
                Colour.SPEAK, "","You are in your house. It's not big, but it's clean and cozy. In the corner you see your bed.","",
                Colour.ENHANCEMENT, "In the center of the room you see your ", "crafting machine","","Now you just have to figure out how it works"
            },
            houseOptionList, houseOptionButton);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "r") Utilities.ToTown();
        else if (choice == "s")
        {
            Console.Clear();            
            if (UI.Confirm(
                new List<int> { 0, 2, 1 }, new List<string>
                {
                    "Would you like to sleep until morning?",
                    Colour.HEALTH,Colour.ENERGY,"Your ", "Health " ,"and " ,"Energy " , "will be restored to maximum",
                    Colour.TIME, "Time will advance by ","one ","day",
                }))
            {
                Console.Clear();
                Time.DayChange(1);
                UI.Keypress(new List<int> { 0, 0, 1, 1, 1, 0, 0 }, new List<string>
                    {
                        "You sleep until morning",
                        "",
                        Colour.HEALTH, "", "Health " , "at Maximum ",
                        Colour.ENERGY , "", "Energy " ,  "at maximum",
                        Colour.HEALTH, "Your potion returns to " , "full " , "size",
                        "",
                        "You can explore again",
                    });
            }
            else Location.list[8].Menu();
        }
        //If you hit c and it's available, you get to choose how to craft
        if (choice == "e")
            UI.Keypress(new List<int> { 0}, new List<string>
                    {
                        "Not Yet Implemented"
                    });
        Location.list[8].Menu();
    }    
}